using CleanArchCqrs.Application.Dtos;
using MediatR;

namespace CleanArchCqrs.Application.ComandsHandlers.Payment.Commands
{
    public class PaymentCreateCommand : IRequest<PaymentCreateResponse>
    {
        public int Id { get; private set; }

        public string Goal { get; private set; }

        public string Type { get; private set; }

        public decimal Value { get; private set; }

        public int ProductId { get; private set; }

        public int AgentId { get; private set; }

        public PaymentCreateCommand(int id, string goal, string type, decimal value, int productId, int agentId)
        {
            Id = id;
            Goal = goal;
            Type = type;
            Value = value;
            ProductId = productId;
            AgentId = agentId;
        }
    }
}
