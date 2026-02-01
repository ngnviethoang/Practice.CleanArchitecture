namespace WeTicket.Domain.Entities;

public interface IFullAuditedObject<TKey>
{
    DateTimeOffset CreationTime { get; set; }

    TKey? CreatorId { get; set; }

    DateTimeOffset? LastModificationTime { get; set; }

    TKey? LastModifierId { get; set; }
}