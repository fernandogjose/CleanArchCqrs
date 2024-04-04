using AutoMapper;
using CleanArchCqrs.Application.ComandsHandlers.Product.Commands;
using CleanArchCqrs.Application.Dtos;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using CleanArchCqrs.Domain.Interfaces.DomainValidations;
using MediatR;

namespace CleanArchCqrs.Application.ComandsHandlers.Product.Handlers
{
    public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, ProductDeleteResponse>
    {
        private readonly IMapper _mapper;

        private readonly IProductValidation _productValidation;

        private readonly IProductRepository _productRepository;

        public ProductDeleteCommandHandler(IProductRepository productRepository, IMapper mapper, IProductValidation productValidation)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productValidation = productValidation;
        }

        public async Task<ProductDeleteResponse> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            var productEntityRequest = _mapper.Map<Domain.Entities.Product>(request);
            await _productValidation.ValidateDeleteAsync(productEntityRequest);

            var productEntityResponse = await _productRepository.DeleteAsync(productEntityRequest);
            var productDeleteResponse = _mapper.Map<ProductDeleteResponse>(productEntityResponse);
            return productDeleteResponse;
        }
    }
}
