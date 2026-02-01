namespace WeTicket.Domain.Infrastructure.Messaging;

public class MetaData
{
    public string MessageId { get; set; }

    public string MessageVersion { get; set; }

    public string ActivityId { get; set; }

    public DateTimeOffset? CreationTime { get; set; }

    public DateTimeOffset? EnqueuedTime { get; set; }
}