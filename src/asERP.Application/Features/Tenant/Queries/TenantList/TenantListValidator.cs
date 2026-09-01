using FluentValidation;

namespace asERP.Application.Features.Tenant.Queries.TenantList;

public class TenantListValidator : AbstractValidator<TenantListQuery>
{
    public TenantListValidator()
    {
        RuleFor(p => p.UserId)
            .NotNull().WithMessage("{PropertyName} must not be null.")
            .NotEmpty().WithMessage("{PropertyName} is required.");

        // No rules on PageNumber/PageSize: paging is zero-based and ToPaginatedListAsync already
        // clamps both (negative page → 0, size ≤ 0 → 10, size > 200 → 200). Rejecting those values
        // here would turn requests the rest of the system serves fine into 400s.
    }
}
