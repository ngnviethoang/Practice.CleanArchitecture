using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace WeTicket.Application;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(AssemblyReference.Assembly);
        return services;
    }
}