using System.Reflection;
using Duende.IdentityServer.Hosting;
using Duende.IdentityServer.Licensing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MiniStore.IdentityServer.Pages;

[AllowAnonymous]
public class Index : PageModel
{
    public Index(LicenseInformation? license = null)
    {
        License = license;
    }

    public string Version => typeof(IdentityServerMiddleware).Assembly
                                 .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                                 ?.InformationalVersion.Split('+').First()
                             ?? "unavailable";

    public LicenseInformation? License { get; }
}