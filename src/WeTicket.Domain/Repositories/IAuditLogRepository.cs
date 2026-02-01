using WeTicket.Domain.Entities;

namespace WeTicket.Domain.Repositories;

public interface IAuditLogRepository : IRepository<AuditLog, Guid>
{
    Task<List<AuditLog>> GetByUserIdAsync(Guid userId);
}