using Microsoft.EntityFrameworkCore;
using WeTicket.Contract.Tenants;
using WeTicket.Domain.Identity;

namespace WeTicket.Persistence;

public class WeTicketDbContextMultiTenant : WeTicketDbContext
{
    private readonly ITenantProvider _tenantProvider;

    public WeTicketDbContextMultiTenant(ITenantProvider tenantProvider, ICurrentUser currentUser, DbContextOptions<WeTicketDbContext> options) : base(options, currentUser)
    {
        _tenantProvider = tenantProvider;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_tenantProvider.Tenant.ConnectionString);
    }
}