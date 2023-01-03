
namespace Education.Core.DTOs
{
    public class EducationCategoryDto : BaseDto
    {
        public string Name { get; set; }
    }
    public class EducationCategoryCreateDto
    {
        public string Name { get; set; }
    }
    public class EducationCategoryUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
