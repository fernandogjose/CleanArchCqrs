using CleanArchCqrs.Domain.BusinessRules;
using CleanArchCqrs.Domain.Interfaces.DomainHelpers;

namespace CleanArchCqrs.Domain.Helpers
{
    public class ShipmentToCreateHelper : IShipmentToCreateHelper
    {
        public List<string> Process(List<ShipmentToCreate> shipmentsToCreate, string productCategoryName)
        {
            var response = new List<string>();
            foreach (var shipmentToCreate in shipmentsToCreate.Where(s => string.IsNullOrEmpty(s.ProductCategoryName) || s.ProductCategoryName.ToLower() == productCategoryName.ToLower()))
            {
                //TODO:: chamar o serviço para gerar a remessa

                foreach (var email in shipmentToCreate.Emails)
                {
                    //TODO:: chamar o serviço para enviar o email
                }

                response.Add("adiciona a remessa que foi gerada");
            }
            return response;
        }
    }
}
