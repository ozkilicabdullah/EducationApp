using Education.Core.Models;

namespace Education.Core.DTOs
{
    public class EducationContentHistoryResponseDto
    {
        public EducationContentHistoryResponseDto()
        {
            ActionHistories = new();
            UserInfo = new();
        }
        public int EducationContentId { get; set; }
        public string EducationContentName { get; set; }
        public string Descriptiron { get; set; }
        public ContentType ContentType { get; set; }
        public List<EducationContentHistoryActionDto> ActionHistories { get; set; }
        public UserMiniCardInfoDto UserInfo { get; set; }
    }
}
