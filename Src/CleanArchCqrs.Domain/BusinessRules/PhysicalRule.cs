using CleanArchCqrs.Domain.Enums;

namespace CleanArchCqrs.Domain.BusinessRules
{
    // Criei essa class de forma temporária, o interessante seria ter estas informação em um banco ou json e ser populado por alguma aplicação
    // para que o usuário possa criar as próprias regras
    public class PhysicalRule : BaseRule
    {
        public PhysicalRule()
        {
            ProductType = ProductTypeEnum.Physical;
            ShipmentsToCreate = [
                new("", "", ["email1", "email2"]),
                new("", "Livro", ["email-do-royalties"]),
            ];
            ResourcesToAdd = [
                new("Aprendendo a Esquiar", "link-do-recurso")
            ];
            AgentCommissions = [
                new ("Livro", 10)
            ];
            PaymentGoals = [
                new (PaymentGoalEnum.Adhesion, true),
                new (PaymentGoalEnum.Upgrade, true)
            ];
        }
    }
}