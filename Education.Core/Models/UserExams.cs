namespace Education.Core.Models
{
    public class UserExam:DbBaseEntity
    {
        public int UserId { get; set; }
        public int ExamId { get; set; }
    }
}
