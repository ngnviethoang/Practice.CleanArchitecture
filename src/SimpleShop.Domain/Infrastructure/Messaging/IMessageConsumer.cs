namespace SimpleShop.Domain.Infrastructure.Messaging;

public interface IMessageConsumer<TConsumer, TData>
{
    Task HandleAsync(Message<TData> message, CancellationToken cancellationToken = default);
}