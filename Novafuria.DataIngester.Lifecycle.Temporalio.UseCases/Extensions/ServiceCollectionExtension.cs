using Microsoft.Extensions.DependencyInjection;
using Temporalio.Extensions.Hosting;
using Novafuria.DataIngester.Lifecycle.Temporalio.UseCases.Activities;
using Novafuria.DataIngester.Lifecycle.Temporalio.UseCases.Workflows;
using Novafuria.DataIngester.Lifecycle.Domain.UseCases;
using Novafuria.DataIngester.Lifecycle.Temporalio.UseCases.Extensions.Options;

namespace Novafuria.DataIngester.Lifecycle.Temporalio.UseCases.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddLifecycleTemporalioUseCases(this IServiceCollection services, Action<UseCasesBuilderOptions> Options)
        {
            // Setup ApplicationBuilderOptions
            var options = new UseCasesBuilderOptions();
            Options(options);

            // Validate required options
            if (!options.ValidateOptionsRequired())
            {
                throw new System.Exception("Required options not set");
            }

            // Add Temporalio Activities
            options.TemporalWorkerServiceOptionsBuilder?.AddScopedActivities<DataIngesterInitilizationActivities>();

            // Add Temporalio Workflows
            options.TemporalWorkerServiceOptionsBuilder?.AddWorkflow<DataIngesterInitializationWorkflow>();

            // Add Use Cases
            services.AddScoped<IDataIngesterInitializationUseCase, DataIngesterInitializationWorkflow>();

            return services;
        }
    }
}
