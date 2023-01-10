using Education.Core.Models;

namespace Education.Core.DTOs
{
    /// <summary>
    /// Kullanıcıya atanan eğitimlerde kullanılır
    /// </summary>
    public class GetMyAssignedEducationDto
    {
        public int EducationId { get; set; }
        public UserEducationStatus AssignedEducationStatus { get; set; }
        public string EducationCategoryName { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EducationTime { get; set; }
        public string Description { get; set; }
        public string Educator { get; set; }
        public EducationType EducationType { get; set; }
    }
}
