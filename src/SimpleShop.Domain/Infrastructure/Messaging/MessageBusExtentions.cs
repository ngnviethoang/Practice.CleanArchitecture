using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleShop.Domain.Infrastructure.Messaging;

public static class MessageBusExtentions
{
    public static void AddMessageBusConsumers(this IServiceCollection services, Assembly assembly)
    {
        MessageBus.AddConsumers(assembly, services);
    }
}