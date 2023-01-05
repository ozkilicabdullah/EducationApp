namespace Education.Core.Models
{
    public class UserEducationContentQuestionAnswer:DbBaseEntity
    {
        public int UserId { get; set; }
        public int EducationContentId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public bool IsCorrect { get; set; }
    }

}
