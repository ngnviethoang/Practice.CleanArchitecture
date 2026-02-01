namespace WeTicket.Domain.Entities;

public class OutboxMessage : Entity<Guid>
{
    public string EventType { get; set; }

    public Guid TriggeredById { get; set; }

    public string ObjectId { get; set; }

    public string Payload { get; set; }

    public bool IsPublished { get; set; }

    public string ActivityId { get; set; }
}