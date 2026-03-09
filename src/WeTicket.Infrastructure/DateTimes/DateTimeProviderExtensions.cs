using Microsoft.Extensions.DependencyInjection;
using WeTicket.Contract.Datetimes;

namespace WeTicket.Infrastructure.DateTimes;

public static class DateTimeProviderExtensions
{
    public static IServiceCollection AddDateTimeProvider(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}