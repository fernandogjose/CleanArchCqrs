namespace CleanArchCqrs.Domain.Entities
{
    public sealed class PaymentProcessed : Base
    {
        public string ShipmentsCreated { get; private set; }
        public string ResourcesToAdd { get; private set; }
        public decimal Comission { get; private set; }
        public int PaymentId { get; private set; }
        public Payment Payment { get; set; }

        public PaymentProcessed(int id)
        {
            Id = id;
        }

        public PaymentProcessed(string shipmentsCreated, string resourcesToAdd, decimal comission, int paymentId)
        {
            ShipmentsCreated = shipmentsCreated;
            ResourcesToAdd = resourcesToAdd;
            Comission = comission;
            PaymentId = paymentId;
        }
    }
}
