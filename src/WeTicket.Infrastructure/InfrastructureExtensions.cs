using Microsoft.Extensions.DependencyInjection;
using WeTicket.Infrastructure.DateTimes;
using WeTicket.Infrastructure.Guids;

namespace WeTicket.Infrastructure;

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