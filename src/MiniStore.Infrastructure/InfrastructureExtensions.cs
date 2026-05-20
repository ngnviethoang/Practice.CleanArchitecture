using Microsoft.Extensions.DependencyInjection;
using MiniStore.Infrastructure.DateTimes;
using MiniStore.Infrastructure.Guids;

namespace MiniStore.Infrastructure;

public static class InfrastructureExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddInfrastructure()
        {
            services
                .AddDateTimeProvider()
                .AddGuidProvider();
            return services;
        }
    }
}