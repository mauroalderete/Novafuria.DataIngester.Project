using Novafuria.DataIngester.Domain.Core.ValueObject.Abstractions;

namespace Novafuria.DataIngester.Prepaper.Domain.Core.ValueObjects
{
    public class Origin : ValueObjectBase<string>
    {
        protected Origin(string value) : base(value)
        {
        }

        public static Origin Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new System.ArgumentException("Value cannot be null or whitespace.", nameof(value));
            }

            return new Origin(value);
        }
    }
}
