using Microsoft.Extensions.DependencyInjection;
using Novafuria.DataIngester.Lifecycle.Temporalio.Presentation.Options;

namespace Novafuria.DataIngester.Lifecycle.Temporalio.Presentation.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddLifecycleTemporalioPresentation(this IServiceCollection services, Action<PresentationBuilderOptions> builder)
        {
            // Setup PresentationBuilderOptions
            var options = new PresentationBuilderOptions();
            builder(options);

            // Validate required options
            if (!options.ValidateOptionsRequired())
            {
                throw new System.Exception("Required options not set");
            }

            return services;
        }
    }
}
