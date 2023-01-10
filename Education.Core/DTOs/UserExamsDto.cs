namespace Education.Core.DTOs
{
    public class UserExamDto : BaseDto
    {
        public int UserId { get; set; }
        public int ExamId { get; set; }
    }
    public class UserExamCreateDto
    {
        public int UserId { get; set; }
        public int ExamId { get; set; }
    }
}
