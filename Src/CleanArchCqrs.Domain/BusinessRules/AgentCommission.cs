namespace CleanArchCqrs.Domain.BusinessRules
{
    public class AgentCommission(string productCategoryName, int commissionPercentage)
    {
        public string ProductCategoryName { get; } = productCategoryName;
        public int CommissionPercentage { get; } = commissionPercentage;
    }
}
