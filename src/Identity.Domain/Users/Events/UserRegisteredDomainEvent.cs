using Identity.Domain.Primitives;

namespace Identity.Domain.Users.Events;

public sealed record UserRegisteredDomainEvent(UserId UserId, DateTimeOffset OccurredOnUtc) : IDomainEvent;
 