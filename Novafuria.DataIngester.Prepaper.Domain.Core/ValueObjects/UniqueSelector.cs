using Novafuria.DataIngester.Domain.Core.ValueObject.Abstractions;

namespace Novafuria.DataIngester.Prepaper.Domain.Core.ValueObjects
{
    public class UniqueSelector : ValueObjectBase<string>
    {
        protected UniqueSelector(string value) : base(value)
        {
        }

        public static UniqueSelector Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new System.ArgumentException("Value cannot be null or whitespace.", nameof(value));
            }

            return new UniqueSelector(value);
        }
    }
}
