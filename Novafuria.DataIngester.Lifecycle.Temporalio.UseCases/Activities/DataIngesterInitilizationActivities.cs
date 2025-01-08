using Microsoft.Extensions.Logging;
using Novafuria.DataIngester.Domain.Core.DomainEvents.Abstractions;
using Novafuria.DataIngester.Lifecycle.Domain.Core.Aggregates;
using Novafuria.DataIngester.Lifecycle.Domain.Infrastructure.Repositories;
using Novafuria.DataIngester.Lifecycle.Domain.UseCases.Activities;
using Temporalio.Activities;
using Temporalio.Client.Schedules;
using Temporalio.Client;
using Temporalio.Workflows;

namespace Novafuria.DataIngester.Lifecycle.Temporalio.UseCases.Activities
{
    public class DataIngesterInitilizationActivities : IDataIngesterInitializationActivities
    {
        private ILogger<DataIngesterInitilizationActivities> _logger;
        private readonly IDomainLifecycleRepository _domainLifecycleRepository;
        private readonly IDataIngesterInitializationActivities _activitiesBase;
        private readonly ITemporalClient _client;

        public DataIngesterInitilizationActivities(
            ILogger<DataIngesterInitilizationActivities> logger,
            IDomainLifecycleRepository domainLifecycleRepository,
            IDataIngesterInitializationActivities activitiesBase,
            ITemporalClient client
            )
        {
            _logger = logger;
            _domainLifecycleRepository = domainLifecycleRepository;
            _activitiesBase = activitiesBase;
            _client = client;
        }

        [Activity]
        public async Task<LifecycleAggregate> FetchOrCreateLifecycleAggregateAsync()
        {
            return await _activitiesBase.FetchOrCreateLifecycleAggregateAsync();
        }

        [Activity]
        public async Task<IReadOnlyCollection<IDomainEvent>> InitializeLifecycleAsync(LifecycleAggregate lifecycleAggregate)
        {
            var result = await _activitiesBase.InitializeLifecycleAsync(lifecycleAggregate);


            var handle = await _client.CreateScheduleAsync(
                "my-schedule-id",
            new(
                    Action: ScheduleActionStartWorkflow.Create(
                        (MyWorkflow wf) => wf.RunAsync(),
                        new(id: "my-workflow-id", taskQueue: "my-task-queue")),
                    Spec: new()
                    {
                        Intervals = new List<ScheduleIntervalSpec> { new(Every: TimeSpan.FromDays(1)) },
                    }));

            return result;
        }

        [Activity]
        public async Task UpdateLifecycleAggregateInitializedAsync(LifecycleAggregate lifecycleAggregate)
        {
            await _activitiesBase.UpdateLifecycleAggregateInitializedAsync(lifecycleAggregate);
        }

        [Activity]
        public async Task NotifyDataIngesterInitilizedAsync(IReadOnlyCollection<IDomainEvent> domainEvents)
        {
            await _activitiesBase.NotifyDataIngesterInitilizedAsync(domainEvents);
        }
    }
}
