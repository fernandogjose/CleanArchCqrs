using AutoMapper;
using CleanArchCqrs.Application.Dtos;
using CleanArchCqrs.Application.Product.Queries;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using MediatR;

namespace CleanArchCqrs.Application.Product.Handlers
{
    public class ProductGetAllQueryHandler : IRequestHandler<ProductGetAllQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public ProductGetAllQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(ProductGetAllQuery request, CancellationToken cancellationToken)
        {
            var productsEntityResponse = await _productRepository.GetAllAsync();
            var productsDtoResponse = _mapper.Map<IEnumerable<ProductDto>>(productsEntityResponse);
            return productsDtoResponse;
        }
    }
}
