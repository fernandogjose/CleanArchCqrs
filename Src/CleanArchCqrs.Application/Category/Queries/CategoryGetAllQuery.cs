using CleanArchCqrs.Application.Dtos;
using MediatR;

namespace CleanArchCqrs.Application.Category.Queries
{
    public class CategoryGetAllQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }
}
