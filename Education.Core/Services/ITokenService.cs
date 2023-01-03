using Education.Core.DTOs;
using Education.Core.Models;

namespace Education.Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(User user);
    }
}
