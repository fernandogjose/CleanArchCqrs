using AutoMapper;
using CleanArchCqrs.Application.Cqrs.Product.Queries;
using CleanArchCqrs.Application.Dtos;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using MediatR;

namespace CleanArchCqrs.Application.Cqrs.Product.Handlers
{
    public class ProductGetByIdQueryHandler : IRequestHandler<ProductGetByIdQuery, ProductGetByIdResponse>
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public ProductGetByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductGetByIdResponse> Handle(ProductGetByIdQuery request, CancellationToken cancellationToken)
        {
            var productEntityResponse = await _productRepository.GetByIdAsync(request.Id);
            var productDtoResponse = _mapper.Map<ProductGetByIdResponse>(productEntityResponse);
            return productDtoResponse;
        }
    }
}
