using Novafuria.DataIngester.Prepaper.Domain.Core.ValueObjects;

namespace Novafuria.DataIngester.Preparer.Domain.UseCase
{
    public interface IPrepareUseCase
    {
        Task PrepareDataAsync(ConciliationWorkflow workflow, Origin origin, UniqueSelector uniqueSelector);
    }
}
