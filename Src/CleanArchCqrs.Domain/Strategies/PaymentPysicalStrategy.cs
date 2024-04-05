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
            //TODO:: Carregar as regras de negócio de um banco de dados ou de um json assim permiti que tenha um sistema para popular as regras
            _businessRule = new PhysicalRule();
        }

        public BaseRule GetBusinessRule()
        {
            return _businessRule;
        }
    }
}
