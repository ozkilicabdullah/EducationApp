
using AutoMapper;
using Education.Core;
using Education.Core.DTOs;
using Education.Core.Models;
using Education.Core.Services;

namespace Education.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IUserRefreshTokenService _userRefreshTokenService;
        private readonly IMapper _mapper;
        public AuthenticationService(
            ITokenService tokenService,
            IUserService userService,
            IUserRefreshTokenService userRefreshTokenService,
            IMapper mapper)
        {
            _tokenService = tokenService;
            _userService = userService;
            _userRefreshTokenService = userRefreshTokenService;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<TokenDto>> CreateToken(LoginDto loginDto)
        {
            if (loginDto == null)
                throw new ArgumentNullException(nameof(loginDto));

            var user = await _userService.GetUserByUserName(loginDto.UserName);
            if (user == null)
                return CustomResponseDto<TokenDto>.Fail(400, "Email or Passrod is wrong");

            if (!_userService.CheckPassword(user, loginDto.Password))
                return CustomResponseDto<TokenDto>.Fail(400, "Email or Passrod is wrong");

            var token = _tokenService.CreateToken(user);
            var existUserRefreshToken = await _userRefreshTokenService.GetByUserId(user.Id);

            if (existUserRefreshToken == null)
                await _userRefreshTokenService.AddAsync(new UserRefreshToken { UserId = user.Id, RefreshToken = token.RefreshToken, Expiration = token.RefreshTokenExpiration });
            else
            {
                existUserRefreshToken.RefreshToken = token.RefreshToken;
                existUserRefreshToken.Expiration = token.RefreshTokenExpiration;
                await _userRefreshTokenService.UpdateAsync(existUserRefreshToken);
            }

            
            return CustomResponseDto<TokenDto>.Success(200, token);
        }

        public async Task<CustomResponseDto<TokenDto>> CreateTokenByRefreshToken(string refreshToken)
        {
            var existUserRefreshToken = await _userRefreshTokenService.GetByRefreshToken(refreshToken);
            if (existUserRefreshToken == null)
                return CustomResponseDto<TokenDto>.Fail(400, "Refresh token not found!");

            var user = await _userService.GetByIdAsync(existUserRefreshToken.UserId);
            if (user == null)
                return CustomResponseDto<TokenDto>.Fail(400, "User Id not found");

            var token = _tokenService.CreateToken(user);

            existUserRefreshToken.RefreshToken = token.RefreshToken;
            existUserRefreshToken.Expiration = token.RefreshTokenExpiration;
            await _userRefreshTokenService.UpdateAsync(existUserRefreshToken);
            return CustomResponseDto<TokenDto>.Success(200, token);

        }

        public async Task<CustomResponseDto<NoContentDto>> RevokeRefreshToken(string refreshToken)
        {
            var existUserRefreshToken = await _userRefreshTokenService.GetByRefreshToken(refreshToken);
            if (existUserRefreshToken == null)
                return CustomResponseDto<NoContentDto>.Fail(400, "Refresh token not found!");

            await _userRefreshTokenService.RemoveAsync(existUserRefreshToken);

            return CustomResponseDto<NoContentDto>.Success(204);

        }
    }
}
