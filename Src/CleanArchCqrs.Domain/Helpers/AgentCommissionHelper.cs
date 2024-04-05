using CleanArchCqrs.Domain.BusinessRules;
using CleanArchCqrs.Domain.Interfaces.DomainHelpers;

namespace CleanArchCqrs.Domain.Helpers
{
    public class AgentCommissionHelper : IAgentCommissionHelper
    {
        public decimal Process(List<AgentCommission> agentComissions, string productCategoryName, decimal productPrice)
        {
            var response = 0m;
            foreach (var agentComission in agentComissions.Where(s => string.IsNullOrEmpty(s.ProductCategoryName) || s.ProductCategoryName.ToLower() == productCategoryName.ToLower()))
            {
                response += agentComission.CommissionPercentage / 100 * productPrice;
            }
            return response;
        }
    }
}
