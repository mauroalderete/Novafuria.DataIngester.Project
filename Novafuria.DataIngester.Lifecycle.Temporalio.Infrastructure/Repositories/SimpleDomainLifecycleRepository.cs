using Microsoft.Extensions.Logging;
using Novafuria.DataIngester.Lifecycle.Domain.Core.Aggregates;
using Novafuria.DataIngester.Lifecycle.Domain.Infrastructure.Repositories;

namespace Novafuria.DataIngester.Lifecycle.Temporalio.Infrastructure.Repositories
{
    public class SimpleDomainLifecycleRepository : IDomainLifecycleRepository
    {
        private readonly ILogger<SimpleDomainLifecycleRepository> _logger;
        private LifecycleAggregate? aggregate { get; set; }

        public SimpleDomainLifecycleRepository(ILogger<SimpleDomainLifecycleRepository> logger)
        {
            _logger = logger;
        }

        public Task<LifecycleAggregate?> GetDomainLifecycleAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(aggregate);
        }

        public Task SaveDomainLifecycleAsync(LifecycleAggregate aggregate, CancellationToken cancellationToken = default)
        {
            this.aggregate = aggregate;

            return Task.CompletedTask;
        }
    }
}
