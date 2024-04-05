using Amazon;
using Amazon.SQS;
using CleanArchCqrs.Domain.Interfaces.Sqs.Factories;
using CleanArchCqrs.Domain.Options;
using Microsoft.Extensions.Options;

namespace CleanArchCqrs.Infra.Sqs.Factories
{
    public class SqsClientFactory : ISqsClientFactory
    {
        private readonly IOptions<SqsOptions> _sqsOptions;

        public SqsClientFactory(IOptions<SqsOptions> sqsOptions)
        {
            _sqsOptions = sqsOptions;
        }

        public IAmazonSQS GetSqsClient()
        {
            var config = new AmazonSQSConfig
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName(_sqsOptions.Value.SqsRegion),
                ServiceURL = $"https://sqs.{_sqsOptions.Value.SqsRegion}.amazonaws.com"
            };

            return new AmazonSQSClient(_sqsOptions.Value.IamAccessKey, _sqsOptions.Value.IamSecretKey, config);
        }

        public string GetSqsQueue() =>
            $"https://sqs.{_sqsOptions.Value.SqsRegion}.amazonaws.com/{_sqsOptions.Value.SqsQueueId}/{_sqsOptions.Value.SqsQueueName}";
    }
}
