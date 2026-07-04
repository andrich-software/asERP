using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.MSSQL.Migrations;

/// <inheritdoc />
public partial class AddShippingFeature : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_shipping_provider_rate_shipping_provider_ShippingProviderId",
            table: "shipping_provider_rate");

        migrationBuilder.DropIndex(
            name: "IX_shipping_provider_rate_ShippingProviderId",
            table: "shipping_provider_rate");

        migrationBuilder.DropColumn(
            name: "ShippingProviderName",
            table: "shipping");

        migrationBuilder.DropColumn(
            name: "ShippingTaxRate",
            table: "shipping");

        migrationBuilder.AlterColumn<Guid>(
            name: "ShippingProviderId",
            table: "shipping_provider_rate",
            type: "uniqueidentifier",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
            oldClrType: typeof(Guid),
            oldType: "uniqueidentifier",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "shipping_provider_rate",
            type: "nvarchar(100)",
            maxLength: 100,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AddColumn<decimal>(
            name: "Price",
            table: "shipping_provider_rate",
            type: "decimal(18,2)",
            precision: 18,
            scale: 2,
            nullable: false,
            defaultValue: 0m);

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "shipping_provider",
            type: "nvarchar(100)",
            maxLength: 100,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AddColumn<string>(
            name: "AccountNumber",
            table: "shipping_provider",
            type: "nvarchar(64)",
            maxLength: 64,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "AdditionalConfigJson",
            table: "shipping_provider",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "ApiKey",
            table: "shipping_provider",
            type: "nvarchar(max)",
            maxLength: 4096,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "ApiSecret",
            table: "shipping_provider",
            type: "nvarchar(max)",
            maxLength: 4096,
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "IsEnabled",
            table: "shipping_provider",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<DateTime>(
            name: "LastTrackingPollStartedAt",
            table: "shipping_provider",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Password",
            table: "shipping_provider",
            type: "nvarchar(max)",
            maxLength: 4096,
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<int>(
            name: "TrackingPollIntervalSeconds",
            table: "shipping_provider",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<int>(
            name: "Type",
            table: "shipping_provider",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<bool>(
            name: "UseSandbox",
            table: "shipping_provider",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<string>(
            name: "Username",
            table: "shipping_provider",
            type: "nvarchar(255)",
            maxLength: 255,
            nullable: false,
            defaultValue: "");

        migrationBuilder.AlterColumn<string>(
            name: "TrackingNumber",
            table: "shipping",
            type: "nvarchar(100)",
            maxLength: 100,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        // Hand-edited: no string -> decimal cast; the table was never written by app code,
        // so drop + re-add instead of converting.
        migrationBuilder.DropColumn(
            name: "ShippingCost",
            table: "shipping");

        migrationBuilder.AddColumn<decimal>(
            name: "ShippingCost",
            table: "shipping",
            type: "decimal(18,2)",
            precision: 18,
            scale: 2,
            nullable: false,
            defaultValue: 0m);

        migrationBuilder.AddColumn<string>(
            name: "CarrierShipmentId",
            table: "shipping",
            type: "nvarchar(128)",
            maxLength: 128,
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "DeliveredAt",
            table: "shipping",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<decimal>(
            name: "HeightCm",
            table: "shipping",
            type: "decimal(18,4)",
            precision: 18,
            scale: 4,
            nullable: true);

        migrationBuilder.AddColumn<byte[]>(
            name: "LabelData",
            table: "shipping",
            type: "varbinary(max)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "LabelFormat",
            table: "shipping",
            type: "nvarchar(32)",
            maxLength: 32,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "LastCarrierStatusRaw",
            table: "shipping",
            type: "nvarchar(512)",
            maxLength: 512,
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "LastTrackedAt",
            table: "shipping",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<decimal>(
            name: "LengthCm",
            table: "shipping",
            type: "decimal(18,4)",
            precision: 18,
            scale: 4,
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "ShippedAt",
            table: "shipping",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "ShippingProviderRateId",
            table: "shipping",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.AddColumn<int>(
            name: "Status",
            table: "shipping",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<double>(
            name: "TaxRate",
            table: "shipping",
            type: "float",
            nullable: false,
            defaultValue: 0.0);

        migrationBuilder.AddColumn<string>(
            name: "TrackingUrl",
            table: "shipping",
            type: "nvarchar(512)",
            maxLength: 512,
            nullable: true);

        migrationBuilder.AddColumn<decimal>(
            name: "WeightKg",
            table: "shipping",
            type: "decimal(18,4)",
            precision: 18,
            scale: 4,
            nullable: true);

        migrationBuilder.AddColumn<decimal>(
            name: "WidthCm",
            table: "shipping",
            type: "decimal(18,4)",
            precision: 18,
            scale: 4,
            nullable: true);

        migrationBuilder.AlterColumn<Guid>(
            name: "ShippingId",
            table: "sales_item",
            type: "uniqueidentifier",
            nullable: true,
            oldClrType: typeof(Guid),
            oldType: "uniqueidentifier");

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

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2227), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2228) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2824), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2824) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2828), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2828) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2829), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2830) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2838), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2839) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2840), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2840) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2842), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2842) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2843), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2844) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2845), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2845) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2847), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2847) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2848), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2849) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2850), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2850) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2853), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2853) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2854), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2855) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2866), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2867) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2868), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2869) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2870), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2870) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2872), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2872) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2874), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2874) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2875), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2876) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2878), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2878) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2880), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2880) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2881), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2881) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2892), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2892) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2894), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2894) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2895), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2895) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2903), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2903) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2912), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2912) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2915), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2915) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2916), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2916) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2925), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2926) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2928), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2928) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2929), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2929) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2931), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2932) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2933), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2933) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2935), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2935) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2938), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2938) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2940), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2940) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2941), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2941) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2942), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2943) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2944), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2944) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2946), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2946) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2947), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2947) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2949), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2949) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2951), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2951) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2953), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2953) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2961), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2962) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2964), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2965) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2967), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2967) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2968), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2968) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2970), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2970) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2971), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2971) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2974), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2974) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2975), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2976) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2977), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2977) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2979), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2979) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2980), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2980) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2982), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2982) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2983), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2983) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2984), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2985) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2987), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2987) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2989), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2989) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2997), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2997) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3000), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3000) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3001), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3001) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3003), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3003) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3005), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3005) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3006), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3006) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3009), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3009) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3011), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3011) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3012), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3012) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3014), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3014) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3016), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3016) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3017), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3017) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3019), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3019) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3020), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3020) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3023), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3023) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3024), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3025) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3033), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3033) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3036), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3036) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3037), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3037) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3039), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3039) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3041), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3041) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3042), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3042) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3045), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3045) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3047), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3047) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3048), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3049) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3050), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3050) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3052), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3052) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3053), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3053) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3055), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3055) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3056), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3056) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3059), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3059) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3060), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3060) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3069), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3069) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3072), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3072) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3073), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3073) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3075), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3075) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3076), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3077) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3078), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3078) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3081), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3081) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3083), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3084) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3085), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3086) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3087), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3087) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3089), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3089) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3091), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3091) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3093), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3093) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3095), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3095) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3097), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3098) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3099), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3099) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3100), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3101) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3102), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3102) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3103), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3103) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3105), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3105) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3106), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3106) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3108), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3108) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3114), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3114) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3115), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3115) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3117), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3117) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3118), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3118) });

        migrationBuilder.UpdateData(
            table: "manufacturer",
            keyColumn: "Id",
            keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 821, DateTimeKind.Utc).AddTicks(2213), new DateTime(2026, 7, 3, 19, 25, 28, 821, DateTimeKind.Utc).AddTicks(2214) });

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
            column: "ConcurrencyStamp",
            value: "8e71e8e0-2915-49e6-945d-43efc1781b65");

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
            column: "ConcurrencyStamp",
            value: "829fadb0-0aeb-4741-a310-6ec041f66f88");

        migrationBuilder.UpdateData(
            table: "saleschannel",
            keyColumn: "Id",
            keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 832, DateTimeKind.Utc).AddTicks(7052), new DateTime(2026, 7, 3, 19, 25, 28, 832, DateTimeKind.Utc).AddTicks(7056) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4477), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4479) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4915), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4915) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4918), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4918) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4920), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4920) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4921), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4922) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4944), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4944) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4946), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4946) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4950), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4950) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4952), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4952) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4923), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4923) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4931), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4931) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4933), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4933) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4934), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4934) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4935), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4936) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4937), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4937) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4939), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4939) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4940), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4940) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4941), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4942) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4947), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4947) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4949), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4949) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 834, DateTimeKind.Utc).AddTicks(3092), new DateTime(2026, 7, 3, 19, 25, 28, 834, DateTimeKind.Utc).AddTicks(3094) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 834, DateTimeKind.Utc).AddTicks(3303), new DateTime(2026, 7, 3, 19, 25, 28, 834, DateTimeKind.Utc).AddTicks(3304) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 834, DateTimeKind.Utc).AddTicks(3306), new DateTime(2026, 7, 3, 19, 25, 28, 834, DateTimeKind.Utc).AddTicks(3306) });

        migrationBuilder.UpdateData(
            table: "tenant",
            keyColumn: "Id",
            keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 813, DateTimeKind.Utc).AddTicks(4304), new DateTime(2026, 7, 3, 19, 25, 28, 813, DateTimeKind.Utc).AddTicks(4308) });

        migrationBuilder.UpdateData(
            table: "user",
            keyColumn: "Id",
            keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
            columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
            values: new object[] { "a75d9d13-eb9d-446b-a79e-045e2c3ba148", new DateTime(2026, 7, 3, 19, 25, 28, 774, DateTimeKind.Utc).AddTicks(1818), new DateTime(2026, 7, 3, 19, 25, 28, 774, DateTimeKind.Utc).AddTicks(1821), "AQAAAAIAAYagAAAAEL4XxQI3HHUkm08zg0alyEc7A4YlxGTo/+Mb6yY7F/bFeTh1vc/CRe9YZ0yNnU+f/g==", "a87e5690-3e7f-4f7b-a2da-452c1a6ccfe3" });

        migrationBuilder.UpdateData(
            table: "user_tenant",
            keyColumns: new[] { "TenantId", "UserId" },
            keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
            columns: new[] { "DateCreated", "DateModified", "Id" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 818, DateTimeKind.Utc).AddTicks(3153), new DateTime(2026, 7, 3, 19, 25, 28, 818, DateTimeKind.Utc).AddTicks(3280), new Guid("1528bed9-5ea6-4c6c-b274-9e5e569aca1f") });

        migrationBuilder.UpdateData(
            table: "warehouse",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(5911), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(5911) });

        migrationBuilder.CreateIndex(
            name: "IX_shipping_provider_rate_ShippingProviderId_Name_TenantId",
            table: "shipping_provider_rate",
            columns: new[] { "ShippingProviderId", "Name", "TenantId" },
            unique: true,
            filter: "[TenantId] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_shipping_provider_Name_TenantId",
            table: "shipping_provider",
            columns: new[] { "Name", "TenantId" },
            unique: true,
            filter: "[TenantId] IS NOT NULL");

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
            name: "IX_shipping_provider_rate_country_CountryId",
            table: "shipping_provider_rate_country",
            column: "CountryId");

        migrationBuilder.CreateIndex(
            name: "IX_shipping_provider_rate_country_ShippingProviderRateId_CountryId",
            table: "shipping_provider_rate_country",
            columns: new[] { "ShippingProviderRateId", "CountryId" },
            unique: true);

        migrationBuilder.AddForeignKey(
            name: "FK_shipping_sales_SalesId",
            table: "shipping",
            column: "SalesId",
            principalTable: "sales",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_shipping_shipping_provider_ShippingProviderId",
            table: "shipping",
            column: "ShippingProviderId",
            principalTable: "shipping_provider",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_shipping_shipping_provider_rate_ShippingProviderRateId",
            table: "shipping",
            column: "ShippingProviderRateId",
            principalTable: "shipping_provider_rate",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_shipping_provider_rate_shipping_provider_ShippingProviderId",
            table: "shipping_provider_rate",
            column: "ShippingProviderId",
            principalTable: "shipping_provider",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_shipping_sales_SalesId",
            table: "shipping");

        migrationBuilder.DropForeignKey(
            name: "FK_shipping_shipping_provider_ShippingProviderId",
            table: "shipping");

        migrationBuilder.DropForeignKey(
            name: "FK_shipping_shipping_provider_rate_ShippingProviderRateId",
            table: "shipping");

        migrationBuilder.DropForeignKey(
            name: "FK_shipping_provider_rate_shipping_provider_ShippingProviderId",
            table: "shipping_provider_rate");

        migrationBuilder.DropTable(
            name: "shipping_label_outbox");

        migrationBuilder.DropTable(
            name: "shipping_provider_rate_country");

        migrationBuilder.DropIndex(
            name: "IX_shipping_provider_rate_ShippingProviderId_Name_TenantId",
            table: "shipping_provider_rate");

        migrationBuilder.DropIndex(
            name: "IX_shipping_provider_Name_TenantId",
            table: "shipping_provider");

        migrationBuilder.DropIndex(
            name: "IX_shipping_SalesId",
            table: "shipping");

        migrationBuilder.DropIndex(
            name: "IX_shipping_ShippingProviderId",
            table: "shipping");

        migrationBuilder.DropIndex(
            name: "IX_shipping_ShippingProviderRateId",
            table: "shipping");

        migrationBuilder.DropIndex(
            name: "IX_shipping_Status",
            table: "shipping");

        migrationBuilder.DropIndex(
            name: "IX_shipping_TrackingNumber_TenantId",
            table: "shipping");

        migrationBuilder.DropColumn(
            name: "Price",
            table: "shipping_provider_rate");

        migrationBuilder.DropColumn(
            name: "AccountNumber",
            table: "shipping_provider");

        migrationBuilder.DropColumn(
            name: "AdditionalConfigJson",
            table: "shipping_provider");

        migrationBuilder.DropColumn(
            name: "ApiKey",
            table: "shipping_provider");

        migrationBuilder.DropColumn(
            name: "ApiSecret",
            table: "shipping_provider");

        migrationBuilder.DropColumn(
            name: "IsEnabled",
            table: "shipping_provider");

        migrationBuilder.DropColumn(
            name: "LastTrackingPollStartedAt",
            table: "shipping_provider");

        migrationBuilder.DropColumn(
            name: "Password",
            table: "shipping_provider");

        migrationBuilder.DropColumn(
            name: "TrackingPollIntervalSeconds",
            table: "shipping_provider");

        migrationBuilder.DropColumn(
            name: "Type",
            table: "shipping_provider");

        migrationBuilder.DropColumn(
            name: "UseSandbox",
            table: "shipping_provider");

        migrationBuilder.DropColumn(
            name: "Username",
            table: "shipping_provider");

        migrationBuilder.DropColumn(
            name: "CarrierShipmentId",
            table: "shipping");

        migrationBuilder.DropColumn(
            name: "DeliveredAt",
            table: "shipping");

        migrationBuilder.DropColumn(
            name: "HeightCm",
            table: "shipping");

        migrationBuilder.DropColumn(
            name: "LabelData",
            table: "shipping");

        migrationBuilder.DropColumn(
            name: "LabelFormat",
            table: "shipping");

        migrationBuilder.DropColumn(
            name: "LastCarrierStatusRaw",
            table: "shipping");

        migrationBuilder.DropColumn(
            name: "LastTrackedAt",
            table: "shipping");

        migrationBuilder.DropColumn(
            name: "LengthCm",
            table: "shipping");

        migrationBuilder.DropColumn(
            name: "ShippedAt",
            table: "shipping");

        migrationBuilder.DropColumn(
            name: "ShippingProviderRateId",
            table: "shipping");

        migrationBuilder.DropColumn(
            name: "Status",
            table: "shipping");

        migrationBuilder.DropColumn(
            name: "TaxRate",
            table: "shipping");

        migrationBuilder.DropColumn(
            name: "TrackingUrl",
            table: "shipping");

        migrationBuilder.DropColumn(
            name: "WeightKg",
            table: "shipping");

        migrationBuilder.DropColumn(
            name: "WidthCm",
            table: "shipping");

        migrationBuilder.AlterColumn<Guid>(
            name: "ShippingProviderId",
            table: "shipping_provider_rate",
            type: "uniqueidentifier",
            nullable: true,
            oldClrType: typeof(Guid),
            oldType: "uniqueidentifier");

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "shipping_provider_rate",
            type: "nvarchar(max)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(100)",
            oldMaxLength: 100);

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "shipping_provider",
            type: "nvarchar(max)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(100)",
            oldMaxLength: 100);

        migrationBuilder.AlterColumn<string>(
            name: "TrackingNumber",
            table: "shipping",
            type: "nvarchar(max)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(100)",
            oldMaxLength: 100);

        // Hand-edited: mirror of the Up() drop + re-add.
        migrationBuilder.DropColumn(
            name: "ShippingCost",
            table: "shipping");

        migrationBuilder.AddColumn<string>(
            name: "ShippingCost",
            table: "shipping",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "ShippingProviderName",
            table: "shipping",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "ShippingTaxRate",
            table: "shipping",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");

        migrationBuilder.AlterColumn<Guid>(
            name: "ShippingId",
            table: "sales_item",
            type: "uniqueidentifier",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
            oldClrType: typeof(Guid),
            oldType: "uniqueidentifier",
            oldNullable: true);

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1268), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1269) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1958), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1958) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1961), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1961) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1974), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1975) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1977), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1977) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1979), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1979) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1986), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1986) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1988), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1988) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1990), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1990) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1991), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1991) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1993), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1993) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1995), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1995) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1996), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1997) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1998), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1998) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2001), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2002) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2003), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2003) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2005), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2005) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2006), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2007) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2008), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2008) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2018), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2019) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2021), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2021) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2023), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2023) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2026), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2026) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2027), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2028) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2029), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2029) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2031), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2031) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2043), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2043) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2046), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2047) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2048), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2048) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2050), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2050) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2053), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2053) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2055), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2055) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2056), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2056) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2058), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2058) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2059), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2060) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2069), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2070) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2072), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2072) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2074), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2074) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2077), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2077) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2078), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2079) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2080), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2080) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2082), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2082) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2083), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2084) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2085), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2085) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2087), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2087) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2088), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2089) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2091), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2092) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2093), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2093) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2095), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2095) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2096), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2097) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2098), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2098) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2107), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2108) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2110), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2111) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2112), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2112) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2115), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2116) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2117), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2117) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2119), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2119) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2121), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2121) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2122), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2123) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2124), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2124) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2126), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2126) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2136), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2136) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2139), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2140) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2141), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2141) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2143), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2143) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2145), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2145) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2146), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2146) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2156), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2156) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2158), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2159) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2161), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2161) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2164), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2164) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2166), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2167) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2168), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2168) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2170), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2170) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2172), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2172) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2174), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2174) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2175), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2176) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2178), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2178) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2181), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2181) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2183), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2183) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2185), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2185) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2186), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2187) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2188), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2188) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2197), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2198) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2200), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2200) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2202), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2202) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2205), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2205) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2206), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2207) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2208), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2208) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2210), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2210) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2212), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2212) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2213), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2213) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2215), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2215) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2216), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2217) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2219), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2220) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2221), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2221) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2223), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2223) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2224), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2225) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2226), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2226) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2235), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2236) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2238), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2239) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2241), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2241) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2245), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2245) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2247), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2248) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2249), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2250) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2251), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2251) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2253), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2253) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2255), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2255) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2257), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2257) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2259), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2259) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2262), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2262) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2264), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2264) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2265), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2266) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2267), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2267) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2269), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2269) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2270), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2271) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2272), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2272) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2274), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2274) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2277), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2277) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2279), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2279) });

        migrationBuilder.UpdateData(
            table: "manufacturer",
            keyColumn: "Id",
            keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 37, DateTimeKind.Utc).AddTicks(2728), new DateTime(2026, 7, 2, 14, 8, 15, 37, DateTimeKind.Utc).AddTicks(2729) });

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
            column: "ConcurrencyStamp",
            value: "159a6658-de1d-407b-9db5-024a8c5c1173");

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
            column: "ConcurrencyStamp",
            value: "cd2844cb-5888-4ed7-b687-6a4e919b47ae");

        migrationBuilder.UpdateData(
            table: "saleschannel",
            keyColumn: "Id",
            keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 49, DateTimeKind.Utc).AddTicks(5714), new DateTime(2026, 7, 2, 14, 8, 15, 49, DateTimeKind.Utc).AddTicks(5715) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9538), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9542) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9924), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9924) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9927), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9928) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9930), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9930) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9932), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9932) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9949), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9950) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9951), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9951) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9957), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9957) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9959), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9959) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9934), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9934) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9935), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9935) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9937), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9937) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9941), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9941) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9942), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9942) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9944), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9944) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9945), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9945) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9947), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9947) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9948), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9948) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9954), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9954) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9955), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9956) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 51, DateTimeKind.Utc).AddTicks(2126), new DateTime(2026, 7, 2, 14, 8, 15, 51, DateTimeKind.Utc).AddTicks(2128) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 51, DateTimeKind.Utc).AddTicks(2343), new DateTime(2026, 7, 2, 14, 8, 15, 51, DateTimeKind.Utc).AddTicks(2343) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 51, DateTimeKind.Utc).AddTicks(2346), new DateTime(2026, 7, 2, 14, 8, 15, 51, DateTimeKind.Utc).AddTicks(2346) });

        migrationBuilder.UpdateData(
            table: "tenant",
            keyColumn: "Id",
            keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 28, DateTimeKind.Utc).AddTicks(8520), new DateTime(2026, 7, 2, 14, 8, 15, 28, DateTimeKind.Utc).AddTicks(8524) });

        migrationBuilder.UpdateData(
            table: "user",
            keyColumn: "Id",
            keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
            columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
            values: new object[] { "1d6e5726-6a77-46ac-80fd-a7f525bc3e77", new DateTime(2026, 7, 2, 14, 8, 14, 984, DateTimeKind.Utc).AddTicks(6633), new DateTime(2026, 7, 2, 14, 8, 14, 984, DateTimeKind.Utc).AddTicks(6636), "AQAAAAIAAYagAAAAEFLRo9HgcxCO+rclSRzdC8fVqrPysGclru2CRWeROo3SV2AjWe++LiSstZQq8RAZNw==", "42c7635e-b3f7-40af-9d25-f802b1b3b36d" });

        migrationBuilder.UpdateData(
            table: "user_tenant",
            keyColumns: new[] { "TenantId", "UserId" },
            keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
            columns: new[] { "DateCreated", "DateModified", "Id" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 34, DateTimeKind.Utc).AddTicks(151), new DateTime(2026, 7, 2, 14, 8, 15, 34, DateTimeKind.Utc).AddTicks(279), new Guid("311018f1-fd56-42c1-b812-1d8822db31f2") });

        migrationBuilder.UpdateData(
            table: "warehouse",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(5411), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(5412) });

        migrationBuilder.CreateIndex(
            name: "IX_shipping_provider_rate_ShippingProviderId",
            table: "shipping_provider_rate",
            column: "ShippingProviderId");

        migrationBuilder.AddForeignKey(
            name: "FK_shipping_provider_rate_shipping_provider_ShippingProviderId",
            table: "shipping_provider_rate",
            column: "ShippingProviderId",
            principalTable: "shipping_provider",
            principalColumn: "Id");
    }
}
