using AutoMapper;
using Education.Core.ViewModel;
using Education.Core;
using Education.Core.DTOs;
using Education.Core.Models;
using Education.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Education.Core.Repositories;
using Education.API.Filters;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class QuestionController : CustomBaseController
    {
        #region Ctor
        private readonly IMapper _mapper;
        private readonly IQuestionService _questionService;
        private readonly IQuestionCategoryService _questionCategoryService;
        public QuestionController(IMapper mapper, IQuestionService questionService, IQuestionCategoryService questionCategoryService)
        {
            _mapper = mapper;
            _questionService = questionService;
            _questionCategoryService = questionCategoryService;
        }
        #endregion

        #region GetMethods
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNo = 1, int pageSize = 20)
        {
            #region  prepared model
            var questions = await _questionService.GetAllWithPagingAsync(pageNo, pageSize);
            var questionsDto = _mapper.Map<List<QuestionDto>>(questions);
            int totalRecord = await _questionService.GetTotalRecord();
            var responseModel = GetPaginationResponseDto<List<QuestionDto>>.SetData(
                questionsDto,
                pageNo,
                pageSize,
                totalRecord);
            #endregion 

            return CreateActionResult(CustomResponseDto<GetPaginationResponseDto<List<QuestionDto>>>.Success(200, responseModel));
        }

        [ServiceFilter(typeof(NotFoundFilter<Question>))]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var question = await _questionService.GetByIdAsync(Id);
            var questionDto = _mapper.Map<QuestionDto>(question);
            // View Model
            QuestionDtoViewModel data = new() { question = questionDto };
            return CreateActionResult(CustomResponseDto<QuestionDtoViewModel>.Success(200, data));
        }
        #endregion

        #region Post Methods
        [HttpPost]
        public async Task<IActionResult> CreateAsync(QuestionCreatePayloadDto questionCreatePayloadDto)
        {
            // Sorunun ekleneceği soru kategorisi var mı  ve aktif mi ? --> Eğer yoksa hata mesajını döner
            await _questionCategoryService.GetByIdAsync(questionCreatePayloadDto.payload.QuestionCategoryId);

            var question = await _questionService.AddAsync(_mapper.Map<Question>(questionCreatePayloadDto.payload));
            var questionDto = _mapper.Map<QuestionDto>(question);
            return CreateActionResult(CustomResponseDto<QuestionDto>.Success(200, questionDto));
        }
        #endregion

        #region Put Methods
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(QuestionUpdatePayloadDto questionUpdatePayloadDto)
        {
            // Sorunun ekleneceği soru kategorisi var mı  ve aktif mi ? --> Eğer yoksa hata mesajını döner
            await _questionCategoryService.GetByIdAsync(questionUpdatePayloadDto.payload.QuestionCategoryId);

            await _questionService.UpdateAsync(_mapper.Map<Question>(questionUpdatePayloadDto.payload));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }
        #endregion

        #region Delete Methods
        [ServiceFilter(typeof(NotFoundFilter<Question>))]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveAsync(int Id)
        {
            var question = await _questionService.GetByIdAsync(Id);
            await _questionService.RemoveAsync(question);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        #endregion
    }
}
