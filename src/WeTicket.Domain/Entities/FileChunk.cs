using WeTicket.Domain.Entities.Abstracts;

namespace WeTicket.Domain.Entities;

public class FileChunk : Entity<Guid>
{
    public string Name { get; set; }

    public string Location { get; set; }

    public string ShortText { get; set; }

    public Guid FileEntryId { get; set; }
}