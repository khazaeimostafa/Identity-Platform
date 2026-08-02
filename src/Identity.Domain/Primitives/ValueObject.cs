namespace Identity.Domain.Primitives;

public abstract  class ValueObject
{
    protected abstract IEnumerable<Object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {

        if(obj is null || obj.GetType() != GetType()) return false;

         var other =  (ValueObject)obj;
        return  GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents().Aggregate(0,(hash, obj)=>   HashCode.Combine(hash,obj));
    }
}