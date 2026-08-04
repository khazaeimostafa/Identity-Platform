using Identity.Domain.Primitives;

namespace Identity.Domain.ValueObjects;

public sealed class EmailAddress : ValueObject
{
    public string Value { get; }
    private EmailAddress(string value) => Value = value;

    public static EmailAddress Create(string value)
    {
        value = Normalize(value);
        Validate(value);

        return new EmailAddress(value);
    }

    private static void Validate(string value)
    {
    }

    private static string Normalize(string value)
    => value.Trim().ToLowerInvariant();

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}