using WeTicket.Application.Shared.Commands;
using WeTicket.Contract.Datetimes;
using WeTicket.Contract.Guids;
using WeTicket.Domain.Entities;
using WeTicket.Domain.Repositories;

namespace WeTicket.Application.Shows.Commands.CreateShowCommands;

internal class CreateShowCommandHandler : ICommandHandler<CreateShowCommand, Guid>
{
    private readonly IShowRepository _showRepository;
    private readonly IGuidProvider _guidProvider;
    private readonly IDateTimeProvider _dateTimeProvider;

    public CreateShowCommandHandler(IShowRepository showRepository, IGuidProvider guidProvider, IDateTimeProvider dateTimeProvider)
    {
        _showRepository = showRepository;
        _guidProvider = guidProvider;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Guid> HandleAsync(CreateShowCommand request, CancellationToken cancellationToken = default)
    {
        Show show = new()
        {
            Id = _guidProvider.Create(),
            Name = request.Name,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            Location = request.Location,
            UserId = request.UserId,
            CreationTime = _dateTimeProvider.OffsetUtcNow,
            CreatorId = request.UserId,
            RowVersion = _guidProvider.Create()
        };

        await _showRepository.AddAsync(show, cancellationToken);
        return show.Id;
    }
}