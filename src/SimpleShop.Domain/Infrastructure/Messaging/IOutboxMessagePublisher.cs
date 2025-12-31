namespace SimpleShop.Domain.Infrastructure.Messaging;

public interface IOutboxMessagePublisher
{
    static abstract string[] CanHandleEventTypes();

    static abstract string CanHandleEventSource();

    Task HandleAsync(OutboxMessage message, CancellationToken cancellationToken = default);
}