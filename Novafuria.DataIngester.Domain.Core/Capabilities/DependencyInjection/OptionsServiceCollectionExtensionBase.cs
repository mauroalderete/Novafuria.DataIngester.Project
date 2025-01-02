namespace Novafuria.DataIngester.Domain.Core.Capabilities.DependencyInjection
{
    public abstract record class OptionsServiceCollectionExtensionBase
    {
        abstract public bool ValidateOptionsRequired();
    }
}
