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
    public class EducationSubjectController : CustomBaseController
    {
        #region Ctor

        private readonly IMapper _mapper;
        private readonly IEducationSubjectService _educationSubjectService;

        public EducationSubjectController(IMapper mapper, IEducationSubjectService educationSubjectService)
        {
            _mapper = mapper;
            _educationSubjectService = educationSubjectService;
        }

        #endregion

        #region Get Methods

        [HttpGet("GetEducationSubjectsByEducationId/{educationId}")]
        public async Task<IActionResult> GetEducationSubjectsByEducationId(int educationId)
        {
            var educationSubjects = await _educationSubjectService.GetEducationSubjectsByEducationId(educationId);
            var educationSubjectsDtos = _mapper.Map<List<EducationSubjectDto>>(educationSubjects);
            return CreateActionResult(CustomResponseDto<List<EducationSubjectDto>>.Success(200, educationSubjectsDtos));
        }

        //[ServiceFilter(typeof(NotFoundFilter<EducationSubject>))]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var educationSubject = await _educationSubjectService.GetByIdAsync(Id);
            var educationSubjetDto = _mapper.Map<EducationSubjectDto>(educationSubject);
            // View Model
            EducationSubjectDtoViewModel data = new() { educationSubject = educationSubjetDto };
            return CreateActionResult(CustomResponseDto<EducationSubjectDtoViewModel>.Success(200, data));
        }
        #endregion

        #region Post Methods 
        [HttpPost]
        public async Task<IActionResult> CreateAsync(EducationSubjectCreatePayloadDto educationSubjectCreatePayloadDto)
        {
            var educationSubject = await _educationSubjectService.AddAsync(_mapper.Map<EducationSubject>(educationSubjectCreatePayloadDto.payload));
            var educationSubjectDto = _mapper.Map<EducationSubjectDto>(educationSubject);
            return CreateActionResult(CustomResponseDto<EducationSubjectDto>.Success(200, educationSubjectDto));
        }
        #endregion

        #region Put Methods
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(EducationSubjectUpdatePayloadDto educationSubjectUpdatePayloadDto)
        {
            await _educationSubjectService.UpdateAsync(_mapper.Map<EducationSubject>(educationSubjectUpdatePayloadDto.payload));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }
        #endregion

        #region Delete Methods
        //[ServiceFilter(typeof(NotFoundFilter<EducationSubject>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int Id)
        {
            var educationSubject = await _educationSubjectService.GetByIdAsync(Id);
            await _educationSubjectService.RemoveAsync(educationSubject);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        #endregion
    }
}
