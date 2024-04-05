namespace CleanArchCqrs.Domain.BusinessRules
{
    public class ResourceToAdd(string productName, string resourceLink)
    {
        public string ProductName { get; } = productName;
        public string ResourceLink { get; } = resourceLink;
    }
}