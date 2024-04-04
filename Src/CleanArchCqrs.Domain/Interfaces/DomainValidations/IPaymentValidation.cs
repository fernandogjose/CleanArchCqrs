using CleanArchCqrs.Domain.Entities;

namespace CleanArchCqrs.Domain.Interfaces.DomainValidations
{
    public interface IPaymentValidation
    {
        Task ValidateCreateAsync(Payment payment);
    }
}
