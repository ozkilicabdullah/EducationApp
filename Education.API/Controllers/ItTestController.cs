using AutoMapper;
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
    public class ItTestController : CustomBaseController
    {
        private readonly IITtestService _iTtestService;
        private readonly IMapper _mapper;

        public ItTestController(IITtestService iTtestService, IMapper mapper)
        {
            _iTtestService = iTtestService;
            _mapper = mapper;
        }
        #region Get Methods
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var resultModel = await _iTtestService.GetAll();
            var modelDto = _mapper.Map<List<ITTestDto>>(resultModel.ToList());

            return CreateActionResult(CustomResponseDto<List<ITTestDto>>.Success(200, modelDto));
        }
        #endregion
        [HttpPost]
        public async Task<IActionResult> AddAsync(ITTestCreateDto requestModel)
        {
            var entity = _mapper.Map<ITTest>(requestModel);
            var model = await _iTtestService.AddAsync(entity);
            return CreateActionResult(CustomResponseDto<ITTest>.Success(200, model));
        }
    }
}
