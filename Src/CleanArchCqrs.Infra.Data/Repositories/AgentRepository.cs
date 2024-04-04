using CleanArchCqrs.Domain.Entities;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using CleanArchCqrs.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchCqrs.Infra.Data.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AgentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Agent> CreateAsync(Agent agent)
        {
            _applicationDbContext.Add(agent);
            await _applicationDbContext.SaveChangesAsync();
            return agent;
        }

        public async Task<Agent> UpdateAsync(Agent agent)
        {
            _applicationDbContext.Update(agent);
            await _applicationDbContext.SaveChangesAsync();
            return agent;
        }

        public async Task<Agent> DeleteAsync(Agent agent)
        {
            _applicationDbContext.Remove(agent);
            await _applicationDbContext.SaveChangesAsync();
            return agent;
        }

        public async Task<Agent> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Agents.AsNoTracking().FirstOrDefaultAsync(where => where.Id == id);
        }

        public async Task<IEnumerable<Agent>> GetAllAsync()
        {
            return await _applicationDbContext.Agents.ToListAsync();
        }
    }
}
