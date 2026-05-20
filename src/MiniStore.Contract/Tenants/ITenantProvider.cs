namespace MiniStore.Contract.Tenants;

public interface ITenantProvider
{
    Tenant Tenant { get; }
}