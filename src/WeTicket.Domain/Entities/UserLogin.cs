namespace WeTicket.Domain.Entities;

public class UserLogin : Entity<Guid>
{
    public string LoginProvider { get; set; }

    public string ProviderKey { get; set; }

    public string ProviderDisplayName { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; }
}