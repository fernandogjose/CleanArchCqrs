namespace CleanArchCqrs.Domain.BusinessRules
{
    public class ShipmentToCreate(string productName, string productCategoryName, List<string> emails)
    {
        public string ProductName { get; } = productName;
        public string ProductCategoryName { get; } = productCategoryName;
        public List<string> Emails { get; } = emails;
    }
}