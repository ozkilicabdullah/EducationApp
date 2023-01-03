namespace Education.Core.DTOs
{
    public class DepartmentDto : BaseDto
    {
        public string Name { get; set; }
        public string IFSDepartmentCode { get; set; }

    }
    public class DepartmentCreateDto
    {
        public string Name { get; set; }
        public string IFSDepartmentCode { get; set; }

    }
    public class DepartmentUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IFSDepartmentCode { get; set; }

    }
}
