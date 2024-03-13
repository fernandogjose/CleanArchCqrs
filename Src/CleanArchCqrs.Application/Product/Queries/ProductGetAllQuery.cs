using CleanArchCqrs.Application.Dtos;
using MediatR;

namespace CleanArchCqrs.Application.Product.Queries
{
    public class ProductGetAllQuery : IRequest<IEnumerable<ProductDto>>
    {
    }
}
