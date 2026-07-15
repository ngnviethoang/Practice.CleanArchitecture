using System.Data;
using System.Diagnostics;
using Dapper;
using Microsoft.Extensions.Logging;
using MiniStore.IdentityServer.Contracts.Configurations;
using MiniStore.IdentityServer.DataAccess.Connections.Interfaces;
using Npgsql;

namespace MiniStore.IdentityServer.DataAccess.Connections;

public class Connection : IConnection
{
    private readonly ConnectionOption _connectionOption;
    private readonly ILogger _logger;

    public Connection(ConnectionOption connectionOption, ILogger logger)
    {
        _connectionOption = connectionOption;
        _logger = logger;
    }

    public async Task<IDbConnection> OpenAsync()
    {
        NpgsqlConnection connection = new(_connectionOption.ConnectionString);
        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        return connection;
    }

    public async Task<List<T>> QueryAsync<T>(string sql, object sqlParams)
    {
        using IDbConnection connection = await OpenAsync();
        IEnumerable<T> result = await connection.QueryAsync<T>(sql, commandType: CommandType.Text, commandTimeout: _connectionOption.CommandTimeout, param: sqlParams);
        return result.ToList();
    }

    public async Task<int> ExecuteAsync(string sql, object sqlParams)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        using IDbConnection connection = await OpenAsync();
        using IDbTransaction transaction = connection.BeginTransaction();
        try
        {
            int result = await connection.ExecuteAsync(sql, commandType: CommandType.Text, commandTimeout: _connectionOption.CommandTimeout, param: sqlParams, transaction: transaction);
            transaction.Commit();
            return result;
        }
        catch (NpgsqlException e)
        {
            _logger.LogWarning(e, "ExecuteAsync error. SQL: {Sql}", sql);
            transaction.Rollback();
            throw;
        }
        finally
        {
            stopwatch.Stop();
            _logger.LogInformation("ExecuteAsync completed in {ElapsedMilliseconds}ms. SQL: {Sql}", stopwatch.ElapsedMilliseconds, sql);
        }
    }

    public async Task<T?> ExecuteScalarAsync<T>(string sql, object sqlParams)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        using IDbConnection connection = await OpenAsync();
        using IDbTransaction transaction = connection.BeginTransaction();
        try
        {
            T? result = await connection.ExecuteScalarAsync<T>(sql, commandType: CommandType.Text, commandTimeout: _connectionOption.CommandTimeout, param: sqlParams, transaction: transaction);
            transaction.Commit();
            return result;
        }
        catch (NpgsqlException e)
        {
            _logger.LogWarning(e, "ExecuteScalarAsync<{TypeName}> error. SQL: {Sql}", typeof(T).Name, sql);
            transaction.Rollback();
            throw;
        }
        finally
        {
            stopwatch.Stop();
            _logger.LogInformation("ExecuteScalarAsync<{TypeName}> completed in {ElapsedMilliseconds}ms. SQL: {Sql}", typeof(T).Name, stopwatch.ElapsedMilliseconds, sql);
        }
    }

    public async Task<List<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(
        string sql,
        Func<TFirst, TSecond, TReturn> map,
        string splitOn,
        object? sqlParams = null)
    {
        using IDbConnection connection = await OpenAsync();
        IEnumerable<TReturn> result = await connection
            .QueryAsync(
                sql,
                map,
                splitOn: splitOn,
                commandType: CommandType.Text,
                commandTimeout: _connectionOption.CommandTimeout,
                param: sqlParams);
        return result.ToList();
    }

    public async Task<List<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(
        string sql,
        Func<TFirst, TSecond, TThird, TReturn> map,
        string splitOn,
        object? sqlParams = null)
    {
        using IDbConnection connection = await OpenAsync();
        IEnumerable<TReturn> result = await connection
            .QueryAsync(
                sql,
                map,
                splitOn: splitOn,
                commandType: CommandType.Text,
                commandTimeout: _connectionOption.CommandTimeout,
                param: sqlParams);
        return result.ToList();
    }

    public async Task<List<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(
        string sql,
        Func<TFirst, TSecond, TThird, TFourth, TReturn> map,
        string splitOn,
        object? sqlParams = null)
    {
        using IDbConnection connection = await OpenAsync();
        IEnumerable<TReturn> result = await connection
            .QueryAsync(
                sql,
                map,
                splitOn: splitOn,
                commandType: CommandType.Text,
                commandTimeout: _connectionOption.CommandTimeout,
                param: sqlParams);
        return result.ToList();
    }
}