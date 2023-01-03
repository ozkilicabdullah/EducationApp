using Education.Core.DTOs;
using FluentValidation;
namespace Education.Service.Validations
{
    public class EducationBatchAssigmentForUserDtoValidator : AbstractValidator<EducationBatchAssignmentForUsersDto>
    {
        public EducationBatchAssigmentForUserDtoValidator()
        {
            RuleFor(x => x.UserIds).Must(x => x == null || x.Any()).WithMessage("{PropertyName} is required");
            RuleFor(x => x.EducationId).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
        }
    }
}
