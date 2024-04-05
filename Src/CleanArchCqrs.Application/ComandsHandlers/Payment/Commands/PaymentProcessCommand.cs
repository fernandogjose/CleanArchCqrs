using CleanArchCqrs.Domain.Enums;
using MediatR;

namespace CleanArchCqrs.Application.ComandsHandlers.Payment.Commands
{
    public class PaymentProcessCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public PaymentGoalEnum Goal { get; set; }

        public PaymentTypeEnum Type { get; set; }

        public decimal Value { get; set; }

        public int ProductId { get; set; }

        public int AgentId { get; set; }

        public PaymentProcessProduct Product { get; set; }

        public PaymentProcessAgent Agent { get; set; }
    }

    public class PaymentProcessAgent
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class PaymentProcessProduct
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public int CategoryId { get; set; }

        public ProductTypeEnum Type { get; set; }

        public PaymentProcessCategory Category { get; set; }
    }

    public class PaymentProcessCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
