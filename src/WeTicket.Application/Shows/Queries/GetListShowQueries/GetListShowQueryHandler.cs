using WeTicket.Application.Shared.Queries;
using WeTicket.Application.Shows.DTOs;
using WeTicket.Domain.Repositories;

namespace WeTicket.Application.Shows.Queries.GetListShowQueries;

internal sealed class GetListShowQueryHandler : IQueryHandler<PagedQuery<ShowDto>, IEnumerable<ShowDto>>
{
    private readonly IShowRepository _showRepository;

    public GetListShowQueryHandler(IShowRepository showRepository)
    {
        _showRepository = showRepository;
    }

    public async Task<IEnumerable<ShowDto>> HandleAsync(PagedQuery<ShowDto> request, CancellationToken cancellationToken = default)
    {
        IQueryable<ShowDto> queryable = _showRepository
            .GetQueryable()
            .Select(show => new ShowDto
            {
                Id = show.Id,
                StartTime = show.StartTime,
                EndTime = show.EndTime,
                UserId = show.UserId,
                Location = show.Location,
                Name = show.Name
            });
        return await _showRepository.ToListAsync(queryable, cancellationToken);
    }
}