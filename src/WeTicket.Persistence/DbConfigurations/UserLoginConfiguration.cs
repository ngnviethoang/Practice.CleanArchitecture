using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeTicket.Domain.Entities;

namespace WeTicket.Persistence.DbConfigurations;

public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.ToTable("UserLogins");
        builder.HasOne(i => i.User).WithMany().HasForeignKey(i => i.UserId);
    }
}