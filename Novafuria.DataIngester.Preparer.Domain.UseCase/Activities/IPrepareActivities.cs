using Novafuria.DataIngester.Prepaper.Domain.Core.ValueObjects;

namespace Novafuria.DataIngester.Preparer.Domain.UseCase.Activities
{
    public interface IPrepareActivities
    {
        Task ValidateUniqueSelector(UniqueSelector uniqueSelector);
    }
}
