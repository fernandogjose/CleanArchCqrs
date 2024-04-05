using CleanArchCqrs.Domain.Enums;

namespace CleanArchCqrs.Domain.BusinessRules
{
    public class PaymentGoal(PaymentGoalEnum goal, bool sendEmailToAgent)
    {
        public PaymentGoalEnum Goal { get; } = goal;
        public bool SendEmailToAgent { get; } = sendEmailToAgent;
    }
}