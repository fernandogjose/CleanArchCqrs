using CleanArchCqrs.Application.Dtos;
using MediatR;

namespace CleanArchCqrs.Application.Cqrs.Product.Commands
{
    public class ProductDeleteCommand : IRequest<Dtos.ProductGetAllResponse>
    {
        public int Id { get; private set; }
    }
}
