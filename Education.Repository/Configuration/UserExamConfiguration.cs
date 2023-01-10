using Education.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Repository.Configuration
{
    public class UserExamConfiguration : IEntityTypeConfiguration<UserExam>
    {
        public void Configure(EntityTypeBuilder<UserExam> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.ExamId).IsRequired();
        }
    }
}
