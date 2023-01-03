using Education.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Repository.Configuration
{
    public class DepartmentUnitConfiguration : IEntityTypeConfiguration<DepartmentUnit>
    {
        public void Configure(EntityTypeBuilder<DepartmentUnit> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.DepartmentId).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(300);
            builder.Property(x => x.IFSDepartmentUnitCode).HasMaxLength(300);
        }
    }
}
