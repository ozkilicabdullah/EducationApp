using Education.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service.Validations
{
    public class QuestionDtoValidator : AbstractValidator<QuestionDto>
    {
        public QuestionDtoValidator()
        {
            RuleFor(x => x.AnswerType).NotNull().WithMessage("{PropertyName} is required!")
               .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.QuestionCategoryId).NotNull().WithMessage("{PropertyName} is required!")
               .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.QuestionContent).NotNull().WithMessage("{PropertyName} is required!")
               .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
    public class QuestionCreateDtoValidator : AbstractValidator<QuestionCreateDto>
    {
        public QuestionCreateDtoValidator()
        {
            RuleFor(x => x.AnswerType).NotNull().WithMessage("{PropertyName} is required!")
               .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.QuestionCategoryId).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
            RuleFor(x => x.QuestionContent).NotNull().WithMessage("{PropertyName} is required!")
               .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
    public class QuestionUpdateDtoValidator : AbstractValidator<QuestionUpdateDto>
    {
        public QuestionUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.AnswerType).NotNull().WithMessage("{PropertyName} is required!")
               .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.QuestionCategoryId).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
            RuleFor(x => x.QuestionContent).NotNull().WithMessage("{PropertyName} is required!")
               .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
