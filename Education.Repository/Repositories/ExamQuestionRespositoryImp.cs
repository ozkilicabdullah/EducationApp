using AutoMapper;
using Education.Core.DTOs;
using Education.Core.DTOs.ExamDtos;
using Education.Core.Models;
using Education.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Education.Repository.Repositories
{
    public class ExamQuestionRespositoryImp : GenericRepository<ExamQuestion>, IExamQuestionsRepository
    {
        public ExamQuestionRespositoryImp(EducationDbContext context) : base(context)
        {
        }

        public async Task<List<QuestionDto>> GetExamQuestion(int examId)
        {
            List<QuestionDto> response = new();

            var query = (from q in _context.Questions
                         join eq in _context.ExamQuestions on q.Id equals eq.QuestionId
                         where q.Status == Status.Active && eq.ExamId == examId
                         select new QuestionDto
                         {
                             AnswerType = q.AnswerType,
                             Id = q.Id,
                             QuestionContent = q.QuestionContent,
                             QuestionCategoryId = q.QuestionCategoryId,
                             QuestionDefinition = q.QuestionDefinition,
                         });
            response = await query.ToListAsync();
            return response;
        }
    }
}
