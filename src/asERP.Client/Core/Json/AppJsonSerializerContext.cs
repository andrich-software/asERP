using System.Text.Json.Serialization;
using asERP.Client.Core.Models;
using asERP.Client.Features.Auth.Models;
using asERP.Domain.Dtos.Account;
using asERP.Domain.Dtos.AiModel;
using asERP.Domain.Dtos.AiPrompt;
using asERP.Domain.Dtos.Auth;
using asERP.Domain.Dtos.Country;
using asERP.Domain.Dtos.Customer;
using asERP.Domain.Dtos.Feed;
using asERP.Domain.Dtos.Invoice;
using asERP.Domain.Dtos.Manufacturer;
using asERP.Domain.Dtos.Product;
using asERP.Domain.Dtos.ProductAttribute;
using asERP.Domain.Dtos.Returns;
using asERP.Domain.Dtos.Sales;
using asERP.Domain.Dtos.SalesChannel;
using asERP.Domain.Dtos.Search;
using asERP.Domain.Dtos.ServerInfo;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Dtos.Statistic;
using asERP.Domain.Dtos.Superadmin;
using asERP.Domain.Dtos.TaxClass;
using asERP.Domain.Dtos.Tenant;
using asERP.Domain.Dtos.User;
using asERP.Domain.Dtos.Warehouse;
using asERP.Domain.Dtos.WebAnalytics;

namespace asERP.Client.Core.Json;

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
[JsonSerializable(typeof(PaginatedResponse<FeedListDto>))]
[JsonSerializable(typeof(PaginatedResponse<FeedLogDto>))]
[JsonSerializable(typeof(PaginatedResponse<FeedProductSelectionDto>))]
[JsonSerializable(typeof(PaginatedResponse<CountryListDto>))]
[JsonSerializable(typeof(PaginatedResponse<UserListDto>))]
[JsonSerializable(typeof(PaginatedResponse<ShipmentListItemDto>))]
[JsonSerializable(typeof(PaginatedResponse<SalesReadyToShipListDto>))]
[JsonSerializable(typeof(PaginatedResponse<ReturnShipmentListItemDto>))]

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
[JsonSerializable(typeof(ApiResponse<CountryDetailDto>))]
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
[JsonSerializable(typeof(ApiResponse<FeedDetailDto>))]
[JsonSerializable(typeof(ApiResponse<asERP.Domain.Dtos.SalesChannelOAuth.OAuthStartResponseDto>))]
[JsonSerializable(typeof(ApiResponse<asERP.Domain.Dtos.SystemOAuthSettings.SystemOAuthSettingsDto>))]
[JsonSerializable(typeof(asERP.Domain.Dtos.SystemOAuthSettings.SystemOAuthSettingsInputDto))]
[JsonSerializable(typeof(ApiResponse<List<asERP.Domain.Dtos.GlobalSettings.GlobalSettingDto>>))]
[JsonSerializable(typeof(asERP.Domain.Dtos.GlobalSettings.GlobalSettingsUpdateInputDto))]
[JsonSerializable(typeof(ApiResponse<asERP.Domain.Dtos.TenantOAuthAppSettings.TenantOAuthAppSettingsDetailDto>))]
[JsonSerializable(typeof(ApiResponse<List<asERP.Domain.Dtos.TenantOAuthAppSettings.TenantOAuthAppSettingsListDto>>))]
[JsonSerializable(typeof(asERP.Domain.Dtos.TenantOAuthAppSettings.TenantOAuthAppSettingsInputDto))]
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
[JsonSerializable(typeof(ApiResponse<ReturnShipmentDetailDto>))]
[JsonSerializable(typeof(ApiResponse<List<ReturnableSalesItemDto>>))]

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
[JsonSerializable(typeof(CountryInputDto))]
[JsonSerializable(typeof(ProductAttributeInputDto))]
[JsonSerializable(typeof(SalesChannelInputDto))]
[JsonSerializable(typeof(FeedInputDto))]
[JsonSerializable(typeof(FeedProductSelectionUpdateDto))]
[JsonSerializable(typeof(ProductInputDto))]
[JsonSerializable(typeof(ProductVariantGenerateDto))]
[JsonSerializable(typeof(ProductImageReorderDto))]
[JsonSerializable(typeof(SalesInputDto))]
[JsonSerializable(typeof(ShippingInputDto))]
[JsonSerializable(typeof(ReturnShipmentInputDto))]
[JsonSerializable(typeof(ReturnReceiveInputDto))]
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
