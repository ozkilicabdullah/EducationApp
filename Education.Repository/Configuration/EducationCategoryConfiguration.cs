using Education.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Repository.Configuration
{
    internal class EducationCategoryConfiguration : IEntityTypeConfiguration<EducationCategory>
    {
        public void Configure(EntityTypeBuilder<EducationCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        }
    }
}
