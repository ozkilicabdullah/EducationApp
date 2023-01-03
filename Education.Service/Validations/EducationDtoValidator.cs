using Education.Core.DTOs;
using FluentValidation;

namespace Education.Service.Validations
{
    public class EducationDtoValidator : AbstractValidator<EducationDto>
    {
        public EducationDtoValidator()
        {
            RuleFor(x => x.Tittle).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
    public class EducationCreateDtoValidator : AbstractValidator<EducationCreateDto>
    {
        public EducationCreateDtoValidator()
        {
            RuleFor(x => x.Tittle).NotNull().WithMessage("{PropertyName} is required!")
            .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
    public class EducaitonUpdateDtoValidator : AbstractValidator<EducationUpdateDto>
    {
        public EducaitonUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Tittle).NotNull().WithMessage("{PropertyName} is required!")
            .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
