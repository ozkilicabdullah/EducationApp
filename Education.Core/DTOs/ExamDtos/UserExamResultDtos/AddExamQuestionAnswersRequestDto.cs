using System.Text.Json.Serialization;

namespace Education.Core.DTOs
{
    public class AddExamQuestionAnswersRequestDto
    {
        public int UserExamId { get; set; }
        public List<QuestionAnswerListDto> QuestionsAnswers { get; set; }
    }
    public class QuestionAnswerListDto
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        [JsonIgnore]
        public bool IsCorrect { get; set; }
    }
}
