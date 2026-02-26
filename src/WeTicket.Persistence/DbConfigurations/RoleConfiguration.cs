using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeTicket.Domain.Entities;

namespace WeTicket.Persistence.DbConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
        builder.HasIndex(i => i.NormalizedName).IsUnique();
        builder.HasMany(i => i.RoleClaims).WithOne().HasForeignKey(i => i.RoleId);
    }
}