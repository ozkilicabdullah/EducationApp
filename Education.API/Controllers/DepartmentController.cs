using AutoMapper;
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
    public class DepartmentController : CustomBaseController
    {
        #region Ctor
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }
        #endregion

        #region Get Mehods 
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(FilterRequestDto? requestDto)
        {
            if (requestDto == null)
                requestDto = new();
            #region preperad Model

            var departments = await _departmentService.GetAllWithPagingAsync(requestDto.pageNo, requestDto.pageSize); // get enitites
            var departmentsDto = _mapper.Map<List<DepartmentDto>>(departments); // mapping 
            int totalRecord = await _departmentService.GetTotalRecord(); // get total record
            var responseModel = GetPaginationResponseDto<List<DepartmentDto>>.SetData(departmentsDto, requestDto.pageNo, requestDto.pageSize, totalRecord); // response model
            #endregion

            return CreateActionResult(CustomResponseDto<GetPaginationResponseDto<List<DepartmentDto>>>.Success(200, responseModel));
        }
        //[ServiceFilter(typeof(NotFoundFilter<Department>))]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var department = await _departmentService.GetByIdAsync(Id);
            var departmentDto = _mapper.Map<DepartmentDto>(department);
            // View Model
            DepartmentDtoViewModel data = new() { department = departmentDto };
            return CreateActionResult(CustomResponseDto<DepartmentDtoViewModel>.Success(200, data));
        }
        #endregion

        #region Post Method
        [HttpPost]
        public async Task<IActionResult> CreateAsync(DepartmentCreatePayloadDto departmentCreatePayloadDto)
        {
            var department = await _departmentService.AddAsync(_mapper.Map<Department>(departmentCreatePayloadDto.payload));
            var departmentDto = _mapper.Map<DepartmentDto>(department);
            return CreateActionResult(CustomResponseDto<DepartmentDto>.Success(200, departmentDto));
        }
        #endregion

        #region Put Method
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(DepartmentUpdatePayloadDto departmentUpdatePayloadDto)
        {
            await _departmentService.UpdateAsync(_mapper.Map<Department>(departmentUpdatePayloadDto.payload));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }
        #endregion

        #region Delete Method
        //[ServiceFilter(typeof(NotFoundFilter<Department>))]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveAsync(int Id)
        {
            var department = await _departmentService.GetByIdAsync(Id);
            await _departmentService.RemoveAsync(department);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        #endregion
    }
}
