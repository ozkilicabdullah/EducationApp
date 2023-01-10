namespace Education.Core.DTOs
{
    public class UserExamQuestionAnswerDto : BaseDto
    {
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public bool IsCorrect { get; set; }
    }
    public class UserExamQuestionAnswerCreateDto
    {
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
