using Education.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Repository.Configuration
{
    public class UserExamResultConfiguration : IEntityTypeConfiguration<UserExamResult>
    {
        public void Configure(EntityTypeBuilder<UserExamResult> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.ExamId).IsRequired();
            builder.Property(x => x.TotalQuestionCount).IsRequired();
            builder.Property(x => x.IsSuccess).IsRequired();
            builder.Property(x => x.CorrectAnswerCount).IsRequired();
            builder.Property(x => x.ExamScore).IsRequired();
        }
    }
}
