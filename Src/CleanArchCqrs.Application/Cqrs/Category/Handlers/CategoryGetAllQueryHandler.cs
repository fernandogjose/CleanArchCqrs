using AutoMapper;
using CleanArchCqrs.Application.Cqrs.Category.Queries;
using CleanArchCqrs.Application.Dtos;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using MediatR;

namespace CleanArchCqrs.Application.Cqrs.Category.Handlers
{
    public class CategoryGetAllQueryHandler : IRequestHandler<CategoryGetAllQuery, IEnumerable<CategoryGetAllResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IMapper _mapper;

        public CategoryGetAllQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryGetAllResponse>> Handle(CategoryGetAllQuery request, CancellationToken cancellationToken)
        {
            var categorysEntityResponse = await _categoryRepository.GetAllAsync();
            var categoryGetAllResponse = _mapper.Map<IEnumerable<CategoryGetAllResponse>>(categorysEntityResponse);
            return categoryGetAllResponse;
        }
    }
}
