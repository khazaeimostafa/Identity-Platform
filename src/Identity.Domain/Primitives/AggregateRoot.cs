namespace Identity.Domain.Primitives;

public abstract class AggregateRoot<TId> : Entity<TId> where TId : IStronglyTypedId
{

    private readonly List<IDomainEvent> _domainEvents = new();

    protected AggregateRoot(TId id) : base(id) { }

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;


    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        ArgumentNullException.ThrowIfNull(domainEvent);

        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}



/// بیرون Aggregate نمی‌توانیم Entityهای داخلی را آزادانه تغییر دهیم.
/// 
/// Aggregate Root تصمیم می‌گیرد، Entity تخصص خودش را انجام می‌دهد
///  
////
///  چرا AggregateRoot<TId> از Entity<TId> ارث‌بری می‌کند؟
///
///از دید DDD هر Aggregate Root یک Entity است، ولی هر Entity لزوماً Aggregate Root نیست.
///Aggregate Root مرز ورود به Aggregate است.
/// 
////چرا abstract
///چون این کلاس یک Base Class است.
///هدفش این است که ویژگی‌های مشترک Aggregateها را فراهم کند.
///
///چرا Generic است؟
///چون Aggregateهای مختلف ممکن است IDهای مختلف داشته باشند.
///
///چرا Event داخل Aggregate نگهداری می‌شود؟
///چرا همان لحظه Publish نکنیم؟
///این کار در Domain Layer مشکل ایجاد می‌کند.
///چون Domain نباید به Infrastructure وابسته باشد.
///
///چرا _domainEvents خصوصی است؟
///عمداً بیرون کلاس قابل دستکاری نیست.
///
/// Aggregate باید خودش مالک Eventهایش باشد.
/// اصل  Encapsulation
/// 
/// چرا List<IDomainEvent>?
/// 
/// List
///چون ممکن است چند Event داشته باشیم
///
/// 
/// دوم: ?
///یعنی Collection از ابتدا ساخته نمی‌شود.
///
///چرا protected؟
///چون فقط کلاس‌های Derived باید بتوانند AggregateRoot را بسازند.
///
/// RaiseDomainEvent  چرا protected است؟
/// چون فقط خود Aggregate یا کلاس‌های فرزندش باید بتوانند Event ایجاد کنند.
/// 
/// Event نباید null باشد.
/// 
/// 
/// ClearDomainEvents ? 
/// بعد از اینکه Eventها پردازش شدند، دیگر نباید دوباره همان Eventها Dispatch شوند.
///  
/// Domain Event می‌گوید داخل Domain چه اتفاقی افتاد؟
/// 
/// Integration Event  :برای ارتباط بین سرویس‌هاست:
/// 
/// چرا DomainEvents باید متعلق به Aggregate Root باشد؟
/// چون Event باید در مرز Aggregate مدیریت شود.
/// 
/// اگر OrderItem تغییر کند و این تغییر از نظر Domain مهم باشد، بهتر است Aggregate Root یعنی Order کنترل کند که چه Eventی تولید شود.
/// public void AddItem(ProductId productId, int quantity)
//{
//    // invariant checks

//    _items.Add(...);

//    RaiseDomainEvent(
//        new OrderItemAddedDomainEvent(Id, productId)
//    );
//}
///
/// Aggregate Root فقط یک Container برای Entityها نیست.
/// لکه مسئول حفظ: Invariant های Aggregate است.
/// 
/// 
/////                  Aggregate Root
//                       │
//             ┌─────────┴─────────┐
//             │                   │
//           State Behavior
//             │                   │
//             │              Domain Rules
//             │                   │
//             │              Invariant Check
//             │                   │
//             └─────────┬─────────┘
//                       │
//                State Changes
//                       │
//                       ↓
//                RaiseDomainEvent
//                       │
//                       ↓
//                DomainEvents[]
//                       │
//                       ↓
//              Application/Infra
//                       │
//                       ↓
//               Dispatch / Outbox
//                       │
//                       ↓
//             External Side Effects
/// 
///




//AggregateRoot تعیین مرز Aggregate
//Entity < TId > هویت Entity
//IStronglyTypedId    جلوگیری از اشتباه IDها
//private _domainEvents Encapsulation
//IReadOnlyCollection جلوگیری از Mutation بیرونی
//RaiseDomainEvent    کنترل تولید Event توسط Aggregate
//protected محدود کردن تغییرات به خود Aggregate
//ThrowIfNull حفظ قرارداد
//??= Lazy Allocation
//ClearDomainEvents   جلوگیری از Dispatch مجدد