using Microsoft.Extensions.Logging;

namespace MiniStore.IdentityServer.DataAccess.Connections.Interfaces;

public interface IConnectionFactory
{
    IConnection CreateDatabaseConnection(string database, ILogger logger);

    IConnection CreateReadonlyDatabaseConnection(string database, ILogger logger);
}