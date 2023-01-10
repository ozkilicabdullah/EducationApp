namespace Education.Core.DTOs
{
    public class UserEducationContentQuestionAnswerDto : BaseDto
    {
        public int UserId { get; set; }
        public int EducationContentId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class UserEducationContentQuestionAnswerCreateDto
    {
        public int UserId { get; set; }
        public int EducationContentId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public bool IsCorrect { get; set; }
    }

}
