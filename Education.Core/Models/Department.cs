
namespace Education.Core.Models
{
    public class Department : DbBaseEntity
    {
        public string Name { get; set; }
        public string IFSDepartmentCode { get; set; }
        public ICollection<DepartmentUnit> DepartmentUnits { get; set; }

    }
}
