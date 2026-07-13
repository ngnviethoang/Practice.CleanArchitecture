using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MiniStore.IdentityServer.Pages.Error;

[AllowAnonymous]
[SecurityHeaders]
public class Index : PageModel
{
    private readonly IWebHostEnvironment _environment;
    private readonly IIdentityServerInteractionService _interaction;

    public Index(IIdentityServerInteractionService interaction, IWebHostEnvironment environment)
    {
        _interaction = interaction;
        _environment = environment;
    }

    public ViewModel View { get; set; } = new();

    public async Task OnGetAsync(string? errorId, CancellationToken ct)
    {
        // retrieve error details from IdentityServer
        ErrorMessage? message = await _interaction.GetErrorContextAsync(errorId, ct);
        if (message != null)
        {
            View.Error = message;

            if (!_environment.IsDevelopment())
            {
                // only show in development
                message.ErrorDescription = null;
            }
        }
    }
}