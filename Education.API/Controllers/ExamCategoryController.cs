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
    public class ExamCategoryController : CustomBaseController
    {
        #region Ctor

        private readonly IMapper _mapper;
        private readonly IExamCategoryService _examCategoryService;

        public ExamCategoryController(IMapper mapper, IExamCategoryService examCategoryService)
        {
            _mapper = mapper;
            _examCategoryService = examCategoryService;
        }

        #endregion

        #region Get Methods
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNo = 1, int pageSize = 20)
        {
            #region prepared model
            var examCategory = await _examCategoryService.GetAllWithPagingAsync(pageNo, pageSize); // get enitites
            var examCategoryDto = _mapper.Map<List<ExamCategoryDto>>(examCategory);// mapping
            int totalRecord = await _examCategoryService.GetTotalRecord(); // record count
            var responseModel = GetPaginationResponseDto<List<ExamCategoryDto>>.SetData(examCategoryDto, pageNo, pageSize, totalRecord);
            #endregion

            return CreateActionResult(CustomResponseDto<GetPaginationResponseDto<List<ExamCategoryDto>>>.Success(200, responseModel));
        }

        [ServiceFilter(typeof(NotFoundFilter<ExamCategory>))]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var examCategory = await _examCategoryService.GetByIdAsync(Id);
            var examCategoryDto = _mapper.Map<ExamCategoryDto>(examCategory);
            // View Model
            ExamCategoryDtoViewModel data = new() { examCategory = examCategoryDto };
            return CreateActionResult(CustomResponseDto<ExamCategoryDtoViewModel>.Success(200, data));
        }
        #endregion

        #region Post Methods

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ExamCategoryCreatePayloadDto examCategoryCreatePayloadDto)
        {
            var examCategory = await _examCategoryService.AddAsync(_mapper.Map<ExamCategory>(examCategoryCreatePayloadDto.payload));
            var examCategoryDto = _mapper.Map<ExamCategoryDto>(examCategory);
            return CreateActionResult(CustomResponseDto<ExamCategoryDto>.Success(200, examCategoryDto));
        }
        #endregion

        #region Put Methods 
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(ExamCategoryUpdatePayloadDto examCategoryUpdatePayloadDto)
        {
            await _examCategoryService.UpdateAsync(_mapper.Map<ExamCategory>(examCategoryUpdatePayloadDto.payload));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }
        #endregion

        #region Delete  Methods
        [ServiceFilter(typeof(NotFoundFilter<ExamCategory>))]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveAsync(int Id)
        {
            var examCategory = await _examCategoryService.GetByIdAsync(Id);
            await _examCategoryService.RemoveAsync(examCategory);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        #endregion
    }
}
