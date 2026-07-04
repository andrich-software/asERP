using System.Text.Json.Serialization;
using asToolkit.Client.Core.Models;
using asToolkit.Client.Features.Auth.Models;
using asToolkit.Domain.Dtos.Account;
using asToolkit.Domain.Dtos.AiModel;
using asToolkit.Domain.Dtos.AiPrompt;
using asToolkit.Domain.Dtos.Auth;
using asToolkit.Domain.Dtos.Country;
using asToolkit.Domain.Dtos.Customer;
using asToolkit.Domain.Dtos.Invoice;
using asToolkit.Domain.Dtos.Manufacturer;
using asToolkit.Domain.Dtos.Sales;
using asToolkit.Domain.Dtos.Search;
using asToolkit.Domain.Dtos.Product;
using asToolkit.Domain.Dtos.ProductAttribute;
using asToolkit.Domain.Dtos.SalesChannel;
using asToolkit.Domain.Dtos.ServerInfo;
using asToolkit.Domain.Dtos.Shipping;
using asToolkit.Domain.Dtos.Statistic;
using asToolkit.Domain.Dtos.Superadmin;
using asToolkit.Domain.Dtos.TaxClass;
using asToolkit.Domain.Dtos.Tenant;
using asToolkit.Domain.Dtos.User;
using asToolkit.Domain.Dtos.Warehouse;
using asToolkit.Domain.Dtos.WebAnalytics;

namespace asToolkit.Client.Core.Json;

[JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]

// PaginatedResponse<T> types
[JsonSerializable(typeof(PaginatedResponse<AiModelListDto>))]
[JsonSerializable(typeof(PaginatedResponse<AiPromptListDto>))]
[JsonSerializable(typeof(PaginatedResponse<TenantListDto>))]
[JsonSerializable(typeof(PaginatedResponse<ProductListDto>))]
[JsonSerializable(typeof(PaginatedResponse<WarehouseListDto>))]
[JsonSerializable(typeof(PaginatedResponse<CustomerListDto>))]
[JsonSerializable(typeof(PaginatedResponse<CustomerListWithAddressDto>))]
[JsonSerializable(typeof(PaginatedResponse<TaxClassListDto>))]
[JsonSerializable(typeof(PaginatedResponse<ProductAttributeListDto>))]
[JsonSerializable(typeof(PaginatedResponse<InvoiceListDto>))]
[JsonSerializable(typeof(PaginatedResponse<SalesListDto>))]
[JsonSerializable(typeof(PaginatedResponse<ManufacturerListDto>))]
[JsonSerializable(typeof(PaginatedResponse<SalesChannelListDto>))]
[JsonSerializable(typeof(PaginatedResponse<CountryListDto>))]
[JsonSerializable(typeof(PaginatedResponse<UserListDto>))]
[JsonSerializable(typeof(PaginatedResponse<ShipmentListItemDto>))]

