using Education.Core;
using Education.Core.DTOs;
using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Education.Service.Services
{
    public class AssignedEducationServiceImp : Service<AssignedEducation>, IAssignedEducationService
    {
        private readonly IAssignedEducationRepository _assignedEducationRepository;
        private readonly IEducationService _educationService;
        private readonly IUnitOfWork _unitOfWork;
        public AssignedEducationServiceImp(IGenericRepository<AssignedEducation> repository, IUnitOfWork unitOfWork, IAssignedEducationRepository assignedEducationRepository, IEducationService educationService) : base(repository, unitOfWork)
        {
            _assignedEducationRepository = assignedEducationRepository;
            _educationService = educationService;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Kullanıcıya atanmış eğitimleri dön
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<CustomResponseDto<List<UserAssignedEducationDto>>> GetAssignedEducationForUser(int userId)
        {
            var entity = await _assignedEducationRepository.GetAssignedEducationForUser(userId);
            if (entity == null || entity.Count < 1)
                return CustomResponseDto<List<UserAssignedEducationDto>>.Fail(400, "Not found any recod!");

            return CustomResponseDto<List<UserAssignedEducationDto>>.Success(200, entity);
        }

        /// <summary>
        /// Eğitime toplu kullanıcı atama
        /// </summary>
        /// <param name="educationBatchAssigmentForUserDto"></param>
        /// <returns></returns>
        public async Task<CustomResponseDto<NoContentDto>> EducationBatchAssignmentForUser(EducationBatchAssignmentForUsersDto educationBatchAssigmentForUserDto)
        {
            // İlgili Id'ye ait eğitim yoksa hata döner
            await _educationService.GetByIdAsync(educationBatchAssigmentForUserDto.EducationId);

            #region Prepering entity
            List<AssignedEducation> entities = new();
            foreach (var item in educationBatchAssigmentForUserDto.UserIds)
            {
                // kayıt varsa ekleme
                bool isExist = await _assignedEducationRepository.AnyAsync(x => x.EducationId == educationBatchAssigmentForUserDto.EducationId && x.UserId == item);
                if (!isExist)
                {
                    AssignedEducation entity = new()
                    {
                        EducationId = educationBatchAssigmentForUserDto.EducationId,
                        UserId = item,
                        EducationStatus = UserEducationStatus.Assigned
                    };
                    entities.Add(entity);
                }
            }
            #endregion
            // eklenecek kayıt varsa database'ye yansıt
            if (entities.Count < 1)
                return CustomResponseDto<NoContentDto>.Fail(400, "No records to be added or these records have already added! Please check the primary keys of the users submitted!");

            await _assignedEducationRepository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(200);
        }

        /// <summary>
        /// Eğitime atanmış kullanıcıları döner
        /// </summary>
        /// <param name="educationId"></param>
        /// <returns></returns>
        public async Task<CustomResponseDto<AssignedUserForEducationDto>> GetAssignedUserForEducation(int educationId)
        {
            var model = await _assignedEducationRepository.GetAssignedUserForEducation(educationId);
            if (model == null)
                return CustomResponseDto<AssignedUserForEducationDto>.Fail(400, "Not found any record!");

            return CustomResponseDto<AssignedUserForEducationDto>.Success(200, model);
        }

    }
}
