using Education.Core.DTOs;
using Education.Core.Models;

namespace Education.Core.Services
{
    public interface IAssignedEducationService : IService<AssignedEducation>
    {
        /// <summary>
        /// Kullanıcıya atanmış eğitimleri dön
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<CustomResponseDto<List<UserAssignedEducationDto>>> GetAssignedEducationForUser(int userId);
       
        /// <summary>
        /// Eğitime atanmış kullanıcıları döner
        /// </summary>
        /// <param name="educationId"></param>
        /// <returns></returns>
        Task<CustomResponseDto<AssignedUserForEducationDto>> GetAssignedUserForEducation(int educationId);

        /// <summary>
        /// Eğitime toplu kullanıcı atama
        /// </summary>
        /// <param name="educationBatchAssigmentForUserDto"></param>
        /// <returns></returns>
        Task<CustomResponseDto<NoContentDto>> EducationBatchAssignmentForUser(EducationBatchAssignmentForUsersDto educationBatchAssigmentForUserDto);

    }
}
