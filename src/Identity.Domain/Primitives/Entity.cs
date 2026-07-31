namespace Identity.Domain.Primitives;

public class Entity<TId> : IEquatable<Entity<TId>> where TId : notnull
{

    public TId Id { get; }
    
    
    public bool Equals(Entity<TId>? other)
    {
        if (other is null)   
         return false;
         if (ReferenceEquals(this,other)) return true;
         return Id.Equals(other.Id);
    }
}