using Education.Core.Models;
using System.Text.Json.Serialization;

namespace Education.Core.DTOs
{
    public class AssignedEducationDto : BaseDto
    {
        public int UserId { get; set; }
        public int EducationId { get; set; }
        public UserEducationStatus EducationStatus { get; set; }
        public DateTime? ComplatedDate { get; set; }
    }
    public class AssignedEducationCreateDto
    {
        public int UserId { get; set; }
        public int EducationId { get; set; }
        [JsonIgnore]
        public UserEducationStatus EducationStatus { get; set; }
        public AssignedEducationCreateDto()
        {
            EducationStatus = UserEducationStatus.Assigned;
        }
    }
    public class AssignedEducationUpdateDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EducationId { get; set; }
        public UserEducationStatus EducationStatus { get; set; }
    }
    /// <summary>
    /// Kullanıcıya atanmış eğitimler için kullanılır
    /// </summary>
    public class UserAssignedEducationDto
    {
        public int UserId { get; set; }
        public int EducationId { get; set; }
        public string EducationStatus { get; set; }
        [JsonPropertyName("dateOfAssigned")]
        public DateTime CreatedOn { get; set; }
        public string EducationTittle { get; set; }
        public string EducationCategoryName { get; set; }
    }
    /// <summary>
    /// Eğitime atanmış kullanıcılar
    /// </summary>
    public class AssignedUserForEducationDto
    {
        public int EducationId { get; set; }
        public string EducationStatus { get; set; }
        public string EducationTittle { get; set; }
        public string EducationCategoryName { get; set; }
        public List<UserMiniCardInfoDto> UserInfo { get; set; }
    }
    /// <summary>
    /// Eğitime toplu kullancı atama
    /// </summary>
    public class EducationBatchAssignmentForUsersDto
    {
        public int EducationId { get; set; }
        public List<int> UserIds { get; set; }
    }
}

