namespace Education.Core.Models
{
    public class ExamCategory : DbBaseEntity
    {
        public string Name { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
