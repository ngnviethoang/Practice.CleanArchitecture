using WeTicket.Domain.Entities.Abstracts;

namespace WeTicket.Domain.Entities;

public class FileEntry : Entity<Guid>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public long Size { get; set; }

    public DateTimeOffset UploadedTime { get; set; }

    public string Path { get; set; }

    public ICollection<FileChunk> FileChunks { get; set; }
}