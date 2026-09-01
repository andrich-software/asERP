namespace asERP.Domain.Wrapper;

/// <summary>
/// Stable, machine-readable error codes. A client branches or looks up a translation by code and
/// treats <see cref="Error.Message"/> only as a developer-facing fallback.
/// <para>
/// They live in the Domain rather than beside each feature because <c>asERP.Domain</c> is the one
/// project the Uno client already references, so it can use these constants instead of literals.
/// </para>
/// <para>
/// The taxonomy is deliberately coarse: <c>{entity}.{kind}</c>, where the kind mirrors
/// <see cref="ErrorType"/>. Split a code when a client genuinely needs to tell two failures apart,
/// but never reuse one for an unrelated situation.
/// </para>
/// </summary>
public static class ErrorCodes
{
    public static class Account
    {
        public const string AlreadyExists = "account.already_exists";
        public const string Invalid = "account.invalid";
        public const string NotFound = "account.not_found";
        public const string Unauthorized = "account.unauthorized";
    }

    public static class AiModel
    {
        public const string Invalid = "ai_model.invalid";
        public const string NotFound = "ai_model.not_found";
    }

    public static class AiPrompt
    {
        public const string NotFound = "ai_prompt.not_found";
    }

    public static class Auth
    {
        public const string Forbidden = "auth.forbidden";
        public const string Invalid = "auth.invalid";
        public const string Unauthorized = "auth.unauthorized";
    }

    public static class Category
    {
        public const string NotFound = "category.not_found";
    }

    public static class Country
    {
        public const string NotFound = "country.not_found";
    }

    public static class Customer
    {
        public const string Invalid = "customer.invalid";
        public const string NotFound = "customer.not_found";
    }

    public static class Feed
    {
        public const string Invalid = "feed.invalid";
        public const string NotFound = "feed.not_found";
    }

    public static class GoodsReceipt
    {
        public const string NotFound = "goods_receipt.not_found";
    }

    public static class ImportExport
    {
        public const string Invalid = "import_export.invalid";
    }

    public static class Invoice
    {
        public const string AlreadyExists = "invoice.already_exists";
        public const string Invalid = "invoice.invalid";
        public const string NotFound = "invoice.not_found";
        public const string Unexpected = "invoice.unexpected";
    }

    public static class Manufacturer
    {
        public const string NotFound = "manufacturer.not_found";
    }

    public static class OAuthAppSettings
    {
        public const string Invalid = "oauth_app_settings.invalid";
    }

    public static class Product
    {
        public const string Invalid = "product.invalid";
        public const string NotFound = "product.not_found";
    }

    public static class ProductAttribute
    {
        public const string Invalid = "product_attribute.invalid";
        public const string NotFound = "product_attribute.not_found";
    }

    public static class ProductImage
    {
        public const string Invalid = "product_image.invalid";
        public const string NotFound = "product_image.not_found";
    }

    public static class Request
    {
        public const string Forbidden = "request.forbidden";
        public const string Invalid = "request.invalid";
        public const string NotFound = "request.not_found";
        public const string Unauthorized = "request.unauthorized";
        public const string Unexpected = "request.unexpected";
    }

    public static class ReturnCarrier
    {
        public const string Invalid = "return_carrier.invalid";
    }

    public static class Returns
    {
        public const string Invalid = "returns.invalid";
        public const string NotFound = "returns.not_found";
    }

    public static class Sales
    {
        public const string Invalid = "sales.invalid";
        public const string NotFound = "sales.not_found";
    }

    public static class SalesChannel
    {
        public const string Invalid = "sales_channel.invalid";
        public const string NotFound = "sales_channel.not_found";
    }

    public static class SalesChannelOauth
    {
        public const string Invalid = "sales_channel_oauth.invalid";
        public const string NotFound = "sales_channel_oauth.not_found";
    }

    public static class Setting
    {
        public const string Invalid = "setting.invalid";
        public const string NotFound = "setting.not_found";
    }

    public static class Setup
    {
        public const string Forbidden = "setup.forbidden";
        public const string Invalid = "setup.invalid";
    }

    public static class Shipping
    {
        public const string Invalid = "shipping.invalid";
        public const string NotFound = "shipping.not_found";
    }

    public static class ShippingCarrier
    {
        public const string Invalid = "shipping_carrier.invalid";
    }

    public static class ShippingProvider
    {
        public const string Invalid = "shipping_provider.invalid";
    }

    public static class ShippingProviderRate
    {
        public const string Invalid = "shipping_provider_rate.invalid";
    }

    public static class ShopDomain
    {
        public const string Invalid = "shop_domain.invalid";
        public const string NotFound = "shop_domain.not_found";
    }

    public static class Superadmin
    {
        public const string AlreadyExists = "superadmin.already_exists";
        public const string Forbidden = "superadmin.forbidden";
        public const string Invalid = "superadmin.invalid";
        public const string NotFound = "superadmin.not_found";
        public const string Unauthorized = "superadmin.unauthorized";
        public const string Unexpected = "superadmin.unexpected";
    }

    public static class SystemOAuthSettings
    {
        public const string Invalid = "system_oauth_settings.invalid";
    }

    public static class TaxClass
    {
        public const string NotFound = "tax_class.not_found";
    }

    public static class Tenant
    {
        public const string Forbidden = "tenant.forbidden";
        public const string Invalid = "tenant.invalid";
        public const string NotFound = "tenant.not_found";
    }

    public static class TenantEmailSettings
    {
        public const string Invalid = "tenant_email_settings.invalid";
        public const string NotFound = "tenant_email_settings.not_found";
        public const string Unexpected = "tenant_email_settings.unexpected";
    }

    public static class TenantOauthAppSettings
    {
        public const string Invalid = "tenant_oauth_app_settings.invalid";
        public const string NotFound = "tenant_oauth_app_settings.not_found";
    }

    public static class User
    {
        public const string Invalid = "user.invalid";
    }

    public static class Warehouse
    {
        public const string Invalid = "warehouse.invalid";
        public const string NotFound = "warehouse.not_found";
    }
}
