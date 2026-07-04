using FluentValidation;

namespace asERP.Application.Features.Country.Commands.CountryDelete;

public class CountryDeleteValidator : AbstractValidator<CountryDeleteCommand>
{
    public CountryDeleteValidator()
    {
        RuleFor(p => p.Id)
            .NotNull()
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} cannot be empty.");
    }
}
