namespace Education.Core.DTOs
{
    public class ExamQuestionsDto : BaseDto
    {
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
    }
    public class ExamQuestionsCreateDto
    {
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
    }
    public class ExamQuestionsUpdateDto
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
    }
}
