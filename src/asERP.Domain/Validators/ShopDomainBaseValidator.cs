using asERP.Domain.Interfaces;
using asERP.Domain.Services;
using FluentValidation;

namespace asERP.Domain.Validators;

public class ShopDomainBaseValidator<T> : AbstractValidator<T> where T : IShopDomainInputModel
{
    public ShopDomainBaseValidator()
    {
        RuleFor(p => p.SalesChannelId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.Host)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Must(BeANormalizableHost)
            .WithMessage("{PropertyName} must be a plain hostname without scheme, port or path (e.g. shop.example.com).");

        // 0 is the "any port" sentinel — the normal case behind Cloudflare/reverse proxies.
        RuleFor(p => p.Port)
            .InclusiveBetween(0, 65535).WithMessage("{PropertyName} must be between 0 (any) and 65535.");
    }

    private static bool BeANormalizableHost(string host)
    {
        return ShopHostNormalizer.TryNormalize(host, out _);
    }
}
