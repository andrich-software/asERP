using FluentValidation;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Interfaces;

namespace asToolkit.Domain.Validators;

public class SalesChannelBaseValidator<T> : AbstractValidator<T> where T : ISalesChannelInputModel
{
    /// <param name="requirePassword">
    /// When <c>true</c> (create), a password is required for credential-based channels.
    /// When <c>false</c> (update), an empty password means "keep the stored secret unchanged",
    /// so it is not required — the secret is write-only and never round-tripped to the client.
    /// </param>
    public SalesChannelBaseValidator(bool requirePassword = true)
    {
        // SalesChannelType must be a valid enum value
        RuleFor(p => p.SalesChannelType)
            .IsInEnum().WithMessage("{PropertyName} is invalid.");

        // Name is always required
        RuleFor(p => p.Name)
            .NotNull().WithMessage("{PropertyName} is required.")
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

        // URL is required only for Shopware6, WooCommerce
        RuleFor(p => p.Url)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Must(BeAValidUrl).WithMessage("{PropertyName} must be a valid URL.")
            .When(p => RequiresUrl(p.SalesChannelType));

        // Username is required for all types except PointOfSale
        RuleFor(p => p.Username)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .When(p => RequiresCredentials(p.SalesChannelType));

        // Password is required for all types except PointOfSale — but only on create.
        // On update an empty password signals "keep the existing secret".
        if (requirePassword)
        {
            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .When(p => RequiresCredentials(p.SalesChannelType));
        }
    }

    private static bool BeAValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }

    private static bool RequiresUrl(SalesChannelType type)
    {
        // WooCommerceDatabase talks to MySQL directly, but still needs the shop's base URL
        // to build the public product-image download links.
        return type is SalesChannelType.Shopware6
            or SalesChannelType.WooCommerce
            or SalesChannelType.WooCommerceDatabase;
    }

    private static bool RequiresCredentials(SalesChannelType type)
    {
        return type != SalesChannelType.PointOfSale;
    }
}