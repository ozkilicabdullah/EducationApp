using Education.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Education.Repository.Configuration
{
    public class EducationSubjectConfiguration : IEntityTypeConfiguration<EducationSubject>
    {
        public void Configure(EntityTypeBuilder<EducationSubject> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.EducationId).IsRequired();
        }
    }
}
