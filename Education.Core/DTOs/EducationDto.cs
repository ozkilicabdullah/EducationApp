namespace Education.Core.DTOs
{
    public class EducationDto : BaseDto
    {
        public string Tittle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EducationTime { get; set; }
        public int CreatedDepartmentId { get; set; }
        public int EducationCategoryId { get; set; }
        public string Description { get; set; }
        public string Educator { get; set; }
        public int? BeforeExamId { get; set; }
        public int? AfterExamId { get; set; }
    }

    public class EducationCreateDto
    {
        public string Tittle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EducationTime { get; set; }
        public int CreatedDepartmentId { get; set; }
        public int EducationCategoryId { get; set; }
        public int? BeforeExamId { get; set; }
        public int? AfterExamId { get; set; }
        public string Educator { get; set; }
        public string Description { get; set; }
    }
    public class EducationUpdateDto
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EducationTime { get; set; }
        public int CreatedDepartmentId { get; set; }
        public int EducationCategoryId { get; set; }
        public int? BeforeExamId { get; set; }
        public int? AfterExamId { get; set; }
        public string Educator { get; set; }
        public string Description { get; set; }
    }
}
