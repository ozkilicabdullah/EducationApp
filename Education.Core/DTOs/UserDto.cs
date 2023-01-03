namespace Education.Core.DTOs
{
    public class UserDto : BaseDto
    {
        public int DepartmentUnitId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string RegistrationNumber { get; set; }
        public string IFSPersonNumber { get; set; }
        public string Role { get; set; }
        public string[] Authorities { get; set; }
    }
    public class UserCreateDto
    {
        public int DepartmentUnitId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string RegistrationNumber { get; set; }
        public string IFSPersonNumber { get; set; }
        public string Role { get; set; }

    }
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public int DepartmentUnitId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string RegistrationNumber { get; set; }
        public string IFSPersonNumber { get; set; }
        public string Role { get; set; }

    }
    public class UserMiniCardInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
