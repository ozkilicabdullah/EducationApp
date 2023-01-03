using Education.Core.DTOs;
using FluentValidation;

namespace Education.Service.Validations
{
    public class EducationSubjectDtoValidator : AbstractValidator<EducationSubjectDto>
    {
        public EducationSubjectDtoValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.EducationId).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
    public class EducationSubjectCreateDtoValidator : AbstractValidator<EducationSubjectCreateDto>
    {
        public EducationSubjectCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.EducationId).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
    public class EducationSubjectUpdateDtoValidator : AbstractValidator<EducationSubjectUpdateDto>
    {
        public EducationSubjectUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Title).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.EducationId).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
