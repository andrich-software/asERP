using FluentValidation;

namespace asERP.Application.Features.Shipping.Commands.ShippingUpdate;

public class ShippingUpdateValidator : AbstractValidator<ShippingUpdateCommand>
{
    public ShippingUpdateValidator()
    {
        RuleFor(s => s.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(s => s.TrackingNumber)
            .MaximumLength(100).WithMessage("Tracking number must not exceed 100 characters.");

        RuleFor(s => s.TrackingUrl)
            .MaximumLength(512).WithMessage("Tracking URL must not exceed 512 characters.");

        RuleFor(s => s.ShippingCost)
            .GreaterThanOrEqualTo(0).When(s => s.ShippingCost.HasValue)
            .WithMessage("Shipping cost must not be negative.");

        RuleFor(s => s.TaxRate)
            .GreaterThanOrEqualTo(0).When(s => s.TaxRate.HasValue)
            .WithMessage("Tax rate must not be negative.");

        RuleFor(s => s.Status)
            .IsInEnum().When(s => s.Status.HasValue)
            .WithMessage("Status must be a valid shipping status.");
    }
}
