using Education.Core.DTOs;
using FluentValidation;


namespace Education.Service.Validations
{
    public class UserExamQuestionAnswerDtoValidator : AbstractValidator<UserExamQuestionAnswerDto>
    {
        public UserExamQuestionAnswerDtoValidator()
        {
            RuleFor(x => x.UserId)
               .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!")
               .NotNull().WithMessage("{PropertyName} is required!")
               .NotNull().WithMessage("{PropertyName} cannot be empty!");
            RuleFor(x => x.ExamId)
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
        }
    }
    public class UserExamQuestionAnswerCreateDtoValidator : AbstractValidator<UserExamQuestionAnswerCreateDto>
    {
        public UserExamQuestionAnswerCreateDtoValidator()
        {
            RuleFor(x => x.UserId)
             .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!")
             .NotNull().WithMessage("{PropertyName} is required!")
             .NotNull().WithMessage("{PropertyName} cannot be empty!");
            RuleFor(x => x.ExamId)
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
        }
    }
}
