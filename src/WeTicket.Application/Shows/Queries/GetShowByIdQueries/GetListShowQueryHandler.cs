using WeTicket.Application.Shared.Queries;
using WeTicket.Application.Shows.DTOs;
using WeTicket.Domain.Repositories;

namespace WeTicket.Application.Shows.Queries.GetShowByIdQueries;

internal class GetShowByIdQueryHandler : IQueryHandler<GetByIdQuery<ShowDto?>, ShowDto?>
{
    private readonly IShowRepository _showRepository;

    public GetShowByIdQueryHandler(IShowRepository showRepository)
    {
        _showRepository = showRepository;
    }

    public async Task<ShowDto?> HandleAsync(GetByIdQuery<ShowDto?> request, CancellationToken cancellationToken = default)
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
        return await _showRepository.FirstOrDefaultAsync(queryable, cancellationToken);
    }
}