using CleanArchCqrs.Domain.BusinessRules;
using CleanArchCqrs.Domain.Enums;

namespace CleanArchCqrs.Domain.Interfaces.DomainHelpers
{
    public interface IPaymentGoalHelper
    {
        void Process(List<PaymentGoal> paymentGoals, PaymentGoalEnum goal, string agentEmail);
    }
}
