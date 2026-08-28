using Identity.Domain.Primitives;
using Identity.Domain.Users.Credentials;

namespace Identity.Domain.Users;
///
/// Business Rule باید داخل Domain محافظت شود.
/// Aggregate Root تصمیم می‌گیرد، Entity تخصص خودش را انجام می‌دهد
/// 
/// 
public sealed class User : AggregateRoot<UserId>
{


    public User(UserId id) : base(id)
    {

    }


    private readonly List<Credential> _credentials = [];
    public IReadOnlyCollection<Credential> Credentials
    => _credentials;

    public static User Register()
    {
        throw new NotImplementedException();
    }
}