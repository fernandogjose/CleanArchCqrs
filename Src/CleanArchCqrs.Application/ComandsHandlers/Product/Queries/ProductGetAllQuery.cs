using CleanArchCqrs.Application.Dtos;
using MediatR;

namespace CleanArchCqrs.Application.ComandsHandlers.Product.Queries
{
    public class ProductGetAllQuery : IRequest<IEnumerable<Dtos.ProductGetAllResponse>>
    {
    }
}
