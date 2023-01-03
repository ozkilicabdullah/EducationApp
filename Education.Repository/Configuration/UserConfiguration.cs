using Education.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Repository.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(300);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(300);
            builder.Property(x => x.RegistrationNumber).HasMaxLength(20);
            builder.Property(x => x.IFSPersonNumber).HasMaxLength(50);

        }
    }
}
