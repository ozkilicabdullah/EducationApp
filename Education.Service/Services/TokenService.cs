using AutoMapper;
using Education.Core.Configuration;
using Education.Core.DTOs;
using Education.Core.Models;
using Education.Core.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Education.Service.Services
{
    public class TokenService : ITokenService
    {
        private readonly CustomTokenOption _customTokenOption;
        private readonly IMapper _mapper;

        public TokenService(IOptions<CustomTokenOption> options, IMapper mapper)
        {
            _customTokenOption = options.Value;
            _mapper = mapper;
        }

        public TokenDto CreateToken(User user)
        {
            var accessTokenExpiration = DateTime.Now.AddHours(_customTokenOption.AccessTokenExpiration);
            var refreshTokenTokenExpiration = DateTime.Now.AddHours(_customTokenOption.RefreshTokenExpiration);
            var securityKey = SignService.GetSymmetricSecurityKey(_customTokenOption.SecurityKey);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _customTokenOption.Issuer,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: GetClaims(user, _customTokenOption.Audience),
                signingCredentials: signingCredentials
                );

            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);

            var tokenDto = new TokenDto
            {
                AccessToken = token,
                RefreshToken = CreateRefreshToken(),
                AccessTokenExpiration = accessTokenExpiration,
                RefreshTokenExpiration = refreshTokenTokenExpiration
            };

            var userDto = _mapper.Map<UserDto>(user);
            if (userDto != null && !string.IsNullOrEmpty(userDto.Role))
            {
                string[] userRoles = user.Role.Split(',');

                if (userRoles.Count() > 0)
                {
                    if (userDto.Authorities == null)
                        userDto.Authorities = new string[userRoles.Count()];
                    for (int i = 0; i < userRoles.Count(); i++)
                    {
                        userDto.Authorities[i] = userRoles[i];
                    }
                }
                tokenDto.UserInfo = userDto;
            }
            return tokenDto;
        }

        private string CreateRefreshToken()
        {
            var numberByte = new Byte[32];
            using var randomKey = RandomNumberGenerator.Create();
            randomKey.GetBytes(numberByte);
            return Convert.ToBase64String(numberByte);
        }

        private IEnumerable<Claim> GetClaims(User user, List<string> audiences)
        {
            var userList = new List<Claim>
            {
                //new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Sid,user.Id.ToString()),
                new Claim(ClaimTypes.Role,user.Role),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            userList.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));
            return userList;
        }
    }
}
