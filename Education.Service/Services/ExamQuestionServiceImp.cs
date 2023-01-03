using Education.Core;
using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;
using Education.Core.ViewModel;

namespace Education.Service.Services
{
    public class ExamQuestionServiceImp : Service<ExamQuestion>, IExamQuestionsService
    {
        private readonly IExamQuestionsRepository _examQuestionsRepository;
        private readonly IExamRepository _examRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ExamQuestionServiceImp(IGenericRepository<ExamQuestion> repository, IUnitOfWork unitOfWork, IExamQuestionsRepository examQuestionsRepository, IExamRepository examRepository) : base(repository, unitOfWork)
        {
            _examQuestionsRepository = examQuestionsRepository;
            _unitOfWork = unitOfWork;
            _examRepository = examRepository;
        }
        
        /// <summary>
        /// Sınav için çoklu soru ekleme
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<CustomResponseDto<NoContentDto>> AddQuestionsForExam(ExamQuestionCreatePayloadDto requestModel)
        {
            // İlgili sınav muvcut mu? Eğer yoksa hata mesajı döner
            await _examRepository.GetByIdAsync(requestModel.payload.ExamId);

            #region Preparing entity
            List<ExamQuestion> entities = new();
            foreach (var item in requestModel.payload.QuestionIds)
            {
                bool isExist = await _examQuestionsRepository.AnyAsync(x => x.ExamId == requestModel.payload.ExamId && x.QuestionId == item);
                if (!isExist)
                {
                    ExamQuestion entity = new()
                    {
                        ExamId = requestModel.payload.ExamId,
                        QuestionId = item
                    };
                    entities.Add(entity);
                }
            }
            #endregion

            if (entities.Count > 0)
            {
                await _examQuestionsRepository.AddRangeAsync(entities);
                await _unitOfWork.CommitAsync();
            }
            return CustomResponseDto<NoContentDto>.Success(200);
        }
    }
}
