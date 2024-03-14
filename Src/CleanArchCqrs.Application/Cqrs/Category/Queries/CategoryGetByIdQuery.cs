using CleanArchCqrs.Application.Dtos;
using MediatR;

namespace CleanArchCqrs.Application.Cqrs.Category.Queries
{
    public class CategoryGetByIdQuery : IRequest<Dtos.Category>
    {
        public int Id { get; private set; }

        public CategoryGetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
