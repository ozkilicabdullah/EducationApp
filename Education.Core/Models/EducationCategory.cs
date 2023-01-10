
namespace Education.Core.Models
{
    public class EducationCategory : DbBaseEntity
    {
        public string Name { get; set; }
        public ICollection<Education> Educations { get; set; }
    }
}
