using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MiniStore.IdentityServer.Contracts.Configurations;
using MiniStore.IdentityServer.DataAccess.Connections.Interfaces;

namespace MiniStore.IdentityServer.DataAccess.Connections;

public class ConnectionFactory : IConnectionFactory
{
    private readonly IConfiguration _configuration;

    public ConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public IConnection CreateDatabaseConnection(string database, ILogger logger)
    {
        ConnectionOption options = new()
        {
            ConnectionString = _configuration.GetValue<string>($"{database}:ConnectionString") ?? throw new InvalidOperationException($"Connection string) for database '{database}' is not configured."),
            CommandTimeout = _configuration.GetValue<int>($"{database}:CommandTimeout")
        };
        return new Connection(options, logger);
    }

    public IConnection CreateReadonlyDatabaseConnection(string database, ILogger logger)
    {
        ConnectionOption options = new()
        {
            ConnectionString = _configuration.GetValue<string>($"{database}:ConnectionStringReadonly") ?? throw new InvalidOperationException($"Connection string) for database '{database}' is not configured."),
            CommandTimeout = _configuration.GetValue<int>($"{database}:CommandTimeout")
        };

        return new Connection(options, logger);
    }
}