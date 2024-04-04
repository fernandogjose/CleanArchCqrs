using CleanArchCqrs.Application.Dtos;
using MediatR;

namespace CleanArchCqrs.Application.ComandsHandlers.Category.Commands
{
    public abstract class CategoryCommand : IRequest<CategoryGetAllResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
