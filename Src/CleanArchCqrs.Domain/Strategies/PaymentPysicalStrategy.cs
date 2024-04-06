using CleanArchCqrs.Domain.BusinessRules;
using CleanArchCqrs.Domain.Enums;
using CleanArchCqrs.Domain.Interfaces.DomainStrategies;

namespace CleanArchCqrs.Domain.Strategies
{
    public class PaymentPysicalStrategy : IPaymentBusinessRuleStrategy
    {
        private readonly PhysicalRule _businessRule;

        public ProductTypeEnum SatisfiedBy => ProductTypeEnum.Physical;

        public PaymentPysicalStrategy()
        {
            //TODO:: Mudar para carregar as regras de negócio de um Json e popular este objeto
            //TODO:: Este Json pode ser populado por um outro sistema, permitindo que o usuário possa criar as regras de negócio sem a necessidade de mudança do código
            //TODO:: Dependendo da necessidade o json pode virar um banco de dados relacional ou não relacional, ou ainda algum sistema de terceiro
            _businessRule = new PhysicalRule();
        }

        public BaseRule GetBusinessRule()
        {
            return _businessRule;
        }
    }
}
