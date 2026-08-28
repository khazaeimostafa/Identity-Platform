using Identity.Domain.Primitives;
using NUlid;

namespace Identity.Domain.Users;

public readonly record struct UserId : IStronglyTypedId
{
    public Ulid Value { get; }
    public UserId(Ulid value)
    {

        if (value == default)
            throw new ArgumentException(
                "UserId cannot be empty.",
                nameof(value));

        Value = value;
    }

    public static UserId New() => new(Ulid.NewUlid());

    public static UserId From(Ulid value) => new(value);

}
