using MiniStore.Domain.Entities.Abstracts;

namespace MiniStore.Domain.Entities;

public class UserClaim : Entity<Guid>
{
    public Guid UserId { get; set; }

    public string ClaimType { get; set; }

    public string ClaimValue { get; set; }
}