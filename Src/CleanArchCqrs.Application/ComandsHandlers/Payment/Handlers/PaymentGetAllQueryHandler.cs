using AutoMapper;
using CleanArchCqrs.Application.ComandsHandlers.Payment.Queries;
using CleanArchCqrs.Application.Dtos;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using MediatR;

namespace CleanArchCqrs.Application.ComandsHandlers.Payment.Handlers
{
    public class PaymentGetAllQueryHandler : IRequestHandler<PaymentGetAllQuery, IEnumerable<PaymentGetAllResponse>>
    {
        private readonly IPaymentRepository _paymentRepository;

        private readonly IMapper _mapper;

        public PaymentGetAllQueryHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Dtos.PaymentGetAllResponse>> Handle(PaymentGetAllQuery request, CancellationToken cancellationToken)
        {
            var paymentsEntityResponse = await _paymentRepository.GetAllAsync();
            var paymentsDtoResponse = _mapper.Map<IEnumerable<PaymentGetAllResponse>>(paymentsEntityResponse);
            return paymentsDtoResponse;
        }
    }
}
