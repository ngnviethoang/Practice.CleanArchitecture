using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MiniStore.Domain.Repositories;
using MiniStore.Persistence.Repositories;

namespace MiniStore.Persistence;

public static class PersistenceExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddPersistence(string connectionString)
        {
            services
                .AddDbContext<MiniStoreDbContext>(options => options.UseSqlServer(connectionString))
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