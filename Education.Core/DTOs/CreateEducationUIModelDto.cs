namespace Education.Core.DTOs
{
    public class CreateEducationSelectItemsDto
    {
        public List<SelectItemDto> Departments { get; set; }
        public List<SelectItemDto> EducationCategories { get; set; }
        public List<SelectItemDto> PrelimExams { get; set; }
        public List<SelectItemDto> MidTermExams { get; set; }
        public List<SelectItemDto> LastExams { get; set; }
    }
}