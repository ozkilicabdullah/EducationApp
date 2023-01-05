namespace Education.Core.Models
{
    public class UserExamQuestionAnswer:DbBaseEntity
    {
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
