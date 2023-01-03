using Education.Core.DTOs;
using FluentValidation;

namespace Education.Service.Validations
{
    public class AnswerDtoValidator : AbstractValidator<AnswerDto>
    {
        public AnswerDtoValidator()
        {
            RuleFor(x => x.AnswerContent).NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.IsCorrect).NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
    public class AnswerCreateDtoValdiator : AbstractValidator<AnswerCreateDto>
    {
        public AnswerCreateDtoValdiator()
        {
            RuleFor(x => x.AnswerContent).NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.IsCorrect).NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
    public class AnswerUpdateDtoValdiator : AbstractValidator<AnswerUpdateDto>
    {
        public AnswerUpdateDtoValdiator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.AnswerContent).NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.IsCorrect).NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
