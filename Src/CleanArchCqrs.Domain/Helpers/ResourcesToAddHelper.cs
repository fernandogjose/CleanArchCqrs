using CleanArchCqrs.Domain.BusinessRules;
using CleanArchCqrs.Domain.Interfaces.DomainHelpers;

namespace CleanArchCqrs.Domain.Helpers
{
    public class ResourcesToAddHelper : IResourcesToAddHelper
    {
        public List<string> Process(List<ResourceToAdd> resourcesToAdd, string productName)
        {
            var response = new List<string>();
            foreach (var resourceToAdd in resourcesToAdd.Where(s => s.ProductName.ToLower() == productName.ToLower()))
            {
                response.Add(resourceToAdd.ResourceLink);
            }
            return response;
        }
    }
}
