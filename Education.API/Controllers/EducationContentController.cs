using AutoMapper;
using Education.Core.ViewModel;
using Education.Core;
using Education.Core.DTOs;
using Education.Core.Models;
using Education.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Runtime.CompilerServices;
using Education.API.Filters;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EducationContentController : CustomBaseController
    {
        #region Ctor 
        private readonly IMapper _mapper;
        private readonly IEducationContentService _educationContentService;
        private readonly IEducationService _educationService;
        private readonly IUserEducationContentHistoryService _userEducationContentHistoryService;
        private readonly IFirebaseStorageService _firebaseStorageService;
        private readonly IEducationContentQuestionsService _educationContentQuestionsService;
        public EducationContentController(IMapper mapper, IEducationContentService educationContentService, IEducationService educationService, IUserEducationContentHistoryService userEducationContentHistoryService, IFirebaseStorageService firebaseStorageService, IEducationContentQuestionsService educationContentQuestionsService)
        {
            _mapper = mapper;
            _educationContentService = educationContentService;
            _educationService = educationService;
            _userEducationContentHistoryService = userEducationContentHistoryService;
            _firebaseStorageService = firebaseStorageService;
            _educationContentQuestionsService = educationContentQuestionsService;
        }
        #endregion

        #region Get Methods
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNo = 1, int pageSize = 20)
        {
            #region prepared model
            var educationContents = await _educationContentService.GetAllWithPagingAsync(pageNo, pageSize); // get enetites
            var educationContentsDto = _mapper.Map<List<EducationContentDto>>(educationContents.ToList()); // mapping
            int totalRecord = await _educationContentService.GetTotalRecord(); // get total record count
            var responseModel = GetPaginationResponseDto<List<EducationContentDto>>.SetData(
                educationContentsDto,
                pageSize,
                pageSize,
                totalRecord);
            #endregion

            return CreateActionResult(CustomResponseDto<GetPaginationResponseDto<List<EducationContentDto>>>.Success(200, responseModel));
        }

        [ServiceFilter(typeof(NotFoundFilter<EducationContent>))]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var educationContent = await _educationContentService.GetByIdAsync(Id);
            var educationContentDto = _mapper.Map<EducationContentDto>(educationContent);
            // View Model
            EducationContentDtoViewModel data = new() { educationContent = educationContentDto };
            return CreateActionResult(CustomResponseDto<EducationContentDtoViewModel>.Success(200, data));
        }

        [HttpGet("GetCreateEducationContentSelectItems")]
        public async Task<IActionResult> GetCreateEducationContentSelectItems()
        {
            return CreateActionResult(await _educationContentService.GetCreateEducationContentSelectItems());
        }

        /// <summary>
        /// İçerik türüne göre içerik listesi döner
        /// </summary>
        /// <param name="contentType"></param>
        /// <returns></returns>
        [HttpGet("GetEducationContentByContentType")]
        public async Task<IActionResult> GetEducationContentByContentType(ContentType contentType)
        {
            return CreateActionResult(await _educationContentService.GetEducationContentsByContentType(contentType));
        }

        /// <summary>
        /// Eğitim içeriğine ait aksiyonları döner
        /// </summary>
        [HttpGet("GetEducationContentHistoryForUser/{educationContentId}")]
        public async Task<IActionResult> GetEducationContentHistoryForUser(int educationContentId)
        {
            var userId = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Sid).FirstOrDefault().Value;
            var response = await _userEducationContentHistoryService.GetEducationContentHistoryForUser(new EducationContentHistoryUserRequestDto()
            {
                UserId = Convert.ToInt32(userId),
                EducationContentId = educationContentId
            });

            return CreateActionResult(response);
        }

        /// <summary>
        /// Eğitime ait tüm içeriklerdeki aksiyon verilerini döner
        /// </summary>
        [HttpGet("GetEducationContentsHistoryForUser/{educationId}")]
        public async Task<IActionResult> GetEducationContentsHistoryForUser(int educationId)
        {
            var userId = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Sid).FirstOrDefault().Value;
            var response = await _userEducationContentHistoryService.GetEducationContentsHistoryForUser(new EducationContentsHistoryUserRequestDto()
            {
                EducationId = educationId,
                UserId = Convert.ToInt32(userId)
            });
            return CreateActionResult(response);
        }
        #endregion

        #region Post Methods
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] EducationContentCreateDto educationContentCreateDto)
        {
            #region model validaton
            if (educationContentCreateDto.file == null || educationContentCreateDto.file.Length < 1)
                return CreateActionResult(CustomResponseDto<EducationContentDto>.Fail(400, "File is required!"));

            //Çağrılıma sebebi NotFoundFilter eğer bu Id'ye sahip kayıt yoksa hata dönecektir
            await _educationService.GetByIdAsync(educationContentCreateDto.EducationId);
            #endregion

            #region Önce video upload ediliyor, upload başarız olursa hata döner
            string url = await _firebaseStorageService.UploadFile(educationContentCreateDto.file);
            if (string.IsNullOrEmpty(url))
                return CreateActionResult(CustomResponseDto<EducationContentDto>.Fail(400, "An error occurred while uploading the file!"));
            educationContentCreateDto.Url = url;
            #endregion

            var educationContent = await _educationContentService.AddAsync(_mapper.Map<EducationContent>(educationContentCreateDto));
            var edicationContentDto = _mapper.Map<EducationContentDto>(educationContent);
            return CreateActionResult(CustomResponseDto<EducationContentDto>.Success(200, edicationContentDto));
        }

        /// <summary>
        /// Kullanıcının eğitim içeriği aksiyonlarının kayıt edilmesi (Başla/bitir)
        /// </summary>
        /// <param name="userEducationContentHistoryCreateDto"></param>
        /// <returns></returns>
        [HttpPost("AddEducationContentHistoryForUser")]
        public async Task<IActionResult> AddEducationContentHistoryForUser(UserEducationContentHistoryCreateDto userEducationContentHistoryCreateDto)
        {
            var educationContentHistory = await _userEducationContentHistoryService.AddAsync(_mapper.Map<UserEducationContentHistory>(userEducationContentHistoryCreateDto));
            var educationContentHistoryDto = _mapper.Map<UserEducationContentHistoryDto>(educationContentHistory);
            return CreateActionResult(CustomResponseDto<UserEducationContentHistoryDto>.Success(200, educationContentHistoryDto));
        }
        /// <summary>
        /// Eğitim içeriğine soru ekleme
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPost("AddQuestionsForEducation")]
        public async Task<IActionResult> AddQuestionsForEducation(EducationContentQuestionCreatePayloadDto requestModel)
        {
            return CreateActionResult(await _educationContentQuestionsService.AddQuestionsForEducation(requestModel));
        }

        #endregion

        #region Put Methods
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(EducationContenUpdatePayloadDto educationContenUpdatePayloadDto)
        {
            //Çağrılıma sebebi NotFoundFilter eğer bu Id'ye sahip kayıt yoksa hata dönecektir
            await _educationService.GetByIdAsync(educationContenUpdatePayloadDto.payload.EducationId);

            await _educationContentService.UpdateAsync(_mapper.Map<EducationContent>(educationContenUpdatePayloadDto.payload));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }
        #endregion

        #region Delete Methods
        [ServiceFilter(typeof(NotFoundFilter<EducationContent>))]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveAsync(int Id)
        {
            var educationContent = await _educationContentService.GetByIdAsync(Id);
            await _educationContentService.RemoveAsync(educationContent);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        #endregion
    }
}
