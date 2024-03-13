using AutoMapper;
using CleanArchCqrs.Application.Dtos;
using CleanArchCqrs.Application.Product.Queries;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using MediatR;

namespace CleanArchCqrs.Application.Category.Handlers
{
    public class CategoryGetByIdQueryHandler : IRequestHandler<CategoryGetByIdQuery, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IMapper _mapper;

        public CategoryGetByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(CategoryGetByIdQuery request, CancellationToken cancellationToken)
        {
            var categoryEntityResponse = await _categoryRepository.GetByIdAsync(request.Id);
            var categoryDtoResponse = _mapper.Map<CategoryDto>(categoryEntityResponse);
            return categoryDtoResponse;
        }
    }
}
