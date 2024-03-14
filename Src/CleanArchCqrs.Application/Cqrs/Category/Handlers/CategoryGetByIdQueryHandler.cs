using AutoMapper;
using CleanArchCqrs.Application.Cqrs.Category.Queries;
using CleanArchCqrs.Application.Dtos;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using MediatR;

namespace CleanArchCqrs.Application.Cqrs.Category.Handlers
{
    public class CategoryGetByIdQueryHandler : IRequestHandler<CategoryGetByIdQuery, Dtos.Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IMapper _mapper;

        public CategoryGetByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Dtos.Category> Handle(CategoryGetByIdQuery request, CancellationToken cancellationToken)
        {
            var categoryEntityResponse = await _categoryRepository.GetByIdAsync(request.Id);
            var categoryDtoResponse = _mapper.Map<Dtos.Category>(categoryEntityResponse);
            return categoryDtoResponse;
        }
    }
}
