namespace CleanArchCqrs.Domain.Enums
{
    public enum PaymentTypeEnum
    {
        CreditCard = 0,
        DebitCard = 1,
        Pix = 2
    }

    public enum PaymentStatusEnum
    {
        Received = 0,
        Failed = 1,
        Succeeded = 2
    }
}
