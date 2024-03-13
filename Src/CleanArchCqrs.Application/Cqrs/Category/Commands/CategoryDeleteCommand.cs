using CleanArchCqrs.Application.Dtos;
using MediatR;

namespace CleanArchCqrs.Application.Cqrs.Category.Commands
{
    public class CategoryDeleteCommand : IRequest<CategoryDto>
    {
        public int Id { get; private set; }
    }
}
