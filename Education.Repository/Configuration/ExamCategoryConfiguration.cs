using Education.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.Configuration
{
    public class ExamCategoryConfiguration : IEntityTypeConfiguration<ExamCategory>
    {
        public void Configure(EntityTypeBuilder<ExamCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
        }
    }
}
