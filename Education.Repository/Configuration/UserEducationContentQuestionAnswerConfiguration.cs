using Education.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Education.Repository.Configuration
{
    public class UserEducationContentQuestionAnswerConfiguration : IEntityTypeConfiguration<UserEducationContentQuestionAnswer>
    {
        public void Configure(EntityTypeBuilder<UserEducationContentQuestionAnswer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.AnswerId).IsRequired();
            builder.Property(x => x.EducationContentId).IsRequired();
            builder.Property(x => x.QuestionId).IsRequired();
            builder.Property(x => x.IsCorrect).IsRequired();
        }
    }
}
