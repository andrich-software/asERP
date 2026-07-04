using asERP.Application.Contracts.Persistence;
using asERP.Application.Features.ShippingProviderRate.Commands.ShippingProviderRateCreate;
using FluentValidation;

namespace asERP.Application.Features.ShippingProviderRate.Commands.ShippingProviderRateUpdate;

public class ShippingProviderRateUpdateValidator : AbstractValidator<ShippingProviderRateUpdateCommand>
{
    public ShippingProviderRateUpdateValidator(
        IShippingProviderRateRepository shippingProviderRateRepository,
        ICountryRepository countryRepository)
    {
        RuleFor(r => r.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(r => r.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(r => r)
            .MustAsync(async (command, _) =>
                await shippingProviderRateRepository.IsNameUniqueForProviderAsync(command.ShippingProviderId, command.Name, command.Id))
            .WithMessage("A shipping option with this name already exists for this provider.")
            .When(r => !string.IsNullOrEmpty(r.Name) && r.ShippingProviderId != Guid.Empty);

        ShippingProviderRateCreateValidator.ApplySharedRules(this, countryRepository);
    }
}
