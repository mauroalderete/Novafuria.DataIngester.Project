namespace Novafuria.DataIngester.Lifecycle.Temporalio.Infrastructure.Configurations
{
    public record TemporalioConnectionConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Namespace { get; set; }
        public string TaskQueue { get; set; }

        public TemporalioConnectionConfig()
        {
            Host = string.Empty;
            Port = default;
            Namespace = string.Empty;
            TaskQueue = string.Empty;
        }
    }
}
