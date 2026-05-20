using Microsoft.Extensions.DependencyInjection;
using MiniStore.Contract.Datetimes;

namespace MiniStore.Infrastructure.DateTimes;

public static class DateTimeProviderExtensions
{
    public static IServiceCollection AddDateTimeProvider(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}