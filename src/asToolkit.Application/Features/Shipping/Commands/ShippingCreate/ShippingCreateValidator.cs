using asToolkit.Application.Contracts.Persistence;
using FluentValidation;

namespace asToolkit.Application.Features.Shipping.Commands.ShippingCreate;

/// <summary>
/// Field-level checks. Cross-entity rules that need loaded aggregates (destination country
/// allowed, measurements within the rate's limits, sales-item ownership) live in the handler.
/// </summary>
public class ShippingCreateValidator : AbstractValidator<ShippingCreateCommand>
{
    public ShippingCreateValidator(ISalesRepository salesRepository, IShippingProviderRateRepository rateRepository)
    {
        RuleFor(s => s.SalesId)
            .NotEmpty().WithMessage("SalesId is required.")
            .MustAsync(async (salesId, _) => await salesRepository.ExistsAsync(salesId))
            .WithMessage("The sales order does not exist.");

        RuleFor(s => s.ShippingProviderRateId)
            .NotEmpty().WithMessage("ShippingProviderRateId is required.")
            .MustAsync(async (rateId, _) => await rateRepository.ExistsAsync(rateId))
            .WithMessage("The shipping option does not exist.");

        RuleFor(s => s.TrackingNumber)
            .MaximumLength(100).WithMessage("Tracking number must not exceed 100 characters.");

        RuleFor(s => s.ShippingCost)
            .GreaterThanOrEqualTo(0).When(s => s.ShippingCost.HasValue)
            .WithMessage("Shipping cost must not be negative.");

        RuleFor(s => s.TaxRate)
            .GreaterThanOrEqualTo(0).WithMessage("Tax rate must not be negative.");

        RuleFor(s => s.WeightKg)
            .GreaterThan(0).When(s => s.WeightKg.HasValue)
            .WithMessage("Weight must be greater than 0.");

        RuleFor(s => s.LengthCm)
            .GreaterThan(0).When(s => s.LengthCm.HasValue)
            .WithMessage("Length must be greater than 0.");

        RuleFor(s => s.WidthCm)
            .GreaterThan(0).When(s => s.WidthCm.HasValue)
            .WithMessage("Width must be greater than 0.");

        RuleFor(s => s.HeightCm)
            .GreaterThan(0).When(s => s.HeightCm.HasValue)
            .WithMessage("Height must be greater than 0.");
    }
}
