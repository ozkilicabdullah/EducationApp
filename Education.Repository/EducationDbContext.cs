using Education.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository
{
    public class EducationDbContext : DbContext
    {
        public EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options) { }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentUnit> DepartmentUnits { get; set; }
        public DbSet<Core.Models.Education> Educations { get; set; }
        public DbSet<EducationCategory> EducationCategories { get; set; }
        public DbSet<EducationContent> EducationContents { get; set; }
        public DbSet<EducationSubject> EducationSubjects { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamCategory> ExamCategories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionCategory> QuestionCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        public DbSet<AssignedEducation> AssignedEducations { get; set; }
        public DbSet<UserEducationContentHistory> UserEducationContentHistories { get; set; }
        public DbSet<EducationContentQuestion> EducationContentQuestions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // one-to-many relationship
            modelBuilder.Entity<Question>().HasOne(x => x.QuestionCategory).WithMany(x => x.Questions).HasForeignKey(x => x.QuestionCategoryId);
            modelBuilder.Entity<Answer>().HasOne(x => x.Question).WithMany(x => x.Answers).HasForeignKey(x => x.QuestionId);
            modelBuilder.Entity<EducationContent>().HasOne(x => x.Education).WithMany(x => x.EducationContents).HasForeignKey(x => x.EducationId);
            modelBuilder.Entity<EducationSubject>().HasOne(x => x.Education).WithMany(x => x.EducationSubjects).HasForeignKey(x => x.EducationId);
            modelBuilder.Entity<Exam>().HasOne(x => x.ExamCategory).WithMany(x => x.Exams).HasForeignKey(x => x.ExcamCategoryId);
            modelBuilder.Entity<DepartmentUnit>().HasOne(x => x.Department).WithMany(x => x.DepartmentUnits).HasForeignKey(x => x.DepartmentId);
            modelBuilder.Entity<User>().HasOne(x => x.DepartmentUnit).WithMany(x => x.Users).HasForeignKey(x => x.DepartmentUnitId);

            // n-n table relationship
            //modelBuilder.Entity<EducationContentQuestion>().HasKey(x => new { x.QuestionId, x.EducationContentId });
            //modelBuilder.Entity<EducationContentQuestion>().HasOne(x => x.Question).WithMany(q => q.EducationContentQuestions).HasForeignKey(x => x.QuestionId);
            //modelBuilder.Entity<EducationContentQuestion>().HasOne(x => x.EducationContent).WithMany(q => q.EducationContentQuestions).HasForeignKey(x => x.EducationContentId);

            // n-n table relationship
            //modelBuilder.Entity<ExamQuestion>().HasKey(x => new { x.ExamId, x.QuestionId });
            //modelBuilder.Entity<ExamQuestion>().HasOne(x => x.Question).WithMany(x => x.ExamQuestions).HasForeignKey(x => x.QuestionId);
            //modelBuilder.Entity<ExamQuestion>().HasOne(x => x.Exam).WithMany(x => x.ExamQuestions).HasForeignKey(x => x.ExamId);

            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is DbBaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedOn = DateTime.Now;
                                entityReference.Status = Status.Active;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReference).Property(x => x.CreatedOn).IsModified = false;
                                entityReference.ModifiedOn = DateTime.Now;
                                break;
                            }
                    }
                }

            }

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is DbBaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedOn = DateTime.Now;
                                entityReference.Status = Status.Active;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                entityReference.ModifiedOn = DateTime.Now;
                                Entry(entityReference).Property(x => x.CreatedOn).IsModified = false;
                                break;
                            }
                    }
                }

            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
