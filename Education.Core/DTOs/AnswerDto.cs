namespace Education.Core.DTOs
{
    public class AnswerDto : BaseDto
    {
        public int QuestionId { get; set; }
        public string AnswerContent { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class AnswerCreateDto
    {
        public int QuestionId { get; set; }
        public string AnswerContent { get; set; }
        public bool IsCorrect { get; set; }

    }
    public class AnswerUpdateDto
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string AnswerContent { get; set; }
        public bool IsCorrect { get; set; }
    }

}
