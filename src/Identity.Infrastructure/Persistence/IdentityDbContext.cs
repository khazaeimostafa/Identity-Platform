using System.Security.Cryptography.X509Certificates;
using Identity.Domain.Users;
using Identity.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Persistence;

public class IdentityDbContext : IdentityDbContext<ApplicationIdentityUser, IdentityRole<UserId>, UserId>
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<ApplicationIdentityUser>()
        .Property(x => x.Id)
        .HasConversion(userId => userId.Value,
        value => new UserId(value));
    }

}