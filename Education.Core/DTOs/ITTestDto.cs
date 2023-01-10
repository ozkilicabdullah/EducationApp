
namespace Education.Core.DTOs
{
    public class ITTestDto : BaseDto
    {
        public string Name { get; set; }
    }

    public class ITTestCreateDto
    {
        public string Name { get; set; }
    }

    public class ITTestUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
