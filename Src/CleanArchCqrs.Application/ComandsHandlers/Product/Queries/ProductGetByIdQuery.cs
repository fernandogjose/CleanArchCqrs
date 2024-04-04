using CleanArchCqrs.Application.Dtos;
using MediatR;

namespace CleanArchCqrs.Application.ComandsHandlers.Product.Queries
{
    public class ProductGetByIdQuery : IRequest<ProductGetByIdResponse>
    {
        public int Id { get; private set; }

        public ProductGetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
