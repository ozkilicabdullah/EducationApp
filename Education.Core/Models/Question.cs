namespace Education.Core.Models
{
    public class Question : DbBaseEntity
    {
        public QuestionCategory QuestionCategory { get; set; }
        public int QuestionCategoryId { get; set; }
        public string QuestionDefinition { get; set; }
        public string QuestionContent { get; set; }
        public AnswerType AnswerType { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<EducationContentQuestion> EducationContentQuestions { get; set; }
        public ICollection<ExamQuestion> ExamQuestions { get; set; }
    }
}
