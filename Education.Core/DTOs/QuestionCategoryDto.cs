namespace Education.Core.DTOs
{
    public class QuestionCategoryDto : BaseDto
    {
        public string Name { get; set; }
    }
    public class QuestionCategoryCreateDto
    {
        public string Name { get; set; }
    }
    public class QuestionCategoryUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
