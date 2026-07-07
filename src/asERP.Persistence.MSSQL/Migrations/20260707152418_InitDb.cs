using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace asERP.Persistence.MSSQL.Migrations
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AiModelType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApiUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApiUsername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApiPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApiKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NCtx = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ai_model", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VatNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerStatus = table.Column<int>(type: "int", nullable: false),
                    DateEnrollment = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    State = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "oauth_state",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Provider = table.Column<int>(type: "int", nullable: false),
                    StateToken = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Nonce = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsumedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oauth_state", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "product_attribute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_attribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "refresh_token",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    TokenHash = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Family = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReplacedByTokenId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsPersistent = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refresh_token", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "saleschannel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", maxLength: 8192, nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", maxLength: 8192, nullable: true),
                    TokenExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarketplaceId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    AdditionalConfigJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImportProducts = table.Column<bool>(type: "bit", nullable: false),
                    ImportCustomers = table.Column<bool>(type: "bit", nullable: false),
                    ImportSaless = table.Column<bool>(type: "bit", nullable: false),
                    ExportProducts = table.Column<bool>(type: "bit", nullable: false),
                    ExportCustomers = table.Column<bool>(type: "bit", nullable: false),
                    ExportSaless = table.Column<bool>(type: "bit", nullable: false),
                    ExportStock = table.Column<bool>(type: "bit", nullable: false),
                    PushSalesCancellations = table.Column<bool>(type: "bit", nullable: false),
                    ImportStock = table.Column<bool>(type: "bit", nullable: false),
                    InitialProductImportCompleted = table.Column<bool>(type: "bit", nullable: false),
                    InitialProductExportCompleted = table.Column<bool>(type: "bit", nullable: false),
                    InitialCustomerImportCompleted = table.Column<bool>(type: "bit", nullable: false),
                    InitialSalesImportCompleted = table.Column<bool>(type: "bit", nullable: false),
                    SalesImportBackfillCursor = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerImportPageCursor = table.Column<int>(type: "int", nullable: false),
                    SyncIntervalSeconds = table.Column<int>(type: "int", nullable: false),
                    LastSyncStartedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    TrackingEnabled = table.Column<bool>(type: "bit", nullable: false),
                    TrackingToken = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    TrackingTokenHash = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    WebhookSecret = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saleschannel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEncrypted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_setting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "shipping_provider",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UseSandbox = table.Column<bool>(type: "bit", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: false),
                    ApiKey = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    ApiSecret = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    AdditionalConfigJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackingPollIntervalSeconds = table.Column<int>(type: "int", nullable: false),
                    LastTrackingPollStartedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipping_provider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "stock_movement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantityDelta = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SalesItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesChannelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock_movement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tax_class",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxRate = table.Column<double>(type: "float", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tax_class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tenant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Street2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Iban = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: true),
                    PackingSlipShowPrices = table.Column<bool>(type: "bit", nullable: false),
                    PackingSlipPrintByDefault = table.Column<bool>(type: "bit", nullable: false),
                    SendShippingNotificationEmails = table.Column<bool>(type: "bit", nullable: false),
                    SendDeliveryNotificationEmails = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "warehouse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ai_prompt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AiModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Identifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PromptText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultDeliveryAddress = table.Column<bool>(type: "bit", nullable: false),
                    DefaultInvoiceAddress = table.Column<bool>(type: "bit", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemoteCustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesId = table.Column<int>(type: "int", nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemoteSalesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ShippingCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalTax = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentProvider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentTransactionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternalNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressZip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressZip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesConfirmationSent = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceSent = table.Column<bool>(type: "bit", nullable: false),
                    ShippingInformationSent = table.Column<bool>(type: "bit", nullable: false),
                    DateSalesed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductAttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Operation = table.Column<int>(type: "int", nullable: false),
                    AggregateType = table.Column<int>(type: "int", nullable: false),
                    AggregateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PayloadJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdempotencyKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    AttemptCount = table.Column<int>(type: "int", nullable: false),
                    NextAttemptAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LastError = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorrelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Operation = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Exception = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Operation = table.Column<int>(type: "int", nullable: false),
                    TriggerSource = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ItemsProcessed = table.Column<int>(type: "int", nullable: false),
                    ItemsFailed = table.Column<int>(type: "int", nullable: false),
                    ItemsTotal = table.Column<int>(type: "int", nullable: true),
                    ErrorSummary = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CorrelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShippingProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaxLength = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    MaxWidth = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    MaxHeight = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    MaxWeight = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameOptimized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ean = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Asin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gtin = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Mpn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionOptimized = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseOptimized = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Msrp = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Width = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Depth = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    TaxClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManufacturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    ParentProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VariantSortOrder = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProviderType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SmtpHost = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SmtpPort = table.Column<int>(type: "int", nullable: true),
                    SmtpUsername = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SmtpPassword = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    SmtpEnableSsl = table.Column<bool>(type: "bit", nullable: true),
                    M365TenantId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    M365ClientId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    M365ClientSecret = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    M365SenderAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FromAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FromName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ReplyToAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ReplyToName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Provider = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ClientSecret = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    RedirectUri = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RuName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Scopes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    UseSandbox = table.Column<bool>(type: "bit", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultTenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
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
                    SalesChannelsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehousesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SalesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ShippingCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalTax = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    InvoiceStatus = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentTransactionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressZip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceAddressCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressZip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShippingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesStatusOld = table.Column<int>(type: "int", nullable: true),
                    SalesStatusNew = table.Column<int>(type: "int", nullable: true),
                    PaymentStatusOld = table.Column<int>(type: "int", nullable: true),
                    PaymentStatusNew = table.Column<int>(type: "int", nullable: true),
                    ShippingStatusOld = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingStatusNew = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSystemGenerated = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxRate = table.Column<double>(type: "float", nullable: false),
                    MissingProductSku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MissingProductEan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShippingProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShippingProviderRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TrackingNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrackingUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ShippingCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxRate = table.Column<double>(type: "float", nullable: false),
                    WeightKg = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    LengthCm = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    WidthCm = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    HeightCm = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    CarrierShipmentId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    LabelData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LabelFormat = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    LastTrackedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShippedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveredAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastCarrierStatusRaw = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    CustomerNotifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerDeliveryNotifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShippingProviderRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "date", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    RelativePath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ThumbnailPath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    OriginalFileName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    SalesChannelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RemoteImageId = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    AltText = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    FileSizeBytes = table.Column<long>(type: "bigint", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemoteProductId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ExternalListingId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    IsListed = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MinPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    MaxPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    RepricingType = table.Column<int>(type: "int", nullable: false),
                    MinimumProfit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MinimumProfitUnit = table.Column<int>(type: "int", nullable: false),
                    StockBuffer = table.Column<int>(type: "int", nullable: false),
                    FulfillmentChannel = table.Column<int>(type: "int", nullable: false),
                    SyncStatus = table.Column<int>(type: "int", nullable: false),
                    LastSyncedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastExportHash = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    LastErrorMessage = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MetadataJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stock = table.Column<double>(type: "float", nullable: false),
                    StockMin = table.Column<double>(type: "float", nullable: false),
                    StockMax = table.Column<double>(type: "float", nullable: false),
                    StorageLocation = table.Column<double>(type: "float", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductAttributeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductAttributeValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RoleManageTenant = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RoleManageUser = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxRate = table.Column<double>(type: "float", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OriginalShippingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShippingProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TrackingNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrackingUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    CarrierShipmentId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    LabelData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LabelFormat = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    RefundAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ReceivedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastTrackedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastCarrierStatusRaw = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShippingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShippingProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdempotencyKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AttemptCount = table.Column<int>(type: "int", nullable: false),
                    NextAttemptAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastError = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReturnShipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShippingProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdempotencyKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AttemptCount = table.Column<int>(type: "int", nullable: false),
                    NextAttemptAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastError = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReturnShipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Reason = table.Column<int>(type: "int", nullable: false),
                    ReasonText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReturnShipmentItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    { new Guid("00000000-0000-0000-0000-000000000001"), "DE", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(6047), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(6055), "Germany", null },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "AT", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8001), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8001), "Austria", null },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "CH", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8040), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8040), "Switzerland", null },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "AD", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8044), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8045), "Andorra", null },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "AF", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8048), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8049), "Afghanistan", null },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "AG", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8052), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8052), "Antigua and Barbuda", null },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "AL", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8055), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8056), "Albania", null },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "AM", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8059), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8059), "Armenia", null },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "AO", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8063), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8063), "Angola", null },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "AX", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8071), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8072), "Åland Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "AR", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8075), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8075), "Argentina", null },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "AQ", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8078), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8079), "Antarctica", null },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "AU", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8082), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8082), "Australia", null },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "AZ", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8085), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8086), "Azerbaijan", null },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "BA", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8089), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8089), "Bosnia and Herzegovina", null },
                    { new Guid("00000000-0000-0000-0000-000000000016"), "BB", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8092), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8093), "Barbados", null },
                    { new Guid("00000000-0000-0000-0000-000000000017"), "BE", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8096), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8096), "Belgium", null },
                    { new Guid("00000000-0000-0000-0000-000000000018"), "BG", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8103), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8103), "Bulgaria", null },
                    { new Guid("00000000-0000-0000-0000-000000000019"), "BL", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8126), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8126), "Saint Barthélemy", null },
                    { new Guid("00000000-0000-0000-0000-000000000020"), "BO", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8129), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8130), "Bolivia", null },
                    { new Guid("00000000-0000-0000-0000-000000000021"), "BR", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8133), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8134), "Brazil", null },
                    { new Guid("00000000-0000-0000-0000-000000000022"), "BS", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8137), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8137), "Bahamas", null },
                    { new Guid("00000000-0000-0000-0000-000000000023"), "BY", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8140), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8141), "Belarus", null },
                    { new Guid("00000000-0000-0000-0000-000000000024"), "BZ", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8144), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8144), "Belize", null },
                    { new Guid("00000000-0000-0000-0000-000000000025"), "CA", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8147), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8148), "Canada", null },
                    { new Guid("00000000-0000-0000-0000-000000000026"), "CC", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8154), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8154), "Cocos (Keeling) Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000027"), "CI", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8158), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8158), "Ivory Coast", null },
                    { new Guid("00000000-0000-0000-0000-000000000028"), "CL", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8161), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8162), "Chile", null },
                    { new Guid("00000000-0000-0000-0000-000000000029"), "CN", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8165), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8165), "China", null },
                    { new Guid("00000000-0000-0000-0000-000000000030"), "CO", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8169), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8169), "Colombia", null },
                    { new Guid("00000000-0000-0000-0000-000000000031"), "CR", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8172), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8173), "Costa Rica", null },
                    { new Guid("00000000-0000-0000-0000-000000000032"), "CU", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8177), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8178), "Cuba", null },
                    { new Guid("00000000-0000-0000-0000-000000000033"), "CY", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8181), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8182), "Cyprus", null },
                    { new Guid("00000000-0000-0000-0000-000000000034"), "CZ", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8188), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8188), "Czech Republic", null },
                    { new Guid("00000000-0000-0000-0000-000000000035"), "DO", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8210), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8211), "Dominican Republic", null },
                    { new Guid("00000000-0000-0000-0000-000000000036"), "DK", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8214), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8214), "Denmark", null },
                    { new Guid("00000000-0000-0000-0000-000000000037"), "DZ", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8217), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8218), "Algeria", null },
                    { new Guid("00000000-0000-0000-0000-000000000038"), "EC", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8221), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8221), "Ecuador", null },
                    { new Guid("00000000-0000-0000-0000-000000000039"), "EE", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8224), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8225), "Estonia", null },
                    { new Guid("00000000-0000-0000-0000-000000000040"), "EG", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8228), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8228), "Egypt", null },
                    { new Guid("00000000-0000-0000-0000-000000000041"), "ER", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8231), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8232), "Eritrea", null },
                    { new Guid("00000000-0000-0000-0000-000000000042"), "ES", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8238), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8239), "Spain", null },
                    { new Guid("00000000-0000-0000-0000-000000000043"), "ET", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8242), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8242), "Ethiopia", null },
                    { new Guid("00000000-0000-0000-0000-000000000044"), "FI", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8245), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8246), "Finland", null },
                    { new Guid("00000000-0000-0000-0000-000000000045"), "FR", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8249), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8249), "France", null },
                    { new Guid("00000000-0000-0000-0000-000000000046"), "GB", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8252), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8253), "United Kingdom", null },
                    { new Guid("00000000-0000-0000-0000-000000000047"), "GE", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8256), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8256), "Georgia", null },
                    { new Guid("00000000-0000-0000-0000-000000000048"), "GF", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8259), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8260), "French Guiana", null },
                    { new Guid("00000000-0000-0000-0000-000000000049"), "GH", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8263), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8263), "Ghana", null },
                    { new Guid("00000000-0000-0000-0000-000000000050"), "GL", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8270), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8270), "Greenland", null },
                    { new Guid("00000000-0000-0000-0000-000000000051"), "GP", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8292), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8293), "Guadeloupe", null },
                    { new Guid("00000000-0000-0000-0000-000000000052"), "GR", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8296), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8296), "Greece", null },
                    { new Guid("00000000-0000-0000-0000-000000000053"), "GT", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8300), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8300), "Guatemala", null },
                    { new Guid("00000000-0000-0000-0000-000000000054"), "GY", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8303), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8304), "Guyana", null },
                    { new Guid("00000000-0000-0000-0000-000000000055"), "HN", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8339), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8340), "Honduras", null },
                    { new Guid("00000000-0000-0000-0000-000000000056"), "HR", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8343), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8343), "Croatia", null },
                    { new Guid("00000000-0000-0000-0000-000000000057"), "HT", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8346), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8347), "Haiti", null },
                    { new Guid("00000000-0000-0000-0000-000000000058"), "HU", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8353), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8354), "Hungary", null },
                    { new Guid("00000000-0000-0000-0000-000000000059"), "ID", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8357), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8358), "Indonesia", null },
                    { new Guid("00000000-0000-0000-0000-000000000060"), "IE", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8360), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8361), "Ireland", null },
                    { new Guid("00000000-0000-0000-0000-000000000061"), "IN", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8364), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8365), "India", null },
                    { new Guid("00000000-0000-0000-0000-000000000062"), "IR", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8368), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8368), "Iran", null },
                    { new Guid("00000000-0000-0000-0000-000000000063"), "IS", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8371), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8372), "Iceland", null },
                    { new Guid("00000000-0000-0000-0000-000000000064"), "IT", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8375), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8375), "Italy", null },
                    { new Guid("00000000-0000-0000-0000-000000000065"), "JM", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8378), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8379), "Jamaica", null },
                    { new Guid("00000000-0000-0000-0000-000000000066"), "JP", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8385), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8386), "Japan", null },
                    { new Guid("00000000-0000-0000-0000-000000000067"), "KE", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8408), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8408), "Kenya", null },
                    { new Guid("00000000-0000-0000-0000-000000000068"), "KG", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8411), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8412), "Kyrgyzstan", null },
                    { new Guid("00000000-0000-0000-0000-000000000069"), "KR", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8415), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8415), "South Korea", null },
                    { new Guid("00000000-0000-0000-0000-000000000070"), "KW", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8418), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8419), "Kuwait", null },
                    { new Guid("00000000-0000-0000-0000-000000000071"), "KZ", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8422), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8422), "Kazakhstan", null },
                    { new Guid("00000000-0000-0000-0000-000000000072"), "LU", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8425), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8426), "Luxembourg", null },
                    { new Guid("00000000-0000-0000-0000-000000000073"), "LT", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8429), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8429), "Lithuania", null },
                    { new Guid("00000000-0000-0000-0000-000000000074"), "LV", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8435), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8436), "Latvia", null },
                    { new Guid("00000000-0000-0000-0000-000000000075"), "MA", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8439), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8440), "Morocco", null },
                    { new Guid("00000000-0000-0000-0000-000000000076"), "MC", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8443), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8443), "Monaco", null },
                    { new Guid("00000000-0000-0000-0000-000000000077"), "MD", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8446), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8447), "Moldova", null },
                    { new Guid("00000000-0000-0000-0000-000000000078"), "MF", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8450), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8450), "Saint Martin", null },
                    { new Guid("00000000-0000-0000-0000-000000000079"), "MG", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8453), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8454), "Madagascar", null },
                    { new Guid("00000000-0000-0000-0000-000000000080"), "MQ", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8457), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8457), "Martinique", null },
                    { new Guid("00000000-0000-0000-0000-000000000081"), "MT", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8461), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8461), "Malta", null },
                    { new Guid("00000000-0000-0000-0000-000000000082"), "MX", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8468), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8468), "Mexico", null },
                    { new Guid("00000000-0000-0000-0000-000000000083"), "MY", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8489), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8489), "Malaysia", null },
                    { new Guid("00000000-0000-0000-0000-000000000084"), "NG", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8492), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8493), "Nigeria", null },
                    { new Guid("00000000-0000-0000-0000-000000000085"), "NI", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8496), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8497), "Nicaragua", null },
                    { new Guid("00000000-0000-0000-0000-000000000086"), "NL", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8499), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8500), "Netherlands", null },
                    { new Guid("00000000-0000-0000-0000-000000000087"), "NO", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8503), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8504), "Norway", null },
                    { new Guid("00000000-0000-0000-0000-000000000088"), "NZ", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8507), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8507), "New Zealand", null },
                    { new Guid("00000000-0000-0000-0000-000000000089"), "OM", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8510), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8510), "Oman", null },
                    { new Guid("00000000-0000-0000-0000-000000000090"), "PA", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8517), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8518), "Panama", null },
                    { new Guid("00000000-0000-0000-0000-000000000091"), "PE", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8521), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8521), "Peru", null },
                    { new Guid("00000000-0000-0000-0000-000000000092"), "PL", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8524), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8525), "Poland", null },
                    { new Guid("00000000-0000-0000-0000-000000000093"), "PM", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8528), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8528), "Saint Pierre and Miquelon", null },
                    { new Guid("00000000-0000-0000-0000-000000000094"), "PR", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8531), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8532), "Puerto Rico", null },
                    { new Guid("00000000-0000-0000-0000-000000000095"), "PT", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8535), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8536), "Portugal", null },
                    { new Guid("00000000-0000-0000-0000-000000000096"), "PY", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8539), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8539), "Paraguay", null },
                    { new Guid("00000000-0000-0000-0000-000000000097"), "QA", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8542), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8543), "Qatar", null },
                    { new Guid("00000000-0000-0000-0000-000000000098"), "RO", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8549), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8549), "Romania", null },
                    { new Guid("00000000-0000-0000-0000-000000000099"), "RS", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8570), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8570), "Serbia", null },
                    { new Guid("00000000-0000-0000-0000-000000000100"), "RU", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8573), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8574), "Russia", null },
                    { new Guid("00000000-0000-0000-0000-000000000101"), "SA", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8577), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8577), "Saudi Arabia", null },
                    { new Guid("00000000-0000-0000-0000-000000000102"), "SE", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8580), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8581), "Sweden", null },
                    { new Guid("00000000-0000-0000-0000-000000000103"), "SG", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8584), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8584), "Singapore", null },
                    { new Guid("00000000-0000-0000-0000-000000000104"), "SI", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8587), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8588), "Slovenia", null },
                    { new Guid("00000000-0000-0000-0000-000000000105"), "SK", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8591), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8591), "Slovakia", null },
                    { new Guid("00000000-0000-0000-0000-000000000106"), "SN", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8598), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8598), "Senegal", null },
                    { new Guid("00000000-0000-0000-0000-000000000107"), "SR", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8601), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8602), "Suriname", null },
                    { new Guid("00000000-0000-0000-0000-000000000108"), "SV", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8605), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8605), "El Salvador", null },
                    { new Guid("00000000-0000-0000-0000-000000000109"), "TR", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8608), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8609), "Turkey", null },
                    { new Guid("00000000-0000-0000-0000-000000000110"), "TT", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8612), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8612), "Trinidad and Tobago", null },
                    { new Guid("00000000-0000-0000-0000-000000000111"), "UA", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8616), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8616), "Ukraine", null },
                    { new Guid("00000000-0000-0000-0000-000000000112"), "US", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8619), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8619), "United States", null },
                    { new Guid("00000000-0000-0000-0000-000000000113"), "UY", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8623), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8623), "Uruguay", null },
                    { new Guid("00000000-0000-0000-0000-000000000114"), "VE", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8630), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8630), "Venezuela", null },
                    { new Guid("00000000-0000-0000-0000-000000000115"), "VI", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8633), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8634), "Virgin Islands", null },
                    { new Guid("00000000-0000-0000-0000-000000000116"), "VN", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8637), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8637), "Vietnam", null },
                    { new Guid("00000000-0000-0000-0000-000000000117"), "YE", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8640), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8641), "Yemen", null },
                    { new Guid("00000000-0000-0000-0000-000000000118"), "ZA", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8644), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8644), "South Africa", null },
                    { new Guid("00000000-0000-0000-0000-000000000119"), "ZM", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8648), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8648), "Zambia", null },
                    { new Guid("00000000-0000-0000-0000-000000000120"), "ZW", new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8651), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8651), "Zimbabwe", null }
                });

            migrationBuilder.InsertData(
                table: "manufacturer",
                columns: new[] { "Id", "City", "Country", "DateCreated", "DateModified", "Email", "Logo", "Name", "Phone", "State", "Street", "TenantId", "Website", "ZipCode" },
                values: new object[] { new Guid("55555555-5555-5555-5555-555555555555"), "Berlin", "Deutschland", new DateTime(2026, 7, 7, 15, 20, 22, 248, DateTimeKind.Utc).AddTicks(8962), new DateTime(2026, 7, 7, 15, 20, 22, 248, DateTimeKind.Utc).AddTicks(8965), "info@beispiel-hersteller.de", null, "Beispiel Hersteller GmbH", "+49 30 12345678", "Berlin", "Musterstraße 123", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "https://www.beispiel-hersteller.de", "10115" });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "abc43a7e-f7bb-4447-baaf-1add431ddbdf", "f3610330-991a-4e0b-a2f1-732111c5e090", "Superadmin", "SUPERADMIN" },
                    { "cac43a6e-f7bb-4448-baaf-1add431ccbbf", "d3fdb538-705f-4a3a-9bf5-400ca37c3d02", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "saleschannel",
                columns: new[] { "Id", "AccessToken", "AdditionalConfigJson", "ConcurrencyToken", "CustomerImportPageCursor", "DateCreated", "DateModified", "ExportCustomers", "ExportProducts", "ExportSaless", "ExportStock", "ImportCustomers", "ImportProducts", "ImportSaless", "ImportStock", "InitialCustomerImportCompleted", "InitialProductExportCompleted", "InitialProductImportCompleted", "InitialSalesImportCompleted", "IsEnabled", "LastSyncStartedAt", "MarketplaceId", "Name", "Password", "PushSalesCancellations", "RefreshToken", "SalesImportBackfillCursor", "SyncIntervalSeconds", "TenantId", "TokenExpiresAt", "TrackingEnabled", "TrackingToken", "TrackingTokenHash", "Type", "Url", "Username", "WebhookSecret" },
                values: new object[] { new Guid("88888888-8888-8888-8888-888888888888"), null, null, new Guid("00000000-0000-0000-0000-000000000000"), 0, new DateTime(2026, 7, 7, 15, 20, 22, 280, DateTimeKind.Utc).AddTicks(2249), new DateTime(2026, 7, 7, 15, 20, 22, 280, DateTimeKind.Utc).AddTicks(2255), false, false, false, false, false, false, false, false, false, false, false, false, true, null, null, "Kasse Ladengeschäft", "", false, null, null, 60, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), null, false, null, null, 1, "", "", null });

            migrationBuilder.InsertData(
                table: "setting",
                columns: new[] { "Id", "DateCreated", "DateModified", "IsEncrypted", "Key", "Value" },
                values: new object[,]
                {
                    { new Guid("66666666-6666-6666-6666-666666666615"), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(1199), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(1204), false, "Jwt.Issuer", "asERP.Server" },
                    { new Guid("66666666-6666-6666-6666-666666666616"), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3016), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3017), false, "Jwt.Audience", "asERP.Client" },
                    { new Guid("66666666-6666-6666-6666-666666666617"), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3024), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3024), false, "Jwt.DurationInMinutes", "60" },
                    { new Guid("66666666-6666-6666-6666-666666666618"), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3029), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3029), false, "Jwt.RefreshTokenExpireDays", "7" },
                    { new Guid("66666666-6666-6666-6666-666666666619"), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3046), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3046), false, "Email.ProviderType", "Smtp" },
                    { new Guid("66666666-6666-6666-6666-666666666620"), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3600), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3601), false, "Email.FromAddress", "no-reply@martin-andrich.de" },
                    { new Guid("66666666-6666-6666-6666-666666666621"), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3604), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3605), false, "Email.FromName", "asERP" },
                    { new Guid("66666666-6666-6666-6666-666666666622"), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3615), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3615), false, "Telemetry.Endpoint", "http://localhost:4317" },
                    { new Guid("66666666-6666-6666-6666-666666666623"), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3618), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3619), false, "Telemetry.ServiceName", "asERP.Server" },
                    { new Guid("66666666-6666-6666-6666-666666666624"), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3050), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3051), false, "Email.SmtpHost", "" },
                    { new Guid("66666666-6666-6666-6666-666666666625"), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3054), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3054), false, "Email.SmtpPort", "587" },
                    { new Guid("66666666-6666-6666-6666-666666666626"), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3057), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3058), false, "Email.SmtpUsername", "" },
                    { new Guid("66666666-6666-6666-6666-666666666627"), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3061), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3062), true, "Email.SmtpPassword", "" },
                    { new Guid("66666666-6666-6666-6666-666666666628"), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3573), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3574), false, "Email.SmtpEnableSsl", "true" },
                    { new Guid("66666666-6666-6666-6666-666666666629"), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3579), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3580), false, "Email.M365TenantId", "" },
                    { new Guid("66666666-6666-6666-6666-666666666630"), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3583), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3584), false, "Email.M365ClientId", "" },
                    { new Guid("66666666-6666-6666-6666-666666666631"), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3593), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3593), true, "Email.M365ClientSecret", "" },
                    { new Guid("66666666-6666-6666-6666-666666666632"), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3597), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3597), false, "Email.M365SenderAddress", "" },
                    { new Guid("66666666-6666-6666-6666-666666666633"), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3608), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3608), false, "Email.ReplyToAddress", "" },
                    { new Guid("66666666-6666-6666-6666-666666666634"), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3611), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3612), false, "Email.ReplyToName", "" }
                });

            migrationBuilder.InsertData(
                table: "tax_class",
                columns: new[] { "Id", "DateCreated", "DateModified", "TaxRate", "TenantId" },
                values: new object[,]
                {
                    { new Guid("77777777-7777-7777-7777-777777777771"), new DateTime(2026, 7, 7, 15, 20, 22, 285, DateTimeKind.Utc).AddTicks(8067), new DateTime(2026, 7, 7, 15, 20, 22, 285, DateTimeKind.Utc).AddTicks(8071), 19.0, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("77777777-7777-7777-7777-777777777772"), new DateTime(2026, 7, 7, 15, 20, 22, 285, DateTimeKind.Utc).AddTicks(8935), new DateTime(2026, 7, 7, 15, 20, 22, 285, DateTimeKind.Utc).AddTicks(8936), 7.0, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("77777777-7777-7777-7777-777777777773"), new DateTime(2026, 7, 7, 15, 20, 22, 285, DateTimeKind.Utc).AddTicks(8942), new DateTime(2026, 7, 7, 15, 20, 22, 285, DateTimeKind.Utc).AddTicks(8943), 0.0, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") }
                });

            migrationBuilder.InsertData(
                table: "warehouse",
                columns: new[] { "Id", "DateCreated", "DateModified", "Name", "TenantId" },
                values: new object[] { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 7, 7, 15, 20, 22, 247, DateTimeKind.Utc).AddTicks(322), new DateTime(2026, 7, 7, 15, 20, 22, 247, DateTimeKind.Utc).AddTicks(325), "Hauptlager", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

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
                unique: true,
                filter: "[TenantId] IS NOT NULL");

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
                unique: true,
                filter: "[TenantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_product_attribute_TenantId_Name",
                table: "product_attribute",
                columns: new[] { "TenantId", "Name" },
                unique: true,
                filter: "[TenantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_product_attribute_value_ProductAttributeId",
                table: "product_attribute_value",
                column: "ProductAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_product_attribute_value_TenantId_ProductAttributeId_Value",
                table: "product_attribute_value",
                columns: new[] { "TenantId", "ProductAttributeId", "Value" },
                unique: true,
                filter: "[TenantId] IS NOT NULL");

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
                unique: true,
                filter: "[TenantId] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[TenantId] IS NOT NULL");

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
                unique: true,
                filter: "[TenantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_shipping_provider_rate_ShippingProviderId_Name_TenantId",
                table: "shipping_provider_rate",
                columns: new[] { "ShippingProviderId", "Name", "TenantId" },
                unique: true,
                filter: "[TenantId] IS NOT NULL");

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
                filter: "[SalesItemId] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
