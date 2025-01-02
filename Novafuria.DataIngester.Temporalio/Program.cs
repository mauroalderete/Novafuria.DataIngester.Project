using Microsoft.Extensions.Options;
using Temporalio.Extensions.Hosting;
using Temporalio.Client;
using Novafuria.DataIngester.Lifecycle.Base.UseCases.Extensions;
using Novafuria.DataIngester.Lifecycle.Temporalio.Infrastructure.Configurations;
using Novafuria.DataIngester.Lifecycle.Temporalio.Infrastructure.Extensions;
using Novafuria.DataIngester.Lifecycle.Temporalio.UseCases.Extensions;
using Novafuria.DataIngester.Lifecycle.Temporalio.Presentation.Extensions;
using Novafuria.DataIngester.Lifecycle.Temporalio.UseCases.Workflows;

namespace Novafuria.DataIngester.Temporalio
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ITemporalWorkerServiceOptionsBuilder? temporalWorkerServiceOptionsBuilder = null;

            // Add Lifecycle Base layers
            builder.Services.AddLifecycleBaseUseCases(options => {});

            // Add Lifecycle Temporalio layers
            builder.Services.AddLifecycleTemporalioInfrastructure(options =>
            {
                options.SetServiceConfiguration(builder.Configuration);
                options.SetHandleTemporalWorkerServiceOptionsBuilder(builder => temporalWorkerServiceOptionsBuilder = builder);
            });

            builder.Services.AddLifecycleTemporalioUseCases(options =>
            {
                if (temporalWorkerServiceOptionsBuilder == null) {
                    throw new Exception("TemporalWorkerServiceOptionsBuilder not set");
                }

                options.SetTemporalWorkerServiceOptionsBuilder(temporalWorkerServiceOptionsBuilder);
            });

            builder.Services.AddLifecycleTemporalioPresentation(options =>
            {
                if (temporalWorkerServiceOptionsBuilder == null)
                {
                    throw new Exception("TemporalWorkerServiceOptionsBuilder not set");
                }

                options.SetTemporalWorkerServiceOptionsBuilder(temporalWorkerServiceOptionsBuilder);
            });

            // Add tipical services

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            await OnStart(app);

            await app.RunAsync();
        }

        public static async Task OnStart(WebApplication app)
        {
            // Domain Lifecycle Invocations
            using (var scope = app.Services.CreateScope())
            {
                ITemporalClient client = scope.ServiceProvider.GetRequiredService<ITemporalClient>();
                var temporalioConfig = scope.ServiceProvider.GetRequiredService<IOptions<TemporalioConnectionConfig>>().Value;

                if (client == null)
                {
                    throw new Exception("TemporalClient not set");
                }

                await client.StartWorkflowAsync(
                    (DataIngesterInitializationWorkflow wf) => wf.InitializeDataIngesterAsync(),
                    new WorkflowOptions
                    {
                        Id = "domain-initialization",
                        TaskQueue = temporalioConfig.TaskQueue,
                    });
            }
        }
    }
}
