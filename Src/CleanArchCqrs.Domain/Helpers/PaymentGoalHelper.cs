using CleanArchCqrs.Domain.BusinessRules;
using CleanArchCqrs.Domain.Enums;
using CleanArchCqrs.Domain.Interfaces.DomainHelpers;

namespace CleanArchCqrs.Domain.Helpers
{
    public class PaymentGoalHelper : IPaymentGoalHelper
    {
        public void Process(List<PaymentGoal> paymentGoals, PaymentGoalEnum goal, string agentEmail)
        {
            foreach (var paymentGoal in paymentGoals.Where(s => s.Goal == goal))
            {
                if (paymentGoal.SendEmailToAgent)
                {
                    //TODO:: chamar o serviço para enviar o email
                }
            }
        }
    }
}
