using AutoMapper;
using Education.Core;
using Education.Core.DTOs;
using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;
using Education.Core.ViewModel;

namespace Education.Service.Services
{
    public class EducationServiceImp : Service<Core.Models.Education>, IEducationService
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IDepartmentService _departmentService;
        private readonly IEducationCategoryService _educationCategoryService;
        private readonly IExamService _examService;
        private readonly IMapper _mapper;

        public EducationServiceImp(
            IGenericRepository<Core.Models.Education> repository,
            IUnitOfWork unitOfWork,
            IEducationRepository educationRepository,
            IExamService examService,
            IEducationCategoryService educationCategoryService,
            IDepartmentService departmentService,
            IMapper mapper) : base(repository, unitOfWork)
        {
            _educationRepository = educationRepository;
            _examService = examService;
            _educationCategoryService = educationCategoryService;
            _departmentService = departmentService;
            _mapper = mapper;
        }
        public async Task<CreateEducationSelectItemsDto> GetCreateEducationSelectItems()
        {
            CreateEducationSelectItemsDto responseModel = new();

            var departments = await _departmentService.GetAllWithPagingAsync(1, 100000);
            var educationCategories = await _educationCategoryService.GetAllWithPagingAsync(1, 100000);
            var exams = await _examService.GetAllWithPagingAsync(1, 100000);

            #region Preparing model

            if (departments != null && departments.Count() > 0)
            {
                responseModel.Departments = new List<SelectItemDto>();
                foreach (var item in departments)
                {
                    var entity = new SelectItemDto() { Id = item.Id, Value = item.Name };
                    responseModel.Departments.Add(entity);
                }
            }

            if (educationCategories != null && educationCategories.Count() > 0)
            {
                responseModel.EducationCategories = new List<SelectItemDto>();
                foreach (var item in educationCategories)
                {
                    var entity = new SelectItemDto() { Id = item.Id, Value = item.Name };
                    responseModel.EducationCategories.Add(entity);
                }
            }

            if (exams != null && exams.Count() > 0)
            {
                var prelimExams = exams.Where(x => x.ExamType == Core.Models.ExamType.Prelim).ToList();
                if (prelimExams != null && prelimExams.Count() > 0)
                {
                    responseModel.PrelimExams = new List<SelectItemDto>();
                    foreach (var item in prelimExams)
                    {
                        var entity = new SelectItemDto() { Id = item.Id, Value = item.Defination };
                        responseModel.PrelimExams.Add(entity);
                    }
                }

                var midTermExams = exams.Where(x => x.ExamType == Core.Models.ExamType.MidTerm).ToList();
                if (midTermExams != null && midTermExams.Count() > 0)
                {
                    responseModel.MidTermExams = new List<SelectItemDto>();
                    foreach (var item in midTermExams)
                    {
                        var entity = new SelectItemDto() { Id = item.Id, Value = item.Defination };
                        responseModel.MidTermExams.Add(entity);
                    }
                }

                var lastExams = exams.Where(x => x.ExamType == Core.Models.ExamType.LastExam).ToList();
                if (lastExams != null && lastExams.Count() > 0)
                {
                    responseModel.LastExams = new List<SelectItemDto>();
                    foreach (var item in lastExams)
                    {
                        var entity = new SelectItemDto() { Id = item.Id, Value = item.Defination };
                        responseModel.LastExams.Add(entity);
                    }
                }

            }

            #endregion

            return responseModel;
        }

        /// <summary>
        /// Kullanıcıya atanan eğitimleri döner(Gruplanır)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<CustomResponseDto<GetMyAssignedEducationPayloadDto>> GetMyAssignedEducation(int userId)
        {
            GetMyAssignedEducationPayloadDto resultModel = new();
            var entities = await _educationRepository.GetMyAssignedEducations(userId);

            if (entities == null || entities.Count < 0)
                return CustomResponseDto<GetMyAssignedEducationPayloadDto>.Fail(400, "No education assigned to the person found!");

            GetMyAssignedEducationDtoWithGroup payload = new()
            {

                Assigned = entities.Where(x => x.AssignedEducationStatus == UserEducationStatus.Assigned).ToList(),
                Complated = entities.Where(x => x.AssignedEducationStatus == UserEducationStatus.Complated).ToList(),
                Resuming = entities.Where(x => x.AssignedEducationStatus == UserEducationStatus.Resuming).ToList(),
            };
            resultModel.payload = payload;
            return CustomResponseDto<GetMyAssignedEducationPayloadDto>.Success(200, resultModel);
        }
    }
}