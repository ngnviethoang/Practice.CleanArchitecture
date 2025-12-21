using Microsoft.EntityFrameworkCore;
using SimpleShop.Contract.Providers;
using SimpleShop.Domain.Entities;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Persistence.Repositories;

public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : Entity<TKey>
{
    private readonly SimpleShopDbContext _dbContext;

    private readonly IDateTimeProvider _dateTimeProvider;

    protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

    public IUnitOfWork UnitOfWork => _dbContext;

    public Repository(SimpleShopDbContext dbContext, IDateTimeProvider dateTimeProvider)
    {
        _dbContext = dbContext;
        _dateTimeProvider = dateTimeProvider;
    }

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