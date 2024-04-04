using CleanArchCqrs.Domain.Entities;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using CleanArchCqrs.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchCqrs.Infra.Data.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PaymentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Payment> CreateAsync(Payment payment)
        {
            _applicationDbContext.Add(payment);
            await _applicationDbContext.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> UpdateAsync(Payment payment)
        {
            _applicationDbContext.Update(payment);
            await _applicationDbContext.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> DeleteAsync(Payment payment)
        {
            _applicationDbContext.Remove(payment);
            await _applicationDbContext.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Payments.AsNoTracking().FirstOrDefaultAsync(where => where.Id == id);
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _applicationDbContext.Payments.ToListAsync();
        }
    }
}
