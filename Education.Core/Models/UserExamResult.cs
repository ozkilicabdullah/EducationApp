namespace Education.Core.Models
{
    public class UserExamResult : DbBaseEntity
    {
        public int UserExamId { get; set; }
        public int ExamScore { get; set; }
        public bool IsSuccess { get; set; }
        public int TotalQuestionCount { get; set; }
        public int CorrectAnswerCount { get; set; }
    }
}
