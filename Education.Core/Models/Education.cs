namespace Education.Core.Models
{
    public class Education : DbBaseEntity
    {
        public string Tittle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EducationTime { get; set; }
        public int CreatedDepartmentId { get; set; }
        public int? BeforeExamId { get; set; }
        public int? AfterExamId { get; set; }
        public int EducationCategoryId { get; set; }
        public string Description { get; set; }
        public string Educator { get; set; }
        public ICollection<EducationContent> EducationContents { get; set; }
        public ICollection<EducationSubject> EducationSubjects { get; set; }
    }
}
