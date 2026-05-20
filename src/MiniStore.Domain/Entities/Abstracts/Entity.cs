using System.ComponentModel.DataAnnotations;

namespace MiniStore.Domain.Entities.Abstracts;

public abstract class Entity<TKey> : IHasKey<TKey>, IFullAuditedObject<TKey>, IHasRowVersion
{
    public DateTimeOffset CreationTime { get; set; }

    public TKey? CreatorId { get; set; }

    public DateTimeOffset? LastModificationTime { get; set; }

    public TKey? LastModifierId { get; set; }

    public bool IsDeleted { get; set; }
    public TKey Id { get; set; }

    [ConcurrencyCheck]
    public Guid RowVersion { get; set; }
}