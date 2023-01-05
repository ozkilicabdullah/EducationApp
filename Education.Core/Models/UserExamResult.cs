namespace Education.Core.Models
{
    public class UserExamResult:DbBaseEntity
    {
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public int ExamScore { get; set; }
        public bool IsSuccess { get; set; }
        public int TotalQuestionCount { get; set; }
        public int CorrectAnswerCount { get; set; }
    }
}
