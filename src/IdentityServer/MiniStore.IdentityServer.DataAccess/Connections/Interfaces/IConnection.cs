using System.Data;

namespace MiniStore.IdentityServer.DataAccess.Connections.Interfaces;

public interface IConnection
{
    Task<IDbConnection> OpenAsync();

    Task<List<T>> QueryAsync<T>(string sql, object sqlParams);

    Task<int> ExecuteAsync(string sql, object sqlParams);

    Task<T?> ExecuteScalarAsync<T>(string sql, object sqlParams);

    Task<List<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(
        string sql,
        Func<TFirst, TSecond, TReturn> map,
        string splitOn,
        object? sqlParams = null);

    Task<List<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(
        string sql,
        Func<TFirst, TSecond, TThird, TReturn> map,
        string splitOn,
        object? sqlParams = null);

    Task<List<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(
        string sql,
        Func<TFirst, TSecond, TThird, TFourth, TReturn> map,
        string splitOn,
        object? sqlParams = null);
}