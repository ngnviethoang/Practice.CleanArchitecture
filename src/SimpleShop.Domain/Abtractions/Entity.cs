namespace SimpleShop.Domain.Abtractions
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; set; }

        public byte[] EntityVersion { get; }

        public DateTimeOffset CreationTime { set; set; }

        public Guid? CreatorId { set; set; }

        public DateTimeOffset? LastModificationTime { set; set; }

        public Guid? LastModifierId { set; set; }

        public bool IsDeleted { set; set; }

        public DateTimeOffset? DeletionTime { set; set; }

        public Guid? DeleterId { set; set; }

        public string? ExtraProperties { get; set; }
    }
}