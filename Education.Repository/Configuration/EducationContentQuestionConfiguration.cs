using Education.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Repository.Configuration
{
    public class EducationContentQuestionConfiguration : IEntityTypeConfiguration<EducationContentQuestion>
    {
        public void Configure(EntityTypeBuilder<EducationContentQuestion> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
