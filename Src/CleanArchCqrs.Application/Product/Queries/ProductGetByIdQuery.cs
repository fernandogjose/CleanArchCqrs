using CleanArchCqrs.Application.Dtos;
using MediatR;

namespace CleanArchCqrs.Application.Product.Queries
{
    public class ProductGetByIdQuery : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}
