using Education.Core.DTOs;
using FluentValidation;

namespace Education.Service.Validations
{
    public class DepartmentDtoValidator : AbstractValidator<DepartmentDto>
    {
        public DepartmentDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
    public class DepartmentCreateDtoValidator : AbstractValidator<DepartmentCreateDto>
    {
        public DepartmentCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
    public class DepartmentUpdateDtoValidator : AbstractValidator<DepartmentUpdateDto>
    {
        public DepartmentUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
