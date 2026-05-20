using Microsoft.EntityFrameworkCore;
using MiniStore.Contract.Datetimes;
using MiniStore.Domain.Entities;
using MiniStore.Domain.Repositories;

namespace MiniStore.Persistence.Repositories;

public class UserRepository : Repository<User, Guid>, IUserRepository
{
    public UserRepository(MiniStoreDbContext dbContext, IDateTimeProvider dateTimeProvider)
        : base(dbContext, dateTimeProvider)
    {
    }

    public async Task<User?> GetAsync(Guid id)
    {
        return await DbSet.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
    }
}