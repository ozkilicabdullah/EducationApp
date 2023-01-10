using AutoMapper;
using Education.Core.Models;
using Education.Core;
using Education.Core.Services;
using Education.Core.ViewModel;
using Education.Core.Repositories;
using Education.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Education.Service.Services
{
    /// <summary>
    /// Kullanıcının sınavlar, sorular,cevaplar ile ilgili tüm işlemlerinin yapılacağı servistir.
    /// </summary>
    public class UserExamServiceImp : Service<UserExam>, IUserExamService
    {
        private readonly IUserEducationContentQuestionAnswerService _userEducationContentQuestionAnswerService; // Eğitim içeriklerindeki sorulara verilen yanıtlar
        private readonly IQuestionService _questionService; // Soru kayıtları
        private readonly IEducationContentService _educationContentService; // Eğitim içerikleri (Video/Pdf)
        private readonly IExamService _examService; // Sınav Kayıtları
        private readonly IAnswerService _answerService; // Cevap kayıtları
        private readonly IAnswerRepository _answerRepository; // Cevap kayıtları repository
        private readonly IUserExamQuestionAnswerService _userExamQuestionAnswerService; // Sınavlara verilen cevaplar
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUserExamRepository _userExamRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExamQuestionsService _examQuestionsService;
        private readonly IUserExamResultService _userExamResultService;
        public UserExamServiceImp
            (IGenericRepository<UserExam> repository,
            IUnitOfWork unitOfWork,
            IUserEducationContentQuestionAnswerService userEducationContentQuestionAnswerService,
            IQuestionService questionService,
            IEducationContentService educationContentService,
            IAnswerService answerService,
            IMapper mapper,
            IExamService examService,
            IUserExamQuestionAnswerService userExamQuestionAnswerService,
            IAnswerRepository answerRepository,
            IUserRepository userRepository,
            IUserExamRepository userExamRepository,
            IExamQuestionsService examQuestionsService) : base(repository, unitOfWork)
        {
            _userEducationContentQuestionAnswerService = userEducationContentQuestionAnswerService;
            _questionService = questionService;
            _educationContentService = educationContentService;
            _answerService = answerService;
            _mapper = mapper;
            _examService = examService;
            _userExamQuestionAnswerService = userExamQuestionAnswerService;
            _answerRepository = answerRepository;
            _userRepository = userRepository;
            _userExamRepository = userExamRepository;
            _unitOfWork = unitOfWork;
            _examQuestionsService = examQuestionsService;
        }

        /// <summary>
        /// Eğitim içeriğinde çıkan sorulara verilen yanıtın kayıt edilmesi
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<CustomResponseDto<NoContentDto>> AddAnswerForEducationContentQuestion(EducationContentQuestionAnswerRequestPayloadDto requestModel)
        {
            // Eğitim içeriği varmı?
            await _educationContentService.GetByIdAsync(requestModel.payload.EducationId);
            // Soru varmı ?
            await _questionService.GetByIdAsync(requestModel.payload.QuestionId);
            // cevap varmı ?
            var answer = await _answerService.GetByIdAsync(requestModel.payload.AnswerId);

            // Mapping
            var entity = _mapper.Map<UserEducationContentQuestionAnswer>(requestModel.payload);
            entity.IsCorrect = answer.IsCorrect;

            await _userEducationContentQuestionAnswerService.AddAsync(entity);
            return CustomResponseDto<NoContentDto>.Success(200);
        }

        /// <summary>
        /// Kullanıcının sınav sorularına verdiği yanıtın kayıt edilmesi
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<CustomResponseDto<NoContentDto>> AddExamAnswersForUser(AddExamQuestionAnswersRequestPayloadDto requestModel)
        {
            // Kullanıcıya atanmış sınav var mı?
            await _userExamRepository.GetByIdAsync(requestModel.payload.UserExamId);
            List<UserExamQuestionAnswer> entities = new();
            foreach (var item in requestModel.payload.QuestionsAnswers)
            {
                // Servis üzerinden erişilmemesinin sebebi; 'GetById' methodu servis katmanında ClientSideException fırlatmaktadır.
                // Liste üzerindeki diğer kayıtların kayıt edilebilmesi için repository üzerinden veriye erişilmektedir.
                var answer = await _answerRepository.GetByIdAsync(item.AnswerId);
                if (answer != null)
                {
                    UserExamQuestionAnswer entity = new()
                    {
                        AnswerId = item.AnswerId,
                        UserExamId = requestModel.payload.UserExamId,
                        QuestionId = item.QuestionId,
                        IsCorrect = answer.IsCorrect
                    };
                    entities.Add(entity);
                }
            }
            var userExamResult = await CalculateExamResult(entities);
            if (userExamResult == null)
                CustomResponseDto<NoContentDto>.Fail(400, "Answers cannot be recorded until all questions have been answered!");

            await _userExamQuestionAnswerService.AddRangeAsync(entities); // Cevapları kayıt et
            await _userExamResultService.AddAsync(userExamResult); // Sınav sonucunu kayıt et

            return CustomResponseDto<NoContentDto>.Success(200);
        }

        /// <summary>
        /// Kullanıcılara sınav atama
        /// </summary>
        /// <returns></returns>
        public async Task<CustomResponseDto<NoContentDto>> AssignExamForUsers(AssignExamForUsersRequestDto requestModel)
        {
            // ilgili sınav mevcut mu?
            await _examService.GetByIdAsync(requestModel.ExamId);
            List<UserExam> entities = new();
            foreach (var item in requestModel.UserIds)
            {
                // herhabgi bir kullanıcıya erişilmediği zaman 'ClientSideException'  fırlatmaması için repository'den çağırılmıştır.
                bool isExistUser = await _userRepository.AnyAsync(x => x.Id == item);
                if (isExistUser)
                {
                    bool isExistRecord = await _userExamRepository.Where(x => x.UserId == item && x.ExamId == requestModel.ExamId).AnyAsync();
                    if (!isExistRecord)
                    {
                        UserExam entity = new() { UserId = item, ExamId = requestModel.ExamId };
                        entities.Add(entity);
                    }
                }
            }
            if (entities.Count < 1)
                return CustomResponseDto<NoContentDto>.Fail(400, "No records to be added or records have already added!Please check the primary keys of userIds submitted!");

            await _userExamRepository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(200);
        }

        /// <summary>
        /// Sınav sonucunu hesaplar ve kayıt edilecek nesneyi döner
        /// </summary>
        /// <param name="answers"></param>
        /// <returns></returns>
        private async Task<UserExamResult> CalculateExamResult(List<UserExamQuestionAnswer> answers)
        {
            UserExamResult result = new UserExamResult();
            int? examId = _userExamRepository.Where(x => x.Id == answers.FirstOrDefault().UserExamId).FirstOrDefaultAsync().Result.ExamId;
            var examQuestionCount = _examQuestionsService.Where(x => x.Id == examId.GetValueOrDefault()).Count();
            if (examQuestionCount != answers.Count)
                return null;
            int totalAnswerCount = answers.Count();
            int correctAnswerCount = answers.Where(x => x.IsCorrect).Count();
            double score = Convert.ToDouble((correctAnswerCount * 100) / totalAnswerCount);

            result.TotalQuestionCount = totalAnswerCount;
            result.CorrectAnswerCount = correctAnswerCount;
            result.IsSuccess = score > 70 ? true : false;
            return result;
        }
    }
}
