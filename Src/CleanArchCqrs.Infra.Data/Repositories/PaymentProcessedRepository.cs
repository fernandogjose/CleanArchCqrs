using CleanArchCqrs.Domain.Entities;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using CleanArchCqrs.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchCqrs.Infra.Data.Repositories
{
    public class PaymentProcessedRepository : IPaymentProcessedRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PaymentProcessedRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<PaymentProcessed> CreateAsync(PaymentProcessed paymentProcessed)
        {
            _applicationDbContext.Add(paymentProcessed);
            await _applicationDbContext.SaveChangesAsync();
            return paymentProcessed;
        }

        public async Task<PaymentProcessed> UpdateAsync(PaymentProcessed paymentProcessed)
        {
            _applicationDbContext.Update(paymentProcessed);
            await _applicationDbContext.SaveChangesAsync();
            return paymentProcessed;
        }

        public async Task<PaymentProcessed> DeleteAsync(PaymentProcessed paymentProcessed)
        {
            _applicationDbContext.Remove(paymentProcessed);
            await _applicationDbContext.SaveChangesAsync();
            return paymentProcessed;
        }

        public async Task<PaymentProcessed> GetByIdAsync(int id)
        {
            return await _applicationDbContext.PaymentProcesseds.AsNoTracking().FirstOrDefaultAsync(where => where.Id == id);
        }

        public async Task<IEnumerable<PaymentProcessed>> GetAllAsync()
        {
            return await _applicationDbContext.PaymentProcesseds.ToListAsync();
        }
    }
}
