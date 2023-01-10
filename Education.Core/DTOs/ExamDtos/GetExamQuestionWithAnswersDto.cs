
using Education.Core.Models;

namespace Education.Core.DTOs.ExamDtos
{
    public class GetExamQuestionWithAnswersDto
    {
        public int Id { get; set; }
        public ExamType ExamType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Defination { get; set; }
        public string Description { get; set; }
        public bool IsQuestionsSortRandom { get; set; }
        public bool IsAnswersSortRandom { get; set; }
        public List<QuestionWtihAnswerDto> Questions { get; set; }

    }

    public class QuestionWtihAnswerDto
    {
        public int Id { get; set; }
        public int QuestionCategoryId { get; set; }
        public string QuestionDefinition { get; set; }
        public string QuestionContent { get; set; }
        public AnswerType AnswerType { get; set; }

        public List<AnswerDto> Answers { get; set; }
    }
}
