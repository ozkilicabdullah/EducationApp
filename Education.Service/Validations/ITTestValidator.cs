using Education.Core.DTOs;
using FluentValidation;


namespace Education.Service.Validations
{
    public class ITTestValidator : AbstractValidator<ITTestDto>
    {
        public ITTestValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required!").NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
