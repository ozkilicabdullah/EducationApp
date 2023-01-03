using Education.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service.Validations
{
    public class ExamDtoValidator : AbstractValidator<ExamDto>
    {
        public ExamDtoValidator()
        {
            RuleFor(x => x.ExamType).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.StartDate).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.EndDate).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.IsQuestionsSortRandom).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.IsAnswersSortRandom).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Defination).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
    public class ExamCreateDtoValidator : AbstractValidator<ExamCreateDto>
    {
        public ExamCreateDtoValidator()
        {
            RuleFor(x => x.ExamType).NotNull().WithMessage("{PropertyName} is required!")
               .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.StartDate).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.EndDate).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.IsQuestionsSortRandom).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.IsAnswersSortRandom).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Defination).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
    public class ExamUpdateDtoValidator : AbstractValidator<ExamUpdateDto>
    {
        public ExamUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.ExamType).NotNull().WithMessage("{PropertyName} is required!")
               .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.StartDate).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.EndDate).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.IsQuestionsSortRandom).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.IsAnswersSortRandom).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Defination).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.ExcamCategoryId).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
        }
    }
}
