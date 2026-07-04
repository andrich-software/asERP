using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class SalesChannelStockSync : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ExportStock",
                table: "saleschannel",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ImportStock",
                table: "saleschannel",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "WebhookSecret",
                table: "saleschannel",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemsTotal",
                table: "channel_sync_run",
                type: "INTEGER",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(5115), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(5122) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7630), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7631) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7640), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7640) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7670), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7671) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7677), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7677) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7681), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7681) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7685), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7685) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7689), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7689) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7692), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7693) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7696), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7697) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7700), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7708), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7709) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7712), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7713) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7716), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7716) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7719), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7723), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7724) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7727), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7727) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7762), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7762) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7766), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7766) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7773), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7773) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7777), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7777) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7780), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7781) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7784), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7785) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7788), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7789) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7791), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7792) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7795), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7796) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7845), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7846) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7867), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7868) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7871), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7871) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7875), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7875) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7878), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7879) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7882), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7883) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7886), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7886) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7908), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7909) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7912), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7913) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7919), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7923), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7923) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7927), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7927) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7931), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7931) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7935), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7935) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7938), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7939) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7942), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7942) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7946), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7946) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7952), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7953) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7956), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7956) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7960), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7963), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7964) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7967), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7967) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7970), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7971) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7993), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7994) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7997), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7998) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8004), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8005) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8008), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8009) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8012), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8013) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8074), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8074) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8077), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8078) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8081), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8082) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8084), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8085) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8088), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8089) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8095), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8096) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8099), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8099) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8102), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8103) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8106), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8107) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8110), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8113), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8114) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8137), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8138) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8141), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8141) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8148), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8148) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8151), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8152) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8155), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8155) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8159), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8163), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8163) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8166), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8167) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8170), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8173), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8174) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8180), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8183), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8184) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8187), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8187) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8190), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8191) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8194), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8194) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8197), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8198) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8221), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8222) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8225), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8226) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8232), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8233) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8236), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8237) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8240), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8244), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8244) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8247), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8248) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8251), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8252) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8255), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8255) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8258), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8259) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8265), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8265) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8268), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8269) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8272), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8273) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8277), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8277) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8280), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8281) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8284), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8284) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8307), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8308) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8310), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8311) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8317), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8318) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8321), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8321) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8324), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8325) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8328), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8329) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8332), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8332) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8335), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8336) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8339), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8343), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8343) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8349), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8353), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8353) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8356), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8357) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8360), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8361) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8363), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8364) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8367), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8367) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8370), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8371) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8374), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8380), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8381) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8384), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8385) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8388), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8388) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8391), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8392) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8395), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8395) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 890, DateTimeKind.Utc).AddTicks(9435), new DateTime(2026, 7, 2, 6, 28, 53, 890, DateTimeKind.Utc).AddTicks(9439) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "eb9f4d4d-5a2d-4169-b236-a28cb4a0a17b");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "875df2a4-d6b6-4faa-a38b-a324eac8a803");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified", "ExportStock", "ImportStock", "WebhookSecret" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 930, DateTimeKind.Utc).AddTicks(1643), new DateTime(2026, 7, 2, 6, 28, 53, 930, DateTimeKind.Utc).AddTicks(1655), false, false, null });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(1251), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(1257) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2691), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2692) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2700), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2700) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2704), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2705) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2708), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2709) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2712), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2713) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2765), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2766) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2772), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2773) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2784), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2784) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2790), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2791) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2716), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2720), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2721) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2733), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2733) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2740), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2740) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2746), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2747) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2750), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2751) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2754), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2754) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2758), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2758) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2761), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2762) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2776), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2777) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2780), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2780) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 935, DateTimeKind.Utc).AddTicks(7734), new DateTime(2026, 7, 2, 6, 28, 53, 935, DateTimeKind.Utc).AddTicks(7740) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 935, DateTimeKind.Utc).AddTicks(8492), new DateTime(2026, 7, 2, 6, 28, 53, 935, DateTimeKind.Utc).AddTicks(8492) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 935, DateTimeKind.Utc).AddTicks(8500), new DateTime(2026, 7, 2, 6, 28, 53, 935, DateTimeKind.Utc).AddTicks(8501) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 863, DateTimeKind.Utc).AddTicks(8097), new DateTime(2026, 7, 2, 6, 28, 53, 863, DateTimeKind.Utc).AddTicks(8101) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52682bba-23ad-41bf-bc76-71420ca4d6a9", new DateTime(2026, 7, 2, 6, 28, 53, 748, DateTimeKind.Utc).AddTicks(4274), new DateTime(2026, 7, 2, 6, 28, 53, 748, DateTimeKind.Utc).AddTicks(4278), "AQAAAAIAAYagAAAAEJwPV2ToTVIk9d2LCFfT5vm8MT69N+PY/QdgQi8hh2A2I4L7vMSynOBH4sPf0CRmLg==", "b949738e-2979-4e75-ba33-2fbcbde9e030" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 879, DateTimeKind.Utc).AddTicks(7881), new DateTime(2026, 7, 2, 6, 28, 53, 879, DateTimeKind.Utc).AddTicks(8411), new Guid("3627f5f1-4e12-412b-b36c-df1cc7d77742") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 888, DateTimeKind.Utc).AddTicks(1722), new DateTime(2026, 7, 2, 6, 28, 53, 888, DateTimeKind.Utc).AddTicks(1723) });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stock_movement");

            migrationBuilder.DropColumn(
                name: "ExportStock",
                table: "saleschannel");

            migrationBuilder.DropColumn(
                name: "ImportStock",
                table: "saleschannel");

            migrationBuilder.DropColumn(
                name: "WebhookSecret",
                table: "saleschannel");

            migrationBuilder.DropColumn(
                name: "ItemsTotal",
                table: "channel_sync_run");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(5710), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(5710) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6190), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6190), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6200), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6200), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6200), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6210), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6210), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6210), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6210), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6220), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6220), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6220), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6220), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6230), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6230), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6230), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6240), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6240), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6240), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6240), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6250), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6250), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6250), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6250), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6260), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6260), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6260), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6260), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6270), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6270), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6270), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6270), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6280), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6280), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6280), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6290), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6290), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6290), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6300), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6300), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6300), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6300), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6310), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6310), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6310), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6310), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6320), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6320), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6320), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6320), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6330), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6330), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6330), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6330), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6340), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6340), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6340), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6360), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6360), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6370), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6370), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6370), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6380), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6380), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6380), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6380), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6390), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6390), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6390), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6400), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6400), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6400), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6410), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6410), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6410), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6410), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6420), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6420), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6420), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6430), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6430), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6430), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6430), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6440), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6440), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6440), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6450), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6450), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6450), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6450), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6460), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6460), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6460), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6470), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6470), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6470), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6470), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6480), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6480), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6480), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6490), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6490), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6490), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6490), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6500), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6500), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6500), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6510), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6510), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6510), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6510), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6520), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6520), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6520), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6530), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6530), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6530), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6540), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6540), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6540) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 441, DateTimeKind.Utc).AddTicks(4280), new DateTime(2026, 7, 1, 15, 25, 6, 441, DateTimeKind.Utc).AddTicks(4280) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "2dee38fd-9758-4668-8fe0-7ca3b37a78f4");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "786aaee9-8c8d-4f92-90a4-551eb5dc9805");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 449, DateTimeKind.Utc).AddTicks(8740), new DateTime(2026, 7, 1, 15, 25, 6, 449, DateTimeKind.Utc).AddTicks(8740) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(10), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(10) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(200), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(200) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(200), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(200) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(210), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(210) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(210), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(210) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(210), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(210) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(240), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(240) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(240), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(240) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(250), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(250) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(250), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(250) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(210), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(210) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(220), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(220) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(220), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(220) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(220), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(220) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(220), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(220) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(230), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(230) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(230), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(230) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(230), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(230) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(240), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(240) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(240), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(240) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(250), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(250) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 450, DateTimeKind.Utc).AddTicks(8650), new DateTime(2026, 7, 1, 15, 25, 6, 450, DateTimeKind.Utc).AddTicks(8650) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 450, DateTimeKind.Utc).AddTicks(8760), new DateTime(2026, 7, 1, 15, 25, 6, 450, DateTimeKind.Utc).AddTicks(8760) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 450, DateTimeKind.Utc).AddTicks(8760), new DateTime(2026, 7, 1, 15, 25, 6, 450, DateTimeKind.Utc).AddTicks(8760) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 434, DateTimeKind.Utc).AddTicks(8370), new DateTime(2026, 7, 1, 15, 25, 6, 434, DateTimeKind.Utc).AddTicks(8370) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30ab4ca7-54cb-46ab-96d3-d6de027de61f", new DateTime(2026, 7, 1, 15, 25, 6, 399, DateTimeKind.Utc).AddTicks(7020), new DateTime(2026, 7, 1, 15, 25, 6, 399, DateTimeKind.Utc).AddTicks(7020), "AQAAAAIAAYagAAAAEBPOYJ6H/ATFH64nayW2wknB8EJLBz/S35vcXLFpiVpf/Kr87tCa/XdNGcfu7Zp2nQ==", "488cfa40-a758-40ee-8fd6-378705bc0fc5" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 437, DateTimeKind.Utc).AddTicks(6520), new DateTime(2026, 7, 1, 15, 25, 6, 437, DateTimeKind.Utc).AddTicks(6620), new Guid("ccd93e6d-a23e-42b0-841b-40eeeceb514d") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(9020), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(9020) });
        }
    }
}
