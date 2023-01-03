using AutoMapper;
using Education.API.Filters;
using Education.Core.ViewModel;
using Education.Core;
using Education.Core.DTOs;
using Education.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EducationController : CustomBaseController
    {
        #region Ctor

        private readonly IMapper _mapper;
        private readonly IEducationService _educationService;

        public EducationController(IMapper mapper, IEducationService educationService)
        {
            _mapper = mapper;
            _educationService = educationService;
        }
        #endregion

        #region Get Methods

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNo = 1, int pageSize = 20)
        {
            #region prepared model
            var educations = await _educationService.GetAllWithPagingAsync(pageNo, pageSize); // get entities
            var educationsDto = _mapper.Map<List<EducationDto>>(educations.ToList()); // mapping
            int totalRecord = await _educationService.GetTotalRecord();
            var responseModel = GetPaginationResponseDto<List<EducationDto>>.SetData(educationsDto, pageNo, pageSize, totalRecord);
            #endregion

            return CreateActionResult(CustomResponseDto<GetPaginationResponseDto<List<EducationDto>>>.Success(200, responseModel));
        }

        //[ServiceFilter(typeof(NotFoundFilter<Core.Models.Education>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var education = await _educationService.GetByIdAsync(Id);
            var educationDto = _mapper.Map<EducationDto>(education);
            // View Model
            EducationDtoViewModel data = new EducationDtoViewModel() { education = educationDto };
            return CreateActionResult(CustomResponseDto<EducationDtoViewModel>.Success(200, data));
        }

        [HttpGet("GetCreateEducationSelectItems")]
        public async Task<IActionResult> GetCreateEducationSelectItems()
        {
            var response = await _educationService.GetCreateEducationSelectItems();
            return CreateActionResult(CustomResponseDto<CreateEducationSelectItemsDto>.Success(200, response));
        }

        #endregion

        #region Post Methods
        [HttpPost]
        public async Task<IActionResult> CreateAsync(EducationCreatePayloadDto educationCreatePayloadDto)
        {
            var education = await _educationService.AddAsync(_mapper.Map<Core.Models.Education>(educationCreatePayloadDto.payload));
            var createdEducation = _mapper.Map<EducationDto>(education);
            return CreateActionResult(CustomResponseDto<EducationDto>.Success(200, createdEducation));
        }
        #endregion

        #region Put Methods
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(EducationUpdatePayloadDto educationUpdatePayloadDto)
        {
            await _educationService.UpdateAsync(_mapper.Map<Core.Models.Education>(educationUpdatePayloadDto.payload));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }
        #endregion

        #region Delete Methods
        //[ServiceFilter(typeof(NotFoundFilter<Core.Models.Education>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int Id)
        {
            var education = await _educationService.GetByIdAsync(Id);
            await _educationService.RemoveAsync(education);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        #endregion

    }
}
