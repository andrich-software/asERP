using FluentValidation;

namespace asERP.Application.Features.ShopDomain.Commands.ShopDomainDelete;

public class ShopDomainDeleteValidator : AbstractValidator<ShopDomainDeleteCommand>
{
    public ShopDomainDeleteValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.");
    }
}
