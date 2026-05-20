using MiniStore.Contract.Datetimes;
using MiniStore.Domain.Entities;
using MiniStore.Domain.Repositories;

namespace MiniStore.Persistence.Repositories;

public class ShowRepository : Repository<Show, Guid>, IShowRepository
{
    public ShowRepository(MiniStoreDbContext dbContext, IDateTimeProvider dateTimeProvider) : base(dbContext, dateTimeProvider)
    {
    }
}