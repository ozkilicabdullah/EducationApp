using Education.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Repository.Configuration
{
    public class UserEducationContentHistoryConfiguration : IEntityTypeConfiguration<UserEducationContentHistory>
    {
        public void Configure(EntityTypeBuilder<UserEducationContentHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.EducationContentId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.ActionType).IsRequired();

        }
    }
}
