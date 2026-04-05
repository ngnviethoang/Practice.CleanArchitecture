using WeTicket.Domain.Entities.Abstracts;

namespace WeTicket.Domain.Entities;

public class FileEmbedding : Entity<Guid>
{
    public float[] Embedding { get; set; }

    public string TokenDetails { get; set; }

    public Guid FileChunkId { get; set; }

    public FileChunk FileChunk { get; set; }
}