namespace WeTicket.Domain.Entities;

public class UserClaim : Entity<Guid>
{
    public Guid UserId { get; set; }

    public string ClaimType { get; set; }

    public string ClaimValue { get; set; }

    public User User { get; set; }
}