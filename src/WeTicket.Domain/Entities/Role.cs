namespace WeTicket.Domain.Entities;

public class Role : Entity<Guid>
{
    public string Name { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
}