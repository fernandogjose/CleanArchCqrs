using AutoMapper;
using CleanArchCqrs.Application.ComandsHandlers.Payment.Commands;
using CleanArchCqrs.Application.Dtos;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using CleanArchCqrs.Domain.Interfaces.DomainValidations;
using CleanArchCqrs.Domain.Interfaces.Sqs.Services;
using MediatR;
using Newtonsoft.Json;

namespace CleanArchCqrs.Application.ComandsHandlers.Payment.Handlers
{
    public class PaymentCreateCommandHandler : IRequestHandler<PaymentCreateCommand, PaymentCreateResponse>
    {
        private readonly IMapper _mapper;

        private readonly IPaymentValidation _paymentValidation;

        private readonly IPaymentRepository _paymentRepository;

        private readonly ISqsService _sqsService;

        public PaymentCreateCommandHandler(IPaymentRepository paymentRepository, IMapper mapper, IPaymentValidation paymentValidation, ISqsService sqsService)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
            _paymentValidation = paymentValidation;
            _sqsService = sqsService;
        }

        public async Task<PaymentCreateResponse> Handle(PaymentCreateCommand request, CancellationToken cancellationToken)
        {
            var paymentEntityRequest = _mapper.Map<Domain.Entities.Payment>(request);

            await _paymentValidation.ValidateCreateAsync(paymentEntityRequest);

            var paymentEntityResponse = await _paymentRepository.CreateAsync(paymentEntityRequest);

            await _sqsService.PublishMessageAsync(JsonConvert.SerializeObject(paymentEntityResponse));

            var paymentCreateResponse = _mapper.Map<PaymentCreateResponse>(paymentEntityResponse);

            return paymentCreateResponse;
        }
    }
}
