
namespace Education.Core.Models
{
    public class User : DbBaseEntity
    {
        public int DepartmentUnitId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string RegistrationNumber { get; set; }
        public string IFSPersonNumber { get; set; }
        public DepartmentUnit DepartmentUnit { get; set; }
        public string Role { get; set; }
    }
}
