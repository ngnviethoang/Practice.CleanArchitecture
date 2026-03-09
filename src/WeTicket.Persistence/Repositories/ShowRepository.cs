using WeTicket.Contract.Datetimes;
using WeTicket.Domain.Entities;
using WeTicket.Domain.Repositories;

namespace WeTicket.Persistence.Repositories;

public class ShowRepository : Repository<Show, Guid>, IShowRepository
{
    public ShowRepository(WeTicketDbContext dbContext, IDateTimeProvider dateTimeProvider) : base(dbContext, dateTimeProvider)
    {
    }
}