using Education.Core.DTOs;
using FluentValidation;


namespace Education.Service.Validations
{
    public class UserExamResultDtoValidator : AbstractValidator<UserExamResultDto>
    {
        public UserExamResultDtoValidator()
        {
            RuleFor(x => x.UserId)
               .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!")
               .NotNull().WithMessage("{PropertyName} is required!")
               .NotNull().WithMessage("{PropertyName} cannot be empty!");
            RuleFor(x => x.ExamId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!")
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} cannot be empty!");
            RuleFor(x => x.TotalQuestionCount)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!")
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} cannot be empty!");
            RuleFor(x => x.CorrectAnswerCount)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!")
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} cannot be empty!");
            RuleFor(x => x.ExamScore)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!")
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} cannot be empty!");
        }
    }
    public class UserExamResultCreateDtoValidator : AbstractValidator<UserExamResultCreateDto>
    {
        public UserExamResultCreateDtoValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!")
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} cannot be empty!");
            RuleFor(x => x.ExamId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!")
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} cannot be empty!");
            RuleFor(x => x.TotalQuestionCount)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!")
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} cannot be empty!");
            RuleFor(x => x.CorrectAnswerCount)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!")
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} cannot be empty!");
            RuleFor(x => x.ExamScore)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!")
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotNull().WithMessage("{PropertyName} cannot be empty!");
        }
    }
}
