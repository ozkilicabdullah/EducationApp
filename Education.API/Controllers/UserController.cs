using AutoMapper;
using Education.Core;
using Education.Core.DTOs;
using Education.Core.Models;
using Education.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        #region Ctor
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }
        #endregion

        #region Get Methods
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAsync(GetPaginationRequestDto getPaginationRequestDto)
        {
            #region prepared model
            var users = await _userService.GetAllWithPagingAsync(getPaginationRequestDto.PageNo, getPaginationRequestDto.PageSize); // get entities
            var usersDto = _mapper.Map<List<UserDto>>(users);
            int totalRecord = await _userService.GetTotalRecord();
            var responesModel = GetPaginationResponseDto<List<UserDto>>.SetData(
                usersDto,
                getPaginationRequestDto.PageNo,
                getPaginationRequestDto.PageSize,
                totalRecord);
            #endregion

            return CreateActionResult(CustomResponseDto<GetPaginationResponseDto<List<UserDto>>>.Success(200, responesModel));
        }
        //[ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var user = await _userService.GetByIdAsync(Id);
            var userDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(200, userDto));
        }

        [Authorize]
        [HttpGet("UserInfo")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userId = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Sid).FirstOrDefault().Value;
            if (string.IsNullOrEmpty(userId))
                return CreateActionResult(CustomResponseDto<UserDto>.Fail(400, "User not found!"));

            var user = await _userService.GetByIdAsync(Convert.ToInt32(userId));
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
            }
            return CreateActionResult(CustomResponseDto<UserDto>.Success(200, userDto));
        }
        #endregion

        #region Post Method
        [HttpPost]
        public async Task<IActionResult> CreateAsync(UserCreateDto userCreateDto)
        {
            if (userCreateDto == null)
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(400, "Model not be empty!"));

            userCreateDto.Password = SecureOperations.MD5Hash(userCreateDto.Password);
            var user = await _userService.AddAsync(_mapper.Map<User>(userCreateDto));
            var userDto = _mapper.Map<UserDto>(user);

            return CreateActionResult(CustomResponseDto<UserDto>.Success(200, userDto));
        }
        #endregion

        #region Put Methods
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            await _userService.UpdateAsync(_mapper.Map<User>(userUpdateDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }
        #endregion

        #region Delete Methods
        //[ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<IActionResult> RemoveAsync(int Id)
        {
            var user = await _userService.GetByIdAsync(Id);
            await _userService.RemoveAsync(user);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpPost("UpdateUserTest")]
        public async Task<IActionResult> UpdateUserTest()
        {
            var user = await _userService.GetByIdAsync(7);
            await _userService.UpdateUserPassword(user, "12345.aaa");
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }
        #endregion
    }
}
