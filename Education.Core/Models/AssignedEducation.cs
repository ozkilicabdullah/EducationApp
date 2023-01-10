using System.ComponentModel.DataAnnotations;

namespace Education.Core.Models
{
    public class AssignedEducation : DbBaseEntity
    {
        [Required]
        public int UserId { get; set; }
        public int EducationId { get; set; }
        public UserEducationStatus EducationStatus { get; set; }
        public DateTime? ComplatedDate { get; set; }
    }
}
