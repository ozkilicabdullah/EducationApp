using AutoMapper;
using Education.API.Filters;
using Education.Core.ViewModel;
using Education.Core;
using Education.Core.DTOs;
using Education.Core.Models;
using Education.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnswerController : CustomBaseController
    {
        #region Ctor

        private readonly IMapper _mapper;
        private readonly IAnswerService _answerService;
        private readonly IQuestionService _questionService;
        public AnswerController(IMapper mapper, IAnswerService answerService, IQuestionService questionService)
        {
            _mapper = mapper;
            _answerService = answerService;
            _questionService = questionService;
        }
        #endregion

        #region Get Methods

        [HttpGet("GetQuestionAnswers/{questionId}")]
        public async Task<IActionResult> GetQuestionAnswers(int questionId)
        {
            var answers = await _answerService.GetQuestionAnswers(questionId);
            var answersDto = _mapper.Map<List<AnswerDto>>(answers.ToList());
            return CreateActionResult(CustomResponseDto<List<AnswerDto>>.Success(200, answersDto));
        }

        [ServiceFilter(typeof(NotFoundFilter<Answer>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var answer = await _answerService.GetByIdAsync(Id);
            var answerDto = _mapper.Map<AnswerDto>(answer);
            // View Model
            AnswerDtoViewModel data = new() { answer = answerDto };
            return CreateActionResult(CustomResponseDto<AnswerDtoViewModel>.Success(200, data));
        }
        #endregion

        #region Post Methods
        [HttpPost]
        public async Task<IActionResult> CreateAsync(AnswerCreatePayloadDto answerCreatepayloadDto)
        {
            #region Spesific Rules
            await _answerService.CheckCreateAnswerRules(answerCreatepayloadDto.payload);
            #endregion

            var answer = await _answerService.AddAsync(_mapper.Map<Answer>(answerCreatepayloadDto.payload));
            var answerDto = _mapper.Map<AnswerDto>(answer);

            return CreateActionResult(CustomResponseDto<AnswerDto>.Success(200, answerDto));
        }
        #endregion

        #region Put Methods
        [HttpPut]
        public async Task<IActionResult> UpdateAsnyc(AnswerUpdatePayloadDto answerUpdatePayloadDto)
        {

            #region Spesific Rules
            await _answerService.CheckUpdateAnswerRules(answerUpdatePayloadDto.payload);
            #endregion
            var answer = _mapper.Map<Answer>(answerUpdatePayloadDto.payload);
            await _answerService.UpdateAsync(answer);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }
        #endregion

        #region Delete Methods
        [ServiceFilter(typeof(NotFoundFilter<Answer>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(int Id)
        {
            var answer = await _answerService.GetByIdAsync(Id);
            await _answerService.RemoveAsync(answer);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        #endregion
    }
}
