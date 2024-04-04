using CleanArchCqrs.Domain.Entities;
using CleanArchCqrs.Domain.Exceptions;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using CleanArchCqrs.Domain.Interfaces.DomainValidations;

namespace CleanArchCqrs.Domain.Validations
{
    public class PaymentValidation : IPaymentValidation
    {
        private readonly IProductRepository _productRepository;

        private readonly IAgentRepository _agentRepository;

        public PaymentValidation(IProductRepository productRepository, IAgentRepository agentRepository)
        {
            _productRepository = productRepository;
            _agentRepository = agentRepository;
        }

        public async Task ValidateCreateAsync(Payment payment)
        {
            ValidateValue(payment.Value);
            await ValidateProductIdAsync(payment.ProductId);
            await ValidateAgentIdAsync(payment.AgentId);
        }

        private void ValidateValue(decimal value)
        {
            DomainException.When(value <= 0, "Value is invalid");
        }

        private async Task ValidateProductIdAsync(int productId)
        {
            DomainException.When(productId < 0, "Product is invalid");
            DomainException.When(await _productRepository.GetByIdAsync(productId) == null, "Product not found");
        }

        private async Task ValidateAgentIdAsync(int agentId)
        {
            DomainException.When(agentId < 0, "Product is invalid");
            DomainException.When(await _agentRepository.GetByIdAsync(agentId) == null, "Agent not found");
        }
    }
}
