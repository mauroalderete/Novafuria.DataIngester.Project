using Novafuria.DataIngester.Domain.Core.Capabilities.DependencyInjection;
using Temporalio.Extensions.Hosting;

namespace Novafuria.DataIngester.Lifecycle.Temporalio.UseCases.Extensions.Options
{
    public record class UseCasesBuilderOptions : OptionsServiceCollectionExtensionBase
    {
        public ITemporalWorkerServiceOptionsBuilder? TemporalWorkerServiceOptionsBuilder { get; private set; }
        public void SetTemporalWorkerServiceOptionsBuilder(ITemporalWorkerServiceOptionsBuilder builder)
        {
            TemporalWorkerServiceOptionsBuilder = builder;
        }

        public override bool ValidateOptionsRequired()
        {
            return TemporalWorkerServiceOptionsBuilder != null;
        }
    }
}
