using Education.Core.DTOs;
using FluentValidation;

namespace Education.Service.Validations
{
    public class EducationContentDtoValidator : AbstractValidator<EducationContentDto>
    {
        public EducationContentDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Url).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
    public class EducationContentCreateDtoValidator : AbstractValidator<EducationContentCreateDto>
    {
        public EducationContentCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required!")
             .NotEmpty().WithMessage("{PropertyName} is required!");
            //RuleFor(x => x.Url).NotNull().WithMessage("{PropertyName} is required!")
            //    .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }

    public class EducationContentUpdateDtoValidator : AbstractValidator<EducationContentUpdateDto>
    {
        public EducationContentUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required!")
             .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Url).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
