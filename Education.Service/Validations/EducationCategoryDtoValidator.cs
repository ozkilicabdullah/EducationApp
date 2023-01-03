using Education.Core.DTOs;
using FluentValidation;
namespace Education.Service.Validations
{
    public class EducationCategoryDtoValidator : AbstractValidator<EducationCategoryDto>
    {
        public EducationCategoryDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
    public class EducationCategoryCreateDtoValidator : AbstractValidator<EducationCategoryCreateDto>
    {
        public EducationCategoryCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
    public class EducationCategoryUpdateDtoValidator : AbstractValidator<EducationCategoryUpdateDto>
    {
        public EducationCategoryUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
