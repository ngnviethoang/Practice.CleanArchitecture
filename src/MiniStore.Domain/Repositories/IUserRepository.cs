using MiniStore.Domain.Entities;

namespace MiniStore.Domain.Repositories;

public interface IUserRepository : IRepository<User, Guid>
{
    Task<User?> GetAsync(Guid id);
}