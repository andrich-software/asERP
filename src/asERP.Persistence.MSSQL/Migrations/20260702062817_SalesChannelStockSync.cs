using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.MSSQL.Migrations
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
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ImportStock",
                table: "saleschannel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "WebhookSecret",
                table: "saleschannel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemsTotal",
                table: "channel_sync_run",
                type: "int",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 133, DateTimeKind.Utc).AddTicks(9747), new DateTime(2026, 7, 2, 6, 28, 0, 133, DateTimeKind.Utc).AddTicks(9760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2374), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2375) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2383), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2384) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2416), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2417) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2445), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2445) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2450), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2453), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2454) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2457), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2458) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2461), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2461) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2465), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2466) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2469), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2469) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2473), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2473) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2483), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2484) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2487), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2488) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2491), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2491) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2494), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2495) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2498), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2498) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2501), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2502) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2505), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2506) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2531), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2531) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2538), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2538) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2541), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2542) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2609), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2613), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2614) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2617), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2617) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2621), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2621) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2666), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2666) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2687), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2687) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2694), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2695) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2698), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2699) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2701), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2702) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2705), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2706) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2709), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2709) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2715), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2716) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2720), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2744), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2745) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2754), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2755) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2758), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2758) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2761), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2762) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2765), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2766) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2769), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2769) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2772), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2773) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2776), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2777) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2780), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2786), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2787) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2790), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2793), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2793) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2797), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2797) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2800), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2803), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2804) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2807), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2807) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2827), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2834), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2834) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2837), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2838) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2841), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2841) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2844), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2845) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2848), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2848) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2851), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2852) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2855), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2855) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2859), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2859) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2865), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2865) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2868), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2869) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2872), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2872) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2875), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2876) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2879), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2879) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2882), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2883) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2886), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2886) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2906), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2907) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2913), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2913) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2917), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2917) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2920), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2921) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2924), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2924) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2927), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2928) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2931), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2932) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2934), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2935) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2938), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2939) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2945), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2945) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2948), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2949) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2952), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2952) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2955), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2956) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2959), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2959) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2963), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2963) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2966), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2967) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2987), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2987) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2993), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2993) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3000), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3003), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3003) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3008), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3008) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3012), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3013) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3017), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3017) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3020), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3024), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3024) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3030), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3033), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3034) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3037), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3037) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3041), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3041) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3046), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3046) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3050), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3053), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3054) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3076), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3077) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3083), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3084) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3087), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3087) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3090), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3094), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3094) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3097), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3098) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3101), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3101) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3104), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3104) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3108), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3108) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3114), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3114) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3119), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3122), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3123) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3126), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3127) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3129), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3133), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3133) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3136), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3137) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3140), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3166), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3166) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3170), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3173), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3174) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3176), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3177) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 137, DateTimeKind.Utc).AddTicks(8640), new DateTime(2026, 7, 2, 6, 28, 0, 137, DateTimeKind.Utc).AddTicks(8649) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "c1c4da35-3af1-45a1-ab34-a9edbc02e501");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "d87e3347-9e2b-4be5-b580-40118bd8c686");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified", "ExportStock", "ImportStock", "WebhookSecret" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 178, DateTimeKind.Utc).AddTicks(2866), new DateTime(2026, 7, 2, 6, 28, 0, 178, DateTimeKind.Utc).AddTicks(2872), false, false, null });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 246, DateTimeKind.Utc).AddTicks(9367), new DateTime(2026, 7, 2, 6, 28, 0, 246, DateTimeKind.Utc).AddTicks(9373) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(654), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(656) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(663), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(664) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(696), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(697) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(700), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(701) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(704), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(705) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(759), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(762), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(763) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(776), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(777) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(780), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(780) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(709), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(709) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(713), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(714) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(717), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(718) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(722), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(722) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(726), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(726) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(734), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(735) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(741), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(741) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(748), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(748) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(753), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(754) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(766), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(766) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(769), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(770) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 183, DateTimeKind.Utc).AddTicks(5895), new DateTime(2026, 7, 2, 6, 28, 0, 183, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 183, DateTimeKind.Utc).AddTicks(6623), new DateTime(2026, 7, 2, 6, 28, 0, 183, DateTimeKind.Utc).AddTicks(6624) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 183, DateTimeKind.Utc).AddTicks(6646), new DateTime(2026, 7, 2, 6, 28, 0, 183, DateTimeKind.Utc).AddTicks(6647) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 109, DateTimeKind.Utc).AddTicks(972), new DateTime(2026, 7, 2, 6, 28, 0, 109, DateTimeKind.Utc).AddTicks(978) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d238fd7-da42-40f3-9849-be6bcad145a2", new DateTime(2026, 7, 2, 6, 27, 59, 988, DateTimeKind.Utc).AddTicks(7138), new DateTime(2026, 7, 2, 6, 27, 59, 988, DateTimeKind.Utc).AddTicks(7148), "AQAAAAIAAYagAAAAENpcxnClpBkKFLoUqmf0ck/ihHvcsqa1j0YpsPqrJDzRu11HYoAB/DXBd3bgBTOt0A==", "e40ede75-7a53-4fae-a86c-3a8ef175b124" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 126, DateTimeKind.Utc).AddTicks(3775), new DateTime(2026, 7, 2, 6, 28, 0, 126, DateTimeKind.Utc).AddTicks(4305), new Guid("1203e739-0a90-4909-a756-0cf49a6949a4") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 135, DateTimeKind.Utc).AddTicks(5481), new DateTime(2026, 7, 2, 6, 28, 0, 135, DateTimeKind.Utc).AddTicks(5484) });

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
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(620), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1030), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1040), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1040), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1040), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1040), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1050), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1050), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1050), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1060), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1060), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1060), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1070), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1070), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1070), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1070), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1080), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1080), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1080), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1090), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1090), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1090), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1090), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1100), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1100), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1100), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1110), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1110), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1110), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1120), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1120), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1120), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1120), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1130), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1130), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1130), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1140), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1140), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1140), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1140), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1150), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1150), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1150), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1160), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1160), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1160), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1160), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1170), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1170), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1170), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1180), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1200), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1200), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1210), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1210), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1210), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1220), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1220), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1220), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1230), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1230), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1230), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1230), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1240), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1240), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1240), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1250), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1250), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1250), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1250), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1260), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1260), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1260), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1270), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1270), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1270), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1280), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1280), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1280), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1280), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1290), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1290), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1290), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1300), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1300), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1300), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1300), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1310), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1310), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1310), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1320), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1320), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1320), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1320), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1330), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1330), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1330), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1340), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1340), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1340), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1350), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1350), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1350), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1350), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1360), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1360), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1360), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1370), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1370), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1370), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1370), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1380), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1380), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1380), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1390), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1390), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1390), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1390), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1400), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1400), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1400) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(8530), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(8530) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "f3a52634-7fdc-42b2-853e-86c7a3b5775b");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "4ff7713d-35fd-4fdb-b84c-75001d4c291b");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 619, DateTimeKind.Utc).AddTicks(8480), new DateTime(2026, 7, 1, 15, 24, 43, 619, DateTimeKind.Utc).AddTicks(8490) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2250), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2250) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2820), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2820) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2820), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2820) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2820), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2820) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2830), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2830) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2830), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2830) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2860), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2860) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2860), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2860) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2870), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2880), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2880) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2830), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2830) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2840), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2840) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2840), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2840) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2840), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2840) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2850), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2850) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2850), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2850) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2850), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2850) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2850), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2860) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2860), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2860) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2870), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2870), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 620, DateTimeKind.Utc).AddTicks(9050), new DateTime(2026, 7, 1, 15, 24, 43, 620, DateTimeKind.Utc).AddTicks(9050) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 620, DateTimeKind.Utc).AddTicks(9160), new DateTime(2026, 7, 1, 15, 24, 43, 620, DateTimeKind.Utc).AddTicks(9160) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 620, DateTimeKind.Utc).AddTicks(9170), new DateTime(2026, 7, 1, 15, 24, 43, 620, DateTimeKind.Utc).AddTicks(9170) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 604, DateTimeKind.Utc).AddTicks(770), new DateTime(2026, 7, 1, 15, 24, 43, 604, DateTimeKind.Utc).AddTicks(770) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c4b0c28-d336-49ad-9021-f755ed71b4da", new DateTime(2026, 7, 1, 15, 24, 43, 567, DateTimeKind.Utc).AddTicks(5550), new DateTime(2026, 7, 1, 15, 24, 43, 567, DateTimeKind.Utc).AddTicks(5550), "AQAAAAIAAYagAAAAEBeQGYQNm8+LoQ0P9d1cdOcZCXcMdZ/zyOwl/NMhnxDHyOV0m6ggOxiEJQXMNmh12g==", "d8c1bf08-f678-4366-8f5f-9f405db7b3a2" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 607, DateTimeKind.Utc).AddTicks(6900), new DateTime(2026, 7, 1, 15, 24, 43, 607, DateTimeKind.Utc).AddTicks(7000), new Guid("340ff6ba-beef-4408-93fb-7e71cbc7307e") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(3230), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(3230) });
        }
    }
}
