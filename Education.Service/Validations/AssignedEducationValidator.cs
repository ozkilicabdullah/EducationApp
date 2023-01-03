using Education.Core.DTOs;
using FluentValidation;
using System.Data;

namespace Education.Service.Validations
{
    public class AssignedEducationDtoValidator : AbstractValidator<AssignedEducationDto>
    {
        public AssignedEducationDtoValidator()
        {
            RuleFor(x => x.UserId)
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
            RuleFor(x => x.EducationId)
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
        }
    }
    public class AssignedEducationCreateDtoValidator : AbstractValidator<AssignedEducationCreateDto>
    {
        public AssignedEducationCreateDtoValidator()
        {
            RuleFor(x => x.UserId)
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
            RuleFor(x => x.EducationId)
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
        }
    }
    public class AssignedEducationUpdateDtoValidator : AbstractValidator<AssignedEducationUpdateDto>
    {
        public AssignedEducationUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
              .NotNull().WithMessage("{PropertyName} is required!")
              .NotEmpty().WithMessage("{PropertyName} is required!")
              .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");

            RuleFor(x => x.UserId)
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");

            RuleFor(x => x.EducationId)
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
        }
    }
}
