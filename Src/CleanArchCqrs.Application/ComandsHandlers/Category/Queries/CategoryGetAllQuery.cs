using CleanArchCqrs.Application.Dtos;
using MediatR;

namespace CleanArchCqrs.Application.ComandsHandlers.Category.Queries
{
    public class CategoryGetAllQuery : IRequest<IEnumerable<CategoryGetAllResponse>>
    {
    }
}
