using WeTicket.Application.Shared.Commands;

namespace WeTicket.Application.Shows.Commands.CreateShowCommands
{
    public class CreateShowCommand : ICommand<Guid>
    {
        public string Name { get; set; }

        public DateTimeOffset StartTime { get; set; }

        public DateTimeOffset EndTime { get; set; }

        public string Location { get; set; }

        public Guid UserId { get; set; }
    }
}