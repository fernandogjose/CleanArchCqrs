using CleanArchCqrs.Application.Dtos;
using MediatR;

namespace CleanArchCqrs.Application.Cqrs.Category.Commands
{
    public abstract class CategoryCommand : IRequest<Dtos.Category>
    {
        public string Name { get; set; } = string.Empty;
    }
}
