using Novafuria.DataIngester.Prepaper.Domain.Core.ValueObjects;
using Novafuria.DataIngester.Preparer.Domain.UseCase;

namespace Novafuria.DataIngester.Preparer.UseCase.Workflows
{
    public class PrepareWorkflow : IPrepareUseCase
    {
        public Task PrepareDataAsync(ConciliationWorkflow workflow, Origin origin, UniqueSelector uniqueSelector)
        {
            throw new NotImplementedException();
        }
    }
}
