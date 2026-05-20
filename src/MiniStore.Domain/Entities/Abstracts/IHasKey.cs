namespace MiniStore.Domain.Entities.Abstracts;

public interface IHasKey<TKey>
{
    TKey Id { get; set; }
}