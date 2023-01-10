
using Education.Core.DTOs;

namespace Education.Core.Repositories
{
    public interface IEducationRepository : IGenericRepository<Models.Education>
    {
        Task<List<GetMyAssignedEducationDto>> GetMyAssignedEducations(int userId);
    }
}
