namespace WeTicket.Domain.Entities;

public class RoleClaim : Entity<Guid>
{
    public Guid RoleId { get; set; }

    public string ClaimType { get; set; }

    public string ClaimValue { get; set; }

    public Role Role { get; set; }
}