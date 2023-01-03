using AutoMapper;
using Education.API.Filters;
using Education.Core.ViewModel;
using Education.Core;
using Education.Core.DTOs;
using Education.Core.Models;
using Education.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ExamController : CustomBaseController
    {
        #region Ctor

        private readonly IMapper _mapper;
        private readonly IExamService _examService;
        private readonly IExamCategoryService _examCategoryService;
        private readonly IExamQuestionsService _examQuestionsService;
        public ExamController(IMapper mapper, IExamService examService, IExamCategoryService examCategoryService, IExamQuestionsService examQuestionsService)
        {
            _mapper = mapper;
            _examService = examService;
            _examCategoryService = examCategoryService;
            _examQuestionsService = examQuestionsService;
        }
        #endregion

        #region Get Methods
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNo = 1, int pageSize = 20)
        {
            #region prepared model
            var exams = await _examService.GetAllWithPagingAsync(pageNo, pageSize);
            var examsDto = _mapper.Map<List<ExamDto>>(exams);
            int totalRecord = await _examCategoryService.GetTotalRecord();
            var responseModel = GetPaginationResponseDto<List<ExamDto>>.SetData(examsDto, pageNo, pageSize, totalRecord);
            #endregion

            return CreateActionResult(CustomResponseDto<GetPaginationResponseDto<List<ExamDto>>>.Success(200, responseModel));
        }
        [ServiceFilter(typeof(NotFoundFilter<Exam>))]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var exam = await _examService.GetByIdAsync(Id);
            var examDto = _mapper.Map<ExamDto>(exam);
            // View Model
            ExamDtoViewModel data = new() { exam = examDto };
            return CreateActionResult(CustomResponseDto<ExamDtoViewModel>.Success(200, data));
        }
        #endregion

        #region Post Methods
        [HttpPost]
        public async Task<IActionResult> CreateAsync(ExamCreatePayloadDto examCreatePayloadDto)
        {
            // belirtilen soru kategorisi mevcutmu kontrolü yapar 
            await _examCategoryService.GetByIdAsync(examCreatePayloadDto.payload.ExcamCategoryId);

            var exam = await _examService.AddAsync(_mapper.Map<Exam>(examCreatePayloadDto.payload));
            var examDto = _mapper.Map<ExamDto>(exam);
            return CreateActionResult(CustomResponseDto<ExamDto>.Success(200, examDto));
        }

        /// <summary>
        /// Sınava soru ekleme
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        [HttpPost("AddQuestionsForExam")]
        public async Task<IActionResult> AddQuestionsForExam(ExamQuestionCreatePayloadDto requestDto)
        {
            return CreateActionResult(await _examQuestionsService.AddQuestionsForExam(requestDto));
        }
        #endregion

        #region Put Methods
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(ExamUpdatePayloadDto examUpdatePayloadDto)
        {
            // belirtilen soru kategorisi mevcutmu kontrolü yapar
            await _examCategoryService.GetByIdAsync(examUpdatePayloadDto.payload.ExcamCategoryId);

            await _examService.UpdateAsync(_mapper.Map<Exam>(examUpdatePayloadDto.payload));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }
        #endregion

        #region Delete Methods
        [ServiceFilter(typeof(NotFoundFilter<Exam>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(int Id)
        {
            var exam = await _examService.GetByIdAsync(Id);
            await _examService.RemoveAsync(exam);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        #endregion
    }
}
