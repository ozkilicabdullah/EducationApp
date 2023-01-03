using Education.Core;
using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;
using Education.Core.ViewModel;

namespace Education.Service.Services
{
    public class EducationContentQuestionServiceImp : Service<EducationContentQuestion>, IEducationContentQuestionsService
    {
        private readonly IEducationContentQuestionsRepository _educationContentQuestionsRepository;
        private readonly IEducationContentService _educationContentService;
        private readonly IUnitOfWork _unitOfWork;

        public EducationContentQuestionServiceImp(IGenericRepository<EducationContentQuestion> repository, IUnitOfWork unitOfWork, IEducationContentService educationContentService, IEducationContentQuestionsRepository educationContentQuestionsRepository) : base(repository, unitOfWork)
        {
            _educationContentService = educationContentService;
            _educationContentQuestionsRepository = educationContentQuestionsRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Eğitim içeriğine çoklu soru ekleme
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<CustomResponseDto<NoContentDto>> AddQuestionsForEducation(EducationContentQuestionCreatePayloadDto requestModel)
        {
            // ilgili eğitim içeriğini bulmazsa hata döner
            await _educationContentService.GetByIdAsync(requestModel.payload.EducationContentId);

            #region Preparing entity
            List<EducationContentQuestion> entities = new();
            foreach (var item in requestModel.payload.Questions)
            {
                bool isExist = await _educationContentQuestionsRepository.AnyAsync(x => x.QuestionId == item.QuestionId && x.EducationContentId == requestModel.payload.EducationContentId);
                if (!isExist)
                {
                    EducationContentQuestion entity = new()
                    {
                        ShowMinute = item.ShowMinute,
                        QuestionId = item.QuestionId,
                        EducationContentId = requestModel.payload.EducationContentId
                    };
                    entities.Add(entity);
                }
            }
            #endregion
            
            if (entities.Count > 0)
            {
                await _educationContentQuestionsRepository.AddRangeAsync(entities);
                await _unitOfWork.CommitAsync();
            }
            return CustomResponseDto<NoContentDto>.Success(200);
        }
    }
}
