using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WeTicket.Domain.Repositories;
using WeTicket.Persistence.Repositories;

namespace WeTicket.Persistence;

public static class PersistenceExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddPersistence(string connectionString)
        {
            services
                .AddDbContext<WeTicketDbContext>(options => options.UseSqlServer(connectionString))
                .AddRepositories();
            return services;
        }

        public IServiceCollection AddRepositories()
        {
            services.AddScoped<IAuditLogRepository, AuditLogRepository>();
            services.AddScoped<IShowRepository, ShowRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}