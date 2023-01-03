using Education.Core.DTOs;
using FluentValidation;
namespace Education.Service.Validations
{
    public class ExamQuestionDtoValidator : AbstractValidator<ExamQuestionsDto>
    {
        public ExamQuestionDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
            RuleFor(x => x.QuestionId).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
            RuleFor(x => x.ExamId).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
        }
    }
    public class ExamQuestionCreateDtoValidator : AbstractValidator<ExamQuestionsCreateDto>
    {
        public ExamQuestionCreateDtoValidator()
        {
            RuleFor(x => x.ExamId).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
            RuleFor(x => x.QuestionId).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
        }
    }
    public class ExamQuestionUpdateDtoValidator : AbstractValidator<ExamQuestionsUpdateDto>
    {
        public ExamQuestionUpdateDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
            RuleFor(x => x.ExamId).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
            RuleFor(x => x.QuestionId).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
        }
    }
}
