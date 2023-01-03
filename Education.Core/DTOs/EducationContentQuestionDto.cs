namespace Education.Core.DTOs
{
    public class EducationContentQuestionDto : BaseDto
    {
        public int EducationContentId { get; set; }
        public int QuestionId { get; set; }
        public int? ShowMinute { get; set; }

    }
    public class EducationContentQuestionCreateDto
    {
        public int EducationContentId { get; set; }
        public int QuestionId { get; set; }
        public int? ShowMinute { get; set; }

    }
    public class EducationContentQuestionUpdateDto
    {
        public int EducationContentId { get; set; }
        public int QuestionId { get; set; }
        public int Id { get; set; }
        public int? ShowMinute { get; set; }

    }
}
