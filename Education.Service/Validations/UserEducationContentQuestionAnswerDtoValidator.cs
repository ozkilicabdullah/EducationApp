using Education.Core.DTOs;
using Education.Core.Models;
using FluentValidation;

namespace Education.Service.Validations
{
    public class UserEducationContentQuestionAnswerDtoValidator : AbstractValidator<UserEducationContentQuestionAnswer>
    {
        public UserEducationContentQuestionAnswerDtoValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!")
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} cannot be empty!");
            RuleFor(x => x.AnswerId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!")
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} cannot be empty!");
            RuleFor(x => x.QuestionId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!")
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} cannot be empty!");
            RuleFor(x => x.EducationContentId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!")
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} cannot be empty!");
        }
    }
    public class UserEducationContentQuestionAnswerCreateDtoValidator : AbstractValidator<UserEducationContentQuestionAnswerCreateDto>
    {
        public UserEducationContentQuestionAnswerCreateDtoValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!")
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} cannot be empty!");
            RuleFor(x => x.AnswerId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!")
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} cannot be empty!");
            RuleFor(x => x.QuestionId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!")
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} cannot be empty!");
            RuleFor(x => x.EducationContentId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!")
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} cannot be empty!");

        }
    }
}
