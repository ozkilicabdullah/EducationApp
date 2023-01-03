
namespace Education.Core.Models
{
    public class Answer : DbBaseEntity
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public string AnswerContent { get; set; }
        public bool IsCorrect { get; set; }
    }
}
