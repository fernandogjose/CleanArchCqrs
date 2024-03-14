using CleanArchCqrs.Domain.Entities;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using CleanArchCqrs.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchCqrs.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _applicationDbContext.Add(product);
            await _applicationDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _applicationDbContext.Update(product);
            await _applicationDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteAsync(Product product)
        {
            _applicationDbContext.Remove(product);
            await _applicationDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Products.AsNoTracking().FirstOrDefaultAsync(where => where.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _applicationDbContext.Products.ToListAsync();
        }
    }
}
