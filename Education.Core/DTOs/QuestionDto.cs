using Education.Core.Models;

namespace Education.Core.DTOs
{
    public class QuestionDto : BaseDto
    {
        public int QuestionCategoryId { get; set; }
        public string QuestionDefinition { get; set; }
        public string QuestionContent { get; set; }
        public AnswerType AnswerType { get; set; }
    }
    public class QuestionCreateDto
    {
        public int QuestionCategoryId { get; set; }
        public string QuestionDefinition { get; set; }
        public string QuestionContent { get; set; }
        public AnswerType AnswerType { get; set; }
        public int EducationContentId { get; set; }

    }
    public class QuestionUpdateDto
    {
        public int Id { get; set; }
        public int QuestionCategoryId { get; set; }
        public string QuestionDefinition { get; set; }
        public string QuestionContent { get; set; }
        public AnswerType AnswerType { get; set; }
        public int EducationContentId { get; set; }

    }
}
