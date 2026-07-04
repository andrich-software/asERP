using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.SQLite.Migrations;

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
            type: "TEXT",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
            oldClrType: typeof(Guid),
            oldType: "TEXT",
            oldNullable: true);

        migrationBuilder.AddColumn<decimal>(
            name: "Price",
            table: "shipping_provider_rate",
            type: "TEXT",
            precision: 18,
            scale: 2,
            nullable: false,
            defaultValue: 0m);

        migrationBuilder.AddColumn<string>(
            name: "AccountNumber",
            table: "shipping_provider",
            type: "TEXT",
            maxLength: 64,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "AdditionalConfigJson",
            table: "shipping_provider",
            type: "TEXT",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "ApiKey",
            table: "shipping_provider",
            type: "TEXT",
            maxLength: 4096,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "ApiSecret",
            table: "shipping_provider",
            type: "TEXT",
            maxLength: 4096,
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "IsEnabled",
            table: "shipping_provider",
            type: "INTEGER",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<DateTime>(
            name: "LastTrackingPollStartedAt",
            table: "shipping_provider",
            type: "TEXT",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Password",
            table: "shipping_provider",
            type: "TEXT",
            maxLength: 4096,
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<int>(
            name: "TrackingPollIntervalSeconds",
            table: "shipping_provider",
            type: "INTEGER",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<int>(
            name: "Type",
            table: "shipping_provider",
            type: "INTEGER",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<bool>(
            name: "UseSandbox",
            table: "shipping_provider",
            type: "INTEGER",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<string>(
            name: "Username",
            table: "shipping_provider",
            type: "TEXT",
            maxLength: 255,
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "CarrierShipmentId",
            table: "shipping",
            type: "TEXT",
            maxLength: 128,
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "DeliveredAt",
            table: "shipping",
            type: "TEXT",
            nullable: true);

        migrationBuilder.AddColumn<decimal>(
            name: "HeightCm",
            table: "shipping",
            type: "TEXT",
            precision: 18,
            scale: 4,
            nullable: true);

        migrationBuilder.AddColumn<byte[]>(
            name: "LabelData",
            table: "shipping",
            type: "BLOB",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "LabelFormat",
            table: "shipping",
            type: "TEXT",
            maxLength: 32,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "LastCarrierStatusRaw",
            table: "shipping",
            type: "TEXT",
            maxLength: 512,
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "LastTrackedAt",
            table: "shipping",
            type: "TEXT",
            nullable: true);

        migrationBuilder.AddColumn<decimal>(
            name: "LengthCm",
            table: "shipping",
            type: "TEXT",
            precision: 18,
            scale: 4,
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "ShippedAt",
            table: "shipping",
            type: "TEXT",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "ShippingProviderRateId",
            table: "shipping",
            type: "TEXT",
            nullable: true);

        migrationBuilder.AddColumn<int>(
            name: "Status",
            table: "shipping",
            type: "INTEGER",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<double>(
            name: "TaxRate",
            table: "shipping",
            type: "REAL",
            nullable: false,
            defaultValue: 0.0);

        migrationBuilder.AddColumn<string>(
            name: "TrackingUrl",
            table: "shipping",
            type: "TEXT",
            maxLength: 512,
            nullable: true);

        migrationBuilder.AddColumn<decimal>(
            name: "WeightKg",
            table: "shipping",
            type: "TEXT",
            precision: 18,
            scale: 4,
            nullable: true);

        migrationBuilder.AddColumn<decimal>(
            name: "WidthCm",
            table: "shipping",
            type: "TEXT",
            precision: 18,
            scale: 4,
            nullable: true);

        migrationBuilder.AlterColumn<Guid>(
            name: "ShippingId",
            table: "sales_item",
            type: "TEXT",
            nullable: true,
            oldClrType: typeof(Guid),
            oldType: "TEXT");

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

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(8376), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(8377) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9042), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9042) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9046), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9046) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9047), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9048) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9049), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9049) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9051), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9051) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9059), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9059) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9061), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9061) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9063), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9063) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9064), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9065) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9066), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9066) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9080), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9080) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9081), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9082) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9083), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9083) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9087), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9087) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9088), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9089) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9100), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9101) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9102), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9103) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9104), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9104) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9106), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9106) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9108), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9108) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9110), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9110) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9113), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9113) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9114), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9115) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9116), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9116) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9118), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9118) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9132), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9132) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9138), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9138) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9140), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9140) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9142), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9142) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9145), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9145) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9146), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9146) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9155), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9156) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9157), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9158) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9159), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9160) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9162), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9162) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9163), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9164) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9165), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9165) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9168), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9168) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9170), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9170) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9172), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9172) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9173), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9174) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9175), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9175) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9177), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9177) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9178), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9179) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9180), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9180) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9183), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9183) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9185), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9185) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9195), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9195) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9197), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9198) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9200), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9200) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9202), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9202) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9204), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9204) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9205), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9205) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9208), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9208) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9210), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9210) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9212), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9212) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9213), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9214) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9215), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9215) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9217), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9217) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9218), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9219) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9220), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9220) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9223), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9223) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9225), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9225) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9233), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9234) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9236), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9236) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9238), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9238) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9240), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9240) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9241), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9241) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9243), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9243) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9246), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9246) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9248), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9248) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9250), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9250) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9251), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9252) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9253), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9253) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9255), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9255) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9256), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9257) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9258), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9258) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9261), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9261) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9263), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9263) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9272), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9272) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9274), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9274) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9276), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9276) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9278), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9278) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9279), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9280) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9281), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9281) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9284), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9284) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9286), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9286) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9288), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9288) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9289), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9290) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9291), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9291) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9293), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9293) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9294), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9294) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9296), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9296) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9299), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9299) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9300), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9300) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9309), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9309) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9312), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9312) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9314), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9314) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9316), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9317) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9318), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9319) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9320), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9321) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9324), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9324) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9325), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9326) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9332), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9332) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9334), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9335) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9337), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9337) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9339), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9339) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9341), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9341) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9343), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9343) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9345), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9346) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9347), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9347) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9349), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9349) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9350), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9351) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9352), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9352) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9354), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9354) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9355), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9356) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9357), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9357) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9360), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9360) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9362), new DateTime(2026, 7, 3, 19, 26, 9, 702, DateTimeKind.Utc).AddTicks(9362) });

        migrationBuilder.UpdateData(
            table: "manufacturer",
            keyColumn: "Id",
            keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 703, DateTimeKind.Utc).AddTicks(9399), new DateTime(2026, 7, 3, 19, 26, 9, 703, DateTimeKind.Utc).AddTicks(9400) });

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
            column: "ConcurrencyStamp",
            value: "ea074e70-97c7-47e5-be3e-49411513fcaf");

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
            column: "ConcurrencyStamp",
            value: "ff8f6e2d-8b5e-4fab-bebc-f3d3afaab083");

        migrationBuilder.UpdateData(
            table: "saleschannel",
            keyColumn: "Id",
            keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 716, DateTimeKind.Utc).AddTicks(1656), new DateTime(2026, 7, 3, 19, 26, 9, 716, DateTimeKind.Utc).AddTicks(1660) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3595), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3598) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3974), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3975) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3984), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3984) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3986), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3987) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3988), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3988) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4006), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4007) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4008), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4008) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4014), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4014) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4016), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4016) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3990), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3990) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3992), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3992) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3993), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3994) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3995), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3995) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3997), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(3997) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4000), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4000) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4001), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4002) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4003), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4003) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4005), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4005) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4009), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4010) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4011), new DateTime(2026, 7, 3, 19, 26, 9, 737, DateTimeKind.Utc).AddTicks(4011) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 717, DateTimeKind.Utc).AddTicks(7857), new DateTime(2026, 7, 3, 19, 26, 9, 717, DateTimeKind.Utc).AddTicks(7859) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 717, DateTimeKind.Utc).AddTicks(8145), new DateTime(2026, 7, 3, 19, 26, 9, 717, DateTimeKind.Utc).AddTicks(8145) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 717, DateTimeKind.Utc).AddTicks(8147), new DateTime(2026, 7, 3, 19, 26, 9, 717, DateTimeKind.Utc).AddTicks(8147) });

        migrationBuilder.UpdateData(
            table: "tenant",
            keyColumn: "Id",
            keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 696, DateTimeKind.Utc).AddTicks(2770), new DateTime(2026, 7, 3, 19, 26, 9, 696, DateTimeKind.Utc).AddTicks(2776) });

        migrationBuilder.UpdateData(
            table: "user",
            keyColumn: "Id",
            keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
            columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
            values: new object[] { "a29cb451-f76a-4985-8cdc-a32454c417b2", new DateTime(2026, 7, 3, 19, 26, 9, 653, DateTimeKind.Utc).AddTicks(9155), new DateTime(2026, 7, 3, 19, 26, 9, 653, DateTimeKind.Utc).AddTicks(9159), "AQAAAAIAAYagAAAAEMrRd1y0pgQRGoDdtiaqwPs6kXwA6cH5ZZEAHWtAqJVdWZlceYjDqkD0j6zoOIukIw==", "48a20bc8-4ccc-48b0-aa98-d1bdf00f701f" });

        migrationBuilder.UpdateData(
            table: "user_tenant",
            keyColumns: new[] { "TenantId", "UserId" },
            keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
            columns: new[] { "DateCreated", "DateModified", "Id" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 700, DateTimeKind.Utc).AddTicks(7544), new DateTime(2026, 7, 3, 19, 26, 9, 700, DateTimeKind.Utc).AddTicks(7670), new Guid("b9c214ca-64a2-4e77-83ca-30d564b089ca") });

        migrationBuilder.UpdateData(
            table: "warehouse",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 9, 703, DateTimeKind.Utc).AddTicks(2659), new DateTime(2026, 7, 3, 19, 26, 9, 703, DateTimeKind.Utc).AddTicks(2660) });

        migrationBuilder.CreateIndex(
            name: "IX_shipping_provider_rate_ShippingProviderId_Name_TenantId",
            table: "shipping_provider_rate",
            columns: new[] { "ShippingProviderId", "Name", "TenantId" },
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_shipping_provider_Name_TenantId",
            table: "shipping_provider",
            columns: new[] { "Name", "TenantId" },
            unique: true);

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
            type: "TEXT",
            nullable: true,
            oldClrType: typeof(Guid),
            oldType: "TEXT");

        migrationBuilder.AddColumn<string>(
            name: "ShippingProviderName",
            table: "shipping",
            type: "TEXT",
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "ShippingTaxRate",
            table: "shipping",
            type: "TEXT",
            nullable: false,
            defaultValue: "");

        migrationBuilder.AlterColumn<Guid>(
            name: "ShippingId",
            table: "sales_item",
            type: "TEXT",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
            oldClrType: typeof(Guid),
            oldType: "TEXT",
            oldNullable: true);

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(594), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(595) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1208), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1209) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1212), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1212) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1214), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1214) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1223), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1223) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1224), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1225) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1226), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1226) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1228), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1228) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1230), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1230) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1231), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1231) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1233), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1233) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1234), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1235) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1238), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1238) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1239), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1239) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1241), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1241) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1242), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1242) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1244), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1244) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1255), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1256) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1257), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1257) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1259), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1259) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1262), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1262) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1263), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1263) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1265), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1265) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1266), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1267) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1268), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1268) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1270), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1270) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1279), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1279) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1284), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1284) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1287), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1287) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1288), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1288) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1289), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1290) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1291), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1291) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1293), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1293) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1302), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1303) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1305), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1305) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1307), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1307) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1310), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1310) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1312), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1312) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1313), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1314) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1315), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1315) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1317), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1317) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1318), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1318) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1320), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1320) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1321), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1321) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1324), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1324) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1325), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1325) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1327), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1327) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1328), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1329) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1330), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1330) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1339), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1339) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1340), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1341) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1342), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1342) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1345), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1345) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1347), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1347) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1348), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1348) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1350), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1350) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1351), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1351) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1353), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1353) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1354), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1354) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1355), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1356) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1358), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1358) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1360), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1360) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1361), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1361) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1363), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1363) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1364), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1364) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1372), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1372) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1374), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1374) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1376), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1376) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1379), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1379) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1381), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1381) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1383), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1383) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1384), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1384) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1385), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1386) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1387), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1387) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1388), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1389) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1390), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1390) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1392), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1393) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1394), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1394) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1395), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1395) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1397), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1397) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1398), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1398) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1407), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1407) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1409), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1409) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1411), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1411) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1414), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1414) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1415), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1415) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1417), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1417) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1419), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1419) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1420), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1420) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1422), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1422) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1424), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1424) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1425), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1425) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1428), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1428) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1429), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1430) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1436), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1436) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1437), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1437) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1439), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1439) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1448), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1448) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1450), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1450) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1452), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1452) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1455), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1455) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1457), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1457) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1459), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1459) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1461), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1461) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1463), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1463) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1465), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1465) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1466), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1467) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1468), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1469) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1471), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1472) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1473), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1473) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1475), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1475) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1476), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1476) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1478), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1478) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1479), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1479) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1480), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1481) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1482), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1482) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1485), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1485) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1486), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1486) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1487), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1488) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1489), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1489) });

        migrationBuilder.UpdateData(
            table: "manufacturer",
            keyColumn: "Id",
            keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 56, DateTimeKind.Utc).AddTicks(1504), new DateTime(2026, 7, 2, 14, 10, 6, 56, DateTimeKind.Utc).AddTicks(1506) });

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
            column: "ConcurrencyStamp",
            value: "2774e1a9-6b8a-4816-9804-eb908fbaffa6");

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
            column: "ConcurrencyStamp",
            value: "eacfe4ea-2768-48d6-99e0-3620ac9b3d2d");

        migrationBuilder.UpdateData(
            table: "saleschannel",
            keyColumn: "Id",
            keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 70, DateTimeKind.Utc).AddTicks(342), new DateTime(2026, 7, 2, 14, 10, 6, 70, DateTimeKind.Utc).AddTicks(344) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(7679), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(7682) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8032), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8032) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8036), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8037) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8038), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8038) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8045), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8045) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8061), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8061) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8062), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8063) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8067), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8067) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8068), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8068) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8047), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8047) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8048), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8049) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8050), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8050) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8051), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8052) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8053), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8053) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8054), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8054) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8056), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8056) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8058), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8059) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8060), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8060) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8064), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8064) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8065), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8065) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 71, DateTimeKind.Utc).AddTicks(5815), new DateTime(2026, 7, 2, 14, 10, 6, 71, DateTimeKind.Utc).AddTicks(5816) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 71, DateTimeKind.Utc).AddTicks(6024), new DateTime(2026, 7, 2, 14, 10, 6, 71, DateTimeKind.Utc).AddTicks(6025) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 71, DateTimeKind.Utc).AddTicks(6027), new DateTime(2026, 7, 2, 14, 10, 6, 71, DateTimeKind.Utc).AddTicks(6027) });

        migrationBuilder.UpdateData(
            table: "tenant",
            keyColumn: "Id",
            keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 47, DateTimeKind.Utc).AddTicks(7358), new DateTime(2026, 7, 2, 14, 10, 6, 47, DateTimeKind.Utc).AddTicks(7361) });

        migrationBuilder.UpdateData(
            table: "user",
            keyColumn: "Id",
            keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
            columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
            values: new object[] { "fbea7973-7637-46ee-bb47-72501ebe367c", new DateTime(2026, 7, 2, 14, 10, 6, 7, DateTimeKind.Utc).AddTicks(8575), new DateTime(2026, 7, 2, 14, 10, 6, 7, DateTimeKind.Utc).AddTicks(8577), "AQAAAAIAAYagAAAAECRi8s1Czxd5q3wUWnUM3S4nEpCRn3D0bdYoNMOLOwvhs6NYssBoXZA1Y2vk4dAYJA==", "05cfeb7b-cf82-4d27-bc97-de88c1535c57" });

        migrationBuilder.UpdateData(
            table: "user_tenant",
            keyColumns: new[] { "TenantId", "UserId" },
            keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
            columns: new[] { "DateCreated", "DateModified", "Id" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 53, DateTimeKind.Utc).AddTicks(1326), new DateTime(2026, 7, 2, 14, 10, 6, 53, DateTimeKind.Utc).AddTicks(1448), new Guid("205f3194-3e24-4179-8573-fce3b4ede524") });

        migrationBuilder.UpdateData(
            table: "warehouse",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(4375), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(4376) });

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
