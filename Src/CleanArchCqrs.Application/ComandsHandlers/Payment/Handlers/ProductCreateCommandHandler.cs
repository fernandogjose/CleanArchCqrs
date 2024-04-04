using AutoMapper;
using CleanArchCqrs.Application.ComandsHandlers.Payment.Commands;
using CleanArchCqrs.Application.Dtos;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using CleanArchCqrs.Domain.Interfaces.DomainValidations;
using MediatR;

namespace CleanArchCqrs.Application.ComandsHandlers.Payment.Handlers
{
    public class PaymentCreateCommandHandler : IRequestHandler<PaymentCreateCommand, PaymentCreateResponse>
    {
        private readonly IMapper _mapper;

        private readonly IPaymentValidation _paymentValidation;

        private readonly IPaymentRepository _paymentRepository;

        public PaymentCreateCommandHandler(IPaymentRepository paymentRepository, IMapper mapper, IPaymentValidation paymentValidation)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
            _paymentValidation = paymentValidation;
        }

        public async Task<PaymentCreateResponse> Handle(PaymentCreateCommand request, CancellationToken cancellationToken)
        {
            var paymentEntityRequest = _mapper.Map<Domain.Entities.Payment>(request);
            await _paymentValidation.ValidateCreateAsync(paymentEntityRequest);

            var paymentEntityResponse = await _paymentRepository.CreateAsync(paymentEntityRequest);
            var paymentCreateResponse = _mapper.Map<PaymentCreateResponse>(paymentEntityResponse);
            return paymentCreateResponse;
        }
    }
}
