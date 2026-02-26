namespace WeTicket.Domain.Entities;

public class UserRole : Entity<Guid>
{
    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }
}