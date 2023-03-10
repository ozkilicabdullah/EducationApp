using AutoMapper;
using Education.Core.DTOs;
using Education.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthController(IAuthenticationService authenticationService, ILogger<AuthController> logger)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _authenticationService.CreateToken(loginDto);
            return new ObjectResult(result) { StatusCode = result.StatusCode };
        }

        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var result = await _authenticationService.CreateTokenByRefreshToken(refreshTokenDto.RefreshToken);
            return new ObjectResult(result) { StatusCode = result.StatusCode };
        }

        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var result = await _authenticationService.RevokeRefreshToken(refreshTokenDto.RefreshToken);
            return new ObjectResult(result) { StatusCode = result.StatusCode };
        }
    }
}
