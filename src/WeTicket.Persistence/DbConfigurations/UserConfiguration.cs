using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeTicket.Domain.Entities;

namespace WeTicket.Persistence.DbConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasIndex(i => i.NormalizedUserName).IsUnique();
        builder.HasIndex(i => i.NormalizedEmail).IsUnique();
    }
}