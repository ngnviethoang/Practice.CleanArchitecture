using System.Buffers.Text;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;

namespace MiniStore.IdentityServer.Pages.Diagnostics;

public class ViewModel
{
    public ViewModel(AuthenticateResult result)
    {
        AuthenticateResult = result;

        if (result?.Properties?.Items.TryGetValue("client_list", out string? encoded) == true)
        {
            if (encoded != null)
            {
                byte[] bytes = Base64Url.DecodeFromChars(encoded);
                string value = Encoding.UTF8.GetString(bytes);
                Clients = JsonSerializer.Deserialize<string[]>(value) ?? Enumerable.Empty<string>();
                return;
            }
        }

        Clients = Enumerable.Empty<string>();
    }

    public AuthenticateResult AuthenticateResult { get; }
    public IEnumerable<string> Clients { get; }
}