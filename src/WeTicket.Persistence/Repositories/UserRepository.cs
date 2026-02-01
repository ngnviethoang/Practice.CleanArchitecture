using Microsoft.EntityFrameworkCore;
using WeTicket.Contract.Providers;
using WeTicket.Domain.Entities;
using WeTicket.Domain.Repositories;

namespace WeTicket.Persistence.Repositories;

public class UserRepository : Repository<User, Guid>, IUserRepository
{
    public UserRepository(WeTicketDbContext dbContext, IDateTimeProvider dateTimeProvider)
        : base(dbContext, dateTimeProvider)
    {
    }

    public async Task<User?> GetAsync(Guid id)
    {
        return await DbSet.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
    }
}