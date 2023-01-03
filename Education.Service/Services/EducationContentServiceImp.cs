using AutoMapper;
using Education.Core.ViewModel;
using Education.Core;
using Education.Core.DTOs;
using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Education.Service.Services
{
    public class EducationContentServiceImp : Service<EducationContent>, IEducationContentService
    {
        private readonly IEducationContentRepository _educationContentRepository;
        private readonly IMapper _mapper;
        public EducationContentServiceImp(IGenericRepository<EducationContent> repository, IUnitOfWork unitOfWork, IEducationContentRepository educationContentRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _educationContentRepository = educationContentRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CreateEducationContentSelectItemDto>> GetCreateEducationContentSelectItems()
        {
            CreateEducationContentSelectItemDto responseModel = new();
            var educationContent = await _educationContentRepository.GetAllWithPaging(1, 100000).ToListAsync();
            if (educationContent == null || educationContent.Count < 0)
                return CustomResponseDto<CreateEducationContentSelectItemDto>.Fail(400, "No record found!");

            #region Preparing model

            var pdfContents = educationContent.Where(x => x.ContentType == ContentType.Pdf).ToList();
            if (pdfContents != null && pdfContents.Count > 0)
            {
                responseModel.PdfContents = new List<SelectItemDto>();
                foreach (var item in pdfContents)
                {
                    var entity = new SelectItemDto() { Id = item.Id, Value = item.Name };
                    responseModel.PdfContents.Add(entity);
                }
            }

            var videoContents = educationContent.Where(x => x.ContentType == ContentType.Video).ToList();
            if (videoContents != null && videoContents.Count > 0)
            {
                responseModel.VideoContents = new List<SelectItemDto>();
                foreach (var item in videoContents)
                {
                    var entity = new SelectItemDto() { Id = item.Id, Value = item.Name };
                    responseModel.VideoContents.Add(entity);
                }
            }
            #endregion

            return CustomResponseDto<CreateEducationContentSelectItemDto>.Success(200, responseModel);
        }

        public async Task<CustomResponseDto<EducationContentListDtoViewModel>> GetEducationContentsByContentType(ContentType contentType)
        {
            EducationContentListDtoViewModel response = new();
            var educationContents = await _educationContentRepository.Where(x => x.ContentType == contentType).ToListAsync();
            if (educationContents == null && educationContents.Count < 0)
                return CustomResponseDto<EducationContentListDtoViewModel>.Fail(404, "Not found any record!");

            response.educationContents = _mapper.Map<List<EducationContentDto>>(educationContents);
            return CustomResponseDto<EducationContentListDtoViewModel>.Success(200, response);
        }
    }
}
