namespace WeTicket.Domain.Entities;

public class UserToken : Entity<Guid>
{
    public Guid UserId { get; set; }

    public string LoginProvider { get; set; }

    public string Name { get; set; }

    public string Value { get; set; }

    public User User { get; set; }
}