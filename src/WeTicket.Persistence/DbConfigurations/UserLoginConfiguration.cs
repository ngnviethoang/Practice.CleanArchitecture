using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeTicket.Domain.Entities;

namespace WeTicket.Persistence.DbConfigurations;

public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.ToTable("UserLogins");
        builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
    }
}