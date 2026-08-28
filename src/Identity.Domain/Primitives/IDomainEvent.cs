namespace Identity.Domain.Primitives;
///
/// Domain Event نباید Aggregate کامل حمل کند
/// 
/// Event یک Fact است.
/// 
/// Outbox کمک می‌کند تغییر Domain و ثبت پیام برای انتشار، به شکل قابل اتکاتری هماهنگ شوند.
/// 
/// 
public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}