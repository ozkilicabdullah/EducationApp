namespace Education.Core.Models
{
    public class EducationContentQuestion : DbBaseEntity
    {
        public int EducationContentId { get; set; }
        public int QuestionId { get; set; }
        public int? ShowMinute { get; set; }
    }
}
