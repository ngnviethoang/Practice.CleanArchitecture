namespace MiniStore.IdentityServer.Contracts.Configurations;

public class ConnectionOption
{
    public string ConnectionString { get; set; }

    public int CommandTimeout { get; set; }
}