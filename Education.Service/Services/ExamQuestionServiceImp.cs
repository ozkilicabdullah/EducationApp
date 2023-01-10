using AutoMapper;
using Education.Core;
using Education.Core.DTOs;
using Education.Core.DTOs.ExamDtos;
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
        private readonly IAnswerService _answerService;
        private readonly IMapper _mapper;

        public ExamQuestionServiceImp(IGenericRepository<ExamQuestion> repository, IUnitOfWork unitOfWork, IExamQuestionsRepository examQuestionsRepository, IQuestionRepository questionRepository, IExamService examService, IMapper mapper, IAnswerService answerService) : base(repository, unitOfWork)
        {
            _examQuestionsRepository = examQuestionsRepository;
            _unitOfWork = unitOfWork;
            _questionRepository = questionRepository;
            _examService = examService;
            _mapper = mapper;
            _answerService = answerService;
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

        /// <summary>
        /// Sınavın sorularını ve cevaplarını döner 
        /// </summary>
        /// <param name="examId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<CustomResponseDto<GetExamQuestionWithAnswersDto>> GetExamQuestionWithAnswers(int examId)
        {
            GetExamQuestionWithAnswersDto response = new();
            var exam = await _examService.GetByIdAsync(examId);
            response = _mapper.Map<GetExamQuestionWithAnswersDto>(exam);

            // Questions
            var question = await _examQuestionsRepository.GetExamQuestion(examId);
            response.Questions = _mapper.Map<List<QuestionWtihAnswerDto>>(question.ToList());

            if (response.Questions != null && response.Questions.Count() > 0)
            {
                foreach (var item in response.Questions)
                {
                    var answers = await _answerService.GetQuestionAnswers(item.Id);
                    item.Answers = _mapper.Map<List<AnswerDto>>(answers);
                }
                return CustomResponseDto<GetExamQuestionWithAnswersDto>.Success(200, response);
            }

            return CustomResponseDto<GetExamQuestionWithAnswersDto>.Fail(400, "There are no questions for the exam");
        }
    }
}
