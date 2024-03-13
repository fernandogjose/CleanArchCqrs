using AutoMapper;
using CleanArchCqrs.Application.Dtos;
using CleanArchCqrs.Application.Category.Queries;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using MediatR;

namespace CleanArchCqrs.Application.Category.Handlers
{
    public class CategoryGetAllQueryHandler : IRequestHandler<CategoryGetAllQuery, IEnumerable<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IMapper _mapper;

        public CategoryGetAllQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(CategoryGetAllQuery request, CancellationToken cancellationToken)
        {
            var categorysEntityResponse = await _categoryRepository.GetAllAsync();
            var categorysDtoResponse = _mapper.Map<IEnumerable<CategoryDto>>(categorysEntityResponse);
            return categorysDtoResponse;
        }
    }
}
