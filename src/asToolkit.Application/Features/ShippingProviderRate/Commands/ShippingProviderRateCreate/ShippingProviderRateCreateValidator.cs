using asToolkit.Application.Contracts.Persistence;
using asToolkit.Domain.Interfaces;
using FluentValidation;

namespace asToolkit.Application.Features.ShippingProviderRate.Commands.ShippingProviderRateCreate;

public class ShippingProviderRateCreateValidator : AbstractValidator<ShippingProviderRateCreateCommand>
{
    public ShippingProviderRateCreateValidator(
        IShippingProviderRepository shippingProviderRepository,
        IShippingProviderRateRepository shippingProviderRateRepository,
        ICountryRepository countryRepository)
    {
        RuleFor(r => r.ShippingProviderId)
            .NotEmpty().WithMessage("ShippingProviderId is required.")
            .MustAsync(async (providerId, _) => await shippingProviderRepository.ExistsAsync(providerId))
            .WithMessage("The shipping provider does not exist.");

        RuleFor(r => r.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(r => r)
            .MustAsync(async (command, _) =>
                await shippingProviderRateRepository.IsNameUniqueForProviderAsync(command.ShippingProviderId, command.Name))
            .WithMessage("A shipping option with this name already exists for this provider.")
            .When(r => !string.IsNullOrEmpty(r.Name) && r.ShippingProviderId != Guid.Empty);

        ApplySharedRules(this, countryRepository);
    }

    /// <summary>Rules shared with the update validator: measurements, price and country checks.</summary>
    internal static void ApplySharedRules<T>(AbstractValidator<T> validator, ICountryRepository countryRepository)
        where T : IShippingProviderRateInputModel
    {
        validator.RuleFor(r => r.MaxLength).GreaterThan(0).WithMessage("MaxLength must be greater than 0.");
        validator.RuleFor(r => r.MaxWidth).GreaterThan(0).WithMessage("MaxWidth must be greater than 0.");
        validator.RuleFor(r => r.MaxHeight).GreaterThan(0).WithMessage("MaxHeight must be greater than 0.");
        validator.RuleFor(r => r.MaxWeight).GreaterThan(0).WithMessage("MaxWeight must be greater than 0.");
        validator.RuleFor(r => r.Price).GreaterThanOrEqualTo(0).WithMessage("Price must not be negative.");

        validator.RuleFor(r => r.AllowedCountryIds)
            .NotEmpty().WithMessage("At least one shipping country is required.")
            .Must(ids => ids.Distinct().Count() == ids.Count).WithMessage("Duplicate country ids are not allowed.");

        validator.RuleForEach(r => r.AllowedCountryIds)
            .MustAsync(async (countryId, _) => await countryRepository.ExistsAsync(countryId))
            .WithMessage((_, countryId) => $"Country {countryId} does not exist.");
    }
}
