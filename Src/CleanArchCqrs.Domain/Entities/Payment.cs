using CleanArchCqrs.Domain.Enums;

namespace CleanArchCqrs.Domain.Entities
{
    public sealed class Payment : Base
    {
        public PaymentGoalEnum Goal { get; private set; }

        public PaymentTypeEnum Type { get; private set; }

        public decimal Value { get; private set; }

        public int ProductId { get; private set; }

        public int AgentId { get; private set; }

        public Product Product { get; set; }

        public Agent Agent { get; set; }

        public Payment(int id)
        {
            Id = id;
        }

        public Payment(PaymentGoalEnum goal, PaymentTypeEnum type, decimal value, int productId, int agentId)
        {
            Goal = goal;
            Type = type;
            Value = value;
            ProductId = productId;
            AgentId = agentId;
        }
    }
}
