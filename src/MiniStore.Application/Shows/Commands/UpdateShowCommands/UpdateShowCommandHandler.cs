using MiniStore.Application.Shared.Commands;
using MiniStore.Contract.Datetimes;
using MiniStore.Domain.Entities;
using MiniStore.Domain.Repositories;

namespace MiniStore.Application.Shows.Commands.UpdateShowCommands;

internal sealed class UpdateShowCommandHandler : ICommandHandler<UpdateShowCommand, Guid>
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IShowRepository _showRepository;

    public UpdateShowCommandHandler(IShowRepository showRepository, IDateTimeProvider dateTimeProvider)
    {
        _showRepository = showRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Guid> HandleAsync(UpdateShowCommand request, CancellationToken cancellationToken = default)
    {
        Show? show = await _showRepository.FindAsync(request.Id, cancellationToken);
        if (show == null)
        {
            return Guid.Empty;
        }

        show.Name = request.Name;
        show.StartTime = request.StartTime;
        show.EndTime = request.EndTime;
        show.Location = request.Location;
        show.LastModificationTime = _dateTimeProvider.OffsetUtcNow;
        show.LastModifierId = request.UserId;
        _showRepository.Update(show);
        return show.Id;
    }
}