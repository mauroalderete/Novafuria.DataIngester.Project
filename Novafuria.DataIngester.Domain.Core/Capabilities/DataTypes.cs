namespace Novafuria.DataIngester.Domain.Core.Capabilities
{
    public static class DataTypes
    {
        public static T Coalesce<T>(params Func<T>[] valueProviders)
        {
            foreach (var provider in valueProviders)
            {
                var result = provider();

                // Safe assertion for string
                if (result is string s)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        return result;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (!EqualityComparer<T>.Default.Equals(result, default!))
                {
                    return result;
                }
            }
            return default!;
        }
    }
}
