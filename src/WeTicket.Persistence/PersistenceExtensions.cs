using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WeTicket.Domain.Repositories;
using WeTicket.Persistence.Repositories;

namespace WeTicket.Persistence;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
    {
        services
            .AddDbContext<WeTicketDbContext>(options => options.UseSqlServer(connectionString))
            .AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        return services;
    }
}