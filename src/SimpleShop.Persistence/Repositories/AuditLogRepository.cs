using Microsoft.EntityFrameworkCore;
using SimpleShop.Contract.Providers;
using SimpleShop.Domain.Entities;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Persistence.Repositories;

public class AuditLogRepository : Repository<AuditLog, Guid>, IAuditLogRepository
{
    public AuditLogRepository(SimpleShopDbContext dbContext, IDateTimeProvider dateTimeProvider)
        : base(dbContext, dateTimeProvider)
    {
    }

    public async Task<List<AuditLog>> GetByUserIdAsync(Guid userId)
    {
        return await DbSet.AsNoTracking().Where(i => i.UserId == userId).ToListAsync();
    }
}