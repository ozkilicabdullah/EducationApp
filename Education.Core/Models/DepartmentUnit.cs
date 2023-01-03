
namespace Education.Core.Models
{
    public class DepartmentUnit : DbBaseEntity
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string IFSDepartmentUnitCode { get; set; }
        public Department Department { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
