namespace SimpleShop.Domain.Infrastructure.Messaging;

public class OutboxMessage
{
    public string Id { get; set; }

    public string EventType { get; set; }

    public string EventSource { get; set; }

    public string Payload { get; set; }

    public string ActivityId { get; set; }
}