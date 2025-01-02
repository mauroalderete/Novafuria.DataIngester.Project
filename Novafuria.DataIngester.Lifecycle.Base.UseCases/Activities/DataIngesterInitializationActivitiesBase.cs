using Microsoft.Extensions.Logging;
using Novafuria.DataIngester.Domain.Core.DomainEvents.Abstractions;
using Novafuria.DataIngester.Lifecycle.Domain.Core.Aggregates;
using Novafuria.DataIngester.Lifecycle.Domain.Infrastructure.Repositories;
using Novafuria.DataIngester.Lifecycle.Domain.UseCases.Activities;

namespace Novafuria.DataIngester.Lifecycle.Base.UseCases.Activities
{
    public class DataIngesterInitializationActivitiesBase : IDataIngesterInitializationActivities
    {
        private ILogger<DataIngesterInitializationActivitiesBase> _logger;
        private readonly IDomainLifecycleRepository _domainLifecycleRepository;

        public DataIngesterInitializationActivitiesBase(
            ILogger<DataIngesterInitializationActivitiesBase> logger,
            IDomainLifecycleRepository domainLifecycleRepository)
        {
            _logger = logger;
            _domainLifecycleRepository = domainLifecycleRepository;
        }

        public async Task<LifecycleAggregate> FetchOrCreateLifecycleAggregateAsync()
        {
            var lifecycle = await _domainLifecycleRepository.GetDomainLifecycleAsync();
            if (lifecycle == null)
            {
                lifecycle = new LifecycleAggregate();
            }

            return lifecycle;
        }

        public async Task<IReadOnlyCollection<IDomainEvent>> InitializeLifecycleAsync(LifecycleAggregate lifecycleAggregate)
        {
            return await Task.Run(() =>
            {
                _domainLifecycleRepository.SaveDomainLifecycleAsync(lifecycleAggregate);

                return lifecycleAggregate.DomainEvents;
            });
        }

        public async Task NotifyDataIngesterInitilizedAsync(IReadOnlyCollection<IDomainEvent> domainEvents)
        {
            await Task.Run(() =>
            {
                foreach (var domainEvent in domainEvents)
                {
                }
            });
        }

        public async Task UpdateLifecycleAggregateInitializedAsync(LifecycleAggregate lifecycleAggregate)
        {
            if (lifecycleAggregate.IsInitialized)
            {
                _logger.LogInformation("Domain already initialized");
                return;
            }

            await _domainLifecycleRepository.SaveDomainLifecycleAsync(lifecycleAggregate);
        }
    }
}
