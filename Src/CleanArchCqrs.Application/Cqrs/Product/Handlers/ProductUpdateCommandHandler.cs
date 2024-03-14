using AutoMapper;
using CleanArchCqrs.Application.Cqrs.Product.Commands;
using CleanArchCqrs.Application.Dtos;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using CleanArchCqrs.Domain.Interfaces.DomainValidations;
using MediatR;

namespace CleanArchCqrs.Application.Cqrs.Product.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, ProductUpdateResponse>
    {
        private readonly IMapper _mapper;

        private readonly IProductValidation _productValidation;

        private readonly IProductRepository _productRepository;

        public ProductUpdateCommandHandler(IProductRepository productRepository, IMapper mapper, IProductValidation productValidation)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productValidation = productValidation;
        }

        public async Task<ProductUpdateResponse> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var productEntityRequest = _mapper.Map<Domain.Entities.Product>(request);
            await _productValidation.ValidateUpdateAsync(productEntityRequest);

            var productEntityResponse = await _productRepository.UpdateAsync(productEntityRequest);
            var productUpdateResponse = _mapper.Map<ProductUpdateResponse>(productEntityResponse);
            return productUpdateResponse;
        }
    }
}
