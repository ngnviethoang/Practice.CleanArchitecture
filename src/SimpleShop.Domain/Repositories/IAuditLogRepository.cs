using SimpleShop.Domain.Entities;

namespace SimpleShop.Domain.Repositories;

public interface IAuditLogRepository : IRepository<AuditLog, Guid>
{
    Task<List<AuditLog>> GetByUserIdAsync(Guid userId);
}