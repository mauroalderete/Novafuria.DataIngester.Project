using System.Text.Json;

namespace Novafuria.DataIngester.Domain.Core.ValueObject.Abstractions
{
    /// <summary>
    /// Represents the base class for value objects, providing equality logic based on the value of the object.
    /// Additional Resources:
    /// - [Value Object Pattern && Operators](https://enterprisecraftsmanship.com/posts/value-object-better-implementation/)
    /// - [Equality in C#](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects#value-object-implementation-in-c)
    /// </summary>
    /// <example>
    /// public class Address : ValueObject
    /// {
    ///     public string Street { get; }
    ///     public string City { get; }
    ///     public string ZipCode { get; }
    /// 
    ///     public Address(string street, string city, string zipCode)
    ///     {
    ///         Street = street;
    ///         City = city;
    ///         ZipCode = zipCode;
    ///     }
    /// 
    ///     protected override IEnumerable<object> GetEqualityComponents()
    ///     {
    ///         yield return Street;
    ///         yield return City;
    ///         yield return ZipCode;
    ///     }
    /// }
    /// </example>
    public abstract class ValueObjectBase
    {
        /// <summary>
        /// Defines the components that determine the equality of the value object.
        /// </summary>
        /// <returns>An enumerable of objects representing the equality components.</returns>
        protected abstract IEnumerable<object?> GetEqualityComponents();

        /// <summary>
        /// Determines whether the specified object is equal to the current value object.
        /// Compares only the equality components of the objects, not their references or instances.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object? other)
        {
            if (other == null || other.GetType() != GetType())
                return false;

            var valueObject = (ValueObjectBase)other;

            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return GetEqualityComponents()
                 .Select(x => x != null ? x.GetHashCode() : 0)
                 .Aggregate((x, y) => x ^ y);
        }

        /// <summary>
        /// Determines whether two value objects are equal using the equality operator.
        /// </summary>
        public static bool operator ==(ValueObjectBase left, ValueObjectBase right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
                return true;
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;
            if (ReferenceEquals(left, right))
                return true;

            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two value objects are not equal using the inequality operator.
        /// </summary>
        public static bool operator !=(ValueObjectBase left, ValueObjectBase right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Returns a string representation of the value object.
        /// </summary>
        /// <returns>A string that represents the value object.</returns>
        public override string ToString()
        {
            return string.Join(", ", GetEqualityComponents());
        }
    }

    /// <summary>
    /// Represents a generic base class for value objects, encapsulating a single value with equality logic.
    /// </summary>
    /// <typeparam name="T">The type of the encapsulated value.</typeparam>
    public abstract class ValueObjectBase<T> : ValueObjectBase
    {
        /// <summary>
        /// The encapsulated value.
        /// </summary>
        protected readonly T Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueObjectBase{T}"/> class with the specified value.
        /// </summary>
        /// <param name="value">The value to encapsulate.</param>
        protected ValueObjectBase(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Defines the components that determine the equality of the value object.
        /// </summary>
        /// <returns>An enumerable of objects representing the equality components.</returns>
        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return JsonSerializer.Serialize(Value);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current value object.
        /// Compares only the equality components of the objects, not their references or instances.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object? other)
        {
            if (other == null || other.GetType() != GetType()) return false;

            var valueObject = (ValueObjectBase<T>)other;

            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        /// <summary>
        /// Determines whether two value objects are equal using the equality operator.
        /// </summary>
        public static bool operator ==(ValueObjectBase<T> left, ValueObjectBase<T> right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
                return true;
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;
            if (ReferenceEquals(left, right))
                return true;

            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two value objects are not equal using the inequality operator.
        /// </summary>
        public static bool operator !=(ValueObjectBase<T> left, ValueObjectBase<T> right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return GetEqualityComponents()
                 .Select(x => x != null ? x.GetHashCode() : 0)
                 .Aggregate((x, y) => x ^ y);
        }

        /// <summary>
        /// Returns a string representation of the encapsulated value.
        /// </summary>
        /// <returns>A string that represents the value object.</returns>
        public override string ToString()
        {
            return Value?.ToString() ?? string.Empty;
        }
    }
}
