using AutoMapper;
using CleanArchCqrs.Application.ComandsHandlers.Payment.Commands;
using CleanArchCqrs.Domain.Entities;
using CleanArchCqrs.Domain.Enums;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using CleanArchCqrs.Domain.Interfaces.DomainHelpers;
using CleanArchCqrs.Domain.Interfaces.DomainStrategies;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CleanArchCqrs.Application.ComandsHandlers.Payment.Handlers
{
    public class PaymentProcessCommandHandler : IRequestHandler<PaymentProcessCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IEnumerable<IPaymentBusinessRuleStrategy> _paymentBusinessRuleStrategies;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IAgentCommissionHelper _agentCommissionHelper;
        private readonly IPaymentGoalHelper _paymentGoalHelper;
        private readonly IResourcesToAddHelper _resourcesToAddHelper;
        private readonly IShipmentToCreateHelper _shipmentToCreateHelper;
        private readonly IPaymentProcessedRepository _paymentProcessedRepository;
        private readonly ILogger<PaymentProcessCommandHandler> _logger;


        public PaymentProcessCommandHandler(
            IMapper mapper,
            ILogger<PaymentProcessCommandHandler> logger,
            IEnumerable<IPaymentBusinessRuleStrategy> paymentBusinessRuleStrategies,
            IShipmentToCreateHelper shipmentToCreateHelper,
            IAgentCommissionHelper agentCommissionHelper,
            IPaymentGoalHelper paymentGoalHelper,
            IResourcesToAddHelper resourcesToAddHelper,
            IPaymentRepository paymentRepository,
            IPaymentProcessedRepository paymentProcessedRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentException(nameof(logger));
            _paymentBusinessRuleStrategies = paymentBusinessRuleStrategies ?? throw new ArgumentNullException(nameof(paymentBusinessRuleStrategies));
            _shipmentToCreateHelper = shipmentToCreateHelper ?? throw new ArgumentException(nameof(shipmentToCreateHelper));
            _agentCommissionHelper = agentCommissionHelper ?? throw new ArgumentException(nameof(agentCommissionHelper));
            _paymentGoalHelper = paymentGoalHelper ?? throw new ArgumentException(nameof(paymentGoalHelper));
            _resourcesToAddHelper = resourcesToAddHelper ?? throw new ArgumentException(nameof(resourcesToAddHelper));
            _paymentRepository = paymentRepository ?? throw new ArgumentException(nameof(paymentRepository));
            _paymentProcessedRepository = paymentProcessedRepository ?? throw new ArgumentException(nameof(paymentProcessedRepository));
        }

        public async Task<bool> Handle(PaymentProcessCommand request, CancellationToken cancellationToken)
        {
            var payment = await _paymentRepository.GetByIdAsync(request.Id);
            if (payment is null)
            {
                //TODO:: chamar serviço para enviar mensagem para um DLQ para ser processado por outro consumer
                _logger.LogError($"Payment not fund: {JsonConvert.SerializeObject(request)}");
                return false;
            }

            try
            {
                var paymentBusinessRuleStrategy = GetPaymentBusinessRuleStrategy(request.Product.Type);
                var businessRule = paymentBusinessRuleStrategy.GetBusinessRule();
                var shipmentsCreated = _shipmentToCreateHelper.Process(businessRule.ShipmentsToCreate, payment.Product.Category.Name);
                var comission = _agentCommissionHelper.Process(businessRule.AgentCommissions, payment.Product.Category.Name, payment.Product.Price);
                var resourcesToAdd = _resourcesToAddHelper.Process(businessRule.ResourcesToAdd, payment.Product.Name);
                _paymentGoalHelper.Process(businessRule.PaymentGoals, request.Goal, payment.Agent.Email);

                //TODO:: processar o pagamento efetivamente dito, chamar um gateway de pagamento ou processar internamente

                //TODO:: implementar o UnitOfWork para gerenciar a transação e dar rollback para caso alguma falhe
                payment.Status = PaymentStatusEnum.Succeeded;
                await _paymentRepository.UpdateAsync(payment);

                //TODO:: entender melhor o "problema" para ver se essa é a melhor forma de gravar o resultado do pagamento
                await _paymentProcessedRepository.CreateAsync(new PaymentProcessed(
                    JsonConvert.SerializeObject(shipmentsCreated),
                    JsonConvert.SerializeObject(resourcesToAdd),
                    comission,
                    payment.Id));
            }
            catch (Exception ex)
            {
                payment.Status = PaymentStatusEnum.Failed;
                await _paymentRepository.UpdateAsync(payment);

                _logger.LogError($"Failed to process payment: {ex}");

                //TODO:: chamar serviço para enviar mensagem para um DLQ para ser processado por outro consumer
            }

            return true;
        }

        private IPaymentBusinessRuleStrategy GetPaymentBusinessRuleStrategy(ProductTypeEnum productTypeEnum)
        {
            var paymentBusinessRuleStrategy = _paymentBusinessRuleStrategies.FirstOrDefault(p => p.SatisfiedBy == productTypeEnum);
            return paymentBusinessRuleStrategy is null ? throw new Exception("Payment business rule strategy not found") : paymentBusinessRuleStrategy;
        }
    }
}