// ApiResponse<T> types
[JsonSerializable(typeof(ApiResponse<TenantDetailDto>))]
[JsonSerializable(typeof(ApiResponse<Guid>))]
[JsonSerializable(typeof(ApiResponse<UserListDto>))]
[JsonSerializable(typeof(ApiResponse<ProductDetailDto>))]
[JsonSerializable(typeof(ApiResponse<ProductImageDto>))]
[JsonSerializable(typeof(ApiResponse<List<ProductImageDto>>))]
[JsonSerializable(typeof(ApiResponse<WarehouseDetailDto>))]
[JsonSerializable(typeof(ApiResponse<CustomerDetailDto>))]
[JsonSerializable(typeof(ApiResponse<TaxClassDetailDto>))]
[JsonSerializable(typeof(ApiResponse<ProductAttributeDetailDto>))]
[JsonSerializable(typeof(ApiResponse<SuperadminTenantDetailDto>))]
[JsonSerializable(typeof(ApiResponse<InvoiceDetailDto>))]
[JsonSerializable(typeof(ApiResponse<SalesTodayDto>))]
[JsonSerializable(typeof(ApiResponse<RevenueChartDto>))]
[JsonSerializable(typeof(ApiResponse<SalessTodayDto>))]
[JsonSerializable(typeof(ApiResponse<CustomersTodayDto>))]
[JsonSerializable(typeof(ApiResponse<ProductsTodayDto>))]
[JsonSerializable(typeof(ApiResponse<SalessLatestDto>))]
[JsonSerializable(typeof(ApiResponse<ProductsBestSellingDto>))]
[JsonSerializable(typeof(ApiResponse<WebSessionsSummaryDto>))]
[JsonSerializable(typeof(ApiResponse<WebTopProductsDto>))]
[JsonSerializable(typeof(ApiResponse<SalesDetailDto>))]
[JsonSerializable(typeof(ApiResponse<SalesChannelDetailDto>))]
[JsonSerializable(typeof(ApiResponse<asToolkit.Domain.Dtos.SalesChannelOAuth.OAuthStartResponseDto>))]
[JsonSerializable(typeof(ApiResponse<asToolkit.Domain.Dtos.SystemOAuthSettings.SystemOAuthSettingsDto>))]
[JsonSerializable(typeof(asToolkit.Domain.Dtos.SystemOAuthSettings.SystemOAuthSettingsInputDto))]
[JsonSerializable(typeof(ApiResponse<asToolkit.Domain.Dtos.TenantOAuthAppSettings.TenantOAuthAppSettingsDetailDto>))]
[JsonSerializable(typeof(ApiResponse<List<asToolkit.Domain.Dtos.TenantOAuthAppSettings.TenantOAuthAppSettingsListDto>>))]
[JsonSerializable(typeof(asToolkit.Domain.Dtos.TenantOAuthAppSettings.TenantOAuthAppSettingsInputDto))]
[JsonSerializable(typeof(SalesChannelSyncResultDto))]
[JsonSerializable(typeof(SalesChannelSyncStatusDto))]
[JsonSerializable(typeof(List<ChannelSyncRunDto>))]
[JsonSerializable(typeof(List<ChannelSyncLogDto>))]
[JsonSerializable(typeof(List<ChannelExportOutboxDto>))]
[JsonSerializable(typeof(ApiResponse<LoginResponseDto>))]
[JsonSerializable(typeof(ApiResponse<CurrentUserProfileDto>))]
[JsonSerializable(typeof(ApiResponse<string>))]
[JsonSerializable(typeof(ApiResponse<List<Guid>>))]
[JsonSerializable(typeof(ApiResponse<GlobalSearchResultDto>))]
[JsonSerializable(typeof(ApiResponse<ShippingDetailDto>))]
[JsonSerializable(typeof(ApiResponse<List<ShippableSalesItemDto>>))]
[JsonSerializable(typeof(ApiResponse<List<ApplicableShippingRateDto>>))]

// Direct response types
[JsonSerializable(typeof(GlobalSearchResultDto))]
[JsonSerializable(typeof(GlobalSearchHitDto))]
[JsonSerializable(typeof(AiModelDetailDto))]
[JsonSerializable(typeof(AiPromptDetailDto))]
[JsonSerializable(typeof(ManufacturerDetailDto))]
[JsonSerializable(typeof(Guid))]

// Input/payload types
[JsonSerializable(typeof(AiModelInputDto))]
[JsonSerializable(typeof(AiPromptInputDto))]
[JsonSerializable(typeof(TenantInputDto))]
[JsonSerializable(typeof(WarehouseInputDto))]
[JsonSerializable(typeof(TaxClassInputDto))]
[JsonSerializable(typeof(ProductAttributeInputDto))]
[JsonSerializable(typeof(SalesChannelInputDto))]
[JsonSerializable(typeof(ProductInputDto))]
[JsonSerializable(typeof(ProductVariantGenerateDto))]
[JsonSerializable(typeof(ProductImageReorderDto))]
[JsonSerializable(typeof(SalesInputDto))]
[JsonSerializable(typeof(ShippingInputDto))]
[JsonSerializable(typeof(ManufacturerInputDto))]
[JsonSerializable(typeof(CustomerInputDto))]
[JsonSerializable(typeof(LoginRequestDto))]
[JsonSerializable(typeof(RefreshTokenRequestDto))]
[JsonSerializable(typeof(RegisterRequestDto))]
[JsonSerializable(typeof(ServerInfoResponseDto))]
[JsonSerializable(typeof(ServerProfile))]
[JsonSerializable(typeof(List<ServerProfile>))]
[JsonSerializable(typeof(AddUserToTenantPayload))]
[JsonSerializable(typeof(AssignUserToTenantPayload))]
[JsonSerializable(typeof(UpdateCurrentUserPayload))]
[JsonSerializable(typeof(ChangePasswordPayload))]

// Error parsing
[JsonSerializable(typeof(ApiErrorResponse))]
internal partial class AppJsonSerializerContext : JsonSerializerContext;
