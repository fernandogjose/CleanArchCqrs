using CleanArchCqrs.Domain.BusinessRules;
using CleanArchCqrs.Domain.Enums;

namespace CleanArchCqrs.Domain.Interfaces.DomainStrategies
{
    public interface IPaymentBusinessRuleStrategy
    {
        ProductTypeEnum SatisfiedBy { get; }

        BaseRule GetBusinessRule();
    }
}
