namespace WeTicket.Domain.Entities.Abstracts;

public interface IHasKey<TKey>
{
    TKey Id { get; set; }
}