using Microsoft.EntityFrameworkCore;
using WeTicket.Contract.Datetimes;
using WeTicket.Domain.Entities;
using WeTicket.Domain.Repositories;

namespace WeTicket.Persistence.Repositories;

public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : Entity<TKey>
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly WeTicketDbContext _dbContext;

    public Repository(WeTicketDbContext dbContext, IDateTimeProvider dateTimeProvider)
    {
        _dbContext = dbContext;
        _dateTimeProvider = dateTimeProvider;
    }

    protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

    public IUnitOfWork UnitOfWork => _dbContext;

    public IQueryable<TEntity> GetQueryable()
    {
        return DbSet.AsQueryable();
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.CreationTime = _dateTimeProvider.OffsetUtcNow;
        await DbSet.AddAsync(entity, cancellationToken);
    }

    public void Update(TEntity entity)
    {
        entity.LastModificationTime = _dateTimeProvider.OffsetUtcNow;
        DbSet.Update(entity);
    }

    public void Remove(TEntity entity)
    {
        entity.LastModificationTime = _dateTimeProvider.OffsetUtcNow;
        DbSet.Remove(entity);
    }

    public Task<T?> FirstOrDefaultAsync<T>(IQueryable<T?> queryable, CancellationToken cancellationToken = default)
    {
        return queryable.FirstOrDefaultAsync(cancellationToken);
    }

    public Task<List<T>> ToListAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default)
    {
        return queryable.ToListAsync(cancellationToken);
    }
}