using CleanArchCqrs.Application.Dtos;
using MediatR;

namespace CleanArchCqrs.Application.Cqrs.Category.Commands
{
    public class CategoryDeleteCommand : IRequest<Dtos.Category>
    {
        public int Id { get; private set; }
    }
}
