namespace asToolkit.Client.Core.Constants;

/// <summary>
/// Centralized API endpoint paths.
/// Base URL is configured via appsettings.json or during login.
/// </summary>
public static class ApiEndpoints
{
    public const string ApiVersion = "v1";
    public const string ApiBase = $"/api/{ApiVersion}";

    // Auth
    public static class Auth
    {
        public const string Base = $"{ApiBase}/auth";
        public const string Login = $"{Base}/login";
        public const string Register = $"{Base}/register";
        public const string RefreshToken = $"{Base}/refresh";
    }

    // AI Models
    public static class AiModels
    {
        public const string Base = $"{ApiBase}/aimodels";
        public static string ById(Guid id) => $"{Base}/{id}";
    }

    // AI Prompts
    public static class AiPrompts
    {
        public const string Base = $"{ApiBase}/aiprompts";
        public static string ById(Guid id) => $"{Base}/{id}";
    }

    // Countries
    public static class Countries
    {
        public const string Base = $"{ApiBase}/countries";
    }

    // Global search
    public static class Search
    {
        public const string Base = $"{ApiBase}/search";
    }

    // Customers
    public static class Customers
    {
        public const string Base = $"{ApiBase}/customers";
        public const string Search = $"{Base}/search";
        public static string ById(Guid id) => $"{Base}/{id}";
    }

    // Saless
    public static class Saless
    {
        public const string Base = $"{ApiBase}/saless";
        public static string ById(Guid id) => $"{Base}/{id}";
        public static string ByCustomer(int customerId) => $"{Base}/customer/{customerId}";
        public static string ShippableItems(Guid id) => $"{Base}/{id}/shippable-items";
        public static string ShippingOptions(Guid id) => $"{Base}/{id}/shipping-options";
        public static string Cancel(Guid id) => $"{Base}/{id}/cancel";
    }

    // Shippings
    public static class Shippings
    {
        public const string Base = $"{ApiBase}/shippings";
        public static string ById(Guid id) => $"{Base}/{id}";
        public static string Label(Guid id) => $"{Base}/{id}/label";
        public static string LabelRetry(Guid id) => $"{Base}/{id}/label/retry";
        public static string PackingSlip(Guid id) => $"{Base}/{id}/packing-slip";
        public static string Cancel(Guid id) => $"{Base}/{id}/cancel";
    }

    // Products
    public static class Products
    {
        public const string Base = $"{ApiBase}/products";
        public static string ById(Guid id) => $"{Base}/{id}";
        public static string GenerateVariants(Guid id) => $"{Base}/{id}/variants/generate";

        // Images (sub-resource)
        public static string Images(Guid productId) => $"{Base}/{productId}/images";
        public static string ImageById(Guid productId, Guid imageId) => $"{Base}/{productId}/images/{imageId}";
        public static string ImagesReorder(Guid productId) => $"{Base}/{productId}/images/reorder";
        public static string ImageContent(Guid productId, Guid imageId, bool thumbnail) =>
            $"{Base}/{productId}/images/{imageId}/content{(thumbnail ? "?thumbnail=true" : string.Empty)}";
    }

    // Warehouses
    public static class Warehouses
    {
        public const string Base = $"{ApiBase}/warehouses";
        public static string ById(Guid id) => $"{Base}/{id}";
    }

    // Goods Receipts
    public static class GoodsReceipts
    {
        public const string Base = $"{ApiBase}/goodsreceipts";
        public static string ById(Guid id) => $"{Base}/{id}";
    }

    // Invoices
    public static class Invoices
    {
        public const string Base = $"{ApiBase}/invoices";
        public static string ById(Guid id) => $"{Base}/{id}";
    }

