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
    public class DepartmentUnitController : CustomBaseController
    {
        #region Ctor
        private readonly IMapper _mapper;
        private readonly IDepartmentUnitService _departmentUnitService;

        public DepartmentUnitController(IMapper mapper, IDepartmentUnitService departmentUnitService)
        {
            _mapper = mapper;
            _departmentUnitService = departmentUnitService;
        }
        #endregion

        #region Get Methods
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNo = 1, int pageSize = 20)
        {
            #region prepared Model
            var departmentUnits = await _departmentUnitService.GetAllWithPagingAsync(pageNo, pageSize); // get enetites
            var departmentUnitsDto = _mapper.Map<List<DepartmentUnitDto>>(departmentUnits);
            int totalRecord = await _departmentUnitService.GetTotalRecord(); // get total record
            var responseModel = GetPaginationResponseDto<List<DepartmentUnitDto>>.SetData(departmentUnitsDto, pageNo, pageSize, totalRecord); // response model
            #endregion

            return CreateActionResult(CustomResponseDto<GetPaginationResponseDto<List<DepartmentUnitDto>>>.Success(200, responseModel));
        }
       
        [ServiceFilter(typeof(NotFoundFilter<DepartmentUnit>))]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var departmentUnit = await _departmentUnitService.GetByIdAsync(Id);
            var departmentUnitDto = _mapper.Map<DepartmentUnitDto>(departmentUnit);
            // View Model
            DepartmentUnitDtoViewModel data = new() { departmentUnit = departmentUnitDto };
            return CreateActionResult(CustomResponseDto<DepartmentUnitDtoViewModel>.Success(200, data));
        }
        #endregion

        #region Post Methods
        [HttpPost]
        public async Task<IActionResult> CreateAsync(DepartmentUnitCreatePayloadDto departmentUnitCreatePayloadDto)
        {
            var departmentUnit = await _departmentUnitService.AddAsync(_mapper.Map<DepartmentUnit>(departmentUnitCreatePayloadDto.payload));
            var departmentUnitDto = _mapper.Map<DepartmentUnitDto>(departmentUnit);
            return CreateActionResult(CustomResponseDto<DepartmentUnitDto>.Success(200, departmentUnitDto));
        }
        #endregion

        #region Put Methods
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(DepartmentUnitUpdatePayloadDto departmentUnitUpdatePayloadDto)
        {
            await _departmentUnitService.UpdateAsync(_mapper.Map<DepartmentUnit>(departmentUnitUpdatePayloadDto.payload));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }
        #endregion

        #region Delete Methods
        [ServiceFilter(typeof(NotFoundFilter<DepartmentUnit>))]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveAsync(int Id)
        {
            var departmentUnit = await _departmentUnitService.GetByIdAsync(Id);
            await _departmentUnitService.RemoveAsync(departmentUnit);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        #endregion
    }
}
