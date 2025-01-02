using Novafuria.DataIngester.Lifecycle.Domain.Core.Aggregates;

namespace Novafuria.DataIngester.Lifecycle.Domain.Infrastructure.Repositories
{
    public interface IDomainLifecycleRepository
    {
        Task<LifecycleAggregate?> GetDomainLifecycleAsync(CancellationToken cancellationToken = default);
        Task SaveDomainLifecycleAsync(LifecycleAggregate aggregate, CancellationToken cancellationToken = default);
    }
}
