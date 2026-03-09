using WeTicket.Application.Shared.Commands;

namespace WeTicket.Application.Shows.Commands.UpdateShowCommand
{
    public class UpdateShowCommand : ICommand<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset StartTime { get; set; }

        public DateTimeOffset EndTime { get; set; }

        public string Location { get; set; }

        public Guid UserId { get; set; }
    }
}