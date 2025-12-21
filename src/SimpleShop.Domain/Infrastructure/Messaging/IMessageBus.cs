namespace SimpleShop.Domain.Infrastructure.Messaging;

public interface IMessageBus
{
    Task SendAsync<TData>(Message<TData> message, CancellationToken cancellationToken = default);

    Task ReceiveAsync<TData>(CancellationToken cancellationToken = default);

    Task ReceiveAsync<TData>(Func<Message<TData>, CancellationToken, Task> action, CancellationToken cancellationToken = default);
}