using Microsoft.Extensions.DependencyInjection;
using Novafuria.DataIngester.Lifecycle.Base.UseCases.Activities;
using Novafuria.DataIngester.Lifecycle.Base.UseCases.Extensions.Options;
using Novafuria.DataIngester.Lifecycle.Domain.UseCases.Activities;

namespace Novafuria.DataIngester.Lifecycle.Base.UseCases.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddLifecycleBaseUseCases(this IServiceCollection services, Action<UseCasesOptions> options)
        {

            var _options = new UseCasesOptions();
            options(_options);

            // Validate required options
            if (!_options.ValidateOptionsRequired())
            {
                throw new System.Exception("Required options not set");
            }

            services.AddScoped<IDataIngesterInitializationActivities, DataIngesterInitializationActivitiesBase>();

            return services;
        }
    }
}
