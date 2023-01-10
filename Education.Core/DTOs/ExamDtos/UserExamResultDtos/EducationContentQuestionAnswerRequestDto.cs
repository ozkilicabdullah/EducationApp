using System.Text.Json.Serialization;

namespace Education.Core.DTOs
{
    public class EducationContentQuestionAnswerRequestDto
    {
        public int EducationId { get; set; }
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
    }
}
