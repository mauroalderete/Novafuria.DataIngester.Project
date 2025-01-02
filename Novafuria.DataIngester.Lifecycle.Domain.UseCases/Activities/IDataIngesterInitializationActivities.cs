using Novafuria.DataIngester.Domain.Core.DomainEvents.Abstractions;
using Novafuria.DataIngester.Lifecycle.Domain.Core.Aggregates;

namespace Novafuria.DataIngester.Lifecycle.Domain.UseCases.Activities
{
    public interface IDataIngesterInitializationActivities
    {
        Task<LifecycleAggregate> FetchOrCreateLifecycleAggregateAsync();
        Task<IReadOnlyCollection<IDomainEvent>> InitializeLifecycleAsync(LifecycleAggregate lifecycleAggregate);
        Task UpdateLifecycleAggregateInitializedAsync(LifecycleAggregate lifecycleAggregate);
        Task NotifyDataIngesterInitilizedAsync(IReadOnlyCollection<IDomainEvent> domainEvents);
    }
}
