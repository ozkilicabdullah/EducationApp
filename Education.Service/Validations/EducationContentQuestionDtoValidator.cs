using Education.Core.DTOs;
using Education.Core.ViewModel;
using FluentValidation;
namespace Education.Service.Validations
{
    public class EducationContentQuestionDtoValidator : AbstractValidator<EducationContentQuestionDto>
    {
        public EducationContentQuestionDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
            RuleFor(x => x.EducationContentId).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
            RuleFor(x => x.QuestionId).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
        }
    }
    public class EducationContentQuestioncCreateDtoValidator : AbstractValidator<EducationContentQuestionCreateDto>
    {
        public EducationContentQuestioncCreateDtoValidator()
        {
            RuleFor(x => x.EducationContentId).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
            RuleFor(x => x.QuestionId).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
        }
    }
    public class EducationContentQuestioncUpdateDtoValidator : AbstractValidator<EducationContentQuestionUpdateDto>
    {
        public EducationContentQuestioncUpdateDtoValidator()
        {
            RuleFor(x => x.EducationContentId).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
            RuleFor(x => x.QuestionId).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
        }
    }
    public class EducationContentQuestionCreatePayloadDtoValidator : AbstractValidator<EducationContentQuestionCreatePayloadDto>
    {
        public EducationContentQuestionCreatePayloadDtoValidator()
        {
            RuleFor(x => x.payload).NotEmpty().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.payload.EducationContentId).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
            RuleFor(x => x.payload.Questions).NotNull().WithMessage("{PropertyNAme} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
    public class EducationContentQuestionBulkCreateDtoValidator : AbstractValidator<EducationContentQuestionBulkCreateDto>
    {
        public EducationContentQuestionBulkCreateDtoValidator()
        {
            RuleFor(x => x.EducationContentId).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
            RuleFor(x => x.Questions).NotNull().WithMessage("{PropertyNAme} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
