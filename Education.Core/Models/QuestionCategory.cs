
namespace Education.Core.Models
{
    public class QuestionCategory : DbBaseEntity
    {
        public string Name { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
