using Education.Core.Services;
using Education.Core.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserExamController : CustomBaseController
    {
        private readonly IUserExamService _userExamService;
        public UserExamController(IUserExamService userExamService)
        {
            _userExamService = userExamService;
        }

        #region HttpPost
        /// <summary>
        /// Eğitim içeriğinde çıkan etkileşimli sorulara kullanıcının verdiği cevapları kayıt etmek için kullanılır
        /// </summary>
        /// <param name="requsetModel"></param>
        /// <returns></returns>
        [HttpPost("AddEducationContentQuestionAnswer")]
        public async Task<IActionResult> EducationContentQuestionAnswer(EducationContentQuestionAnswerRequestPayloadDto requestModel)
        {
            #region Get CurrentUser
            var userId = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Sid).FirstOrDefault().Value;
            requestModel.payload.UserId = Convert.ToInt32(userId);
            #endregion

            return CreateActionResult(await _userExamService.AddAnswerForEducationContentQuestion(requestModel));
        }

        /// <summary>
        /// Sınav sorularına kullanıcının verdiği cevapları kayıt eder
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddExamQuestionAnswers")]
        public async Task<IActionResult> AddExamQuestionAnswers(AddExamQuestionAnswersRequestPayloadDto requestModel)
        {
            return CreateActionResult(await _userExamService.AddExamAnswersForUser(requestModel));
        }
        #endregion
    }
}
