using System.Runtime.InteropServices;
using Identity.Domain.Primitives;
using Identity.Domain.Users.Events;

namespace Identity.Domain.Users;
///
/// Business Rule باید داخل Domain محافظت شود.
/// Aggregate Root تصمیم می‌گیرد، Entity تخصص خودش را انجام می‌دهد
/// 
/// 
public sealed class User : AggregateRoot<UserId>
{
    public User(UserId id) : base(id) { }

    public static User Register(UserId id)
    {
        var user = new User(id);
        user.AddDomainEvent(new UserRegisteredDomainEvent(user.Id, DateTimeOffset.UtcNow));

        return user;
    }
}