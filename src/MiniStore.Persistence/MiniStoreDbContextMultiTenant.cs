using Microsoft.EntityFrameworkCore;
using MiniStore.Contract.Tenants;
using MiniStore.Domain.Identity;

namespace MiniStore.Persistence;

public class MiniStoreDbContextMultiTenant : MiniStoreDbContext
{
    private readonly ITenantProvider _tenantProvider;

    public MiniStoreDbContextMultiTenant(ITenantProvider tenantProvider, ICurrentUser currentUser, DbContextOptions<MiniStoreDbContext> options) : base(options, currentUser)
    {
        _tenantProvider = tenantProvider;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_tenantProvider.Tenant.ConnectionString);
    }
}