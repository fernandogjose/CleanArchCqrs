using CleanArchCqrs.Application.Dtos;
using MediatR;

namespace CleanArchCqrs.Application.Cqrs.Product.Queries
{
    public class ProductGetAllQuery : IRequest<IEnumerable<Dtos.ProductGetAllResponse>>
    {
    }
}
