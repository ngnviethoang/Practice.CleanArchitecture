using Microsoft.Extensions.DependencyInjection;
using MiniStore.Contract.Guids;

namespace MiniStore.Infrastructure.Guids;

public static class GuidProviderExtensions
{
    public static IServiceCollection AddGuidProvider(this IServiceCollection services)
    {
        services.AddSingleton<IGuidProvider, GuidProvider>();
        return services;
    }
}