using asToolkit.Application.Contracts.Persistence;
using FluentValidation;

namespace asToolkit.Application.Features.ShippingProvider.Commands.ShippingProviderCreate;

public class ShippingProviderCreateValidator : AbstractValidator<ShippingProviderCreateCommand>
{
    public ShippingProviderCreateValidator(IShippingProviderRepository shippingProviderRepository)
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.")
            .MustAsync(async (name, _) => await shippingProviderRepository.IsNameUniqueAsync(name))
            .WithMessage("A shipping provider with this name already exists.");

        RuleFor(p => p.Type)
            .IsInEnum().WithMessage("Type must be a valid shipping provider type.");

        RuleFor(p => p.TrackingPollIntervalSeconds)
            .GreaterThanOrEqualTo(60).WithMessage("Tracking poll interval must be at least 60 seconds.");
    }
}
