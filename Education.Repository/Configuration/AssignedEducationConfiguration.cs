using Education.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Repository.Configuration
{
    public class AssignedEducationConfiguration : IEntityTypeConfiguration<AssignedEducation>
    {
        public void Configure(EntityTypeBuilder<AssignedEducation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.EducationId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
        }
    }
}
