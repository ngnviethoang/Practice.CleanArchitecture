namespace SimpleShop.Domain.Entities;

public class AuditLog : Entity<Guid>
{
    public Guid UserId { get; set; }

    public string Action { get; set; }

    public string ObjectId { get; set; }

    public string Log { get; set; }
}