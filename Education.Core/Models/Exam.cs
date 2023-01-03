
namespace Education.Core.Models
{
    public class Exam : DbBaseEntity
    {
        public int ExcamCategoryId { get; set; }
        public virtual ExamCategory ExamCategory { get; set; }
        public ExamType ExamType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Defination { get; set; }
        public string Description { get; set; }
        public bool IsQuestionsSortRandom { get; set; }
        public bool IsAnswersSortRandom { get; set; }
    }
}
