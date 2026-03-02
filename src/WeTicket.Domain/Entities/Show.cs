namespace WeTicket.Domain.Entities;

public class Show : Entity<Guid>
{
    public string Name { get; set; }

    public DateTimeOffset StartTime { get; set; }

    public DateTimeOffset EndTime { get; set; }

    public string Location { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; }
}