using WeTicket.Domain.Entities;

namespace WeTicket.Domain.Repositories;

public interface IRepository<TEntity, TKey>
    where TEntity : Entity<TKey>
{
    IUnitOfWork UnitOfWork { get; }

    IQueryable<TEntity> GetQueryable();

    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    void Update(TEntity entity);

    void Remove(TEntity entity);

    Task<T?> FirstOrDefaultAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default);

    Task<List<T>> ToListAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default);
}