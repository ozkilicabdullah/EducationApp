using Education.Core.DTOs;
using FluentValidation;

namespace Education.Service.Validations
{
    public class QuestionCategoryDtoValidator : AbstractValidator<QuestionCategoryDto>
    {
        public QuestionCategoryDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
    public class QuestionCategoryCreateDtoValidator : AbstractValidator<QuestionCategoryCreateDto>
    {
        public QuestionCategoryCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required!")
            .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
    public class QuestionCategoryUpdateDtoValidator : AbstractValidator<QuestionCategoryUpdateDto>
    {
        public QuestionCategoryUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required!")
            .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
