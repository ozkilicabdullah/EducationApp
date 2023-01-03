using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service.Services
{
    public class QuestionCategoryServiceImp : Service<QuestionCategory>, IQuestionCategoryService
    {
        private readonly IQuestionCategoryRepository _questionCategoryRepository;
        public QuestionCategoryServiceImp(IGenericRepository<QuestionCategory> repository, IUnitOfWork unitOfWork, IQuestionCategoryRepository questionCategoryRepository) : base(repository, unitOfWork)
        {
            _questionCategoryRepository = questionCategoryRepository;
        }
    }
}
