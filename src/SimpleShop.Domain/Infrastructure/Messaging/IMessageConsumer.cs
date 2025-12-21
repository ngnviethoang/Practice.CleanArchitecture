namespace SimpleShop.Domain.Infrastructure.Messaging;

public interface IMessageConsumer<TData>
{
    Task HandleAsync(Message<TData> message, CancellationToken cancellationToken = default);
}