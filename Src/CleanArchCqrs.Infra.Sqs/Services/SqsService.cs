using Amazon.SQS.Model;
using CleanArchCqrs.Domain.Interfaces.Sqs.Factories;
using CleanArchCqrs.Domain.Interfaces.Sqs.Services;

namespace CleanArchCqrs.Infra.Sqs.Services
{
    public class SqsService : ISqsService
    {
        private readonly ISqsClientFactory _sqsClientFactory;

        public SqsService(ISqsClientFactory sqsClientFactory)
        {
            _sqsClientFactory = sqsClientFactory;
        }

        public async Task PublishMessageAsync(string messageBody)
        {
            var request = new SendMessageRequest
            {
                MessageBody = messageBody,
                QueueUrl = _sqsClientFactory.GetSqsQueue(),
            };

            var client = _sqsClientFactory.GetSqsClient();
            await client.SendMessageAsync(request);
        }
    }
}
