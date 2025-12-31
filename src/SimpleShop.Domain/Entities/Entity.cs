using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Domain.Entities;

public abstract class Entity<TKey> : IHasKey<TKey>, IFullAuditedObject<TKey>, IHasRowVersion
{
    public TKey Id { get; set; } = default!;
    
    public DateTimeOffset CreationTime { get; set; }

    public TKey? CreatorId { get; set; }

    public DateTimeOffset? LastModificationTime { get; set; }

    public TKey? LastModifierId { get; set; }

    [ConcurrencyCheck]
    public Guid RowVersion { get; set; }
}