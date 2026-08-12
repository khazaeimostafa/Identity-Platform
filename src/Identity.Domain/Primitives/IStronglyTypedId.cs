namespace Identity.Domain.Primitives;

public interface IStronglyTypedId { }

public interface IStronglyTypedId<TValue> : IStronglyTypedId
{
    TValue Value { get; protected init; }
}