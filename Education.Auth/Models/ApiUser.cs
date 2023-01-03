using Microsoft.AspNetCore.Identity;

namespace Education.Auth.Models
{
    public class ApiUser: IdentityUser
    {
        public string RegisterationNumber { get; set; }
    }
}
