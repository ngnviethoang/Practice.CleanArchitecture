namespace WeTicket.Domain.Entities;

public class Role : Entity<Guid>
{
    public string Name { get; set; }

    public string NormalizedName { get; set; }

    public string ConcurrencyStamp { get; set; }

    public List<RoleClaim> RoleClaims { get; set; }

    public List<User> Users { get; set; }
}