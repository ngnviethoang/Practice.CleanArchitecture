namespace SimpleShop.Domain.Infrastructure.Messaging;

public interface IMessageBus
{
    Task SendAsync<TData>(Message<TData> message, CancellationToken cancellationToken = default);

    Task SendAsync(OutboxMessage message, CancellationToken cancellationToken = default);

    Task ReceiveAsync<TConsumer, TData>(CancellationToken cancellationToken = default);

    Task ReceiveAsync<TConsumer, TData>(Func<Message<TData>, CancellationToken, Task> action, CancellationToken cancellationToken = default);
}