using CleanArchCqrs.Domain.Entities;

namespace CleanArchCqrs.Domain.Interfaces.DataRepositories
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);

        Task<Product> UpdateAsync(Product product);

        Task<Product> DeleteAsync(Product product);

        Task<Product> GetByIdAsync(int id);

        Task<IEnumerable<Product>> GetAllAsync();
    }
}
