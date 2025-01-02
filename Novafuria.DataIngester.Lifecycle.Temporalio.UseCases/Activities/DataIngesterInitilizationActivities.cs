using Microsoft.Extensions.Logging;
using Novafuria.DataIngester.Domain.Core.DomainEvents.Abstractions;
using Novafuria.DataIngester.Lifecycle.Domain.Core.Aggregates;
using Novafuria.DataIngester.Lifecycle.Domain.Infrastructure.Repositories;
using Novafuria.DataIngester.Lifecycle.Domain.UseCases.Activities;
using Temporalio.Activities;

namespace Novafuria.DataIngester.Lifecycle.Temporalio.UseCases.Activities
{
    public class DataIngesterInitilizationActivities : IDataIngesterInitializationActivities
    {
        private ILogger<DataIngesterInitilizationActivities> _logger;
        private readonly IDomainLifecycleRepository _domainLifecycleRepository;
        private readonly IDataIngesterInitializationActivities _activitiesBase;

        public DataIngesterInitilizationActivities(
            ILogger<DataIngesterInitilizationActivities> logger,
            IDomainLifecycleRepository domainLifecycleRepository,
            IDataIngesterInitializationActivities activitiesBase
            )
        {
            _logger = logger;
            _domainLifecycleRepository = domainLifecycleRepository;
            _activitiesBase = activitiesBase;
        }

        [Activity]
        public async Task<LifecycleAggregate> FetchOrCreateLifecycleAggregateAsync()
        {
            return await _activitiesBase.FetchOrCreateLifecycleAggregateAsync();
        }

        [Activity]
        public async Task<IReadOnlyCollection<IDomainEvent>> InitializeLifecycleAsync(LifecycleAggregate lifecycleAggregate)
        {
            return await _activitiesBase.InitializeLifecycleAsync(lifecycleAggregate);
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
