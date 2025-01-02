using Microsoft.Extensions.Configuration;
using Novafuria.DataIngester.Domain.Core.Capabilities.DependencyInjection;
using Novafuria.DataIngester.Lifecycle.Temporalio.Infrastructure.Configurations;
using Temporalio.Extensions.Hosting;

namespace Novafuria.DataIngester.Lifecycle.Temporalio.Infrastructure.Extensions.Options
{
    public record class InfrastructureBuilderOptions : OptionsServiceCollectionExtensionBase
    {
        public IConfiguration Configuration { get; private set; }
        public TemporalioConnectionConfig TemporalioConnectionConfig { get; private set; } = new TemporalioConnectionConfig();
        public Action<ITemporalWorkerServiceOptionsBuilder>? HandleTemporalWorkerOptionsBuilder { get; private set; }

        public void SetServiceConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void SetTemporalioConnectionHost(string host)
        {
            TemporalioConnectionConfig.Host = host;
        }

        public void SetTemporalioConnectionPort(int port)
        {
            TemporalioConnectionConfig.Port = port;
        }

        public void SetTemporalioConnectionNamespace(string @namespace)
        {
            TemporalioConnectionConfig.Namespace = @namespace;
        }

        public void SetTemporalioConnectionTaskQueue(string taskQueue)
        {
            TemporalioConnectionConfig.TaskQueue = taskQueue;
        }

        public void SetHandleTemporalWorkerServiceOptionsBuilder(Action<ITemporalWorkerServiceOptionsBuilder> options)
        {
            HandleTemporalWorkerOptionsBuilder = options;
        }

        public override bool ValidateOptionsRequired()
        {
            return Configuration != null;
        }
    }
}
