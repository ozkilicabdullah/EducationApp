
namespace Education.Core.DTOs
{
    public class ExamCategoryDto : BaseDto
    {
        public string Name { get; set; }
    }
    public class ExamCategoryCreateDto
    {
        public string Name { get; set; }
    }
    public class ExamCategoryUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
