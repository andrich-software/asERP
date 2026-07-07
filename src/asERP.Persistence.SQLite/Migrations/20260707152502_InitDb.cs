using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace asERP.Persistence.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ai_model",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AiModelType = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ApiUrl = table.Column<string>(type: "TEXT", nullable: false),
                    ApiUsername = table.Column<string>(type: "TEXT", nullable: false),
                    ApiPassword = table.Column<string>(type: "TEXT", nullable: false),
                    ApiKey = table.Column<string>(type: "TEXT", nullable: false),
                    NCtx = table.Column<uint>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ai_model", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CountryCode = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Firstname = table.Column<string>(type: "TEXT", nullable: false),
                    Lastname = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Website = table.Column<string>(type: "TEXT", nullable: false),
                    VatNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    DateEnrollment = table.Column<long>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.Id);
                    table.UniqueConstraint("AK_customer_CustomerId", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "manufacturer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Street = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    State = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Country = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Website = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Logo = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "oauth_state",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Provider = table.Column<int>(type: "INTEGER", nullable: false),
                    StateToken = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Nonce = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ConsumedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oauth_state", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "product_attribute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_attribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "refresh_token",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    TokenHash = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Family = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReplacedByTokenId = table.Column<Guid>(type: "TEXT", nullable: true),
                    IsPersistent = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refresh_token", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "saleschannel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConcurrencyToken = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 4096, nullable: false),
                    AccessToken = table.Column<string>(type: "TEXT", maxLength: 8192, nullable: true),
                    RefreshToken = table.Column<string>(type: "TEXT", maxLength: 8192, nullable: true),
                    TokenExpiresAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MarketplaceId = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true),
                    AdditionalConfigJson = table.Column<string>(type: "TEXT", nullable: true),
                    ImportProducts = table.Column<bool>(type: "INTEGER", nullable: false),
                    ImportCustomers = table.Column<bool>(type: "INTEGER", nullable: false),
                    ImportSaless = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExportProducts = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExportCustomers = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExportSaless = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExportStock = table.Column<bool>(type: "INTEGER", nullable: false),
                    PushSalesCancellations = table.Column<bool>(type: "INTEGER", nullable: false),
                    ImportStock = table.Column<bool>(type: "INTEGER", nullable: false),
                    InitialProductImportCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    InitialProductExportCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    InitialCustomerImportCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    InitialSalesImportCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    SalesImportBackfillCursor = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CustomerImportPageCursor = table.Column<int>(type: "INTEGER", nullable: false),
                    SyncIntervalSeconds = table.Column<int>(type: "INTEGER", nullable: false),
                    LastSyncStartedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    TrackingEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    TrackingToken = table.Column<string>(type: "TEXT", maxLength: 4096, nullable: true),
                    TrackingTokenHash = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true),
                    WebhookSecret = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saleschannel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    IsEncrypted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_setting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "shipping_provider",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    IsEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    UseSandbox = table.Column<bool>(type: "INTEGER", nullable: false),
                    Username = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 4096, nullable: false),
                    ApiKey = table.Column<string>(type: "TEXT", maxLength: 4096, nullable: true),
                    ApiSecret = table.Column<string>(type: "TEXT", maxLength: 4096, nullable: true),
                    AccountNumber = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true),
                    AdditionalConfigJson = table.Column<string>(type: "TEXT", nullable: true),
                    TrackingPollIntervalSeconds = table.Column<int>(type: "INTEGER", nullable: false),
                    LastTrackingPollStartedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipping_provider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "stock_movement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    QuantityDelta = table.Column<double>(type: "REAL", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    SalesItemId = table.Column<Guid>(type: "TEXT", nullable: true),
                    SalesChannelId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Note = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock_movement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tax_class",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TaxRate = table.Column<double>(type: "REAL", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tax_class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tenant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    CompanyName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    ContactEmail = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Website = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Street = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Street2 = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Iban = table.Column<string>(type: "TEXT", maxLength: 34, nullable: true),
                    PackingSlipShowPrices = table.Column<bool>(type: "INTEGER", nullable: false),
                    PackingSlipPrintByDefault = table.Column<bool>(type: "INTEGER", nullable: false),
                    SendShippingNotificationEmails = table.Column<bool>(type: "INTEGER", nullable: false),
                    SendDeliveryNotificationEmails = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "warehouse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ai_prompt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AiModelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Identifier = table.Column<string>(type: "TEXT", nullable: false),
                    PromptText = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ai_prompt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ai_prompt_ai_model_AiModelId",
                        column: x => x.AiModelId,
                        principalTable: "ai_model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customer_address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Firstname = table.Column<string>(type: "TEXT", nullable: false),
                    Lastname = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    HouseNr = table.Column<string>(type: "TEXT", nullable: false),
                    Zip = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    DefaultDeliveryAddress = table.Column<bool>(type: "INTEGER", nullable: false),
                    DefaultInvoiceAddress = table.Column<bool>(type: "INTEGER", nullable: false),
                    CountryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_customer_address_country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customer_address_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customer_saleschannel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RemoteCustomerId = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_saleschannel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_customer_saleschannel_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConcurrencyToken = table.Column<Guid>(type: "TEXT", nullable: false),
                    SalesId = table.Column<int>(type: "INTEGER", nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RemoteSalesId = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Subtotal = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    ShippingCost = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    TotalTax = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    PaymentStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentMethod = table.Column<string>(type: "TEXT", nullable: false),
                    PaymentProvider = table.Column<string>(type: "TEXT", nullable: false),
                    PaymentTransactionId = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerNote = table.Column<string>(type: "TEXT", nullable: false),
                    InternalNote = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryAddressFirstName = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryAddressLastName = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryAddressCompanyName = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryAddressPhone = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryAddressStreet = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryAddressCity = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryAddressZip = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryAddressCountry = table.Column<string>(type: "TEXT", nullable: false),
                    InvoiceAddressFirstName = table.Column<string>(type: "TEXT", nullable: false),
                    InvoiceAddressLastName = table.Column<string>(type: "TEXT", nullable: false),
                    InvoiceAddressCompanyName = table.Column<string>(type: "TEXT", nullable: false),
                    InvoiceAddressPhone = table.Column<string>(type: "TEXT", nullable: false),
                    InvoiceAddressStreet = table.Column<string>(type: "TEXT", nullable: false),
                    InvoiceAddressCity = table.Column<string>(type: "TEXT", nullable: false),
                    InvoiceAddressZip = table.Column<string>(type: "TEXT", nullable: false),
                    InvoiceAddressCountry = table.Column<string>(type: "TEXT", nullable: false),
                    SalesConfirmationSent = table.Column<bool>(type: "INTEGER", nullable: false),
                    InvoiceSent = table.Column<bool>(type: "INTEGER", nullable: false),
                    ShippingInformationSent = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateSalesed = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sales_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_attribute_value",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductAttributeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_attribute_value", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_attribute_value_product_attribute_ProductAttributeId",
                        column: x => x.ProductAttributeId,
                        principalTable: "product_attribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "role_claim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_claim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_role_claim_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "channel_export_outbox",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Operation = table.Column<int>(type: "INTEGER", nullable: false),
                    AggregateType = table.Column<int>(type: "INTEGER", nullable: false),
                    AggregateId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PayloadJson = table.Column<string>(type: "TEXT", nullable: false),
                    IdempotencyKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    AttemptCount = table.Column<int>(type: "INTEGER", nullable: false),
                    NextAttemptAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    LastError = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_channel_export_outbox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_channel_export_outbox_saleschannel_SalesChannelId",
                        column: x => x.SalesChannelId,
                        principalTable: "saleschannel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "channel_sync_log",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CorrelationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Operation = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    Message = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: false),
                    Exception = table.Column<string>(type: "TEXT", maxLength: 8000, nullable: true),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_channel_sync_log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_channel_sync_log_saleschannel_SalesChannelId",
                        column: x => x.SalesChannelId,
                        principalTable: "saleschannel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "channel_sync_run",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Operation = table.Column<int>(type: "INTEGER", nullable: false),
                    TriggerSource = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ItemsProcessed = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemsFailed = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemsTotal = table.Column<int>(type: "INTEGER", nullable: true),
                    ErrorSummary = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    CorrelationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_channel_sync_run", x => x.Id);
                    table.ForeignKey(
                        name: "FK_channel_sync_run_saleschannel_SalesChannelId",
                        column: x => x.SalesChannelId,
                        principalTable: "saleschannel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shipping_provider_rate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShippingProviderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    MaxLength = table.Column<decimal>(type: "TEXT", precision: 18, scale: 4, nullable: false),
                    MaxWidth = table.Column<decimal>(type: "TEXT", precision: 18, scale: 4, nullable: false),
                    MaxHeight = table.Column<decimal>(type: "TEXT", precision: 18, scale: 4, nullable: false),
                    MaxWeight = table.Column<decimal>(type: "TEXT", precision: 18, scale: 4, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipping_provider_rate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shipping_provider_rate_shipping_provider_ShippingProviderId",
                        column: x => x.ShippingProviderId,
                        principalTable: "shipping_provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConcurrencyToken = table.Column<Guid>(type: "TEXT", nullable: false),
                    Sku = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    NameOptimized = table.Column<string>(type: "TEXT", nullable: true),
                    Ean = table.Column<string>(type: "TEXT", nullable: true),
                    Asin = table.Column<string>(type: "TEXT", nullable: true),
                    Gtin = table.Column<string>(type: "TEXT", nullable: true),
                    Mpn = table.Column<string>(type: "TEXT", nullable: true),
                    Brand = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DescriptionOptimized = table.Column<string>(type: "TEXT", nullable: true),
                    UseOptimized = table.Column<bool>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Msrp = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Weight = table.Column<decimal>(type: "TEXT", precision: 18, scale: 4, nullable: false),
                    Width = table.Column<decimal>(type: "TEXT", precision: 18, scale: 4, nullable: false),
                    Height = table.Column<decimal>(type: "TEXT", precision: 18, scale: 4, nullable: false),
                    Depth = table.Column<decimal>(type: "TEXT", precision: 18, scale: 4, nullable: false),
                    TaxClassId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ManufacturerId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ProductType = table.Column<int>(type: "INTEGER", nullable: false),
                    ParentProductId = table.Column<Guid>(type: "TEXT", nullable: true),
                    VariantSortOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "manufacturer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_product_product_ParentProductId",
                        column: x => x.ParentProductId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_tax_class_TaxClassId",
                        column: x => x.TaxClassId,
                        principalTable: "tax_class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tenant_email_settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProviderType = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    SmtpHost = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    SmtpPort = table.Column<int>(type: "INTEGER", nullable: true),
                    SmtpUsername = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    SmtpPassword = table.Column<string>(type: "TEXT", maxLength: 4096, nullable: true),
                    SmtpEnableSsl = table.Column<bool>(type: "INTEGER", nullable: true),
                    M365TenantId = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    M365ClientId = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    M365ClientSecret = table.Column<string>(type: "TEXT", maxLength: 4096, nullable: true),
                    M365SenderAddress = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    FromAddress = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    FromName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ReplyToAddress = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ReplyToName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenant_email_settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tenant_email_settings_tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tenant_oauth_app_settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Provider = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ClientId = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ClientSecret = table.Column<string>(type: "TEXT", maxLength: 4096, nullable: true),
                    RedirectUri = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    RuName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Scopes = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    UseSandbox = table.Column<bool>(type: "INTEGER", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenant_oauth_app_settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tenant_oauth_app_settings_tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Firstname = table.Column<string>(type: "TEXT", nullable: false),
                    Lastname = table.Column<string>(type: "TEXT", nullable: false),
                    DefaultTenantId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<long>(type: "INTEGER", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_tenant_DefaultTenantId",
                        column: x => x.DefaultTenantId,
                        principalTable: "tenant",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalesChannelWarehouses",
                columns: table => new
                {
                    SalesChannelsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    WarehousesId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesChannelWarehouses", x => new { x.SalesChannelsId, x.WarehousesId });
                    table.ForeignKey(
                        name: "FK_SalesChannelWarehouses_saleschannel_SalesChannelsId",
                        column: x => x.SalesChannelsId,
                        principalTable: "saleschannel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesChannelWarehouses_warehouse_WarehousesId",
                        column: x => x.WarehousesId,
                        principalTable: "warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "invoice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "TEXT", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SalesId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Subtotal = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    ShippingCost = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    TotalTax = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    PaymentStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    InvoiceStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentMethod = table.Column<string>(type: "TEXT", nullable: false),
                    PaymentTransactionId = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    InvoiceAddressFirstName = table.Column<string>(type: "TEXT", nullable: false),
                    InvoiceAddressLastName = table.Column<string>(type: "TEXT", nullable: false),
                    InvoiceAddressCompanyName = table.Column<string>(type: "TEXT", nullable: false),
                    InvoiceAddressPhone = table.Column<string>(type: "TEXT", nullable: false),
                    InvoiceAddressStreet = table.Column<string>(type: "TEXT", nullable: false),
                    InvoiceAddressCity = table.Column<string>(type: "TEXT", nullable: false),
                    InvoiceAddressZip = table.Column<string>(type: "TEXT", nullable: false),
                    InvoiceAddressCountry = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryAddressFirstName = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryAddressLastName = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryAddressCompanyName = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryAddressPhone = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryAddressStreet = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryAddressCity = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryAddressZip = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryAddressCountry = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_invoice_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_invoice_sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "sales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "sales_history",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SalesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShippingId = table.Column<Guid>(type: "TEXT", nullable: true),
                    SalesStatusOld = table.Column<int>(type: "INTEGER", nullable: true),
                    SalesStatusNew = table.Column<int>(type: "INTEGER", nullable: true),
                    PaymentStatusOld = table.Column<int>(type: "INTEGER", nullable: true),
                    PaymentStatusNew = table.Column<int>(type: "INTEGER", nullable: true),
                    ShippingStatusOld = table.Column<string>(type: "TEXT", nullable: true),
                    ShippingStatusNew = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IsSystemGenerated = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales_history", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sales_history_sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sales_item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SalesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<double>(type: "REAL", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    TaxRate = table.Column<double>(type: "REAL", nullable: false),
                    MissingProductSku = table.Column<string>(type: "TEXT", nullable: false),
                    MissingProductEan = table.Column<string>(type: "TEXT", nullable: false),
                    ShippingId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales_item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sales_item_sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shipping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConcurrencyToken = table.Column<Guid>(type: "TEXT", nullable: false),
                    SalesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShippingProviderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShippingProviderRateId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    TrackingNumber = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TrackingUrl = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true),
                    ShippingCost = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    TaxRate = table.Column<double>(type: "REAL", nullable: false),
                    WeightKg = table.Column<decimal>(type: "TEXT", precision: 18, scale: 4, nullable: true),
                    LengthCm = table.Column<decimal>(type: "TEXT", precision: 18, scale: 4, nullable: true),
                    WidthCm = table.Column<decimal>(type: "TEXT", precision: 18, scale: 4, nullable: true),
                    HeightCm = table.Column<decimal>(type: "TEXT", precision: 18, scale: 4, nullable: true),
                    CarrierShipmentId = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                    LabelData = table.Column<byte[]>(type: "BLOB", nullable: true),
                    LabelFormat = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true),
                    LastTrackedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ShippedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeliveredAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastCarrierStatusRaw = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true),
                    CustomerNotifiedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CustomerDeliveryNotifiedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shipping_sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_shipping_shipping_provider_ShippingProviderId",
                        column: x => x.ShippingProviderId,
                        principalTable: "shipping_provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_shipping_shipping_provider_rate_ShippingProviderRateId",
                        column: x => x.ShippingProviderRateId,
                        principalTable: "shipping_provider_rate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "shipping_provider_rate_country",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShippingProviderRateId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CountryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipping_provider_rate_country", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shipping_provider_rate_country_country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_shipping_provider_rate_country_shipping_provider_rate_ShippingProviderRateId",
                        column: x => x.ShippingProviderRateId,
                        principalTable: "shipping_provider_rate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "goods_receipt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "date", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Supplier = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goods_receipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_goods_receipt_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_goods_receipt_warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    RelativePath = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    ThumbnailPath = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    OriginalFileName = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true),
                    SalesChannelId = table.Column<Guid>(type: "TEXT", nullable: true),
                    RemoteImageId = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true),
                    AltText = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true),
                    FileSizeBytes = table.Column<long>(type: "INTEGER", nullable: false),
                    Width = table.Column<int>(type: "INTEGER", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_image_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_saleschannel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RemoteProductId = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                    ExternalListingId = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                    IsListed = table.Column<bool>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    MinPrice = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: true),
                    MaxPrice = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: true),
                    Currency = table.Column<string>(type: "TEXT", maxLength: 3, nullable: true),
                    RepricingType = table.Column<int>(type: "INTEGER", nullable: false),
                    MinimumProfit = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    MinimumProfitUnit = table.Column<int>(type: "INTEGER", nullable: false),
                    StockBuffer = table.Column<int>(type: "INTEGER", nullable: false),
                    FulfillmentChannel = table.Column<int>(type: "INTEGER", nullable: false),
                    SyncStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    LastSyncedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastExportHash = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true),
                    LastErrorMessage = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    MetadataJson = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_saleschannel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_saleschannel_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_saleschannel_saleschannel_SalesChannelId",
                        column: x => x.SalesChannelId,
                        principalTable: "saleschannel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_stock",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Stock = table.Column<double>(type: "REAL", nullable: false),
                    StockMin = table.Column<double>(type: "REAL", nullable: false),
                    StockMax = table.Column<double>(type: "REAL", nullable: false),
                    StorageLocation = table.Column<double>(type: "REAL", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_stock_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_stock_warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_variant_axis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParentProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductAttributeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_variant_axis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_variant_axis_product_ParentProductId",
                        column: x => x.ParentProductId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_variant_axis_product_attribute_ProductAttributeId",
                        column: x => x.ProductAttributeId,
                        principalTable: "product_attribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_variant_option",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductAttributeValueId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_variant_option", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_variant_option_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_variant_option_product_attribute_value_ProductAttributeValueId",
                        column: x => x.ProductAttributeValueId,
                        principalTable: "product_attribute_value",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_claim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_claim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_claim_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_login",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_login", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_user_login_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_role",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_role", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_user_role_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_role_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_tenant",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsDefault = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    RoleManageTenant = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    RoleManageUser = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_tenant", x => new { x.UserId, x.TenantId });
                    table.ForeignKey(
                        name: "FK_user_tenant_tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_tenant_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_token",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_token", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_user_token_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "invoice_item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Quantity = table.Column<double>(type: "REAL", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    SKU = table.Column<string>(type: "TEXT", nullable: false),
                    EAN = table.Column<string>(type: "TEXT", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    TaxRate = table.Column<double>(type: "REAL", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Unit = table.Column<string>(type: "TEXT", nullable: false),
                    SalesItemId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice_item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_invoice_item_invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_invoice_item_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "sales_item_serialnumber",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SalesItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SerialNumber = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales_item_serialnumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sales_item_serialnumber_sales_item_SalesItemId",
                        column: x => x.SalesItemId,
                        principalTable: "sales_item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "return_shipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SalesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OriginalShippingId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ShippingProviderId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    TrackingNumber = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TrackingUrl = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true),
                    CarrierShipmentId = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                    LabelData = table.Column<byte[]>(type: "BLOB", nullable: true),
                    LabelFormat = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true),
                    RefundAmount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: true),
                    Note = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    ReceivedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastTrackedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastCarrierStatusRaw = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_return_shipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_return_shipment_sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_return_shipment_shipping_OriginalShippingId",
                        column: x => x.OriginalShippingId,
                        principalTable: "shipping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_return_shipment_shipping_provider_ShippingProviderId",
                        column: x => x.ShippingProviderId,
                        principalTable: "shipping_provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "shipping_label_outbox",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShippingId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShippingProviderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdempotencyKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    AttemptCount = table.Column<int>(type: "INTEGER", nullable: false),
                    NextAttemptAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastError = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipping_label_outbox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shipping_label_outbox_shipping_ShippingId",
                        column: x => x.ShippingId,
                        principalTable: "shipping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "return_label_outbox",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReturnShipmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShippingProviderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdempotencyKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    AttemptCount = table.Column<int>(type: "INTEGER", nullable: false),
                    NextAttemptAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastError = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_return_label_outbox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_return_label_outbox_return_shipment_ReturnShipmentId",
                        column: x => x.ReturnShipmentId,
                        principalTable: "return_shipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "return_shipment_item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReturnShipmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SalesItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<double>(type: "REAL", nullable: false),
                    Reason = table.Column<int>(type: "INTEGER", nullable: false),
                    ReasonText = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Condition = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_return_shipment_item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_return_shipment_item_return_shipment_ReturnShipmentId",
                        column: x => x.ReturnShipmentId,
                        principalTable: "return_shipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_return_shipment_item_sales_item_SalesItemId",
                        column: x => x.SalesItemId,
                        principalTable: "sales_item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "return_shipment_item_serialnumber",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReturnShipmentItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SerialNumber = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_return_shipment_item_serialnumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_return_shipment_item_serialnumber_return_shipment_item_ReturnShipmentItemId",
                        column: x => x.ReturnShipmentItemId,
                        principalTable: "return_shipment_item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "country",
                columns: new[] { "Id", "CountryCode", "DateCreated", "DateModified", "Name", "TenantId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "DE", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(2267), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(2272), "Germany", null },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "AT", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3306), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3306), "Austria", null },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "CH", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3310), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3311), "Switzerland", null },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "AD", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3320), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3321), "Andorra", null },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "AF", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3322), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3323), "Afghanistan", null },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "AG", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3324), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3325), "Antigua and Barbuda", null },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "AL", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3326), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3327), "Albania", null },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "AM", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3328), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3329), "Armenia", null },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "AO", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3330), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3330), "Angola", null },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "AX", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3332), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3332), "Åland Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "AR", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3334), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3334), "Argentina", null },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "AQ", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3337), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3337), "Antarctica", null },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "AU", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3339), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3339), "Australia", null },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "AZ", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3341), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3341), "Azerbaijan", null },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "BA", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3343), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3343), "Bosnia and Herzegovina", null },
                    { new Guid("00000000-0000-0000-0000-000000000016"), "BB", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3344), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3345), "Barbados", null },
                    { new Guid("00000000-0000-0000-0000-000000000017"), "BE", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3357), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3357), "Belgium", null },
                    { new Guid("00000000-0000-0000-0000-000000000018"), "BG", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3359), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3359), "Bulgaria", null },
                    { new Guid("00000000-0000-0000-0000-000000000019"), "BL", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3361), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3361), "Saint Barthélemy", null },
                    { new Guid("00000000-0000-0000-0000-000000000020"), "BO", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3364), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3365), "Bolivia", null },
                    { new Guid("00000000-0000-0000-0000-000000000021"), "BR", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3366), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3366), "Brazil", null },
                    { new Guid("00000000-0000-0000-0000-000000000022"), "BS", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3369), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3369), "Bahamas", null },
                    { new Guid("00000000-0000-0000-0000-000000000023"), "BY", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3370), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3371), "Belarus", null },
                    { new Guid("00000000-0000-0000-0000-000000000024"), "BZ", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3372), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3373), "Belize", null },
                    { new Guid("00000000-0000-0000-0000-000000000025"), "CA", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3374), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3374), "Canada", null },
                    { new Guid("00000000-0000-0000-0000-000000000026"), "CC", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3376), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3376), "Cocos (Keeling) Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000027"), "CI", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3378), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3378), "Ivory Coast", null },
                    { new Guid("00000000-0000-0000-0000-000000000028"), "CL", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3381), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3381), "Chile", null },
                    { new Guid("00000000-0000-0000-0000-000000000029"), "CN", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3383), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3383), "China", null },
                    { new Guid("00000000-0000-0000-0000-000000000030"), "CO", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3394), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3395), "Colombia", null },
                    { new Guid("00000000-0000-0000-0000-000000000031"), "CR", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3402), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3403), "Costa Rica", null },
                    { new Guid("00000000-0000-0000-0000-000000000032"), "CU", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3404), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3405), "Cuba", null },
                    { new Guid("00000000-0000-0000-0000-000000000033"), "CY", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3415), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3415), "Cyprus", null },
                    { new Guid("00000000-0000-0000-0000-000000000034"), "CZ", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3417), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3417), "Czech Republic", null },
                    { new Guid("00000000-0000-0000-0000-000000000035"), "DO", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3419), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3419), "Dominican Republic", null },
                    { new Guid("00000000-0000-0000-0000-000000000036"), "DK", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3422), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3423), "Denmark", null },
                    { new Guid("00000000-0000-0000-0000-000000000037"), "DZ", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3424), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3424), "Algeria", null },
                    { new Guid("00000000-0000-0000-0000-000000000038"), "EC", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3426), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3426), "Ecuador", null },
                    { new Guid("00000000-0000-0000-0000-000000000039"), "EE", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3428), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3428), "Estonia", null },
                    { new Guid("00000000-0000-0000-0000-000000000040"), "EG", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3430), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3430), "Egypt", null },
                    { new Guid("00000000-0000-0000-0000-000000000041"), "ER", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3432), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3432), "Eritrea", null },
                    { new Guid("00000000-0000-0000-0000-000000000042"), "ES", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3433), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3434), "Spain", null },
                    { new Guid("00000000-0000-0000-0000-000000000043"), "ET", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3435), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3435), "Ethiopia", null },
                    { new Guid("00000000-0000-0000-0000-000000000044"), "FI", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3439), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3439), "Finland", null },
                    { new Guid("00000000-0000-0000-0000-000000000045"), "FR", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3440), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3441), "France", null },
                    { new Guid("00000000-0000-0000-0000-000000000046"), "GB", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3442), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3442), "United Kingdom", null },
                    { new Guid("00000000-0000-0000-0000-000000000047"), "GE", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3444), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3444), "Georgia", null },
                    { new Guid("00000000-0000-0000-0000-000000000048"), "GF", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3446), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3446), "French Guiana", null },
                    { new Guid("00000000-0000-0000-0000-000000000049"), "GH", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3456), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3456), "Ghana", null },
                    { new Guid("00000000-0000-0000-0000-000000000050"), "GL", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3458), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3458), "Greenland", null },
                    { new Guid("00000000-0000-0000-0000-000000000051"), "GP", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3460), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3460), "Guadeloupe", null },
                    { new Guid("00000000-0000-0000-0000-000000000052"), "GR", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3463), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3464), "Greece", null },
                    { new Guid("00000000-0000-0000-0000-000000000053"), "GT", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3465), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3466), "Guatemala", null },
                    { new Guid("00000000-0000-0000-0000-000000000054"), "GY", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3467), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3468), "Guyana", null },
                    { new Guid("00000000-0000-0000-0000-000000000055"), "HN", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3469), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3470), "Honduras", null },
                    { new Guid("00000000-0000-0000-0000-000000000056"), "HR", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3471), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3471), "Croatia", null },
                    { new Guid("00000000-0000-0000-0000-000000000057"), "HT", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3473), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3473), "Haiti", null },
                    { new Guid("00000000-0000-0000-0000-000000000058"), "HU", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3475), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3475), "Hungary", null },
                    { new Guid("00000000-0000-0000-0000-000000000059"), "ID", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3477), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3477), "Indonesia", null },
                    { new Guid("00000000-0000-0000-0000-000000000060"), "IE", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3480), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3480), "Ireland", null },
                    { new Guid("00000000-0000-0000-0000-000000000061"), "IN", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3482), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3482), "India", null },
                    { new Guid("00000000-0000-0000-0000-000000000062"), "IR", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3483), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3484), "Iran", null },
                    { new Guid("00000000-0000-0000-0000-000000000063"), "IS", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3485), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3485), "Iceland", null },
                    { new Guid("00000000-0000-0000-0000-000000000064"), "IT", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3487), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3487), "Italy", null },
                    { new Guid("00000000-0000-0000-0000-000000000065"), "JM", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3496), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3496), "Jamaica", null },
                    { new Guid("00000000-0000-0000-0000-000000000066"), "JP", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3498), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3499), "Japan", null },
                    { new Guid("00000000-0000-0000-0000-000000000067"), "KE", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3500), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3500), "Kenya", null },
                    { new Guid("00000000-0000-0000-0000-000000000068"), "KG", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3504), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3504), "Kyrgyzstan", null },
                    { new Guid("00000000-0000-0000-0000-000000000069"), "KR", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3506), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3506), "South Korea", null },
                    { new Guid("00000000-0000-0000-0000-000000000070"), "KW", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3507), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3508), "Kuwait", null },
                    { new Guid("00000000-0000-0000-0000-000000000071"), "KZ", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3509), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3510), "Kazakhstan", null },
                    { new Guid("00000000-0000-0000-0000-000000000072"), "LU", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3511), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3511), "Luxembourg", null },
                    { new Guid("00000000-0000-0000-0000-000000000073"), "LT", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3513), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3513), "Lithuania", null },
                    { new Guid("00000000-0000-0000-0000-000000000074"), "LV", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3515), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3515), "Latvia", null },
                    { new Guid("00000000-0000-0000-0000-000000000075"), "MA", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3517), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3517), "Morocco", null },
                    { new Guid("00000000-0000-0000-0000-000000000076"), "MC", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3520), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3520), "Monaco", null },
                    { new Guid("00000000-0000-0000-0000-000000000077"), "MD", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3522), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3522), "Moldova", null },
                    { new Guid("00000000-0000-0000-0000-000000000078"), "MF", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3524), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3524), "Saint Martin", null },
                    { new Guid("00000000-0000-0000-0000-000000000079"), "MG", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3525), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3525), "Madagascar", null },
                    { new Guid("00000000-0000-0000-0000-000000000080"), "MQ", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3527), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3527), "Martinique", null },
                    { new Guid("00000000-0000-0000-0000-000000000081"), "MT", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3537), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3538), "Malta", null },
                    { new Guid("00000000-0000-0000-0000-000000000082"), "MX", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3540), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3540), "Mexico", null },
                    { new Guid("00000000-0000-0000-0000-000000000083"), "MY", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3542), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3542), "Malaysia", null },
                    { new Guid("00000000-0000-0000-0000-000000000084"), "NG", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3545), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3545), "Nigeria", null },
                    { new Guid("00000000-0000-0000-0000-000000000085"), "NI", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3547), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3547), "Nicaragua", null },
                    { new Guid("00000000-0000-0000-0000-000000000086"), "NL", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3549), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3549), "Netherlands", null },
                    { new Guid("00000000-0000-0000-0000-000000000087"), "NO", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3551), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3551), "Norway", null },
                    { new Guid("00000000-0000-0000-0000-000000000088"), "NZ", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3552), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3553), "New Zealand", null },
                    { new Guid("00000000-0000-0000-0000-000000000089"), "OM", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3554), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3554), "Oman", null },
                    { new Guid("00000000-0000-0000-0000-000000000090"), "PA", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3556), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3557), "Panama", null },
                    { new Guid("00000000-0000-0000-0000-000000000091"), "PE", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3558), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3558), "Peru", null },
                    { new Guid("00000000-0000-0000-0000-000000000092"), "PL", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3561), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3562), "Poland", null },
                    { new Guid("00000000-0000-0000-0000-000000000093"), "PM", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3563), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3563), "Saint Pierre and Miquelon", null },
                    { new Guid("00000000-0000-0000-0000-000000000094"), "PR", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3565), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3565), "Puerto Rico", null },
                    { new Guid("00000000-0000-0000-0000-000000000095"), "PT", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3571), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3571), "Portugal", null },
                    { new Guid("00000000-0000-0000-0000-000000000096"), "PY", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3573), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3573), "Paraguay", null },
                    { new Guid("00000000-0000-0000-0000-000000000097"), "QA", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3582), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3583), "Qatar", null },
                    { new Guid("00000000-0000-0000-0000-000000000098"), "RO", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3584), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3585), "Romania", null },
                    { new Guid("00000000-0000-0000-0000-000000000099"), "RS", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3586), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3587), "Serbia", null },
                    { new Guid("00000000-0000-0000-0000-000000000100"), "RU", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3590), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3590), "Russia", null },
                    { new Guid("00000000-0000-0000-0000-000000000101"), "SA", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3592), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3592), "Saudi Arabia", null },
                    { new Guid("00000000-0000-0000-0000-000000000102"), "SE", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3594), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3594), "Sweden", null },
                    { new Guid("00000000-0000-0000-0000-000000000103"), "SG", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3596), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3596), "Singapore", null },
                    { new Guid("00000000-0000-0000-0000-000000000104"), "SI", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3598), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3598), "Slovenia", null },
                    { new Guid("00000000-0000-0000-0000-000000000105"), "SK", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3600), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3600), "Slovakia", null },
                    { new Guid("00000000-0000-0000-0000-000000000106"), "SN", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3602), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3602), "Senegal", null },
                    { new Guid("00000000-0000-0000-0000-000000000107"), "SR", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3603), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3604), "Suriname", null },
                    { new Guid("00000000-0000-0000-0000-000000000108"), "SV", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3607), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3607), "El Salvador", null },
                    { new Guid("00000000-0000-0000-0000-000000000109"), "TR", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3609), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3609), "Turkey", null },
                    { new Guid("00000000-0000-0000-0000-000000000110"), "TT", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3611), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3611), "Trinidad and Tobago", null },
                    { new Guid("00000000-0000-0000-0000-000000000111"), "UA", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3613), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3613), "Ukraine", null },
                    { new Guid("00000000-0000-0000-0000-000000000112"), "US", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3615), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3615), "United States", null },
                    { new Guid("00000000-0000-0000-0000-000000000113"), "UY", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3617), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3617), "Uruguay", null },
                    { new Guid("00000000-0000-0000-0000-000000000114"), "VE", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3618), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3619), "Venezuela", null },
                    { new Guid("00000000-0000-0000-0000-000000000115"), "VI", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3620), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3620), "Virgin Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000116"), "VN", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3623), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3624), "Vietnam", null },
                    { new Guid("00000000-0000-0000-0000-000000000117"), "YE", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3626), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3626), "Yemen", null },
                    { new Guid("00000000-0000-0000-0000-000000000118"), "ZA", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3628), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3628), "South Africa", null },
                    { new Guid("00000000-0000-0000-0000-000000000119"), "ZM", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3629), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3630), "Zambia", null },
                    { new Guid("00000000-0000-0000-0000-000000000120"), "ZW", new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3631), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3631), "Zimbabwe", null }
                });

            migrationBuilder.InsertData(
                table: "manufacturer",
                columns: new[] { "Id", "City", "Country", "DateCreated", "DateModified", "Email", "Logo", "Name", "Phone", "State", "Street", "TenantId", "Website", "ZipCode" },
                values: new object[] { new Guid("55555555-5555-5555-5555-555555555555"), "Berlin", "Deutschland", new DateTime(2026, 7, 7, 15, 25, 1, 400, DateTimeKind.Utc).AddTicks(5792), new DateTime(2026, 7, 7, 15, 25, 1, 400, DateTimeKind.Utc).AddTicks(5793), "info@beispiel-hersteller.de", null, "Beispiel Hersteller GmbH", "+49 30 12345678", "Berlin", "Musterstraße 123", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "https://www.beispiel-hersteller.de", "10115" });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "abc43a7e-f7bb-4447-baaf-1add431ddbdf", "f857316b-33d3-4385-99be-82763f34f6e0", "Superadmin", "SUPERADMIN" },
                    { "cac43a6e-f7bb-4448-baaf-1add431ccbbf", "fbb1af03-aaa0-4931-9902-09e7b7b71a35", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "saleschannel",
                columns: new[] { "Id", "AccessToken", "AdditionalConfigJson", "ConcurrencyToken", "CustomerImportPageCursor", "DateCreated", "DateModified", "ExportCustomers", "ExportProducts", "ExportSaless", "ExportStock", "ImportCustomers", "ImportProducts", "ImportSaless", "ImportStock", "InitialCustomerImportCompleted", "InitialProductExportCompleted", "InitialProductImportCompleted", "InitialSalesImportCompleted", "IsEnabled", "LastSyncStartedAt", "MarketplaceId", "Name", "Password", "PushSalesCancellations", "RefreshToken", "SalesImportBackfillCursor", "SyncIntervalSeconds", "TenantId", "TokenExpiresAt", "TrackingEnabled", "TrackingToken", "TrackingTokenHash", "Type", "Url", "Username", "WebhookSecret" },
                values: new object[] { new Guid("88888888-8888-8888-8888-888888888888"), null, null, new Guid("00000000-0000-0000-0000-000000000000"), 0, new DateTime(2026, 7, 7, 15, 25, 1, 414, DateTimeKind.Utc).AddTicks(6632), new DateTime(2026, 7, 7, 15, 25, 1, 414, DateTimeKind.Utc).AddTicks(6636), false, false, false, false, false, false, false, false, false, false, false, false, true, null, null, "Kasse Ladengeschäft", "", false, null, null, 60, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), null, false, null, null, 1, "", "", null });

            migrationBuilder.InsertData(
                table: "setting",
                columns: new[] { "Id", "DateCreated", "DateModified", "IsEncrypted", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("66666666-6666-6666-6666-666666666615"), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(3), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(7), false, "Jwt.Issuer", "asERP.Server" },
                    { new Guid("66666666-6666-6666-6666-666666666616"), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(604), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(604), false, "Jwt.Audience", "asERP.Client" },
                    { new Guid("66666666-6666-6666-6666-666666666617"), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(607), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(608), false, "Jwt.DurationInMinutes", "60" },
                    { new Guid("66666666-6666-6666-6666-666666666618"), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(610), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(611), false, "Jwt.RefreshTokenExpireDays", "7" },
                    { new Guid("66666666-6666-6666-6666-666666666619"), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(612), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(612), false, "Email.ProviderType", "Smtp" },
                    { new Guid("66666666-6666-6666-6666-666666666620"), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(799), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(799), false, "Email.FromAddress", "no-reply@martin-andrich.de" },
                    { new Guid("66666666-6666-6666-6666-666666666621"), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(800), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(801), false, "Email.FromName", "asERP" },
                    { new Guid("66666666-6666-6666-6666-666666666622"), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(805), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(805), false, "Telemetry.Endpoint", "http://localhost:4317" },
                    { new Guid("66666666-6666-6666-6666-666666666623"), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(807), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(807), false, "Telemetry.ServiceName", "asERP.Server" },
                    { new Guid("66666666-6666-6666-6666-666666666624"), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(614), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(614), false, "Email.SmtpHost", "" },
                    { new Guid("66666666-6666-6666-6666-666666666625"), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(622), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(622), false, "Email.SmtpPort", "587" },
                    { new Guid("66666666-6666-6666-6666-666666666626"), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(624), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(624), false, "Email.SmtpUsername", "" },
                    { new Guid("66666666-6666-6666-6666-666666666627"), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(633), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(633), true, "Email.SmtpPassword", "" },
                    { new Guid("66666666-6666-6666-6666-666666666628"), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(788), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(788), false, "Email.SmtpEnableSsl", "true" },
                    { new Guid("66666666-6666-6666-6666-666666666629"), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(790), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(790), false, "Email.M365TenantId", "" },
                    { new Guid("66666666-6666-6666-6666-666666666630"), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(792), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(792), false, "Email.M365ClientId", "" },
                    { new Guid("66666666-6666-6666-6666-666666666631"), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(793), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(794), true, "Email.M365ClientSecret", "" },
                    { new Guid("66666666-6666-6666-6666-666666666632"), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(795), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(795), false, "Email.M365SenderAddress", "" },
                    { new Guid("66666666-6666-6666-6666-666666666633"), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(802), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(802), false, "Email.ReplyToAddress", "" },
                    { new Guid("66666666-6666-6666-6666-666666666634"), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(804), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(804), false, "Email.ReplyToName", "" }
                });

            migrationBuilder.InsertData(
                table: "tax_class",
                columns: new[] { "Id", "DateCreated", "DateModified", "TaxRate", "TenantId" },
                values: new object[,]
                {
                    { new Guid("77777777-7777-7777-7777-777777777771"), new DateTime(2026, 7, 7, 15, 25, 1, 416, DateTimeKind.Utc).AddTicks(7936), new DateTime(2026, 7, 7, 15, 25, 1, 416, DateTimeKind.Utc).AddTicks(7937), 19.0, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("77777777-7777-7777-7777-777777777772"), new DateTime(2026, 7, 7, 15, 25, 1, 416, DateTimeKind.Utc).AddTicks(8187), new DateTime(2026, 7, 7, 15, 25, 1, 416, DateTimeKind.Utc).AddTicks(8187), 7.0, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("77777777-7777-7777-7777-777777777773"), new DateTime(2026, 7, 7, 15, 25, 1, 416, DateTimeKind.Utc).AddTicks(8189), new DateTime(2026, 7, 7, 15, 25, 1, 416, DateTimeKind.Utc).AddTicks(8190), 0.0, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") }
                });

            migrationBuilder.InsertData(
                table: "warehouse",
                columns: new[] { "Id", "DateCreated", "DateModified", "Name", "TenantId" },
                values: new object[] { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(8167), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(8169), "Hauptlager", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.CreateIndex(
                name: "IX_ai_prompt_AiModelId",
                table: "ai_prompt",
                column: "AiModelId");

            migrationBuilder.CreateIndex(
                name: "IX_channel_export_outbox_SalesChannelId_IdempotencyKey",
                table: "channel_export_outbox",
                columns: new[] { "SalesChannelId", "IdempotencyKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_channel_export_outbox_Status_NextAttemptAt",
                table: "channel_export_outbox",
                columns: new[] { "Status", "NextAttemptAt" });

            migrationBuilder.CreateIndex(
                name: "IX_channel_sync_log_CorrelationId",
                table: "channel_sync_log",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_channel_sync_log_SalesChannelId_Timestamp",
                table: "channel_sync_log",
                columns: new[] { "SalesChannelId", "Timestamp" },
                descending: new[] { false, true });

            migrationBuilder.CreateIndex(
                name: "IX_channel_sync_log_Timestamp",
                table: "channel_sync_log",
                column: "Timestamp");

            migrationBuilder.CreateIndex(
                name: "IX_channel_sync_run_CorrelationId",
                table: "channel_sync_run",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_channel_sync_run_SalesChannelId_StartedAt",
                table: "channel_sync_run",
                columns: new[] { "SalesChannelId", "StartedAt" },
                descending: new[] { false, true });

            migrationBuilder.CreateIndex(
                name: "IX_country_CountryCode_TenantId",
                table: "country",
                columns: new[] { "CountryCode", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customer_address_CountryId",
                table: "customer_address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_customer_address_CustomerId",
                table: "customer_address",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_customer_saleschannel_CustomerId",
                table: "customer_saleschannel",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_customer_saleschannel_SalesChannelId_RemoteCustomerId",
                table: "customer_saleschannel",
                columns: new[] { "SalesChannelId", "RemoteCustomerId" });

            migrationBuilder.CreateIndex(
                name: "IX_goods_receipt_DateCreated",
                table: "goods_receipt",
                column: "DateCreated");

            migrationBuilder.CreateIndex(
                name: "IX_goods_receipt_ProductId",
                table: "goods_receipt",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_goods_receipt_ReceiptDate",
                table: "goods_receipt",
                column: "ReceiptDate");

            migrationBuilder.CreateIndex(
                name: "IX_goods_receipt_TenantId",
                table: "goods_receipt",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_goods_receipt_WarehouseId",
                table: "goods_receipt",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_CustomerId",
                table: "invoice",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_SalesId",
                table: "invoice",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_TenantId",
                table: "invoice",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_item_InvoiceId",
                table: "invoice_item",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_item_ProductId",
                table: "invoice_item",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_item_TenantId",
                table: "invoice_item",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_oauth_state_ExpiresAt",
                table: "oauth_state",
                column: "ExpiresAt");

            migrationBuilder.CreateIndex(
                name: "IX_oauth_state_StateToken",
                table: "oauth_state",
                column: "StateToken",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_Gtin",
                table: "product",
                column: "Gtin");

            migrationBuilder.CreateIndex(
                name: "IX_product_ManufacturerId",
                table: "product",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_product_ParentProductId",
                table: "product",
                column: "ParentProductId");

            migrationBuilder.CreateIndex(
                name: "IX_product_ProductType",
                table: "product",
                column: "ProductType");

            migrationBuilder.CreateIndex(
                name: "IX_product_TaxClassId",
                table: "product",
                column: "TaxClassId");

            migrationBuilder.CreateIndex(
                name: "IX_product_TenantId_Sku",
                table: "product",
                columns: new[] { "TenantId", "Sku" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_attribute_TenantId_Name",
                table: "product_attribute",
                columns: new[] { "TenantId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_attribute_value_ProductAttributeId",
                table: "product_attribute_value",
                column: "ProductAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_product_attribute_value_TenantId_ProductAttributeId_Value",
                table: "product_attribute_value",
                columns: new[] { "TenantId", "ProductAttributeId", "Value" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_image_ProductId_SalesChannelId_RemoteImageId",
                table: "product_image",
                columns: new[] { "ProductId", "SalesChannelId", "RemoteImageId" });

            migrationBuilder.CreateIndex(
                name: "IX_product_image_ProductId_SortOrder",
                table: "product_image",
                columns: new[] { "ProductId", "SortOrder" });

            migrationBuilder.CreateIndex(
                name: "IX_product_saleschannel_ProductId",
                table: "product_saleschannel",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_product_saleschannel_SalesChannelId",
                table: "product_saleschannel",
                column: "SalesChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_product_saleschannel_TenantId_ProductId_SalesChannelId",
                table: "product_saleschannel",
                columns: new[] { "TenantId", "ProductId", "SalesChannelId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_stock_ProductId",
                table: "product_stock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_product_stock_WarehouseId",
                table: "product_stock",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_product_variant_axis_ParentProductId_ProductAttributeId",
                table: "product_variant_axis",
                columns: new[] { "ParentProductId", "ProductAttributeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_variant_axis_ProductAttributeId",
                table: "product_variant_axis",
                column: "ProductAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_product_variant_option_ProductAttributeValueId",
                table: "product_variant_option",
                column: "ProductAttributeValueId");

            migrationBuilder.CreateIndex(
                name: "IX_product_variant_option_ProductId_ProductAttributeValueId",
                table: "product_variant_option",
                columns: new[] { "ProductId", "ProductAttributeValueId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_refresh_token_ExpiresAt",
                table: "refresh_token",
                column: "ExpiresAt");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_token_Family",
                table: "refresh_token",
                column: "Family");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_token_TokenHash",
                table: "refresh_token",
                column: "TokenHash",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_refresh_token_UserId",
                table: "refresh_token",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_return_label_outbox_ReturnShipmentId_IdempotencyKey",
                table: "return_label_outbox",
                columns: new[] { "ReturnShipmentId", "IdempotencyKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_return_label_outbox_Status_NextAttemptAt",
                table: "return_label_outbox",
                columns: new[] { "Status", "NextAttemptAt" });

            migrationBuilder.CreateIndex(
                name: "IX_return_shipment_OriginalShippingId",
                table: "return_shipment",
                column: "OriginalShippingId");

            migrationBuilder.CreateIndex(
                name: "IX_return_shipment_SalesId",
                table: "return_shipment",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_return_shipment_ShippingProviderId",
                table: "return_shipment",
                column: "ShippingProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_return_shipment_Status",
                table: "return_shipment",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_return_shipment_TrackingNumber_TenantId",
                table: "return_shipment",
                columns: new[] { "TrackingNumber", "TenantId" });

            migrationBuilder.CreateIndex(
                name: "IX_return_shipment_item_ReturnShipmentId",
                table: "return_shipment_item",
                column: "ReturnShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_return_shipment_item_SalesItemId",
                table: "return_shipment_item",
                column: "SalesItemId");

            migrationBuilder.CreateIndex(
                name: "IX_return_shipment_item_serialnumber_ReturnShipmentItemId",
                table: "return_shipment_item_serialnumber",
                column: "ReturnShipmentItemId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "role",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_role_claim_RoleId",
                table: "role_claim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_CustomerId",
                table: "sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_SalesChannelId_RemoteSalesId",
                table: "sales",
                columns: new[] { "SalesChannelId", "RemoteSalesId" });

            migrationBuilder.CreateIndex(
                name: "IX_sales_SalesId_TenantId",
                table: "sales",
                columns: new[] { "SalesId", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sales_history_SalesId",
                table: "sales_history",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_history_ShippingId",
                table: "sales_history",
                column: "ShippingId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_history_TenantId",
                table: "sales_history",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_item_SalesId",
                table: "sales_item",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_item_TenantId",
                table: "sales_item",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_item_serialnumber_SalesItemId",
                table: "sales_item_serialnumber",
                column: "SalesItemId");

            migrationBuilder.CreateIndex(
                name: "IX_saleschannel_TenantId",
                table: "saleschannel",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_saleschannel_TrackingTokenHash",
                table: "saleschannel",
                column: "TrackingTokenHash");

            migrationBuilder.CreateIndex(
                name: "IX_SalesChannelWarehouses_WarehousesId",
                table: "SalesChannelWarehouses",
                column: "WarehousesId");

            migrationBuilder.CreateIndex(
                name: "IX_shipping_SalesId",
                table: "shipping",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_shipping_ShippingProviderId",
                table: "shipping",
                column: "ShippingProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_shipping_ShippingProviderRateId",
                table: "shipping",
                column: "ShippingProviderRateId");

            migrationBuilder.CreateIndex(
                name: "IX_shipping_Status",
                table: "shipping",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_shipping_TrackingNumber_TenantId",
                table: "shipping",
                columns: new[] { "TrackingNumber", "TenantId" });

            migrationBuilder.CreateIndex(
                name: "IX_shipping_label_outbox_ShippingId_IdempotencyKey",
                table: "shipping_label_outbox",
                columns: new[] { "ShippingId", "IdempotencyKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shipping_label_outbox_Status_NextAttemptAt",
                table: "shipping_label_outbox",
                columns: new[] { "Status", "NextAttemptAt" });

            migrationBuilder.CreateIndex(
                name: "IX_shipping_provider_Name_TenantId",
                table: "shipping_provider",
                columns: new[] { "Name", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shipping_provider_rate_ShippingProviderId_Name_TenantId",
                table: "shipping_provider_rate",
                columns: new[] { "ShippingProviderId", "Name", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shipping_provider_rate_country_CountryId",
                table: "shipping_provider_rate_country",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_shipping_provider_rate_country_ShippingProviderRateId_CountryId",
                table: "shipping_provider_rate_country",
                columns: new[] { "ShippingProviderRateId", "CountryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_stock_movement_ProductId_WarehouseId_DateCreated",
                table: "stock_movement",
                columns: new[] { "ProductId", "WarehouseId", "DateCreated" });

            migrationBuilder.CreateIndex(
                name: "IX_stock_movement_SalesItemId_Type",
                table: "stock_movement",
                columns: new[] { "SalesItemId", "Type" },
                unique: true,
                filter: "SalesItemId IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_stock_movement_TenantId",
                table: "stock_movement",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_tenant_email_settings_TenantId",
                table: "tenant_email_settings",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_tenant_oauth_app_settings_TenantId_Provider",
                table: "tenant_oauth_app_settings",
                columns: new[] { "TenantId", "Provider" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "user",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_user_DefaultTenantId",
                table: "user",
                column: "DefaultTenantId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "user",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_claim_UserId",
                table: "user_claim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_login_UserId",
                table: "user_login",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_RoleId",
                table: "user_role",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_user_tenant_Id",
                table: "user_tenant",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_tenant_TenantId",
                table: "user_tenant",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ai_prompt");

            migrationBuilder.DropTable(
                name: "channel_export_outbox");

            migrationBuilder.DropTable(
                name: "channel_sync_log");

            migrationBuilder.DropTable(
                name: "channel_sync_run");

            migrationBuilder.DropTable(
                name: "customer_address");

            migrationBuilder.DropTable(
                name: "customer_saleschannel");

            migrationBuilder.DropTable(
                name: "goods_receipt");

            migrationBuilder.DropTable(
                name: "invoice_item");

            migrationBuilder.DropTable(
                name: "oauth_state");

            migrationBuilder.DropTable(
                name: "product_image");

            migrationBuilder.DropTable(
                name: "product_saleschannel");

            migrationBuilder.DropTable(
                name: "product_stock");

            migrationBuilder.DropTable(
                name: "product_variant_axis");

            migrationBuilder.DropTable(
                name: "product_variant_option");

            migrationBuilder.DropTable(
                name: "refresh_token");

            migrationBuilder.DropTable(
                name: "return_label_outbox");

            migrationBuilder.DropTable(
                name: "return_shipment_item_serialnumber");

            migrationBuilder.DropTable(
                name: "role_claim");

            migrationBuilder.DropTable(
                name: "sales_history");

            migrationBuilder.DropTable(
                name: "sales_item_serialnumber");

            migrationBuilder.DropTable(
                name: "SalesChannelWarehouses");

            migrationBuilder.DropTable(
                name: "setting");

            migrationBuilder.DropTable(
                name: "shipping_label_outbox");

            migrationBuilder.DropTable(
                name: "shipping_provider_rate_country");

            migrationBuilder.DropTable(
                name: "stock_movement");

            migrationBuilder.DropTable(
                name: "tenant_email_settings");

            migrationBuilder.DropTable(
                name: "tenant_oauth_app_settings");

            migrationBuilder.DropTable(
                name: "user_claim");

            migrationBuilder.DropTable(
                name: "user_login");

            migrationBuilder.DropTable(
                name: "user_role");

            migrationBuilder.DropTable(
                name: "user_tenant");

            migrationBuilder.DropTable(
                name: "user_token");

            migrationBuilder.DropTable(
                name: "ai_model");

            migrationBuilder.DropTable(
                name: "invoice");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "product_attribute_value");

            migrationBuilder.DropTable(
                name: "return_shipment_item");

            migrationBuilder.DropTable(
                name: "saleschannel");

            migrationBuilder.DropTable(
                name: "warehouse");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "manufacturer");

            migrationBuilder.DropTable(
                name: "tax_class");

            migrationBuilder.DropTable(
                name: "product_attribute");

            migrationBuilder.DropTable(
                name: "return_shipment");

            migrationBuilder.DropTable(
                name: "sales_item");

            migrationBuilder.DropTable(
                name: "tenant");

            migrationBuilder.DropTable(
                name: "shipping");

            migrationBuilder.DropTable(
                name: "sales");

            migrationBuilder.DropTable(
                name: "shipping_provider_rate");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "shipping_provider");
        }
    }
}
