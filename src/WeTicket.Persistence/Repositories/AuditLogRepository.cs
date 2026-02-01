using Microsoft.EntityFrameworkCore;
using WeTicket.Contract.Datetimes;
using WeTicket.Domain.Entities;
using WeTicket.Domain.Repositories;

namespace WeTicket.Persistence.Repositories;

public class AuditLogRepository : Repository<AuditLog, Guid>, IAuditLogRepository
{
    public AuditLogRepository(WeTicketDbContext dbContext, IDateTimeProvider dateTimeProvider)
        : base(dbContext, dateTimeProvider)
    {
    }

    public async Task<List<AuditLog>> GetByUserIdAsync(Guid userId)
    {
        return await DbSet.AsNoTracking().Where(i => i.UserId == userId).ToListAsync();
    }
}