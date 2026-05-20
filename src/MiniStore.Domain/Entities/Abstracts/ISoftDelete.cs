namespace MiniStore.Domain.Entities.Abstracts;

public interface ISoftDelete
{
    bool IsDeleted { get; set; }
}