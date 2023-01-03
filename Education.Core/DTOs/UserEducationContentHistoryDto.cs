using Education.Core.Models;

namespace Education.Core.DTOs
{
    public class UserEducationContentHistoryDto : BaseDto
    {
        public int UserId { get; set; }
        public int EducationContentId { get; set; }
        public EducationContentActionType ActionType { get; set; }
    }
    public class UserEducationContentHistoryCreateDto
    {
        public int UserId { get; set; }
        public int EducationContentId { get; set; }
        public EducationContentActionType ActionType { get; set; }
    }
    public class UserEducationContentHistoryUpdateDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EducationContentId { get; set; }
        public EducationContentActionType ActionType { get; set; }
    }

    public class UserEducationContentHistoryVM
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UserId { get; set; }
        public int EducationContentId { get; set; }
        public EducationContentActionType ActionType { get; set; }
        public UserMiniCardInfoDto UserInfo { get; set; }

    }
}
