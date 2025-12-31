namespace SimpleShop.Domain.Infrastructure.Messaging;

public interface IMessageReceiver<TConsumer, TData>
{
    Task ReceiveAsync(CancellationToken cancellationToken = default);

    Task ReceiveAsync(Func<Message<TData>, CancellationToken, Task> action, CancellationToken cancellationToken = default);
}