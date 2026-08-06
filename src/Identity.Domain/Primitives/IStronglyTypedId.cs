namespace Identity.Domain.Primitives;

public interface IStronglyTypedId<TValue>
{
    TValue Value { get; }
}