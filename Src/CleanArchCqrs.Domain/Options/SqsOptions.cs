namespace CleanArchCqrs.Domain.Options
{
    public static class SqsOptions
    {
        public static string SqsRegion { get; set; }
        public static string SqsQueueId { get; set; }
        public static string SqsQueueName { get; set; }
        public static string IamAccessKey { get; set; }
        public static string IamSecretKey { get; set; }
    }
}
