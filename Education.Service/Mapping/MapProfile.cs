using AutoMapper;
using Education.Core.DTOs;
using Education.Core.DTOs.ExamDtos;
using Education.Core.Models;

namespace Education.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UserEducationContentQuestionAnswer, UserEducationContentQuestionAnswerDto>().ReverseMap();
            CreateMap<UserEducationContentQuestionAnswer, UserEducationContentQuestionAnswerCreateDto>().ReverseMap();
            CreateMap<UserEducationContentQuestionAnswerDto, UserEducationContentQuestionAnswerCreateDto>().ReverseMap();
            CreateMap<UserEducationContentQuestionAnswer, EducationContentQuestionAnswerRequestDto>().ReverseMap();

            CreateMap<UserExamResult, UserExamResultDto>().ReverseMap();
            CreateMap<UserExamResult, UserExamResultCreateDto>().ReverseMap();
            CreateMap<UserExamResultDto, UserExamResultCreateDto>().ReverseMap();

            CreateMap<ITTest, ITTestDto>().ReverseMap();
            CreateMap<ITTest, ITTestCreateDto>().ReverseMap();
            CreateMap<ITTest, ITTestUpdateDto>().ReverseMap();


            CreateMap<UserExamQuestionAnswer, UserExamQuestionAnswerDto>().ReverseMap();
            CreateMap<UserExamQuestionAnswer, UserExamQuestionAnswerCreateDto>().ReverseMap();
            CreateMap<UserExamQuestionAnswerCreateDto, UserExamQuestionAnswerDto>().ReverseMap();


            CreateMap<Answer, AnswerDto>().ReverseMap();
            CreateMap<Answer, AnswerCreateDto>().ReverseMap();
            CreateMap<Answer, AnswerUpdateDto>().ReverseMap();
            CreateMap<AnswerDto, AnswerUpdateDto>().ReverseMap();
            CreateMap<AnswerDto, AnswerCreateDto>().ReverseMap();
            CreateMap<AnswerCreateDto, AnswerUpdateDto>().ReverseMap();

            CreateMap<AssignedEducation, AssignedEducationDto>().ReverseMap();
            CreateMap<AssignedEducation, AssignedEducationCreateDto>().ReverseMap();
            CreateMap<AssignedEducation, AssignedEducationUpdateDto>().ReverseMap();
            CreateMap<AssignedEducationDto, AssignedEducationUpdateDto>().ReverseMap();
            CreateMap<AssignedEducationDto, AssignedEducationCreateDto>().ReverseMap();

            CreateMap<EducationCategory, EducationCategoryDto>().ReverseMap();
            CreateMap<EducationCategory, EducationCategoryUpdateDto>().ReverseMap();
            CreateMap<EducationCategoryDto, EducationCategoryUpdateDto>().ReverseMap();
            CreateMap<EducationCategory, EducationCategoryCreateDto>().ReverseMap();
            CreateMap<EducationCategoryDto, EducationCategoryCreateDto>().ReverseMap();

            CreateMap<EducationContent, EducationContentDto>().ReverseMap();
            CreateMap<EducationContent, EducationContentCreateDto>().ReverseMap();
            CreateMap<EducationContent, EducationContentUpdateDto>().ReverseMap();
            CreateMap<EducationContentDto, EducationContentCreateDto>().ReverseMap();
            CreateMap<EducationContentDto, EducationContentUpdateDto>().ReverseMap();

            CreateMap<EducationContentQuestion, EducationContentQuestionDto>().ReverseMap();
            CreateMap<EducationContentQuestion, EducationContentQuestionCreateDto>().ReverseMap();
            CreateMap<EducationContentQuestion, EducationContentQuestionUpdateDto>().ReverseMap();
            CreateMap<EducationContentQuestionDto, EducationContentQuestionCreateDto>().ReverseMap();
            CreateMap<EducationContentQuestionDto, EducationContentQuestionUpdateDto>().ReverseMap();

            CreateMap<Core.Models.Education, EducationDto>().ReverseMap();
            CreateMap<Core.Models.Education, EducationCreateDto>().ReverseMap();
            CreateMap<Core.Models.Education, EducationUpdateDto>().ReverseMap();

            CreateMap<EducationSubject, EducationSubjectDto>().ReverseMap();
            CreateMap<EducationSubject, EducationSubjectCreateDto>().ReverseMap();
            CreateMap<EducationSubjectDto, EducationSubjectCreateDto>().ReverseMap();
            CreateMap<EducationSubject, EducationSubjectUpdateDto>().ReverseMap();
            CreateMap<EducationSubjectDto, EducationSubjectUpdateDto>().ReverseMap();

            CreateMap<ExamCategory, ExamCategoryDto>().ReverseMap();
            CreateMap<ExamCategory, ExamCategoryCreateDto>().ReverseMap();
            CreateMap<ExamCategoryDto, ExamCategoryCreateDto>().ReverseMap();
            CreateMap<ExamCategory, ExamCategoryUpdateDto>().ReverseMap();
            CreateMap<ExamCategoryDto, ExamCategoryUpdateDto>().ReverseMap();

            CreateMap<Exam, GetExamQuestionWithAnswersDto>().ReverseMap();
            CreateMap<Exam, ExamDto>().ReverseMap();
            CreateMap<Exam, ExamCreateDto>().ReverseMap();
            CreateMap<ExamDto, ExamCreateDto>().ReverseMap();
            CreateMap<Exam, ExamUpdateDto>().ReverseMap();
            CreateMap<ExamDto, ExamUpdateDto>().ReverseMap();

            CreateMap<ExamQuestion, ExamQuestionsDto>().ReverseMap();
            CreateMap<ExamQuestion, ExamQuestionsCreateDto>().ReverseMap();
            CreateMap<ExamQuestion, ExamQuestionsUpdateDto>().ReverseMap();
            CreateMap<ExamQuestionsDto, ExamQuestionsCreateDto>().ReverseMap();
            CreateMap<ExamQuestionsDto, ExamQuestionsUpdateDto>().ReverseMap();

            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Department, DepartmentCreateDto>().ReverseMap();
            CreateMap<DepartmentDto, DepartmentCreateDto>().ReverseMap();
            CreateMap<Department, DepartmentUpdateDto>().ReverseMap();
            CreateMap<DepartmentDto, DepartmentUpdateDto>().ReverseMap();

            CreateMap<DepartmentUnit, DepartmentUnitDto>().ReverseMap();
            CreateMap<DepartmentUnit, DepartmentUnitCreateDto>().ReverseMap();
            CreateMap<DepartmentUnitDto, DepartmentUnitCreateDto>().ReverseMap();
            CreateMap<DepartmentUnit, DepartmentUnitUpdateDto>().ReverseMap();
            CreateMap<DepartmentUnitDto, DepartmentUnitUpdateDto>().ReverseMap();

            CreateMap<QuestionCategory, QuestionCategoryDto>().ReverseMap();
            CreateMap<QuestionCategory, QuestionCategoryCreateDto>().ReverseMap();
            CreateMap<QuestionCategoryDto, QuestionCategoryCreateDto>().ReverseMap();
            CreateMap<QuestionCategory, QuestionCategoryUpdateDto>().ReverseMap();
            CreateMap<QuestionCategoryDto, QuestionCategoryUpdateDto>().ReverseMap();

            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<QuestionWtihAnswerDto, QuestionDto>().ReverseMap();
            CreateMap<Question, QuestionWtihAnswerDto>().ReverseMap();
            CreateMap<Question, QuestionCreateDto>().ReverseMap();
            CreateMap<QuestionDto, QuestionCreateDto>().ReverseMap();
            CreateMap<Question, QuestionUpdateDto>().ReverseMap();
            CreateMap<QuestionUpdateDto, QuestionUpdateDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<UserDto, UserCreateDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<UserDto, UserUpdateDto>().ReverseMap();

            CreateMap<UserEducationContentHistory, UserEducationContentHistoryDto>().ReverseMap();
            CreateMap<UserEducationContentHistory, UserEducationContentHistoryCreateDto>().ReverseMap();
            CreateMap<UserEducationContentHistory, UserEducationContentHistoryUpdateDto>().ReverseMap();
            CreateMap<UserEducationContentHistoryDto, UserEducationContentHistoryCreateDto>().ReverseMap();
            CreateMap<UserEducationContentHistoryDto, UserEducationContentHistoryUpdateDto>().ReverseMap();
        }
    }
}
