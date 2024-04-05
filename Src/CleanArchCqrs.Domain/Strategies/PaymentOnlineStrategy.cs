using CleanArchCqrs.Domain.BusinessRules;
using CleanArchCqrs.Domain.Enums;
using CleanArchCqrs.Domain.Interfaces.DomainStrategies;

namespace CleanArchCqrs.Domain.Strategies
{
    public class PaymentOnlineStrategy : IPaymentBusinessRuleStrategy
    {
        private readonly OnlineRule _businessRule;

        public ProductTypeEnum SatisfiedBy => ProductTypeEnum.OnLine;

        public PaymentOnlineStrategy()
        {
            //TODO:: Carregar as regras de negócio de um banco de dados ou de um json assim permiti que tenha um sistema para popular as regras
            _businessRule = new OnlineRule();
        }

        public BaseRule GetBusinessRule()
        {
            return _businessRule;
        }
    }
}
