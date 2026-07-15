using Dapper;
using Microsoft.Extensions.Logging;
using MiniStore.IdentityServer.Contracts.UserManagement;
using MiniStore.IdentityServer.DataAccess.Connections.Interfaces;
using MiniStore.IdentityServer.DataAccess.UserManagement.Interfaces;
using MiniStore.IdentityServer.DataAccess.UserManagement.Models;

namespace MiniStore.IdentityServer.DataAccess.UserManagement;

public class UserRepository : IUserRepository
{
    private const string _identityServerDatabase = "IdentityServer";
    private readonly IConnection _connection;
    private readonly IConnection _readonlyConnection;

    public UserRepository(IConnectionFactory connectionFactory, ILogger<UserRepository> logger)
    {
        _connection = connectionFactory.CreateDatabaseConnection(_identityServerDatabase, logger);
        _readonlyConnection = connectionFactory.CreateReadonlyDatabaseConnection(_identityServerDatabase, logger);
    }

    public async Task<IEnumerable<UserDTO>> GetListAsync(GetListRequest request)
    {
        SqlBuilder builder = new();
        string sql = @"SELECT * FROM users";
        SqlBuilder.Template template = builder.AddTemplate(sql);
        return await _readonlyConnection.QueryAsync<UserDTO>(template.RawSql, template.Parameters);
    }

    public async Task<int> CreateUserAsync(CreateUserRequest request)
    {
        SqlBuilder builder = new();
        string sql = @"INSERT INTO users (username, email, password) VALUES (@Username, @Email, @Password)";
        SqlBuilder.Template template = builder.AddTemplate(sql);
        return await _connection.ExecuteAsync(template.RawSql, template.Parameters);
    }
}