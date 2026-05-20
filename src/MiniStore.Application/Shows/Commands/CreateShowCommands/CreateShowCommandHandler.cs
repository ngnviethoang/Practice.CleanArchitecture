using MiniStore.Application.Shared.Commands;
using MiniStore.Contract.Datetimes;
using MiniStore.Contract.Guids;
using MiniStore.Domain.Entities;
using MiniStore.Domain.Repositories;

namespace MiniStore.Application.Shows.Commands.CreateShowCommands;

internal sealed class CreateShowCommandHandler : ICommandHandler<CreateShowCommand, Guid>
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IGuidProvider _guidProvider;
    private readonly IShowRepository _showRepository;

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
            UserId = request.UserId
        };

        await _showRepository.AddAsync(show, cancellationToken);
        return show.Id;
    }
}