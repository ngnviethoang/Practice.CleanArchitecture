namespace SimpleShop.Domain.Infrastructure.Messaging;

public interface IMessageSender<TData>
{
    Task SendAsync(Message<TData> message, CancellationToken cancellationToken = default);
}