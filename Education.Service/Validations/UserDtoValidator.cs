using Education.Core.DTOs;
using FluentValidation;

namespace Education.Service.Validations
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.UserName).NotNull().WithMessage("{PropertyName} is required!")
               .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Password).NotNull().WithMessage("{PropertyName} is required!")
               .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Email).NotNull().WithMessage("{PropertyName} is required!")
               .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.DepartmentUnitId).NotNull().GreaterThan(0).WithMessage("{PropertyName} must be greater 0");
        }
    }
    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.UserName).NotNull().WithMessage("{PropertyName} is required!")
               .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Password).NotNull().WithMessage("{PropertyName} is required!")
               .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Email).NotNull().WithMessage("{PropertyName} is required!")
               .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.DepartmentUnitId).NotNull().GreaterThan(0).WithMessage("{PropertyName} must be greater 0");
        }
    }
    public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("{PropertyName} must be grather 0");
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.UserName).NotNull().WithMessage("{PropertyName} is required!")
               .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Password).NotNull().WithMessage("{PropertyName} is required!")
               .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Email).NotNull().WithMessage("{PropertyName} is required!")
               .NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.DepartmentUnitId).NotNull().GreaterThan(0).WithMessage("{PropertyName} must be greater 0");
        }
    }
}
