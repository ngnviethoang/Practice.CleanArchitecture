namespace SimpleShop.Domain.Entities;

public interface IHasRowVersion
{
    Guid RowVersion { get; set; }
}