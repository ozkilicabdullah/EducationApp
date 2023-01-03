using Education.Core.DTOs;
using FluentValidation;

namespace Education.Service.Validations
{
    public class DepartmentUnitDtoValidator : AbstractValidator<DepartmentUnitDto>
    {
        public DepartmentUnitDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.DepartmentId).NotNull().WithMessage("{PropertyName} is required!");
        }
    }
    public class DepartmentUnitCreateDtoValidator : AbstractValidator<DepartmentUnitCreateDto>
    {
        public DepartmentUnitCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.DepartmentId).NotNull().WithMessage("{PropertyName} is required!");
        }
    }
    public class DepartmentUnitUpdateDtoValidator : AbstractValidator<DepartmentUnitUpdateDto>
    {
        public DepartmentUnitUpdateDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.DepartmentId).NotNull().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.IFSDepartmentUnitCode).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MinimumLength(3).WithMessage("{PropertyName} must contain at least 3 characters.!");
        }
    }
}
