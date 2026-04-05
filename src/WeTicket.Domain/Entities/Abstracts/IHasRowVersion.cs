namespace WeTicket.Domain.Entities.Abstracts;

public interface IHasRowVersion
{
    Guid RowVersion { get; set; }
}