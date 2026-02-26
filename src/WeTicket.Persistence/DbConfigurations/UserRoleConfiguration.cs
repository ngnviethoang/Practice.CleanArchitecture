using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeTicket.Domain.Entities;

namespace WeTicket.Persistence.DbConfigurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRoles");
        builder.HasOne(i => i.User).WithMany().HasForeignKey(i => i.UserId);
        builder.HasOne(i => i.Role).WithMany().HasForeignKey(i => i.RoleId);
        builder.HasIndex(x => new { x.UserId, x.RoleId }).IsUnique();
    }
}