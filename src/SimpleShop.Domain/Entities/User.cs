namespace SimpleShop.Domain.Entities;

public class User : Entity<Guid>
{
    public string UserName { get; set; }
}