using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeTicket.Domain.Entities;

namespace WeTicket.Persistence.DbConfigurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRoles");
        builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        builder.HasOne(x => x.Role).WithMany().HasForeignKey(x => x.RoleId);
        builder.HasIndex(x => new { x.UserId, x.RoleId }).IsUnique();
    }
}