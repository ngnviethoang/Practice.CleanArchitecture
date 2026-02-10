using Microsoft.EntityFrameworkCore;
using WeTicket.Contract.Tenants;

namespace WeTicket.Persistence;

public class WeTicketDbContextMultiTenant : WeTicketDbContext
{
    private readonly ITenantProvider _tenantProvider;

    public WeTicketDbContextMultiTenant(ITenantProvider tenantProvider, DbContextOptions<WeTicketDbContext> options) : base(options)
    {
        _tenantProvider = tenantProvider;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_tenantProvider.Tenant.ConnectionString);
    }
}