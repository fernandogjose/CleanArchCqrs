using CleanArchCqrs.Domain.BusinessRules;

namespace CleanArchCqrs.Domain.Interfaces.DomainHelpers
{
    public interface IAgentCommissionHelper
    {
        decimal Process(List<AgentCommission> agentComissions, string productCategoryName, decimal productPrice);
    }
}
