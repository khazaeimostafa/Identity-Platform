namespace Identity.Domain.Primitives;

public abstract class ValueObject
{
    protected abstract IEnumerable<Object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {

        if (obj is null || obj.GetType() != GetType()) return false;

        var other = (ValueObject)obj;
        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        foreach (var component in GetEqualityComponents())
        {
            hash.Add(component);
        }
        return hash.ToHashCode();
    }
    public static bool operator ==(ValueObject? left , ValueObject? right) => Equals(left,right);
    public static bool operator !=(ValueObject? left , ValueObject? right) => !Equals(left,right);
}


 
 
// Value Object:

// Identity مستقل ندارد.
// بر اساس Value مقایسه می‌شود.
// معمولاً Immutable است.
// باید وضعیت معتبر داشته باشد.

// نمونه‌ها:   EmailAddress  PhoneNumber  UserName  Password

///
/// record مزایای زیادی دارد: Value Equality Immutability Hashing
/// 
/// 
/// Benefits  of  Base  class  :
/// کنترل Equality دست خودمان است.
// Behavior مشترک می‌توانیم داشته باشیم.
// Foundation را صریح‌تر می‌بینیم.
// در این مرحله می‌خواهیم semantics را کاملاً درک و کنترل کنیم.


// چرا Value Object باید Immutable باشد؟
//   اگر  mutable  باشد   ممکن است Objectی که در جاهای مختلف استفاده شده ناگهان تغییر کند 


///
/// محل Value Objectها : 
/// برای Value Objectهای عمومی‌تر Domain
/// Identity.Domain/
/// └── ValueObjects/
/// ممکن است توسط چند Aggregate داخل همین Identity Domain استفاده شوند
/// 
/// 