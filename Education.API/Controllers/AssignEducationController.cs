using AutoMapper;
using Education.Core.DTOs;
using Education.Core;
using Education.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AssignEducationController : CustomBaseController
    {
        #region Ctor
        private readonly IAssignedEducationService _assignedEducationService;
        public AssignEducationController(IAssignedEducationService assignedEducationService)
        {
            _assignedEducationService = assignedEducationService;
        }
        #endregion

        #region Get Methods
        /// <summary>
        /// Kullanıcıya atanmış olan tüm eğitimleri döner
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAssignedEducationForUser")]
        public async Task<IActionResult> GetAssignedEducationForUser()
        {
            string userId = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Sid).FirstOrDefault().Value;
            return CreateActionResult(await _assignedEducationService.GetAssignedEducationForUser(Convert.ToInt32(userId)));
        }

        /// <summary>
        /// Eğitime atanmış kullanıcıları döner
        /// </summary>
        /// <param name="educationId"></param>
        /// <returns></returns>
        [HttpGet("GetAssignedUserForEducation/{educationId}")]
        public async Task<IActionResult> GetAssignedUserForEducation(int educationId)
        {
            return CreateActionResult(await _assignedEducationService.GetAssignedUserForEducation(educationId));
        }
        #endregion

        #region Post Methods
        /// <summary>
        /// Eğitimi birden çok kullanıcıya atama
        /// </summary>
        /// <param name="educationBatchAssigmentForUserDto"></param>
        /// <returns></returns>
        [HttpPost("EducationBatchAssignmentForUsers")]
        public async Task<IActionResult> EducationBatchAssignmentForUsers(EducationBatchAssignmentForUsersDto educationBatchAssignmentForUserDto)
        {
            return CreateActionResult(await _assignedEducationService.EducationBatchAssignmentForUser(educationBatchAssignmentForUserDto));
        }
      
        /// <summary>
        /// Mevcut kullanıcıya eğitim atama
        /// </summary>
        /// <param name="educationId"></param>
        /// <returns></returns>
        [HttpPost("AssignEducationForUser/{educationId}")]
        public async Task<IActionResult> AssignEducationForUser(int educationId)
        {
            string userId = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Sid).FirstOrDefault().Value;
            EducationBatchAssignmentForUsersDto request = new()
            {
                EducationId = educationId,
                UserIds = new List<int> { Convert.ToInt32(userId) }
            };
            return CreateActionResult(await _assignedEducationService.EducationBatchAssignmentForUser(request));
        }
        #endregion
    }
}
