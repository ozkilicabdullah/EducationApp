using Education.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Repository.Configuration
{
    public class EducationContentConfiguration : IEntityTypeConfiguration<EducationContent>
    {
        public void Configure(EntityTypeBuilder<EducationContent> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Url).IsRequired();
        }
    }
}
