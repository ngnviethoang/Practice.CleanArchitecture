using Microsoft.Extensions.Logging;
using MiniStore.IdentityServer.Contracts.UserManagement;
using MiniStore.IdentityServer.DataAccess.Connections.Interfaces;
using MiniStore.IdentityServer.DataAccess.UserManagement;
using MiniStore.IdentityServer.DataAccess.UserManagement.Models;
using Moq;
using Xunit;

namespace MiniStore.IdentityServer.DataAccess.UnitTests.Repositories;

public class UserRepositoryTests
{
    private readonly Mock<IConnectionFactory> _connectionFactoryMock = new();
    private readonly Mock<IConnection> _connectionMock = new();
    private readonly Mock<ILogger<UserRepository>> _loggerMock = new();
    private readonly Mock<IConnection> _readonlyConnectionMock = new();

    private readonly UserRepository _repository;

    public UserRepositoryTests()
    {
        _connectionFactoryMock
            .Setup(x => x.CreateDatabaseConnection(It.IsAny<string>(), It.IsAny<ILogger>()))
            .Returns(_connectionMock.Object);

        _connectionFactoryMock
            .Setup(x => x.CreateReadonlyDatabaseConnection(It.IsAny<string>(), It.IsAny<ILogger>()))
            .Returns(_readonlyConnectionMock.Object);

        _repository = new UserRepository(
            _connectionFactoryMock.Object,
            _loggerMock.Object);
    }

    [Fact]
    public async Task GetListAsyncShouldReturnUsers()
    {
        List<UserDTO> expected = new()
        {
            new UserDTO
            {
                Username = "john",
                Email = "john@test.com"
            }
        };

        _readonlyConnectionMock
            .Setup(x => x.QueryAsync<UserDTO>(It.IsAny<string>(), It.IsAny<object?>()))
            .ReturnsAsync(expected);

        IEnumerable<UserDTO> result = await _repository.GetListAsync(new GetListRequest());

        Assert.Single(result);
        Assert.Equal("john", result.First().Username);

        _readonlyConnectionMock.Verify(x => x.QueryAsync<UserDTO>(It.IsAny<string>(), It.IsAny<object?>()), Times.Once);

        _connectionFactoryMock.Verify(x => x.CreateReadonlyDatabaseConnection("IdentityServer", It.IsAny<ILogger>()), Times.Once);
    }

    [Fact]
    public async Task CreateUserAsyncShouldExecuteInsert()
    {
        CreateUserRequest request = new()
        {
            Username = "john",
            Email = "john@test.com",
            Password = "123"
        };

        _connectionMock
            .Setup(x => x.ExecuteAsync(It.IsAny<string>(), It.IsAny<object?>()))
            .ReturnsAsync(1);

        int result = await _repository.CreateUserAsync(request);

        Assert.Equal(1, result);

        _connectionMock.Verify(x => x.ExecuteAsync(It.Is<string>(sql => sql.Contains("INSERT INTO users")), It.IsAny<object?>()), Times.Once);
        _connectionFactoryMock.Verify(x => x.CreateDatabaseConnection("IdentityServer", It.IsAny<ILogger>()), Times.Once);
    }
}