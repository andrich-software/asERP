using asERP.Application.Contracts.Persistence;
using FluentValidation;

namespace asERP.Application.Features.Returns.Commands.ReturnCreate;

/// <summary>
/// Field-level checks. Cross-entity rules that need loaded aggregates (item ownership,
/// shipped-quantity accounting, serial-number whole-line rule) live in the handler.
/// </summary>
public class ReturnCreateValidator : AbstractValidator<ReturnCreateCommand>
{
    public ReturnCreateValidator(ISalesRepository salesRepository)
    {
        RuleFor(r => r.SalesId)
            .NotEmpty().WithMessage("SalesId is required.")
            .MustAsync(async (salesId, _) => await salesRepository.ExistsAsync(salesId))
            .WithMessage("The sales order does not exist.");

        RuleFor(r => r.Items)
            .NotEmpty().WithMessage("At least one item is required.");

        RuleForEach(r => r.Items).ChildRules(item =>
        {
            item.RuleFor(i => i.SalesItemId)
                .NotEmpty().WithMessage("SalesItemId is required for every item.");

            item.RuleFor(i => i.Quantity)
                .GreaterThan(0).WithMessage("Item quantity must be greater than 0.");

            item.RuleFor(i => i.ReasonText)
                .MaximumLength(1000).WithMessage("Reason text must not exceed 1000 characters.");
        });

        RuleFor(r => r)
            .Must(r => r.Items.Select(i => i.SalesItemId).Distinct().Count() == r.Items.Count)
            .WithMessage("A sales item must not appear more than once.");

        RuleFor(r => r.ShippingProviderId)
            .NotEmpty().When(r => r.RequestLabel)
            .WithMessage("ShippingProviderId is required when a return label is requested.");

        RuleFor(r => r.Note)
            .MaximumLength(2000).WithMessage("Note must not exceed 2000 characters.");
    }
}
