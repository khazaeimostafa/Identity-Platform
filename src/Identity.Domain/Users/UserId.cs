using Identity.Domain.Primitives;
using NUlid;

namespace Identity.Domain.Users;

public readonly record struct UserId : IStronglyTypedId<Ulid>
{
    public Ulid Value { get; init; }
    public UserId(Ulid value)
    {
        this.Value = value;
    }

    public static UserId New => new(Ulid.NewUlid());
    public static UserId From(Ulid value) => new(value);

}
