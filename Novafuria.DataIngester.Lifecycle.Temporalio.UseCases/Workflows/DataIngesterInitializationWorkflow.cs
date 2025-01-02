using Novafuria.DataIngester.Domain.Core.DomainEvents.Abstractions;
using Novafuria.DataIngester.Lifecycle.Domain.Core.Aggregates;
using Novafuria.DataIngester.Lifecycle.Domain.UseCases;
using Novafuria.DataIngester.Lifecycle.Temporalio.UseCases.Activities;
using Temporalio.Workflows;


namespace Novafuria.DataIngester.Lifecycle.Temporalio.UseCases.Workflows
{
    [Workflow]
    public class DataIngesterInitializationWorkflow : IDataIngesterInitializationUseCase
    {
        [WorkflowRun]
        public async Task InitializeDataIngesterAsync()
        {
            var activityOptions = new ActivityOptions
            {
                StartToCloseTimeout = TimeSpan.FromMinutes(5)
            };

            LifecycleAggregate? lifecycle = null;
            try
            {
                lifecycle = await Workflow.ExecuteActivityAsync<DataIngesterInitilizationActivities, LifecycleAggregate>(
                    (activity) => activity.FetchOrCreateLifecycleAggregateAsync(),
                    activityOptions);

                if (lifecycle is null)
                {
                    throw new Exception("Lifecycle not set");
                }
            }
            catch (Exception ex)
            {
                // Log exception
            }

            IReadOnlyCollection<IDomainEvent>? events = null;
            try
            {
                events = await Workflow.ExecuteActivityAsync<DataIngesterInitilizationActivities, IReadOnlyCollection<IDomainEvent>>(
                    (activity) => activity.InitializeLifecycleAsync(lifecycle!),
                    activityOptions);

                if (events is null)
                {
                    throw new Exception("Domain events not set");
                }
            } catch (Exception ex)
            {
                // Log exception
            }

            try
            {
                await Workflow.ExecuteActivityAsync<DataIngesterInitilizationActivities>(
                    (activity) => activity.UpdateLifecycleAggregateInitializedAsync(lifecycle!),
                    activityOptions);
            }
            catch (Exception ex)
            {
                // Log exception
            }

            try
            {
                await Workflow.ExecuteActivityAsync<DataIngesterInitilizationActivities>(
                    (activity) => activity.NotifyDataIngesterInitilizedAsync(events!),
                    activityOptions);
            }
            catch (Exception ex)
            {
                // Log exception
            }
        }
    }
}
