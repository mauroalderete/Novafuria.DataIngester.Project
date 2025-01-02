using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Novafuria.DataIngester.Domain.Core.Capabilities;
using Novafuria.DataIngester.Lifecycle.Domain.Infrastructure.Repositories;
using Novafuria.DataIngester.Lifecycle.Temporalio.Infrastructure.Extensions.Options;
using Novafuria.DataIngester.Lifecycle.Temporalio.Infrastructure.Repositories;
using Novafuria.DataIngester.Lifecycle.Temporalio.Infrastructure.Configurations;
using Novafuria.DataIngester.Lifecycle.Temporalio.Infrastructure.AppSettings;

namespace Novafuria.DataIngester.Lifecycle.Temporalio.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddLifecycleTemporalioInfrastructure(this IServiceCollection services, Action<InfrastructureBuilderOptions> options)
        {
            // Setup InfrastructureBuilderOptions
            var _options = new InfrastructureBuilderOptions();
            options(_options);

            // Validate required options
            if (!_options.ValidateOptionsRequired())
            {
                throw new System.Exception("Required options not set");
            }

            // Setup configuration for Temporalio connection
            services.Configure<TemporalioConnectionConfig>( config =>
            {
                var defaultTemporalConnectionSetting = new DefaultTemporalioConnectionConfig();

                config.Host = DataTypes.Coalesce(
                    () => _options.TemporalioConnectionConfig.Host,
                    () => _options.Configuration[AppSettingsKeys.TEMPORALIO_HOST] ?? string.Empty,
                    () => defaultTemporalConnectionSetting.Host
                );

                config.Port = DataTypes.Coalesce(
                    () => _options.TemporalioConnectionConfig.Port,
                    () => int.Parse(_options.Configuration[AppSettingsKeys.TEMPORALIO_PORT] ?? "0"),
                    () => defaultTemporalConnectionSetting.Port
                );

                config.Namespace = DataTypes.Coalesce(
                    () => _options.TemporalioConnectionConfig.Namespace,
                    () => _options.Configuration[AppSettingsKeys.TEMPORALIO_NAMESPACE] ?? string.Empty,
                    () => defaultTemporalConnectionSetting.Namespace
                );

                config.TaskQueue = DataTypes.Coalesce(
                    () => _options.TemporalioConnectionConfig.TaskQueue,
                    () => _options.Configuration[AppSettingsKeys.TEMPORALIO_TASK_QUEUE] ?? string.Empty,
                    () => defaultTemporalConnectionSetting.TaskQueue
                );
            });

            // Get Temporalio connection configuration from DI
            var temporalioConnection = services.BuildServiceProvider().GetRequiredService<IOptions<TemporalioConnectionConfig>>().Value;

            // Setup Temporalio worker
            var workerServiceBuilderOption = services.AddHostedTemporalWorker(
                clientTargetHost: $"{temporalioConnection.Host}:{temporalioConnection.Port}",
                clientNamespace: temporalioConnection.Namespace,
                taskQueue: temporalioConnection.TaskQueue
                );

            services.AddTemporalClient(
                clientTargetHost: $"{temporalioConnection.Host}:{temporalioConnection.Port}",
                clientNamespace: temporalioConnection.Namespace
                );

            // Execute handle options
            _options.HandleTemporalWorkerOptionsBuilder?.Invoke(workerServiceBuilderOption);

            // Register repositories
            // TODO: evaluar si corresponde singleton o scoped... en el caso mas simple es suficiente con singleton.
            services.AddSingleton<IDomainLifecycleRepository, SimpleDomainLifecycleRepository>();

            return services;
        }
    }
}
