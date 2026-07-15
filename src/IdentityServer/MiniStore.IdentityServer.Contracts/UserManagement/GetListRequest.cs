namespace MiniStore.IdentityServer.Contracts.UserManagement;

public class GetListRequest
{
    public string Username { get; set; }

    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}