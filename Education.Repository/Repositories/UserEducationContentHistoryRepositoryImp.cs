using Education.Core.DTOs;
using Education.Core.Models;
using Education.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Education.Repository.Repositories
{
    public class UserEducationContentHistoryRepositoryImp : GenericRepository<UserEducationContentHistory>, IUserEducationContentHistoryRepository
    {
        public UserEducationContentHistoryRepositoryImp(EducationDbContext context) : base(context)
        {
        }

        public async Task<EducationContentHistoryResponseDto> GetEducationContentHistoryForUser(EducationContentHistoryUserRequestDto educationContentHistoryUserRequestDto)
        {

            var responseDto = await (from ec in _context.EducationContents
                                     where ec.Id == educationContentHistoryUserRequestDto.EducationContentId
                                     select new EducationContentHistoryResponseDto()
                                     {
                                         Descriptiron = ec.Descriptiron,
                                         EducationContentId = ec.Id,
                                         EducationContentName = ec.Name,
                                         ContentType = ec.ContentType
                                     }).FirstOrDefaultAsync();
            if (responseDto == null)
                return null;

            responseDto.UserInfo = await (from u in _context.Users
                                          where u.Id == educationContentHistoryUserRequestDto.UserId
                                          select new UserMiniCardInfoDto()
                                          {
                                              Email = u.Email,
                                              Name = u.Name,
                                              RegistrationNumber = u.RegistrationNumber,
                                              Id = u.Id,
                                          }).FirstOrDefaultAsync();


            responseDto.ActionHistories = await (from uch in _context.UserEducationContentHistories
                                                 where uch.EducationContentId == educationContentHistoryUserRequestDto.EducationContentId
                                                 && uch.UserId == educationContentHistoryUserRequestDto.UserId
                                                 select new EducationContentHistoryActionDto()
                                                 {
                                                     ActionType = uch.ActionType,
                                                     CreatedOn = uch.CreatedOn
                                                 }).ToListAsync();
            return responseDto;
        }

        public async Task<List<EducationContentHistoryResponseDto>> GetEducationContentsHistoryForUser(EducationContentsHistoryUserRequestDto educationContentsHistoryUserRequestDto)
        {

            // kullanıcı bilgisi
            var userInfo = await (from u in _context.Users
                                  where u.Id == educationContentsHistoryUserRequestDto.UserId
                                  select new UserMiniCardInfoDto()
                                  {
                                      Email = u.Email,
                                      Name = u.Name,
                                      RegistrationNumber = u.RegistrationNumber,
                                      Id = u.Id,
                                  }).FirstOrDefaultAsync();
            // Eğiteme ait içerikler
            var responseDto = await (from e in _context.Educations
                                     join ec in _context.EducationContents on e.Id equals ec.EducationId
                                     where e.Id == educationContentsHistoryUserRequestDto.EducationId
                                     select new EducationContentHistoryResponseDto()
                                     {
                                         Descriptiron = ec.Descriptiron,
                                         EducationContentId = ec.Id,
                                         EducationContentName = ec.Name,
                                         ContentType = ec.ContentType
                                     }).ToListAsync();
            if (responseDto == null || responseDto.Count < 1)
                return null;

            // içeriğe ait aksiyonlar
            foreach (var item in responseDto)
            {
                item.ActionHistories = await (from uch in _context.UserEducationContentHistories
                                              where uch.EducationContentId == item.EducationContentId
                                              && uch.UserId == educationContentsHistoryUserRequestDto.UserId
                                              select new EducationContentHistoryActionDto()
                                              {
                                                  ActionType = uch.ActionType,
                                                  CreatedOn = uch.CreatedOn
                                              }).ToListAsync();
                item.UserInfo = userInfo;
            }

            return responseDto;
        }
    }
}
