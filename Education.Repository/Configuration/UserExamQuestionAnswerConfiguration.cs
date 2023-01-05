using Education.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Education.Repository.Configuration
{
    public class UserExamQuestionAnswerConfiguration : IEntityTypeConfiguration<UserExamQuestionAnswer>
    {
        public void Configure(EntityTypeBuilder<UserExamQuestionAnswer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.AnswerId).IsRequired();
            builder.Property(x => x.ExamId).IsRequired();
            builder.Property(x => x.QuestionId).IsRequired();
            builder.Property(x => x.IsCorrect).IsRequired();
        }
    }
}
