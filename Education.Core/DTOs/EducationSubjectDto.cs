
namespace Education.Core.DTOs
{
    public class EducationSubjectDto : BaseDto
    {
        public string Title { get; set; }
        public int EducationId { get; set; }
        public string Description { get; set; }

    }
    public class EducationSubjectCreateDto
    {
        public string Title { get; set; }
        public int EducationId { get; set; }
        public string Description { get; set; }
    }
    public class EducationSubjectUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int EducationId { get; set; }
        public string Description { get; set; }
    }
}
