
namespace Education.Core.Models
{
    public class EducationSubject : DbBaseEntity
    {
        public string Title { get; set; }
        public int EducationId { get; set; }
        public Education Education { get; set; }
        public string Description { get; set; }
    }
}
