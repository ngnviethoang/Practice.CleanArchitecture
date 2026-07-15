using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MiniStore.IdentityServer.DataAccess.Connections;
using MiniStore.IdentityServer.DataAccess.Connections.Interfaces;
using Moq;
using Xunit;

namespace MiniStore.IdentityServer.DataAccess.UnitTests.Connections;

public class ConnectionFactoryTests
{
    private readonly Mock<IConfiguration> _configuration = new();
    private readonly Mock<ILogger> _logger = new();

    [Fact]
    public void CreateDatabaseConnectionShouldCreateConnection()
    {
        _configuration
            .Setup(x => x.GetSection("IdentityServer:ConnectionString").Value)
            .Returns("Host=localhost;Database=IdentityServer;");

        _configuration
            .Setup(x => x.GetSection("IdentityServer:CommandTimeout").Value)
            .Returns("30");

        ConnectionFactory factory = new(_configuration.Object);

        IConnection connection = factory.CreateDatabaseConnection("IdentityServer", _logger.Object);

        Assert.NotNull(connection);
    }

    [Fact]
    public void CreateReadonlyDatabaseConnectionShouldCreateConnection()
    {
        _configuration
            .Setup(x => x.GetSection("IdentityServer:ConnectionStringReadonly").Value)
            .Returns("Host=localhost;Database=IdentityServer;");

        _configuration
            .Setup(x => x.GetSection("IdentityServer:CommandTimeout").Value)
            .Returns("30");

        ConnectionFactory factory = new(_configuration.Object);

        IConnection connection = factory.CreateReadonlyDatabaseConnection("IdentityServer", _logger.Object);

        Assert.NotNull(connection);
    }

    [Fact]
    public void CreateDatabaseConnectionShouldThrowWhenConnectionStringMissing()
    {
        _configuration
            .Setup(x => x.GetSection("IdentityServer:ConnectionString").Value)
            .Returns((string?)null);

        ConnectionFactory factory = new(_configuration.Object);

        Assert.Throws<InvalidOperationException>(() => factory.CreateDatabaseConnection("IdentityServer", _logger.Object));
    }

    [Fact]
    public void CreateReadonlyDatabaseConnectionShouldThrowWhenConnectionStringMissing()
    {
        _configuration
            .Setup(x => x.GetSection("IdentityServer:ConnectionStringReadonly").Value)
            .Returns((string?)null);

        ConnectionFactory factory = new(_configuration.Object);

        Assert.Throws<InvalidOperationException>(() => factory.CreateReadonlyDatabaseConnection("IdentityServer", _logger.Object));
    }
}