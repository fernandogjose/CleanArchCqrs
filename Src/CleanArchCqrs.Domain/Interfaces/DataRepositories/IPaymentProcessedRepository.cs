using CleanArchCqrs.Domain.Entities;

namespace CleanArchCqrs.Domain.Interfaces.DataRepositories
{
    public interface IPaymentProcessedRepository
    {
        Task<PaymentProcessed> CreateAsync(PaymentProcessed paymentProcessed);

        Task<PaymentProcessed> UpdateAsync(PaymentProcessed paymentProcessed);

        Task<PaymentProcessed> DeleteAsync(PaymentProcessed paymentProcessed);

        Task<PaymentProcessed> GetByIdAsync(int id);

        Task<IEnumerable<PaymentProcessed>> GetAllAsync();
    }
}