    // Sales Channels
    public static class SalesChannels
    {
        public const string Base = $"{ApiBase}/saleschannels";
        public static string ById(Guid id) => $"{Base}/{id}";
        public static string Sync(Guid id, string operation) => $"{Base}/{id}/sync/{operation}";
        public static string TestConnection(Guid id) => $"{Base}/{id}/test-connection";
        public static string SyncRuns(Guid id) => $"{Base}/{id}/sync-runs";
        public static string SyncLogs(Guid id) => $"{Base}/{id}/sync-logs";
        public static string SyncStatus(Guid id) => $"{Base}/{id}/sync-status";
        public static string DeadLetter(Guid id) => $"{Base}/{id}/outbox/dead-letter";
        public static string RetryDeadLetter(Guid id, Guid outboxId) => $"{Base}/{id}/outbox/{outboxId}/retry";
        public static string OAuthStart(Guid id, string provider) => $"{Base}/{id}/oauth/{provider}/start";
        public static string OAuthDisconnect(Guid id, string provider) => $"{Base}/{id}/oauth/{provider}/disconnect";
    }

    public static class TenantOAuthAppSettings
    {
        public const string Base = $"{ApiBase}/tenant/oauth-app-settings";
        public static string ByProvider(string provider) => $"{Base}/{provider}";
    }

    public static class SystemOAuthAppSettings
    {
        public const string Base = $"{ApiBase}/superadmin/oauth-app-settings";
        public static string ByProvider(string provider) => $"{Base}/{provider}";
    }

    public static class GlobalSettings
    {
        public const string Base = $"{ApiBase}/superadmin/global-settings";
    }

    // Manufacturers
    public static class Manufacturers
    {
        public const string Base = $"{ApiBase}/manufacturers";
        public static string ById(Guid id) => $"{Base}/{id}";
    }

    // Tax Classes
    public static class TaxClasses
    {
        public const string Base = $"{ApiBase}/taxclasses";
        public static string ById(Guid id) => $"{Base}/{id}";
    }

    // Product Attributes
    public static class ProductAttributes
    {
        public const string Base = $"{ApiBase}/productattributes";
        public static string ById(Guid id) => $"{Base}/{id}";
    }

    // Settings
    public static class Settings
    {
        public const string Base = $"{ApiBase}/settings";
    }

    // Statistics
    public static class Statistics
    {
        public const string Base = $"{ApiBase}/statistics";
        public const string SalesToday = $"{Base}/SalesToday";
        public const string SalessToday = $"{Base}/SalessToday";
        public const string CustomersToday = $"{Base}/CustomersToday";
        public const string ProductsToday = $"{Base}/ProductsToday";
        public const string SalessLatest = $"{Base}/SalessLatest";
        public const string ProductsBestSelling = $"{Base}/ProductsBestSelling";
        public const string RevenueChart = $"{Base}/RevenueChart";
    }

    // Web statistics (sales-channel visitor analytics)
    public static class WebStatistics
    {
        public const string Base = $"{ApiBase}/webstatistics";
        public const string Sessions = $"{Base}/Sessions";
        public const string TopProducts = $"{Base}/TopProducts";
    }

    // Tenants
    public static class Tenants
    {
        public const string Base = $"{ApiBase}/tenants";
        public static string ById(Guid id) => $"{Base}/{id}";
        public static string UserSearch(Guid tenantId) => $"{Base}/{tenantId}/users/search";
        public static string Users(Guid tenantId) => $"{Base}/{tenantId}/users";
    }

    // Users
    public static class Users
    {
        public const string Base = $"{ApiBase}/users";
        public static string ById(string id) => $"{Base}/{id}";
    }

    // Account (current user)
    public static class Account
    {
        public const string Base = $"{ApiBase}/account";
        public const string Me = $"{Base}/me";
        public const string ChangePassword = $"{Base}/change-password";
    }

    // Superadmin
    public static class Superadmin
    {
        public const string Base = $"{ApiBase}/superadmin";
        public const string Users = $"{Base}/users";
        public static string UserById(string id) => $"{Users}/{id}";
        public const string Tenants = $"{Base}/tenants";
        public static string TenantById(Guid id) => $"{Tenants}/{id}";

        // User-Tenant management endpoints
        public static string UserTenants(string userId) => $"{Users}/{userId}/tenants";
        public static string UserTenantById(string userId, Guid tenantId) => $"{Users}/{userId}/tenants/{tenantId}";
    }
}