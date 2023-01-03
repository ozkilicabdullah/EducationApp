using Education.Core;
using Education.Core.DTOs;
using Education.Core.Models;
using Education.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Education.Repository.Repositories
{
    public class AssignedEducationRepositoryImp : GenericRepository<AssignedEducation>, IAssignedEducationRepository
    {
        public AssignedEducationRepositoryImp(EducationDbContext context) : base(context)
        {
        }

        public async Task<List<UserAssignedEducationDto>> GetAssignedEducationForUser(int userId)
        {
            var query = (from au in _context.AssignedEducations
                         join e in _context.Educations on au.EducationId equals e.Id
                         join ec in _context.EducationCategories on e.EducationCategoryId equals ec.Id
                         where au.UserId == userId
                         select new UserAssignedEducationDto()
                         {
                             EducationId = au.EducationId,
                             EducationCategoryName = ec.Name,
                             EducationTittle = e.Tittle,
                             IsComplate = au.IsComplate,
                             UserId = au.UserId
                         });

            return await query.ToListAsync();
        }

        public async Task<AssignedUserForEducationDto> GetAssignedUserForEducation(int educationId)
        {
            var responseModel = await (from au in _context.AssignedEducations
                                       join e in _context.Educations on au.EducationId equals e.Id
                                       join ec in _context.EducationCategories on e.EducationCategoryId equals ec.Id
                                       where au.EducationId == educationId
                                       select new AssignedUserForEducationDto()
                                       {
                                           EducationCategoryName = ec.Name,
                                           EducationId = e.Id,
                                           EducationTittle = e.Tittle,
                                           IsComplate = au.IsComplate,
                                       }).FirstOrDefaultAsync();

            responseModel.UserInfo = await (from au in _context.AssignedEducations
                                            join e in _context.Educations on au.EducationId equals e.Id
                                            join ec in _context.EducationCategories on e.EducationCategoryId equals ec.Id
                                            join u in _context.Users on au.UserId equals u.Id
                                            where au.EducationId == educationId
                                            select new UserMiniCardInfoDto()
                                            {
                                                Email = u.Email,
                                                Name = u.Name,
                                                RegistrationNumber = u.RegistrationNumber,
                                                Id = u.Id,
                                            }).ToListAsync();

            return responseModel;
        }
    }
}
