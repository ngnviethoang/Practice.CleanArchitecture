using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeTicket.Domain.Entities;

namespace WeTicket.Persistence.DbConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.Property(u => u.UserName).IsRequired();
        builder.HasIndex(i => i.UserName).IsUnique();
        builder.HasIndex(i => i.NormalizedUserName).IsUnique();
        builder.HasIndex(i => i.NormalizedEmail).IsUnique();
        builder.HasMany(i => i.UserRoles).WithOne().HasForeignKey(i => i.UserId);
        builder.HasMany(i => i.UserClaims).WithOne().HasForeignKey(uc => uc.UserId);
        builder.HasMany(i => i.UserLogins).WithOne().HasForeignKey(i => i.UserId);
        builder.HasMany(i => i.AuditLogs).WithOne().HasForeignKey(i => i.UserId);
    }
}