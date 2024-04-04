using CleanArchCqrs.Domain.Entities;

namespace CleanArchCqrs.Domain.Interfaces.DataRepositories
{
    public interface IAgentRepository
    {
        Task<Agent> CreateAsync(Agent agent);

        Task<Agent> UpdateAsync(Agent agent);

        Task<Agent> DeleteAsync(Agent agent);

        Task<Agent> GetByIdAsync(int id);

        Task<IEnumerable<Agent>> GetAllAsync();
    }
}
