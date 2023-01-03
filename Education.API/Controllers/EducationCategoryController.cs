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
    [ApiController]
    [Authorize]
    public class EducationCategoryController : CustomBaseController
    {
        #region Ctor
        private readonly IMapper _mapper;
        private readonly IEducationCategoryService _educationCategoryService;

        public EducationCategoryController(IMapper mapper, IEducationCategoryService educationCategoryService)
        {
            _mapper = mapper;
            _educationCategoryService = educationCategoryService;
        }

        #endregion

        #region Get Methods
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNo = 1, int pageSize = 20)
        {
            #region prepared Model
            var educationCategories = await _educationCategoryService.GetAllWithPagingAsync(pageNo, pageSize); // get enetites
            var educationCategoriesDto = _mapper.Map<List<EducationCategoryDto>>(educationCategories);
            int totalRecord = await _educationCategoryService.GetTotalRecord();
            var responseModel = GetPaginationResponseDto<List<EducationCategoryDto>>.SetData(
                educationCategoriesDto,
                pageNo,
                pageSize,
                totalRecord);
            #endregion

            return CreateActionResult(CustomResponseDto<GetPaginationResponseDto<List<EducationCategoryDto>>>.Success(200, responseModel));
        }

        //[ServiceFilter(typeof(NotFoundFilter<EducationCategory>))]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetlByIdAsync(int Id)
        {
            var educationCategory = await _educationCategoryService.GetByIdAsync(Id);
            var educationCategoryDto = _mapper.Map<EducationCategoryDto>(educationCategory);
            // View Model
            EducationCategoryDtoViewModel data = new() { educationCategory = educationCategoryDto };
            return CreateActionResult(CustomResponseDto<EducationCategoryDtoViewModel>.Success(200, data));
        }
        #endregion

        #region Post Methods
        [HttpPost]
        public async Task<IActionResult> CreateAsync(EducationCategoryCreatePayloadDto educationCategoryCreatePayloadDto)
        {
            var educationCategory = await _educationCategoryService.AddAsync(_mapper.Map<EducationCategory>(educationCategoryCreatePayloadDto.payload));
            var educationCategoryDto = _mapper.Map<EducationCategoryDto>(educationCategory);
            return CreateActionResult(CustomResponseDto<EducationCategoryDto>.Success(200, educationCategoryDto));
        }
        #endregion

        #region Put Methods
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(EducationCategoryUpdatePayloadDto educationCategoryUpdatePayloadDto)
        {
            await _educationCategoryService.UpdateAsync(_mapper.Map<EducationCategory>(educationCategoryUpdatePayloadDto.payload));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }
        #endregion

        #region Delete Methods
        //[ServiceFilter(typeof(NotFoundFilter<EducationCategory>))]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveAsync(int Id)
        {
            var educationCategory = await _educationCategoryService.GetByIdAsync(Id);
            await _educationCategoryService.RemoveAsync(educationCategory);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        #endregion
    }
}
