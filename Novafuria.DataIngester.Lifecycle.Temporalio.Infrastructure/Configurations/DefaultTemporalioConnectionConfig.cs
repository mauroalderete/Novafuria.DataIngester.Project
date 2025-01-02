namespace Novafuria.DataIngester.Lifecycle.Temporalio.Infrastructure.Configurations
{
    public record DefaultTemporalioConnectionConfig : TemporalioConnectionConfig
    {
        public DefaultTemporalioConnectionConfig()
        {
            Host = "localhost";
            Port = 7233;
            Namespace = "default";
            TaskQueue = "NOVAFURIA_DATAINGESTER_TEMPORALIO_TASK_QUEUE";
        }
    }
}
