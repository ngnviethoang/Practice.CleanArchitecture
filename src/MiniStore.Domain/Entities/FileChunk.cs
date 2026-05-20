using MiniStore.Domain.Entities.Abstracts;

namespace MiniStore.Domain.Entities;

public class FileChunk : Entity<Guid>
{
    public string Name { get; set; }

    public string Location { get; set; }

    public string ShortText { get; set; }

    public Guid FileEntryId { get; set; }
}