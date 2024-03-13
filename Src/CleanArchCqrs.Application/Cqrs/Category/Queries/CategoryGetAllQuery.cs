using CleanArchCqrs.Application.Dtos;
using MediatR;

namespace CleanArchCqrs.Application.Cqrs.Category.Queries
{
    public class CategoryGetAllQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }
}
