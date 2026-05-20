using System.Data;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using MiniStore.Domain.Entities.Abstracts;
using MiniStore.Domain.Identity;
using MiniStore.Domain.Repositories;

namespace MiniStore.Persistence;

public class MiniStoreDbContext : DbContext, IUnitOfWork
{
    private const string _softDeletionFilter = "SoftDeletionFilter";
    private readonly ICurrentUser _currentUser;
    private IDbContextTransaction _dbContextTransaction;

    public MiniStoreDbContext(DbContextOptions<MiniStoreDbContext> options, ICurrentUser currentUser)
        : base(options)
    {
        _currentUser = currentUser;
    }

    public async Task<IDisposable> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, string? lockName = null, CancellationToken cancellationToken = default)
    {
        _dbContextTransaction = await Database.BeginTransactionAsync(isolationLevel, cancellationToken);
        return _dbContextTransaction;
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        await _dbContextTransaction.CommitAsync(cancellationToken);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAuditAndSoftDelete();
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
        foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
            {
                ParameterExpression parameter = Expression.Parameter(entityType.ClrType, "i");
                MemberExpression isDeletedProperty = Expression.Property(parameter, nameof(ISoftDelete.IsDeleted));
                UnaryExpression notIsDeleted = Expression.Not(isDeletedProperty);
                LambdaExpression lambda = Expression.Lambda(notIsDeleted, parameter);
                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(_softDeletionFilter, lambda);
            }
        }
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        const int defaultMaxLength = 256;
        configurationBuilder.Properties<string>().HaveMaxLength(defaultMaxLength);
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        ApplyAuditAndSoftDelete();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        ApplyAuditAndSoftDelete();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void ApplyAuditAndSoftDelete()
    {
        DateTimeOffset now = DateTimeOffset.UtcNow;
        foreach (EntityEntry entry in ChangeTracker.Entries())
        {
            if (entry.Entity is IFullAuditedObject<Guid> auditable)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        auditable.CreationTime = now;
                        auditable.CreatorId = _currentUser.UserId;
                        break;
                    case EntityState.Modified:
                        auditable.LastModificationTime = now;
                        auditable.LastModifierId = _currentUser.UserId;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        auditable.IsDeleted = true;
                        auditable.LastModificationTime = now;
                        auditable.LastModifierId = _currentUser.UserId;
                        break;
                }
            }
        }
    }
}