using asERP.Application.Contracts.Persistence;
using FluentValidation;

namespace asERP.Application.Features.Setup.Commands.SetupInitialize;

public class SetupInitializeValidator : AbstractValidator<SetupInitializeCommand>
{
    private readonly IUserRepository _userRepository;

    public SetupInitializeValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(p => p.Email)
            .NotNull().WithMessage("{PropertyName} is required.")
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .EmailAddress().WithMessage("{PropertyName} must be a valid email address.");

        RuleFor(p => p.Password)
            .NotNull().WithMessage("{PropertyName} is required.")
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.Firstname)
            .NotNull().WithMessage("{PropertyName} is required.")
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must be 100 characters or fewer.");

        RuleFor(p => p.Lastname)
            .NotNull().WithMessage("{PropertyName} is required.")
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must be 100 characters or fewer.");

        // Tenant name is fully re-validated (incl. uniqueness) by the nested
        // TenantCreateCommand; this rule only fails fast before the user is created.
        RuleFor(p => p.TenantName)
            .NotNull().WithMessage("{PropertyName} is required.")
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must be 100 characters or fewer.");

        RuleFor(u => u)
            .MustAsync(UserUnique).WithMessage("User with the same email already exists.");
    }

    private async Task<bool> UserUnique(SetupInitializeCommand command, CancellationToken cancellationToken)
    {
        return !await _userRepository.EmailExistsAsync(command.Email);
    }
}
