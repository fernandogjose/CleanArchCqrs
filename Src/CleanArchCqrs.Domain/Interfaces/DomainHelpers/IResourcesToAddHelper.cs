using CleanArchCqrs.Domain.BusinessRules;

namespace CleanArchCqrs.Domain.Interfaces.DomainHelpers
{
    public interface IResourcesToAddHelper
    {
        List<string> Process(List<ResourceToAdd> resourcesToAdd, string productName);
    }
}
