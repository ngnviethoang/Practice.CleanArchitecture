using Microsoft.Extensions.DependencyInjection;
using WeTicket.Contract.Guids;

namespace WeTicket.Infrastructure.Guids;

public static class GuidProviderExtensions
{
    public static IServiceCollection AddGuidProvider(this IServiceCollection services)
    {
        services.AddSingleton<IGuidProvider, GuidProvider>();
        return services;
    }
}