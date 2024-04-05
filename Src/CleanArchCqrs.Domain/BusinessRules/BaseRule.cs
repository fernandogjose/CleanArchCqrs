using CleanArchCqrs.Domain.Enums;

namespace CleanArchCqrs.Domain.BusinessRules
{
    // Criei essa class de forma temporária, o interessante seria ter estas informação em um banco ou json e ser populado por alguma aplicação
    // para que o usuário possa criar as próprias regras
    public abstract class BaseRule
    {
        public ProductTypeEnum ProductType { get; protected set; }
        public List<ShipmentToCreate> ShipmentsToCreate { get; protected set; }
        public List<ResourceToAdd> ResourcesToAdd { get; protected set; }
        public List<AgentCommission> AgentCommissions { get; protected set; }
        public List<PaymentGoal> PaymentGoals { get; protected set; }
    }
}