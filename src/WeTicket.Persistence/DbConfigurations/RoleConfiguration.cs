using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeTicket.Domain.Entities;

namespace WeTicket.Persistence.DbConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
        builder.Property(u => u.Name).IsRequired();
        builder.HasIndex(i => i.Name).IsUnique();
        builder.HasMany(i => i.UserRoles).WithOne().HasForeignKey(i => i.RoleId);
    }
}