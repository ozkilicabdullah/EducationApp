using Education.Core.DTOs;
using Education.Core.Models;

namespace Education.Core.Repositories
{
    public interface IAssignedEducationRepository : IGenericRepository<AssignedEducation>
    {
        /// <summary>
        /// Kullanıcıya atanmış eğitimleri döner.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<UserAssignedEducationDto>> GetAssignedEducationForUser(int userId);

        /// <summary>
        /// Eğitime atanmış kullanıcıları döner
        /// </summary>
        /// <param name="educationId"></param>
        /// <returns></returns>
        Task<AssignedUserForEducationDto> GetAssignedUserForEducation(int educationId);

    }
}
