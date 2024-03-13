using CleanArchCqrs.Application.Dtos;
using MediatR;

namespace CleanArchCqrs.Application.Cqrs.Product.Commands
{
    public class ProductDeleteCommand : IRequest<ProductDto>
    {
        public int Id { get; private set; }
    }
}
