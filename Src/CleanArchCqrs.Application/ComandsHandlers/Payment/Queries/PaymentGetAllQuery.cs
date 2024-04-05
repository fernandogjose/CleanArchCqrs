using CleanArchCqrs.Application.Dtos;
using MediatR;

namespace CleanArchCqrs.Application.ComandsHandlers.Payment.Queries
{
    public class PaymentGetAllQuery : IRequest<IEnumerable<PaymentGetAllResponse>>
    {
    }
}
