using Microsoft.EntityFrameworkCore;
using MiniStore.Contract.Datetimes;
using MiniStore.Domain.Entities;
using MiniStore.Domain.Repositories;

namespace MiniStore.Persistence.Repositories;

public class AuditLogRepository : Repository<AuditLog, Guid>, IAuditLogRepository
{
    public AuditLogRepository(MiniStoreDbContext dbContext, IDateTimeProvider dateTimeProvider)
        : base(dbContext, dateTimeProvider)
    {
    }

    public async Task<List<AuditLog>> GetByUserIdAsync(Guid userId)
    {
        return await DbSet.AsNoTracking().Where(i => i.UserId == userId).ToListAsync();
    }
}