namespace CleanArchCqrs.Application.Dtos
{
    public class PaymentGetAllResponse
    {
        public int Id { get; set; }

        public string Goal { get; set; }

        public string Type { get; set; }

        public decimal Value { get; set; }

        public int ProductId { get; set; }

        public int AgentId { get; set; }
    }
}
