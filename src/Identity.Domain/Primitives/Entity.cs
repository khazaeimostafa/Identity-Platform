namespace Identity.Domain.Primitives;
///
/// Entity با Identity شناخته می‌شود، نه State.
/// Entity را record نمی‌کنیم.
/// record در C# به‌صورت پیش‌فرض Value-based equality دارد.
/// اما equality یک record بر اساس value/state می‌تواند نتیجه متفاوتی بدهد.
/// این‌که می‌گوییم: 
/// Entity را record نمی‌کنیم
// یک Rule مطلق C# نیست؛ بلکه یک قاعده طراحی DDD


public abstract class Entity<TId> : IEquatable<Entity<TId>> where TId : IStronglyTypedId
{

    public TId Id { get; protected init; }

    protected Entity(TId id)
    {
        Id = id;
    }

    public bool Equals(Entity<TId>? other)
    {
        if (other is null) return false;

        if (ReferenceEquals(this, other)) return true;

     if (GetType() != other.GetType()) return false;

        return Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Entity<TId>);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right) => Equals(left, right);
    public static bool operator !=(Entity<TId>? left, Entity<TId>? right) => !Equals(left , right);

}