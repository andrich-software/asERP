using asToolkit.Application.Contracts.Persistence;
using FluentValidation;

namespace asToolkit.Application.Features.ShippingProvider.Commands.ShippingProviderUpdate;

public class ShippingProviderUpdateValidator : AbstractValidator<ShippingProviderUpdateCommand>
{
    public ShippingProviderUpdateValidator(IShippingProviderRepository shippingProviderRepository)
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.")
            .MustAsync(async (command, name, _) => await shippingProviderRepository.IsNameUniqueAsync(name, command.Id))
            .WithMessage("A shipping provider with this name already exists.");

        RuleFor(p => p.Type)
            .IsInEnum().WithMessage("Type must be a valid shipping provider type.");

        RuleFor(p => p.TrackingPollIntervalSeconds)
            .GreaterThanOrEqualTo(60).WithMessage("Tracking poll interval must be at least 60 seconds.");
    }
}
