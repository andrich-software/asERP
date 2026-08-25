using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.MSSQL.Migrations;

/// <inheritdoc />
public partial class AddCategories : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<bool>(
            name: "InitialCategoryImportCompleted",
            table: "saleschannel_sync_state",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<bool>(
            name: "ExportCategories",
            table: "saleschannel",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<bool>(
            name: "ImportCategories",
            table: "saleschannel",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.CreateTable(
            name: "category",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                Slug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                SortOrder = table.Column<int>(type: "int", nullable: false),
                ParentCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_category", x => x.Id);
                table.ForeignKey(
                    name: "FK_category_category_ParentCategoryId",
                    column: x => x.ParentCategoryId,
                    principalTable: "category",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "category_saleschannel",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                SalesChannelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false),
                RemoteCategoryId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                LastSyncedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastErrorMessage = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_category_saleschannel", x => x.Id);
                table.ForeignKey(
                    name: "FK_category_saleschannel_category_CategoryId",
                    column: x => x.CategoryId,
                    principalTable: "category",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_category_saleschannel_saleschannel_SalesChannelId",
                    column: x => x.SalesChannelId,
                    principalTable: "saleschannel",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "product_category",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_product_category", x => x.Id);
                table.ForeignKey(
                    name: "FK_product_category_category_CategoryId",
                    column: x => x.CategoryId,
                    principalTable: "category",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_product_category_product_ProductId",
                    column: x => x.ProductId,
                    principalTable: "product",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(1543), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(1548) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2357), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2357) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2360), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2361) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2363), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2363) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2372), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2372) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2374), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2374) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2375), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2375) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2377), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2377) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2378), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2379) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2380), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2380) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2381), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2382) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2383), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2383) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2386), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2386) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2388), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2388) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2389), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2389) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2391), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2391) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2392), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2392) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2402), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2403) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2404), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2404) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2406), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2406) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2409), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2409) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2410), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2410) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2412), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2412) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2413), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2413) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2415), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2415) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2416), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2416) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2418), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2418) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2419), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2419) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2422), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2422) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2423), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2424) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2425), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2425) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2426), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2427) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2428), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2428) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2436), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2436) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2438), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2438) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2439), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2439) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2442), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2442) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2444), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2444) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2446), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2446) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2448), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2448) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2449), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2449) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2451), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2451) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2462), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2462) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2463), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2464) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2467), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2467) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2468), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2468) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2470), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2470) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2471), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2471) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2472), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2473) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2481), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2481) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2483), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2483) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2484), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2484) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2487), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2487) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2488), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2489) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2490), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2490) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2491), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2492) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2493), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2493) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2495), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2495) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2496), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2496) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2498), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2498) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2500), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2501) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2502), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2502) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2503), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2504) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2505), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2505) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2507), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2507) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2515), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2515) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2517), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2518) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2519), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2520) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2522), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2523) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2524), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2524) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2525), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2526) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2527), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2527) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2528), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2529) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2530), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2530) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2531), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2532) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2533), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2533) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2535), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2536) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2537), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2537) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2538), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2538) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2540), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2540) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2541), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2541) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2549), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2550) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2551), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2551) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2553), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2553) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2555), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2555) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2557), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2557) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2558), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2558) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2560), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2560) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2561), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2562) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2563), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2563) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2564), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2565) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2566), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2566) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2569), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2569) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2570), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2570) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2572), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2572) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2573), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2573) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2575), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2575) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2582), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2583) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2584), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2584) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2585), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2586) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2588), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2588) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2590), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2590) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2591), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2591) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2593), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2593) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2594), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2594) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2596), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2596) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2597), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2597) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2598), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2599) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2601), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2601) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2603), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2603) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2604), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2604) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2606), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2606) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2607), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2607) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2615), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2615) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2616), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2616) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2618), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2618) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2620), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2621) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2622), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2622) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2623), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2624) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2625), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2625) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2626), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2627) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2628), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2628) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2629), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2630) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2631), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2631) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2634), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2634) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2635), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2635) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2637), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2637) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2638), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2638) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2639), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2640) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2648), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2648) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2650), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2650) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2652), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2652) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2656), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2656) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2657), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2658) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2659), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2659) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2661), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2661) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2667), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2667) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2668), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2669) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2670), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2670) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2671), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2672) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2674), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2674) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2676), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2676) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2677), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2677) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2678), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2679) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2680), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2680) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2688), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2689) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2690), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2690) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2691), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2692) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2694), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2694) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2696), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2696) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2697), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2697) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2699), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2699) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2700), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2700) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2702), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2702) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2703), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2703) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2704), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2705) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2707), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2707) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2709), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2709) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2710), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2710) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2712), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2712) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2713), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2713) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2721), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2721) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2723), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2723) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2724), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2724) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2727), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2727) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2729), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2729) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2730), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2730) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2732), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2732) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2733), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2733) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2735), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2735) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2736), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2736) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2737), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2738) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2740), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2740) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2742), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2742) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2743), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2743) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2744), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2745) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2746), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2746) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2754), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2754) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2755), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2756) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2757), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2757) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2760), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2760) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2761), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2761) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2763), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2763) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2764), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2765) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2766), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2766) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2767), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2768) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2769), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2769) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2770), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2771) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2773), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2773) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2775), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2775) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2776), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2776) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2778), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2778) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2779), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2779) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2787), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2788) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2789), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2790) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2791), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2791) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2794), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2794) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2795), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2796) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2797), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2797) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2798), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2799) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2800), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2800) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2801), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2802) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2803), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2803) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2804), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2805) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2807), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2807) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2809), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2809) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2810), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2810) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2812), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2812) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2813), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2813) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2822), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2822) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2823), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2823) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2825), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2825) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2827), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2827) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2829), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2829) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2830), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2830) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2832), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2832) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2833), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2833) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2835), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2835) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2836), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2836) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2838), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2838) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2840), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2841) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2842), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2842) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2843), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2843) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2845), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2845) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2846), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2846) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2854), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2854) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2855), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2856) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2857), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2857) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2860), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2860) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2867), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2867) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2868), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2868) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2870), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2870) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2871), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2872) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2873), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2873) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2874), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2875) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2876), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2876) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2879), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2879) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2880), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2880) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2882), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2882) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2883), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2883) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2884), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2885) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2886), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2886) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2887), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2888) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2889), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2889) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2891), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2892) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2893), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2893) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2894), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2895) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2896), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2896) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2897), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(2898) });

        migrationBuilder.UpdateData(
            table: "manufacturer",
            keyColumn: "Id",
            keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 612, DateTimeKind.Utc).AddTicks(4275), new DateTime(2026, 8, 24, 4, 30, 37, 612, DateTimeKind.Utc).AddTicks(4276) });

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
            column: "ConcurrencyStamp",
            value: "6060e52d-f6a5-434d-8fe2-9ecefc3b99bd");

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
            column: "ConcurrencyStamp",
            value: "0126a112-b537-497e-8326-f61275d3a3f7");

        migrationBuilder.UpdateData(
            table: "saleschannel",
            keyColumn: "Id",
            keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
            columns: new[] { "DateCreated", "DateModified", "ExportCategories", "ImportCategories" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 623, DateTimeKind.Utc).AddTicks(8705), new DateTime(2026, 8, 24, 4, 30, 37, 623, DateTimeKind.Utc).AddTicks(8706), false, false });

        migrationBuilder.UpdateData(
            table: "saleschannel_sync_state",
            keyColumn: "Id",
            keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
            columns: new[] { "DateCreated", "DateModified", "InitialCategoryImportCompleted" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 626, DateTimeKind.Utc).AddTicks(896), new DateTime(2026, 8, 24, 4, 30, 37, 626, DateTimeKind.Utc).AddTicks(897), false });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(4372), new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(4376) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(4877), new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(4877) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(4886), new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(4886) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(4888), new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(4889) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(4890), new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(4891) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(5037), new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(5038) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(5039), new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(5039) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(5043), new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(5043) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(5045), new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(5045) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(4892), new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(4892) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(4900), new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(4900) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(4901), new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(4902) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(4903), new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(4903) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(5028), new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(5028) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(5029), new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(5030) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(5031), new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(5031) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(5032), new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(5033) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(5034), new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(5034) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(5040), new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(5041) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(5042), new DateTime(2026, 8, 24, 4, 30, 37, 655, DateTimeKind.Utc).AddTicks(5042) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 628, DateTimeKind.Utc).AddTicks(1152), new DateTime(2026, 8, 24, 4, 30, 37, 628, DateTimeKind.Utc).AddTicks(1153) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 628, DateTimeKind.Utc).AddTicks(1367), new DateTime(2026, 8, 24, 4, 30, 37, 628, DateTimeKind.Utc).AddTicks(1368) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 628, DateTimeKind.Utc).AddTicks(1370), new DateTime(2026, 8, 24, 4, 30, 37, 628, DateTimeKind.Utc).AddTicks(1370) });

        migrationBuilder.UpdateData(
            table: "warehouse",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(7738), new DateTime(2026, 8, 24, 4, 30, 37, 611, DateTimeKind.Utc).AddTicks(7738) });

        migrationBuilder.CreateIndex(
            name: "IX_category_ParentCategoryId",
            table: "category",
            column: "ParentCategoryId");

        migrationBuilder.CreateIndex(
            name: "IX_category_TenantId_ParentCategoryId_Name",
            table: "category",
            columns: new[] { "TenantId", "ParentCategoryId", "Name" },
            unique: true,
            filter: "[TenantId] IS NOT NULL AND [ParentCategoryId] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_category_saleschannel_CategoryId",
            table: "category_saleschannel",
            column: "CategoryId");

        migrationBuilder.CreateIndex(
            name: "IX_category_saleschannel_SalesChannelId",
            table: "category_saleschannel",
            column: "SalesChannelId");

        migrationBuilder.CreateIndex(
            name: "IX_category_saleschannel_TenantId_CategoryId_SalesChannelId",
            table: "category_saleschannel",
            columns: new[] { "TenantId", "CategoryId", "SalesChannelId" },
            unique: true,
            filter: "[TenantId] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_product_category_CategoryId",
            table: "product_category",
            column: "CategoryId");

        migrationBuilder.CreateIndex(
            name: "IX_product_category_ProductId",
            table: "product_category",
            column: "ProductId");

        migrationBuilder.CreateIndex(
            name: "IX_product_category_TenantId_ProductId_CategoryId",
            table: "product_category",
            columns: new[] { "TenantId", "ProductId", "CategoryId" },
            unique: true,
            filter: "[TenantId] IS NOT NULL");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "category_saleschannel");

        migrationBuilder.DropTable(
            name: "product_category");

        migrationBuilder.DropTable(
            name: "category");

        migrationBuilder.DropColumn(
            name: "InitialCategoryImportCompleted",
            table: "saleschannel_sync_state");

        migrationBuilder.DropColumn(
            name: "ExportCategories",
            table: "saleschannel");

        migrationBuilder.DropColumn(
            name: "ImportCategories",
            table: "saleschannel");

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(36), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(39) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(765), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(766) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(768), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(769) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(770), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(771) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(778), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(778) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(790), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(790) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(792), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(792) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(793), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(793) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(795), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(795) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(796), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(797) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(798), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(798) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(799), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(800) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(802), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(803) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(804), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(804) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(805), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(806) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(807), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(807) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(809), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(809) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(810), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(810) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(812), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(812) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(813), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(813) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(816), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(816) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(824), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(824) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(826), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(826) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(827), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(827) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(829), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(829) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(830), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(830) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(832), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(832) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(833), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(834) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(836), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(836) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(845), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(846) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(848), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(848) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(850), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(850) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(851), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(852) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(853), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(853) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(854), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(854) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(856), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(856) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(858), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(859) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(867), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(867) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(869), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(869) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(871), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(871) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(872), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(873) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(874), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(874) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(875), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(875) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(889), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(889) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(892), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(892) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(893), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(893) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(895), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(895) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(896), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(896) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(898), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(898) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(899), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(899) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(901), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(901) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(902), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(903) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(905), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(905) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(913), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(913) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(915), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(915) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(916), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(916) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(918), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(918) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(919), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(919) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(921), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(921) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(922), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(922) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(925), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(925) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(927), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(927) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(928), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(928) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(929), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(930) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(931), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(931) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(932), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(933) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(934), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(934) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(935), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(935) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(938), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(938) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(946), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(946) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(948), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(948) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(949), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(950) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(951), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(951) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(952), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(953) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(954), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(954) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(956), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(956) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(958), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(958) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(960), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(960) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(961), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(961) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(962), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(963) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(964), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(964) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(965), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(965) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(967), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(967) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(968), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(968) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(971), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(971) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(979), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(980) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(981), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(981) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(983), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(983) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(984), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(984) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(986), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(986) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(987), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(987) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(989), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(989) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(991), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(992) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(993), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(993) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(994), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(994) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(996), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(996) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(997), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(997) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(998), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(999) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1000), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1000) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1001), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1002) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1004), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1004) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1012), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1012) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1014), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1014) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1016), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1016) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1017), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1017) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1019), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1019) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1020), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1020) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1022), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1022) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1024), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1025) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1026), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1026) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1027), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1028) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1029), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1029) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1030), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1030) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1032), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1032) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1033), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1033) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1035), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1035) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1037), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1037) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1045), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1045) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1046), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1047) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1048), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1048) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1049), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1050) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1051), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1051) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1052), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1053) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1054), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1054) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1057), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1057) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1058), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1058) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1060), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1060) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1061), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1061) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1063), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1063) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1064), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1064) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1065), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1066) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1067), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1067) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1069), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1070) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1078), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1078) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1080), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1080) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1082), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1082) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1083), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1083) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1089), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1089) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1090), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1090) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1092), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1092) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1094), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1094) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1096), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1096) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1097), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1097) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1099), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1099) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1100), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1100) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1101), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1102) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1103), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1103) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1104), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1104) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1107), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1107) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1115), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1116) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1117), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1117) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1118), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1119) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1120), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1120) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1121), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1122) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1123), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1123) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1124), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1125) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1127), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1127) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1129), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1129) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1130), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1130) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1131), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1132) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1133), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1133) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1134), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1135) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1136), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1136) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1137), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1137) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1140), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1140) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1147), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1148) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1150), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1150) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1151), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1152) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1153), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1153) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1154), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1155) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1156), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1156) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1157), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1158) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1160), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1160) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1162), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1162) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1163), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1163) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1164), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1165) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1166), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1166) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1168), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1168) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1169), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1169) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1170), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1171) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1173), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1173) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1180), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1181) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1182), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1182) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1184), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1184) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1185), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1185) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1187), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1187) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1188), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1188) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1189), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1190) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1192), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1192) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1194), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1194) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1195), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1195) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1197), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1197) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1198), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1198) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1200), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1200) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1202), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1202) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1203), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1203) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1206), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1206) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1214), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1215) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1217), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1217) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1218), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1219) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1220), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1220) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1221), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1222) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1223), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1223) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1224), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1224) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1227), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1227) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1228), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1229) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1230), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1230) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1231), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1231) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1233), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1233) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1234), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1234) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1235), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1236) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1237), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1237) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1239), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1240) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1247), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1248) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1250), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1250) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1251), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1252) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1253), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1253) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1255), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1255) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1256), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1256) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1258), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1258) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1260), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1260) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1262), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1262) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1263), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1263) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1265), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1266) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1267), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1267) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1268), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1268) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1270), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1270) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1271), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1271) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1274), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1274) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1281), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1282) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1289), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1289) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1290), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1290) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1292), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1292) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1293), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1294) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1295), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1295) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1296), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1296) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1299), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1299) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1300), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1301) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1302), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1302) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1303), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1304) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1305), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1305) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1306), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1306) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1308), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1308) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1309), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1309) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1312), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1312) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1313), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1313) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1315), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1315) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1316), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1316) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1317), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1318) });

        migrationBuilder.UpdateData(
            table: "manufacturer",
            keyColumn: "Id",
            keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 547, DateTimeKind.Utc).AddTicks(2072), new DateTime(2026, 8, 21, 9, 7, 13, 547, DateTimeKind.Utc).AddTicks(2073) });

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
            column: "ConcurrencyStamp",
            value: "ca5be815-31af-4f30-8985-2847085dafa6");

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
            column: "ConcurrencyStamp",
            value: "ac356d1b-9a64-4cfa-bda7-7bd28968cc9b");

        migrationBuilder.UpdateData(
            table: "saleschannel",
            keyColumn: "Id",
            keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 559, DateTimeKind.Utc).AddTicks(9341), new DateTime(2026, 8, 21, 9, 7, 13, 559, DateTimeKind.Utc).AddTicks(9343) });

        migrationBuilder.UpdateData(
            table: "saleschannel_sync_state",
            keyColumn: "Id",
            keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 562, DateTimeKind.Utc).AddTicks(2187), new DateTime(2026, 8, 21, 9, 7, 13, 562, DateTimeKind.Utc).AddTicks(2189) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(7815), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(7817) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8339), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8339) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8341), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8342) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8344), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8344) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8351), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8351) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8514), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8515) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8516), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8516) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8520), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8520) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8522), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8522) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8353), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8353) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8354), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8354) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8356), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8356) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8357), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8357) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8505), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8505) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8507), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8507) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8508), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8508) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8511), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8512) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8513), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8513) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8517), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8518) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8519), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8519) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 564, DateTimeKind.Utc).AddTicks(1538), new DateTime(2026, 8, 21, 9, 7, 13, 564, DateTimeKind.Utc).AddTicks(1539) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 564, DateTimeKind.Utc).AddTicks(1750), new DateTime(2026, 8, 21, 9, 7, 13, 564, DateTimeKind.Utc).AddTicks(1750) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 564, DateTimeKind.Utc).AddTicks(1753), new DateTime(2026, 8, 21, 9, 7, 13, 564, DateTimeKind.Utc).AddTicks(1753) });

        migrationBuilder.UpdateData(
            table: "warehouse",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(5664), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(5665) });
    }
}
