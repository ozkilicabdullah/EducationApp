namespace Education.Core.Models
{
    public class EducationContentQuestion : DbBaseEntity
    {
        public int EducationContentId { get; set; }
        public EducationContent EducationContent { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int? ShowMinute { get; set; }
    }
}
