namespace Education.Core.Models
{
    public class AssignedEducation : DbBaseEntity
    {
        public int UserId { get; set; }
        public int EducationId { get; set; }
        public bool IsComplate { get; set; }
    }
}
