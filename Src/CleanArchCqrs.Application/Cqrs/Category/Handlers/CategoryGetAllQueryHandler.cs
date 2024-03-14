using AutoMapper;
using CleanArchCqrs.Application.Dtos;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using MediatR;
using CleanArchCqrs.Application.Cqrs.Category.Queries;

namespace CleanArchCqrs.Application.Cqrs.Category.Handlers
{
    public class CategoryGetAllQueryHandler : IRequestHandler<CategoryGetAllQuery, IEnumerable<Dtos.Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IMapper _mapper;

        public CategoryGetAllQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Dtos.Category>> Handle(CategoryGetAllQuery request, CancellationToken cancellationToken)
        {
            var categorysEntityResponse = await _categoryRepository.GetAllAsync();
            var categorysDtoResponse = _mapper.Map<IEnumerable<Dtos.Category>>(categorysEntityResponse);
            return categorysDtoResponse;
        }
    }
}
