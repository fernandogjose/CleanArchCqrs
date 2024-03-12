using CleanArchCqrs.Domain.Entities;

namespace CleanArchCqrs.Domain.Interfaces.DataRepositories
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);

        Task<Category> UpdateAsync(Category category);

        Task<Category> DeleteAsync(Category category);

        Task<Category> GetByIdAsync(int id);

        Task<IEnumerable<Category>> GetAllAsync();
    }
}
