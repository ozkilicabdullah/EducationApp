
namespace Education.Core.DTOs
{
    public class UserExamResultDto : BaseDto
    {
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public int ExamScore { get; set; }
        public bool IsSuccess { get; set; }
        public int TotalQuestionCount { get; set; }
        public int CorrectAnswerCount { get; set; }
    }
    public class UserExamResultCreateDto
    {
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public int ExamScore { get; set; }
        public bool IsSuccess { get; set; }
        public int TotalQuestionCount { get; set; }
        public int CorrectAnswerCount { get; set; }
    }
}
