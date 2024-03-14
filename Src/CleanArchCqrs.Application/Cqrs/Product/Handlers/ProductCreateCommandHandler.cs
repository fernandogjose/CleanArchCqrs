using AutoMapper;
using CleanArchCqrs.Application.Cqrs.Product.Commands;
using CleanArchCqrs.Application.Dtos;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using CleanArchCqrs.Domain.Interfaces.DomainValidations;
using MediatR;

namespace CleanArchCqrs.Application.Cqrs.Product.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, ProductCreateResponse>
    {
        private readonly IMapper _mapper;

        private readonly IProductValidation _productValidation;

        private readonly IProductRepository _productRepository;

        public ProductCreateCommandHandler(IProductRepository productRepository, IMapper mapper, IProductValidation productValidation)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productValidation = productValidation;
        }

        public async Task<ProductCreateResponse> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var productEntityRequest = _mapper.Map<Domain.Entities.Product>(request);
            await _productValidation.ValidateCreateAsync(productEntityRequest);

            var productEntityResponse = await _productRepository.CreateAsync(productEntityRequest);
            var productCreateResponse = _mapper.Map<ProductCreateResponse>(productEntityResponse);
            return productCreateResponse;
        }
    }
}
