using SimpleShop.Domain.Entities;

namespace SimpleShop.Domain.Repositories;

public interface IUserRepository : IRepository<User, Guid>
{
    Task<User?> GetAsync(Guid id);
}