namespace WeTicket.Domain.Entities;

public class User : Entity<Guid>
{
    public string UserName { get; set; }
}