using MiniStore.Domain.Entities;

namespace MiniStore.Domain.Repositories;

public interface IAuditLogRepository : IRepository<AuditLog, Guid>
{
    Task<List<AuditLog>> GetByUserIdAsync(Guid userId);
}