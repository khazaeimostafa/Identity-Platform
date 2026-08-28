namespace Identity.Domain.Primitives;
/// بیرون Aggregate نمی‌توانیم Entityهای داخلی را آزادانه تغییر دهیم.
/// 
/// Aggregate Root تصمیم می‌گیرد، Entity تخصص خودش را انجام می‌دهد
/// 
/// 
/// 
/// 
/// 
public abstract class AggregateRoot<TId> : Entity<TId> where TId : IStronglyTypedId
{

    protected AggregateRoot(TId id) : base(id) { }


    private readonly List<IDomainEvent> _domainEvents = new();


    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();


    protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    
    public void ClearDomainEvents() => _domainEvents.Clear();
}