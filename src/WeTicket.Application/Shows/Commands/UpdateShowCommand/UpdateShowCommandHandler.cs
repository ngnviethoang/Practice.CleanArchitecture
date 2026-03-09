using WeTicket.Application.Shared.Commands;
using WeTicket.Contract.Datetimes;
using WeTicket.Domain.Entities;
using WeTicket.Domain.Repositories;

namespace WeTicket.Application.Shows.Commands.UpdateShowCommand;

internal class UpdateShowCommandHandler : ICommandHandler<UpdateShowCommand, Guid>
{
    private readonly IShowRepository _showRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

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