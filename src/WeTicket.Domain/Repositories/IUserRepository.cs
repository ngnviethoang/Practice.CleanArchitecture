using WeTicket.Domain.Entities;

namespace WeTicket.Domain.Repositories;

public interface IUserRepository : IRepository<User, Guid>
{
    Task<User?> GetAsync(Guid id);
}