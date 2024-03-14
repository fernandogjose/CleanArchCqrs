using AutoMapper;
using CleanArchCqrs.Application.Cqrs.Product.Queries;
using CleanArchCqrs.Application.Dtos;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using MediatR;

namespace CleanArchCqrs.Application.Cqrs.Product.Handlers
{
    public class ProductGetAllQueryHandler : IRequestHandler<ProductGetAllQuery, IEnumerable<ProductGetAllResponse>>
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public ProductGetAllQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Dtos.ProductGetAllResponse>> Handle(ProductGetAllQuery request, CancellationToken cancellationToken)
        {
            var productsEntityResponse = await _productRepository.GetAllAsync();
            var productsDtoResponse = _mapper.Map<IEnumerable<ProductGetAllResponse>>(productsEntityResponse);
            return productsDtoResponse;
        }
    }
}
