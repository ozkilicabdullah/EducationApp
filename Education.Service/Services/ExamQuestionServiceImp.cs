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
        private readonly IExamService _examService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuestionRepository _questionRepository;
        public ExamQuestionServiceImp(IGenericRepository<ExamQuestion> repository, IUnitOfWork unitOfWork, IExamQuestionsRepository examQuestionsRepository, IQuestionRepository questionRepository, IExamService examService) : base(repository, unitOfWork)
        {
            _examQuestionsRepository = examQuestionsRepository;
            _unitOfWork = unitOfWork;
            _questionRepository = questionRepository;
            _examService = examService;
        }

        /// <summary>
        /// Sınav için çoklu soru ekleme
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<CustomResponseDto<NoContentDto>> AddQuestionsForExam(ExamQuestionCreatePayloadDto requestModel)
        {
            // İlgili sınav muvcut mu? Eğer yoksa hata mesajı döner
            await _examService.GetByIdAsync(requestModel.payload.ExamId);

            #region Preparing entity
            List<ExamQuestion> entities = new();
            foreach (var item in requestModel.payload.QuestionIds)
            {
                bool isExist = await _examQuestionsRepository.AnyAsync(x => x.ExamId == requestModel.payload.ExamId && x.QuestionId == item);
                if (!isExist)
                {
                    // Soru database'de var mı? // repository'den alınmasının sebebi ClientSideException fırlatmaması için
                    bool isExistQuestion = await _questionRepository.AnyAsync(x => x.Id == item); 
                    if (isExistQuestion)
                    {
                        ExamQuestion entity = new()
                        {
                            ExamId = requestModel.payload.ExamId,
                            QuestionId = item
                        };
                        entities.Add(entity);
                    }
                }
            }
            #endregion

            if (entities.Count < 1)
                return CustomResponseDto<NoContentDto>.Fail(400, "No records to be added or these records have already added! Please check the primary keys of the questions submitted!");

            await _examQuestionsRepository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(200);
        }
    }
}
