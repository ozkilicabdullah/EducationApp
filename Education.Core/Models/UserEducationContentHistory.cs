namespace Education.Core.Models
{
    public class UserEducationContentHistory : DbBaseEntity
    {
        public int UserId { get; set; }
        public int EducationContentId { get; set; }
        public EducationContentActionType ActionType { get; set; }

    }
}
