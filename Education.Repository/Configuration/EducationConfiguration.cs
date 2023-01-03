using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Repository.Configuration
{
    public class EducationConfiguration : IEntityTypeConfiguration<Core.Models.Education>
    {
        public void Configure(EntityTypeBuilder<Core.Models.Education> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Tittle).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).HasMaxLength(400);
        }
    }
}
