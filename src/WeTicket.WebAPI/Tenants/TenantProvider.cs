using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using WeTicket.Contract.Tenants;
using WeTicket.WebAPI.ConfigurationOptions;

namespace WeTicket.WebAPI.Tenants;

public class TenantProvider : ITenantProvider
{
    private const string _tenantHeaderName = "X-Tenant";
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IDictionary<string, string> _connectionStrings;

    public TenantProvider(
        IHttpContextAccessor httpContextAccessor,
        IOptionsSnapshot<AppSettings> appSettings)
    {
        _httpContextAccessor = httpContextAccessor;
        _connectionStrings = appSettings.Value.ConnectionStrings;
    }

    public Tenant Tenant
    {
        get
        {
            HttpContext context = _httpContextAccessor.HttpContext ?? throw new InvalidOperationException("No active HttpContext.");
            if (!context.Request.Headers.TryGetValue(_tenantHeaderName, out StringValues tenantHeader) || StringValues.IsNullOrEmpty(tenantHeader))
            {
                throw new InvalidOperationException("Tenant header is missing.");
            }

            string tenantName = tenantHeader.ToString();
            if (!_connectionStrings.TryGetValue(tenantName, out string? connectionString) || string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException($"Invalid tenant '{tenantName}'.");
            }

            return new Tenant
            {
                Name = tenantName,
                ConnectionString = connectionString
            };
        }
    }
}