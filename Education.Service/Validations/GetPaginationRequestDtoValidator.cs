using Education.Core.DTOs;
using FluentValidation;
namespace Education.Service.Validations
{
    public class GetPaginationRequestDtoValidator : AbstractValidator<GetPaginationRequestDto>
    {
        public GetPaginationRequestDtoValidator()
        {
            RuleFor(x => x.PageSize).GreaterThan(0).WithMessage("{PropertyName} must be grather than 0!");
            RuleFor(x => x.PageNo).GreaterThan(0).WithMessage("{PropertyName} must be grather than 0!");
        }
    }
}
