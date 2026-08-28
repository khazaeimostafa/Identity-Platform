using System.Net.Mail;
using Identity.Domain.Primitives;

namespace Identity.Domain.ValueObjects;

public sealed class EmailAddress : ValueObject
{
    public string Value { get; }
    private EmailAddress(string value) => Value = value;

    public static EmailAddress Create(string value)
    {

        ArgumentException.ThrowIfNullOrEmpty(value);

        value = Normalize(value);
        if (!IsValid(value))
        {
            throw new ArgumentException("Invalid email Address.", nameof(value));
        }

        return new EmailAddress(value);
    }

    private static bool IsValid(string value)
    {
        try
        {
            var address = new MailAddress(value);
            return address.Address == value;
        }
        catch (FormatException)
        {

            return false;
        }
    }

    private static string Normalize(string value) => value.Trim().ToLowerInvariant();

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString()
    {
        return Value;
    }
}