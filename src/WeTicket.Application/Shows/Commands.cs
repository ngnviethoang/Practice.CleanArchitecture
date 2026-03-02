using WeTicket.Application.Shared.Commands;

namespace WeTicket.Application.Shows;

public class CreateShowCommand : ICommand<Guid>
{
    public string Name { get; set; }

    public DateTimeOffset StartTime { get; set; }

    public DateTimeOffset EndTime { get; set; }

    public string Location { get; set; }

    public Guid UserId { get; set; }
}

public class UpdateShowCommand : ICommand<Guid>
{
    public string Name { get; set; }

    public DateTimeOffset StartTime { get; set; }

    public DateTimeOffset EndTime { get; set; }

    public string Location { get; set; }

    public Guid UserId { get; set; }
}