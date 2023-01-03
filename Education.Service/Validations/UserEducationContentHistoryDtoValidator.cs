using Education.Core.DTOs;
using FluentValidation;

namespace Education.Service.Validations
{
    public class UserEducationContentHistoryDtoValidator : AbstractValidator<UserEducationContentHistoryDto>
    {
        public UserEducationContentHistoryDtoValidator()
        {
            RuleFor(x => x.UserId)
                          .NotNull().WithMessage("{PropertyName} is required!")
                          .NotEmpty().WithMessage("{PropertyName} is required!")
                          .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");

            RuleFor(x => x.EducationContentId)
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");

            RuleFor(x => x.ActionType)
              .NotNull().WithMessage("{PropertyName} is required!")
              .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
    public class UserEducationContentHistoryCreateDtoValidator : AbstractValidator<UserEducationContentHistoryCreateDto>
    {
        public UserEducationContentHistoryCreateDtoValidator()
        {
            RuleFor(x => x.UserId)
                          .NotNull().WithMessage("{PropertyName} is required!")
                          .NotEmpty().WithMessage("{PropertyName} is required!")
                          .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");

            RuleFor(x => x.EducationContentId)
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");

            RuleFor(x => x.ActionType)
              .NotNull().WithMessage("{PropertyName} is required!")
              .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
    public class UserEducationContentHistoryUpdateDtoValidator : AbstractValidator<UserEducationContentHistoryUpdateDto>
    {
        public UserEducationContentHistoryUpdateDtoValidator()
        {

            RuleFor(x => x.Id)
                          .NotNull().WithMessage("{PropertyName} is required!")
                          .NotEmpty().WithMessage("{PropertyName} is required!")
                          .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");

            RuleFor(x => x.UserId)
                          .NotNull().WithMessage("{PropertyName} is required!")
                          .NotEmpty().WithMessage("{PropertyName} is required!")
                          .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
          
            RuleFor(x => x.EducationContentId)
                .NotNull().WithMessage("{PropertyName} is required!")
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0!");
          
            RuleFor(x => x.ActionType)
              .NotNull().WithMessage("{PropertyName} is required!")
              .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
