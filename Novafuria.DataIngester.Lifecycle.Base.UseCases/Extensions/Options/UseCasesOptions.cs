using Novafuria.DataIngester.Domain.Core.Capabilities.DependencyInjection;

namespace Novafuria.DataIngester.Lifecycle.Base.UseCases.Extensions.Options
{
    public record class UseCasesOptions : OptionsServiceCollectionExtensionBase
    {
        public override bool ValidateOptionsRequired()
        {
            return true;
        }
    }
}
