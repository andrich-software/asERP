using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.PostgreSQL.Migrations;

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
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
            oldClrType: typeof(Guid),
            oldType: "uuid",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "shipping_provider_rate",
            type: "character varying(100)",
            maxLength: 100,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AddColumn<decimal>(
            name: "Price",
            table: "shipping_provider_rate",
            type: "numeric(18,2)",
            precision: 18,
            scale: 2,
            nullable: false,
            defaultValue: 0m);

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "shipping_provider",
            type: "character varying(100)",
            maxLength: 100,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AddColumn<string>(
            name: "AccountNumber",
            table: "shipping_provider",
            type: "character varying(64)",
            maxLength: 64,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "AdditionalConfigJson",
            table: "shipping_provider",
            type: "text",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "ApiKey",
            table: "shipping_provider",
            type: "character varying(4096)",
            maxLength: 4096,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "ApiSecret",
            table: "shipping_provider",
            type: "character varying(4096)",
            maxLength: 4096,
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "IsEnabled",
            table: "shipping_provider",
            type: "boolean",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<DateTime>(
            name: "LastTrackingPollStartedAt",
            table: "shipping_provider",
            type: "timestamp with time zone",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Password",
            table: "shipping_provider",
            type: "character varying(4096)",
            maxLength: 4096,
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<int>(
            name: "TrackingPollIntervalSeconds",
            table: "shipping_provider",
            type: "integer",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<int>(
            name: "Type",
            table: "shipping_provider",
            type: "integer",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<bool>(
            name: "UseSandbox",
            table: "shipping_provider",
            type: "boolean",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<string>(
            name: "Username",
            table: "shipping_provider",
            type: "character varying(255)",
            maxLength: 255,
            nullable: false,
            defaultValue: "");

        migrationBuilder.AlterColumn<string>(
            name: "TrackingNumber",
            table: "shipping",
            type: "character varying(100)",
            maxLength: 100,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        // Hand-edited: text -> numeric needs a USING clause on PostgreSQL; the table was never
        // written by app code, so drop + re-add instead of casting.
        migrationBuilder.DropColumn(
            name: "ShippingCost",
            table: "shipping");

        migrationBuilder.AddColumn<decimal>(
            name: "ShippingCost",
            table: "shipping",
            type: "numeric(18,2)",
            precision: 18,
            scale: 2,
            nullable: false,
            defaultValue: 0m);

        migrationBuilder.AddColumn<string>(
            name: "CarrierShipmentId",
            table: "shipping",
            type: "character varying(128)",
            maxLength: 128,
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "DeliveredAt",
            table: "shipping",
            type: "timestamp with time zone",
            nullable: true);

        migrationBuilder.AddColumn<decimal>(
            name: "HeightCm",
            table: "shipping",
            type: "numeric(18,4)",
            precision: 18,
            scale: 4,
            nullable: true);

        migrationBuilder.AddColumn<byte[]>(
            name: "LabelData",
            table: "shipping",
            type: "bytea",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "LabelFormat",
            table: "shipping",
            type: "character varying(32)",
            maxLength: 32,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "LastCarrierStatusRaw",
            table: "shipping",
            type: "character varying(512)",
            maxLength: 512,
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "LastTrackedAt",
            table: "shipping",
            type: "timestamp with time zone",
            nullable: true);

        migrationBuilder.AddColumn<decimal>(
            name: "LengthCm",
            table: "shipping",
            type: "numeric(18,4)",
            precision: 18,
            scale: 4,
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "ShippedAt",
            table: "shipping",
            type: "timestamp with time zone",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "ShippingProviderRateId",
            table: "shipping",
            type: "uuid",
            nullable: true);

        migrationBuilder.AddColumn<int>(
            name: "Status",
            table: "shipping",
            type: "integer",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<double>(
            name: "TaxRate",
            table: "shipping",
            type: "double precision",
            nullable: false,
            defaultValue: 0.0);

        migrationBuilder.AddColumn<string>(
            name: "TrackingUrl",
            table: "shipping",
            type: "character varying(512)",
            maxLength: 512,
            nullable: true);

        migrationBuilder.AddColumn<decimal>(
            name: "WeightKg",
            table: "shipping",
            type: "numeric(18,4)",
            precision: 18,
            scale: 4,
            nullable: true);

        migrationBuilder.AddColumn<decimal>(
            name: "WidthCm",
            table: "shipping",
            type: "numeric(18,4)",
            precision: 18,
            scale: 4,
            nullable: true);

        migrationBuilder.AlterColumn<Guid>(
            name: "ShippingId",
            table: "sales_item",
            type: "uuid",
            nullable: true,
            oldClrType: typeof(Guid),
            oldType: "uuid");

        migrationBuilder.CreateTable(
            name: "shipping_label_outbox",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                ShippingId = table.Column<Guid>(type: "uuid", nullable: false),
                ShippingProviderId = table.Column<Guid>(type: "uuid", nullable: false),
                IdempotencyKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                Status = table.Column<int>(type: "integer", nullable: false),
                AttemptCount = table.Column<int>(type: "integer", nullable: false),
                NextAttemptAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                LastError = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                TenantId = table.Column<Guid>(type: "uuid", nullable: true)
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
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                ShippingProviderRateId = table.Column<Guid>(type: "uuid", nullable: false),
                CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                TenantId = table.Column<Guid>(type: "uuid", nullable: true)
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
                    name: "FK_shipping_provider_rate_country_shipping_provider_rate_Shipp~",
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
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(3365), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(3367) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4138), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4139) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4142), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4142) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4143), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4144) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4145), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4146) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4147), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4147) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4149), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4149) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4170), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4170) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4172), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4172) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4174), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4174) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4176), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4176) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4178), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4178) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4179), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4179) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4181), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4181) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4183), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4183) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4186), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4187) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4188), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4188) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4190), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4190) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4191), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4192) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4193), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4193) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4195), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4195) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4196), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4197) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4198), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4198) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4210), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4210) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4212), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4212) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4214), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4214) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4223), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4224) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4232), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4232) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4234), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4234) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4235), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4236) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4237), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4237) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4240), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4240) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4242), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4242) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4244), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4244) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4245), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4245) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4247), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4247) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4248), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4249) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4250), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4250) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4252), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4252) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4262), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4263) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4265), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4265) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4267), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4267) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4268), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4269) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4270), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4270) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4272), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4272) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4273), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4274) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4275), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4275) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4278), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4278) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4280), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4280) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4282), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4282) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4283), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4283) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4285), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4285) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4286), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4287) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4288), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4288) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4290), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4290) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4301), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4301) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4303), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4304) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4305), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4305) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4307), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4307) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4309), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4309) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4311), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4311) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4312), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4313) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4314), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4314) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4317), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4317) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4319), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4319) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4320), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4321) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4322), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4322) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4324), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4324) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4325), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4326) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4327), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4327) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4329), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4329) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4339), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4339) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4342), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4342) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4344), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4344) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4345), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4346) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4347), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4347) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4349), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4349) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4350), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4351) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4352), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4352) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4355), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4355) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4357), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4357) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4359), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4359) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4361), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4361) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4362), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4362) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4364), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4364) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4366), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4366) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4367), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4368) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4378), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4378) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4389), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4389) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4391), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4391) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4392), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4393) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4394), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4394) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4396), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4396) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4398), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4398) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4399), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4399) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4402), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4402) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4404), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4404) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4406), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4406) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4407), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4408) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4409), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4409) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4411), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4411) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4412), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4413) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4414), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4414) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4424), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4425) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4427), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4427) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4429), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4430) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4431), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4431) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4433), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4434) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4435), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4436) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4437), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4437) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4439), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4439) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4443), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4443) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4445), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4445) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4447), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4447) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4448), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4448) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4450), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4450) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4451), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4452) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4453), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4453) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4455), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4455) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4458), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4458) });

        migrationBuilder.UpdateData(
            table: "manufacturer",
            keyColumn: "Id",
            keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 184, DateTimeKind.Utc).AddTicks(3872), new DateTime(2026, 7, 3, 19, 26, 1, 184, DateTimeKind.Utc).AddTicks(3873) });

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
            column: "ConcurrencyStamp",
            value: "7820520e-5846-4272-878b-dadb5a84cf1a");

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
            column: "ConcurrencyStamp",
            value: "f02c90c0-fe9a-4809-90e0-8614ed9cdea0");

        migrationBuilder.UpdateData(
            table: "saleschannel",
            keyColumn: "Id",
            keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 196, DateTimeKind.Utc).AddTicks(7381), new DateTime(2026, 7, 3, 19, 26, 1, 196, DateTimeKind.Utc).AddTicks(7384) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7065), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7069) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7605), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7605) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7615), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7616) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7618), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7619) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7620), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7620) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7637), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7637) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7638), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7639) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7645), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7645) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7646), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7647) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7621), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7622) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7623), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7623) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7625), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7625) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7626), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7626) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7628), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7628) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7631), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7631) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7632), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7633) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7634), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7634) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7635), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7636) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7640), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7640) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7642), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7642) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 198, DateTimeKind.Utc).AddTicks(4802), new DateTime(2026, 7, 3, 19, 26, 1, 198, DateTimeKind.Utc).AddTicks(4804) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 198, DateTimeKind.Utc).AddTicks(5007), new DateTime(2026, 7, 3, 19, 26, 1, 198, DateTimeKind.Utc).AddTicks(5007) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 198, DateTimeKind.Utc).AddTicks(5009), new DateTime(2026, 7, 3, 19, 26, 1, 198, DateTimeKind.Utc).AddTicks(5009) });

        migrationBuilder.UpdateData(
            table: "tenant",
            keyColumn: "Id",
            keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 176, DateTimeKind.Utc).AddTicks(1170), new DateTime(2026, 7, 3, 19, 26, 1, 176, DateTimeKind.Utc).AddTicks(1175) });

        migrationBuilder.UpdateData(
            table: "user",
            keyColumn: "Id",
            keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
            columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
            values: new object[] { "d41a5d8a-478d-4b9b-829f-93106348868e", new DateTime(2026, 7, 3, 19, 26, 1, 135, DateTimeKind.Utc).AddTicks(1663), new DateTime(2026, 7, 3, 19, 26, 1, 135, DateTimeKind.Utc).AddTicks(1668), "AQAAAAIAAYagAAAAEHniyIwFxc0AM2SJVv8x/LBpafuuScvjFHp2f3boofF5cHGlzbwH1V31Ui6V29DlEw==", "a59bf377-486c-4161-aec6-025e095eca5b" });

        migrationBuilder.UpdateData(
            table: "user_tenant",
            keyColumns: new[] { "TenantId", "UserId" },
            keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
            columns: new[] { "DateCreated", "DateModified", "Id" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 181, DateTimeKind.Utc).AddTicks(355), new DateTime(2026, 7, 3, 19, 26, 1, 181, DateTimeKind.Utc).AddTicks(479), new Guid("83afdc03-1703-4588-b265-6db2bb36637c") });

        migrationBuilder.UpdateData(
            table: "warehouse",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(7612), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(7614) });

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
            name: "IX_shipping_provider_rate_country_ShippingProviderRateId_Count~",
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
            type: "uuid",
            nullable: true,
            oldClrType: typeof(Guid),
            oldType: "uuid");

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "shipping_provider_rate",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(100)",
            oldMaxLength: 100);

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "shipping_provider",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(100)",
            oldMaxLength: 100);

        migrationBuilder.AlterColumn<string>(
            name: "TrackingNumber",
            table: "shipping",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(100)",
            oldMaxLength: 100);

        // Hand-edited: mirror of the Up() drop + re-add (numeric -> text also needs USING).
        migrationBuilder.DropColumn(
            name: "ShippingCost",
            table: "shipping");

        migrationBuilder.AddColumn<string>(
            name: "ShippingCost",
            table: "shipping",
            type: "text",
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "ShippingProviderName",
            table: "shipping",
            type: "text",
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "ShippingTaxRate",
            table: "shipping",
            type: "text",
            nullable: false,
            defaultValue: "");

        migrationBuilder.AlterColumn<Guid>(
            name: "ShippingId",
            table: "sales_item",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
            oldClrType: typeof(Guid),
            oldType: "uuid",
            oldNullable: true);

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(6588), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(6589) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7193), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7193) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7196), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7196) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7198), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7199) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7208), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7208) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7210), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7210) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7211), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7212) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7213), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7213) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7214), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7215) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7216), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7216) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7218), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7218) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7219), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7219) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7223), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7223) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7224), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7225) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7226), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7226) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7227), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7228) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7229), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7229) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7240), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7241) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7243), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7244) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7246), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7246) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7249), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7249) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7251), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7251) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7252), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7252) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7254), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7254) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7255), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7255) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7257), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7257) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7269), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7269) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7273), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7273) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7276), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7276) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7278), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7278) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7279), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7279) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7281), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7281) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7282), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7282) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7291), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7292) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7294), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7294) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7296), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7296) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7299), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7299) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7300), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7301) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7302), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7302) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7303), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7304) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7305), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7305) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7306), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7307) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7308), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7308) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7309), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7310) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7312), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7312) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7314), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7314) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7315), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7315) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7316), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7317) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7318), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7318) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7327), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7328) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7330), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7330) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7332), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7332) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7334), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7335) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7336), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7336) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7338), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7338) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7339), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7339) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7341), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7341) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7343), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7343) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7344), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7344) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7346), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7346) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7348), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7348) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7350), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7350) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7351), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7351) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7353), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7353) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7354), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7355) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7363), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7363) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7365), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7366) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7367), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7367) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7370), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7370) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7371), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7371) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7373), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7373) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7374), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7374) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7376), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7376) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7377), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7377) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7379), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7379) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7388), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7389) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7391), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7391) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7392), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7393) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7394), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7394) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7395), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7396) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7397), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7397) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7405), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7406) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7407), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7407) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7409), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7409) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7412), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7412) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7413), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7413) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7415), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7415) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7416), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7416) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7418), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7418) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7419), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7419) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7421), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7421) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7422), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7422) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7425), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7425) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7426), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7426) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7428), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7428) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7429), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7429) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7431), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7431) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7439), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7440) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7442), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7442) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7443), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7443) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7446), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7446) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7447), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7448) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7449), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7449) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7451), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7451) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7453), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7453) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7455), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7455) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7456), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7456) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7458), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7458) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7461), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7461) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7463), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7463) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7464), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7464) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7466), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7466) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7467), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7468) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7469), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7469) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7470), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7470) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7472), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7472) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7474), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7474) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7476), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7476) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7477), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7477) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7479), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7479) });

        migrationBuilder.UpdateData(
            table: "manufacturer",
            keyColumn: "Id",
            keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 3, DateTimeKind.Utc).AddTicks(6689), new DateTime(2026, 7, 2, 14, 9, 30, 3, DateTimeKind.Utc).AddTicks(6689) });

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
            column: "ConcurrencyStamp",
            value: "0b18fa7e-f199-45fa-a009-5c53e6e65dc6");

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
            column: "ConcurrencyStamp",
            value: "8f0555ac-9247-4b2a-aece-b84fe03e53bf");

        migrationBuilder.UpdateData(
            table: "saleschannel",
            keyColumn: "Id",
            keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 15, DateTimeKind.Utc).AddTicks(2007), new DateTime(2026, 7, 2, 14, 9, 30, 15, DateTimeKind.Utc).AddTicks(2009) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2474), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2477) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2847), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2847) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2850), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2850) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2852), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2852) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2853), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2854) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2875), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2875) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2878), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2878) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2883), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2883) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2884), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2884) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2855), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2855) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2856), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2857) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2865), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2865) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2866), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2866) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2868), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2868) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2869), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2869) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2871), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2871) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2872), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2872) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2874), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2874) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2880), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2880) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2881), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2881) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 16, DateTimeKind.Utc).AddTicks(8078), new DateTime(2026, 7, 2, 14, 9, 30, 16, DateTimeKind.Utc).AddTicks(8079) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 16, DateTimeKind.Utc).AddTicks(8280), new DateTime(2026, 7, 2, 14, 9, 30, 16, DateTimeKind.Utc).AddTicks(8281) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 16, DateTimeKind.Utc).AddTicks(8283), new DateTime(2026, 7, 2, 14, 9, 30, 16, DateTimeKind.Utc).AddTicks(8283) });

        migrationBuilder.UpdateData(
            table: "tenant",
            keyColumn: "Id",
            keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 29, 996, DateTimeKind.Utc).AddTicks(3677), new DateTime(2026, 7, 2, 14, 9, 29, 996, DateTimeKind.Utc).AddTicks(3679) });

        migrationBuilder.UpdateData(
            table: "user",
            keyColumn: "Id",
            keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
            columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
            values: new object[] { "62728db9-5a44-406f-b73c-6824d90aa2e2", new DateTime(2026, 7, 2, 14, 9, 29, 957, DateTimeKind.Utc).AddTicks(3055), new DateTime(2026, 7, 2, 14, 9, 29, 957, DateTimeKind.Utc).AddTicks(3058), "AQAAAAIAAYagAAAAEOyettKwYvYJRPaVhkhiHZGeaQlf5/F/CbT3jyWmpxgpl27hJrr0Nh59r1qylCLlaw==", "82e03d67-2987-4bc2-9f97-7889469a91fe" });

        migrationBuilder.UpdateData(
            table: "user_tenant",
            keyColumns: new[] { "TenantId", "UserId" },
            keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
            columns: new[] { "DateCreated", "DateModified", "Id" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 0, DateTimeKind.Utc).AddTicks(7559), new DateTime(2026, 7, 2, 14, 9, 30, 0, DateTimeKind.Utc).AddTicks(7670), new Guid("a56be791-567b-43e0-9203-6deee5c0097d") });

        migrationBuilder.UpdateData(
            table: "warehouse",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 3, DateTimeKind.Utc).AddTicks(406), new DateTime(2026, 7, 2, 14, 9, 30, 3, DateTimeKind.Utc).AddTicks(407) });

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
