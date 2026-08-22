using asERP.Application.Contracts.Persistence;
using asERP.Domain.Services;
using asERP.Domain.Validators;
using FluentValidation;

namespace asERP.Application.Features.ShopDomain.Commands.ShopDomainUpdate;

public class ShopDomainUpdateValidator : ShopDomainBaseValidator<ShopDomainUpdateCommand>
{
    public ShopDomainUpdateValidator(IShopDomainRepository shopDomainRepository)
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        // Host uniqueness is global (cross-tenant) — the host is the tenant-resolution boundary.
        RuleFor(p => p)
            .MustAsync(async (command, _) =>
            {
                if (!ShopHostNormalizer.TryNormalize(command.Host, out var host))
                {
                    return true; // the base Host rule already reports the format error
                }

                return await shopDomainRepository.HostIsUniqueAsync(host, command.Port, command.Id);
            })
            .WithMessage("This host and port combination is already bound to a shop.")
            .OverridePropertyName(nameof(ShopDomainUpdateCommand.Host));
    }
}
