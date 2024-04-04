namespace CleanArchCqrs.Domain.Interfaces.Sqs.Services
{
    public interface ISqsService
    {
        Task PublishMessageAsync(string messageBody);
    }
}
