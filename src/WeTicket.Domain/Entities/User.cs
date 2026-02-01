namespace WeTicket.Domain.Entities;

public class User : Entity<Guid>
{
    public string UserName { get; set; }

    public string NormalizedUserName { get; set; }

    public string Email { get; set; }

    public string NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string PasswordHash { get; set; }

    public string SecurityStamp { get; set; }

    public string ConcurrencyStamp { get; set; }

    public string PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTimeOffset LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public List<UserClaim> UserClaims { get; set; }

    public List<UserLogin> UserLogins { get; set; }

    public List<UserToken> UserTokens { get; set; }

    public List<Role> Roles { get; set; }
}