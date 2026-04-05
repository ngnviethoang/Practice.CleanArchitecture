using System.ComponentModel.DataAnnotations;

namespace WeTicket.Domain.Entities.Abstracts;

public abstract class Entity<TKey> : IHasKey<TKey>, IFullAuditedObject<TKey>, IHasRowVersion
{
    public TKey Id { get; set; }

    public DateTimeOffset CreationTime { get; set; }

    public TKey? CreatorId { get; set; }

    public DateTimeOffset? LastModificationTime { get; set; }

    public TKey? LastModifierId { get; set; }

    public bool IsDeleted { get; set; }

    [ConcurrencyCheck]
    public Guid RowVersion { get; set; }
}