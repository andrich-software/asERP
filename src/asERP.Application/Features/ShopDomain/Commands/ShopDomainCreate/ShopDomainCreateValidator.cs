using asERP.Application.Contracts.Persistence;
using asERP.Domain.Enums;
using asERP.Domain.Services;
using asERP.Domain.Validators;
using FluentValidation;

namespace asERP.Application.Features.ShopDomain.Commands.ShopDomainCreate;

public class ShopDomainCreateValidator : ShopDomainBaseValidator<ShopDomainCreateCommand>
{
    public ShopDomainCreateValidator(
        ISalesChannelRepository salesChannelRepository,
        IShopDomainRepository shopDomainRepository)
    {
        // Tenant ownership is implicit: GetByIdAsync goes through the tenant query filter, so a
        // foreign tenant's channel simply resolves to null.
        RuleFor(p => p.SalesChannelId)
            .MustAsync(async (salesChannelId, _) =>
            {
                var salesChannel = await salesChannelRepository.GetByIdAsync(salesChannelId, asNoTracking: true);
                return salesChannel is { Type: SalesChannelType.AsShop };
            })
            .WithMessage("Sales channel does not exist or is not an asShop channel.");

        // Host uniqueness is global (cross-tenant) — the host is the tenant-resolution boundary.
        RuleFor(p => p)
            .MustAsync(async (command, _) =>
            {
                if (!ShopHostNormalizer.TryNormalize(command.Host, out var host))
                {
                    return true; // the base Host rule already reports the format error
                }

                return await shopDomainRepository.HostIsUniqueAsync(host, command.Port);
            })
            .WithMessage("This host and port combination is already bound to a shop.")
            .OverridePropertyName(nameof(ShopDomainCreateCommand.Host));
    }
}
