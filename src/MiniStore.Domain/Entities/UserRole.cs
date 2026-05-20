using MiniStore.Domain.Entities.Abstracts;

namespace MiniStore.Domain.Entities;

public class UserRole : Entity<Guid>
{
    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }
}