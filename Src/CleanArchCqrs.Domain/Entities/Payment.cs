using CleanArchCqrs.Domain.Enums;

namespace CleanArchCqrs.Domain.Entities
{
    public sealed class Payment : Base
    {
        public PaymentGoalEnum Goal { get; private set; }

        public PaymentTypeEnum Type { get; private set; }

        public PaymentStatusEnum Status { get; set; }

        public decimal Value { get; private set; }

        public int ProductId { get; private set; }

        public int AgentId { get; private set; }

        public Product Product { get; set; }

        public Agent Agent { get; set; }

        public List<PaymentProcessed> PaymentProcesseds { get; set; }

        public Payment(
            int id = 0,
            PaymentGoalEnum goal = PaymentGoalEnum.Adhesion,
            PaymentTypeEnum type = PaymentTypeEnum.Pix,
            PaymentStatusEnum status = PaymentStatusEnum.Received,
            decimal value = 0M,
            int productId = 0,
            int agentId = 0)
        {
            Id = id;
            Goal = goal;
            Type = type;
            Status = status;
            Value = value;
            ProductId = productId;
            AgentId = agentId;
        }
    }
}
