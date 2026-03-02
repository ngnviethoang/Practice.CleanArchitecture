namespace WeTicket.Application.Shows.DTOs;

public class ShowDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public DateTimeOffset StartTime { get; set; }

    public DateTimeOffset EndTime { get; set; }

    public string Location { get; set; }

    public Guid UserId { get; set; }
}