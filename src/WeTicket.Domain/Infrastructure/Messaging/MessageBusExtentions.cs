using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace WeTicket.Domain.Infrastructure.Messaging;

public static class MessageBusExtensions
{
    public static void AddMessageBusConsumers(this IServiceCollection services, Assembly assembly)
    {
        MessageBus.AddConsumers(assembly, services);
    }

    public static void AddOutboxMessagePublishers(this IServiceCollection services, Assembly assembly)
    {
        MessageBus.AddOutboxMessagePublishers(assembly, services);
    }

    public static void AddMessageBus(this IServiceCollection services, Assembly assembly)
    {
        services.AddTransient<IMessageBus, MessageBus>();
        services.AddMessageBusConsumers(assembly);
        services.AddOutboxMessagePublishers(assembly);
    }
}