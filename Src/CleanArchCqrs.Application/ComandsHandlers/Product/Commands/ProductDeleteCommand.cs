using CleanArchCqrs.Application.Dtos;
using MediatR;

namespace CleanArchCqrs.Application.ComandsHandlers.Product.Commands
{
    public class ProductDeleteCommand : IRequest<ProductDeleteResponse>
    {
        public int Id { get; private set; }

        public ProductDeleteCommand(int id)
        {
            Id = id;
        }
    }
}
