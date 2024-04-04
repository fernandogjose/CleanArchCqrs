using CleanArchCqrs.Application.Dtos;
using MediatR;

namespace CleanArchCqrs.Application.ComandsHandlers.Category.Commands
{
    public class CategoryDeleteCommand : IRequest<CategoryGetAllResponse>
    {
        public int Id { get; private set; }
    }
}
