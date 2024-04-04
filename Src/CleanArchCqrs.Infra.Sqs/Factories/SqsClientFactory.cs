using Amazon;
using Amazon.SQS;
using CleanArchCqrs.Domain.Interfaces.Sqs.Factories;
using CleanArchCqrs.Domain.Options;

namespace CleanArchCqrs.Infra.Sqs.Factories
{
    public class SqsClientFactory : ISqsClientFactory
    {
        public IAmazonSQS GetSqsClient()
        {
            var config = new AmazonSQSConfig
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName(SqsOptions.SqsRegion),
                ServiceURL = $"https://sqs.{SqsOptions.SqsRegion}.amazonaws.com"
            };

            return new AmazonSQSClient(SqsOptions.IamAccessKey, SqsOptions.IamSecretKey, config);
        }

        public string GetSqsQueue() =>
            $"https://sqs.{SqsOptions.SqsRegion}.amazonaws.com/{SqsOptions.SqsQueueId}/{SqsOptions.SqsQueueName}";
    }
}
