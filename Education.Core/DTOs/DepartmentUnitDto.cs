namespace Education.Core.DTOs
{
    public class DepartmentUnitDto : BaseDto
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string IFSDepartmentUnitCode { get; set; }

    }
    public class DepartmentUnitCreateDto
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string IFSDepartmentUnitCode { get; set; }

    }
    public class DepartmentUnitUpdateDto
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string IFSDepartmentUnitCode { get; set; }

    }
}
