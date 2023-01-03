using AutoMapper;
using Education.Core.ViewModel;
using Education.Core;
using Education.Core.DTOs;
using Education.Core.Models;
using Education.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Education.API.Filters;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class QuestionCategoryController : CustomBaseController
    {
        #region Ctor
        private readonly IMapper _mapper;
        private readonly IQuestionCategoryService _questionCategoryService;

        public QuestionCategoryController(IMapper mapper, IQuestionCategoryService questionCategoryService)
        {
            _mapper = mapper;
            _questionCategoryService = questionCategoryService;
        }

        #endregion

        #region Get Methods
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNo = 1, int pageSize = 20)
        {
            #region prepared model
            var questionCategories = await _questionCategoryService.GetAllWithPagingAsync(pageNo, pageSize);
            var questionCategoriesDto = _mapper.Map<List<QuestionCategoryDto>>(questionCategories);
            int totalRecord = await _questionCategoryService.GetTotalRecord();
            var responseModel = GetPaginationResponseDto<List<QuestionCategoryDto>>.SetData(
                questionCategoriesDto,
                pageNo,
                pageSize,
                totalRecord);
            #endregion

            return CreateActionResult(CustomResponseDto<GetPaginationResponseDto<List<QuestionCategoryDto>>>.Success(200, responseModel));
        }

        [HttpGet("{Id}")]
        [ServiceFilter(typeof(NotFoundFilter<QuestionCategory>))]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var questionCategory = await _questionCategoryService.GetByIdAsync(Id);
            var questionCategoryDto = _mapper.Map<QuestionCategoryDto>(questionCategory);
            // View Model
            QuestionCategoryDtoViewModel data = new() { questionCategory = questionCategoryDto };
            return CreateActionResult(CustomResponseDto<QuestionCategoryDtoViewModel>.Success(200, data));
        }
        #endregion

        #region Post Methods
        [HttpPost]
        public async Task<IActionResult> CreateAsync(QuestionCategoryCreatePayloadDto questionCategoryCreatePayloadDto)
        {
            var questionCategory = await _questionCategoryService.AddAsync(_mapper.Map<QuestionCategory>(questionCategoryCreatePayloadDto.payload));
            var questionCategoryDto = _mapper.Map<QuestionCategoryDto>(questionCategory);
            return CreateActionResult(CustomResponseDto<QuestionCategoryDto>.Success(200, questionCategoryDto));
        }
        #endregion

        #region Put Methods
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(QuestionCategoryUpdatePayloadDto questionCategoryUpdatePayloadDto)
        {
            await _questionCategoryService.UpdateAsync(_mapper.Map<QuestionCategory>(questionCategoryUpdatePayloadDto.payload));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }
        #endregion

        #region Delete Methods
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveAsync(int Id)
        {
            var questionCategory = await _questionCategoryService.GetByIdAsync(Id);
            await _questionCategoryService.RemoveAsync(questionCategory);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        #endregion
    }
}
