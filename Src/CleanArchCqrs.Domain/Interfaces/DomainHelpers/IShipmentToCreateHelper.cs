using CleanArchCqrs.Domain.BusinessRules;

namespace CleanArchCqrs.Domain.Interfaces.DomainHelpers
{
    public interface IShipmentToCreateHelper
    {
        List<string> Process(List<ShipmentToCreate> shipmentsToCreate, string productCategoryName);
    }
}
