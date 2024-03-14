using CleanArchCqrs.Domain.Entities;

namespace CleanArchCqrs.Domain.Interfaces.DomainValidations
{
    public interface IProductValidation
    {
        Task ValidateCreateAsync(Product product);

        Task ValidateUpdateAsync(Product product);

        Task ValidateDeleteAsync(Product product);
    }
}
