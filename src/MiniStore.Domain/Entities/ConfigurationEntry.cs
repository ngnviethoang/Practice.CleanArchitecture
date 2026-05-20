using MiniStore.Domain.Entities.Abstracts;

namespace MiniStore.Domain.Entities;

public class ConfigurationEntry : Entity<Guid>
{
    public string Name { get; set; }

    public string Value { get; set; }

    public string Description { get; set; }

    public string IsEncrypted { get; set; }
}