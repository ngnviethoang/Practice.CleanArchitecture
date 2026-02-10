namespace WeTicket.Contract.Tenants;

public interface ITenantProvider
{
    Tenant Tenant { get; }
}