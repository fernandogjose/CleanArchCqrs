using CleanArchCqrs.Domain.Entities;

namespace CleanArchCqrs.Domain.Interfaces.DataRepositories
{
    public interface IPaymentRepository
    {
        Task<Payment> CreateAsync(Payment payment);

        Task<Payment> UpdateAsync(Payment payment);

        Task<Payment> DeleteAsync(Payment payment);

        Task<Payment> GetByIdAsync(int id);

        Task<IEnumerable<Payment>> GetAllAsync();
    }
}
