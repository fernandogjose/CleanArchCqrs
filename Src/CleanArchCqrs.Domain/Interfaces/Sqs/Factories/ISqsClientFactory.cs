using Amazon.SQS;

namespace CleanArchCqrs.Domain.Interfaces.Sqs.Factories
{
    public interface ISqsClientFactory
    {
        IAmazonSQS GetSqsClient();

        string GetSqsQueue();
    }
}
