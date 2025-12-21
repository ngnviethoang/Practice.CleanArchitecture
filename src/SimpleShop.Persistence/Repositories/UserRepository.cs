using Microsoft.EntityFrameworkCore;
using SimpleShop.Contract.Providers;
using SimpleShop.Domain.Entities;
using SimpleShop.Domain.Repositories;

namespace SimpleShop.Persistence.Repositories;

public class UserRepository : Repository<User, Guid>, IUserRepository
{
    public UserRepository(SimpleShopDbContext dbContext, IDateTimeProvider dateTimeProvider)
        : base(dbContext, dateTimeProvider)
    {
    }

    public async Task<User?> GetAsync(Guid id)
    {
        return await DbSet.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
    }
}