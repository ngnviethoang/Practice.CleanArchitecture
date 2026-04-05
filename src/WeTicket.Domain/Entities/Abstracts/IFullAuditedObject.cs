namespace WeTicket.Domain.Entities.Abstracts;

public interface IFullAuditedObject<TKey> : ISoftDelete
{
    DateTimeOffset CreationTime { get; set; }

    TKey? CreatorId { get; set; }

    DateTimeOffset? LastModificationTime { get; set; }

    TKey? LastModifierId { get; set; }
}