using CleanArchCqrs.Application.Dtos;
using MediatR;

namespace CleanArchCqrs.Application.Product.Queries
{
    public class CategoryGetByIdQuery : IRequest<CategoryDto>
    {
        public int Id { get; private set; }

        public CategoryGetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
