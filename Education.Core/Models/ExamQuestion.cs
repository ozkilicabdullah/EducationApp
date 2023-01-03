namespace Education.Core.Models
{
    public class ExamQuestion : DbBaseEntity
    {
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
    }
}
