using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WeTicket.Domain.Entities;
using WeTicket.Domain.Repositories;

namespace WeTicket.Persistence;

public class WeTicketDbContext : DbContext, IUnitOfWork
{
    private IDbContextTransaction _dbContextTransaction;

    public async Task<IDisposable> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default)
    {
        _dbContextTransaction = await Database.BeginTransactionAsync(isolationLevel, cancellationToken);
        return _dbContextTransaction;
    }

    public async Task<IDisposable> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, string? lockName = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        await _dbContextTransaction.CommitAsync(cancellationToken);
    }
}