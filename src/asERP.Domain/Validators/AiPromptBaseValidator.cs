using FluentValidation;
using asERP.Domain.Interfaces;

namespace asERP.Domain.Validators;

public class AiPromptBaseValidator<T> : AbstractValidator<T> where T : IAiPromptInputModel
{
    public AiPromptBaseValidator()
    {
        RuleFor(p => p.Identifier)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(p => p.PromptText)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
    }
}