using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.PostgreSQL.Migrations;

/// <inheritdoc />
public partial class AddCategories : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<bool>(
            name: "InitialCategoryImportCompleted",
            table: "saleschannel_sync_state",
            type: "boolean",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<bool>(
            name: "ExportCategories",
            table: "saleschannel",
            type: "boolean",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<bool>(
            name: "ImportCategories",
            table: "saleschannel",
            type: "boolean",
            nullable: false,
            defaultValue: false);

        migrationBuilder.CreateTable(
            name: "category",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                Slug = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                Description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                SortOrder = table.Column<int>(type: "integer", nullable: false),
                ParentCategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                TenantId = table.Column<Guid>(type: "uuid", nullable: true)
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
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                SalesChannelId = table.Column<Guid>(type: "uuid", nullable: false),
                IsActive = table.Column<bool>(type: "boolean", nullable: false),
                RemoteCategoryId = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                LastSyncedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                LastErrorMessage = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                TenantId = table.Column<Guid>(type: "uuid", nullable: true)
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
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                TenantId = table.Column<Guid>(type: "uuid", nullable: true)
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
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(835), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(848) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1561), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1561) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1564), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1564) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1566), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1566) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1576), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1576) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1577), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1578) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1579), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1579) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1581), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1582) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1583), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1583) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1585), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1585) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1586), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1586) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1588), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1588) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1591), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1591) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1592), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1593) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1594), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1594) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1595), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1596) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1605), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1606) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1607), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1607) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1609), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1609) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1610), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1610) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1613), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1613) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1614), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1615) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1616), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1616) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1617), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1618) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1619), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1619) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1621), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1621) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1622), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1622) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1623), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1624) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1626), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1626) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1627), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1628) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1629), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1629) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1630), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1631) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1639), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1639) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1640), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1640) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1642), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1642) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1643), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1643) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1646), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1646) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1647), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1648) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1649), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1649) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1650), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1650) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1652), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1652) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1653) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1654), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1655) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1656), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1656) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1658), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1659) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1673), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1673) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1675), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1675) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1676), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1676) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1684), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1684) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1686), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1686) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1687), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1687) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1689), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1689) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1691), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1692) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1693), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1693) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1695), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1695) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1696), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1696) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1698), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1698) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1699), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1699) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1700), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1701) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1702), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1702) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1705), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1705) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1706), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1706) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1707), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1708) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1709), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1709) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1717), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1717) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1718), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1719) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1720), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1720) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1721), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1722) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1724), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1724) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1726), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1726) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1727), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1727) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1729), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1729) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1730), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1730) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1731), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1732) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1733), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1733) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1734), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1734) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1737), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1737) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1738), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1738) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1740), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1740) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1741), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1741) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1749), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1749) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1750), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1750) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1752), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1752) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1753), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1753) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1756), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1756) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1757), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1757) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1759), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1759) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1760), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1760) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1762), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1762) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1763), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1763) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1764), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1765) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1766), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1766) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1768), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1769) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1770), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1770) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1771), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1771) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1773), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1773) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1780), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1780) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1782), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1782) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1783), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1783) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1785), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1785) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1787), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1787) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1789), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1789) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1790), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1790) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1792), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1792) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1793), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1793) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1794), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1795) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1796), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1796) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1797), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1797) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1800), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1800) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1801), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1801) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1802), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1803) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1804), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1804) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1811), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1812) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1813), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1813) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1814), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1815) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1816), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1816) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1819), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1819) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1820), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1820) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1821), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1822) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1823), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1823) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1824), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1825) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1826), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1826) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1827), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1827) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1829), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1829) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1831), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1831) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1833), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1833) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1834), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1834) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1836), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1836) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1843), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1843) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1845), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1845) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1847), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1847) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1848), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1848) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1851), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1851) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1852), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1853) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1854), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1854) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1855), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1856) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1857), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1857) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1858), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1859) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1864), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1865) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1866), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1866) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1869), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1869) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1870), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1870) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1872), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1872) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1873), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1873) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1881), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1881) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1882), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1882) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1884), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1884) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1885), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1886) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1888), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1888) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1889), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1890) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1891), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1892) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1893), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1893) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1894), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1894) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1896), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1896) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1897), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1897) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1898), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1899) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1901), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1901) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1902), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1902) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1904), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1904) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1905), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1905) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1913), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1913) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1914), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1914) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1916), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1916) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1917), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1917) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1920), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1920) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1921), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1921) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1923), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1923) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1924), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1924) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1925), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1926) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1927), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1927) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1928), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1929) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1930), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1930) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1932), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1932) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1934), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1934) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1935), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1935) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1937), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1937) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1944), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1944) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1946), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1946) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1947), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1947) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1949), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1949) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1952), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1952) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1953), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1953) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1955), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1955) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1956), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1956) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1958), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1958) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1959), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1959) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1961), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1961) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1962), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1962) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1965), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1965) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1966), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1966) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1968), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1968) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1969), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1969) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1976), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1977) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1978), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1978) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1979), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1980) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1981), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1981) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1983), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1984) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1985), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1985) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1987), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1987) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1988), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1988) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1990), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1990) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1991), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1991) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1993), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1993) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1994), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1994) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1997), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1997) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1998), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(1998) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2000), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2000) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2001), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2001) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2008), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2009) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2010), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2011) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2012), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2012) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2013), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2014) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2016), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2016) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2018), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2018) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2019), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2019) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2021), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2021) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2022), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2022) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2024), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2024) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2025), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2025) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2027), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2027) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2030), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2030) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2031), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2031) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2033), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2033) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2034), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2034) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2042), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2042) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2043), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2043) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2045), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2045) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2046), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2046) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2049), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2049) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2050), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2051) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2052), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2052) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2053), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2053) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2059), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2059) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2060), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2060) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2062), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2062) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2063), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2063) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2066), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2066) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2067), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2067) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2068), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2069) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2070), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2070) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2071), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2071) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2073), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2073) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2074), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2074) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2075), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2076) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2078), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2079) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2080), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2080) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2081), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2082) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2083), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2083) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2084), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(2085) });

        migrationBuilder.UpdateData(
            table: "manufacturer",
            keyColumn: "Id",
            keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 574, DateTimeKind.Utc).AddTicks(6263), new DateTime(2026, 8, 24, 4, 30, 26, 574, DateTimeKind.Utc).AddTicks(6265) });

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
            column: "ConcurrencyStamp",
            value: "fa445e4b-cf57-4983-af0d-ad54fb3935c3");

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
            column: "ConcurrencyStamp",
            value: "7ba26c4e-fa41-4cd2-9429-a258e25ba45b");

        migrationBuilder.UpdateData(
            table: "saleschannel",
            keyColumn: "Id",
            keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
            columns: new[] { "DateCreated", "DateModified", "ExportCategories", "ImportCategories" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 587, DateTimeKind.Utc).AddTicks(9382), new DateTime(2026, 8, 24, 4, 30, 26, 587, DateTimeKind.Utc).AddTicks(9384), false, false });

        migrationBuilder.UpdateData(
            table: "saleschannel_sync_state",
            keyColumn: "Id",
            keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
            columns: new[] { "DateCreated", "DateModified", "InitialCategoryImportCompleted" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 590, DateTimeKind.Utc).AddTicks(8606), new DateTime(2026, 8, 24, 4, 30, 26, 590, DateTimeKind.Utc).AddTicks(8610), false });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5013), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5016) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5496), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5497) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5499), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5499) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5507), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5508) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5509), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5509) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5688), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5688) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5689), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5689) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5700), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5701) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5703), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5703) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5510), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5510) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5512), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5512) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5513), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5513) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5514), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5515) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5678), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5678) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5680), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5680) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5683), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5683) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5685), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5685) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5686), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5686) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5690), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5690) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5692), new DateTime(2026, 8, 24, 4, 30, 26, 618, DateTimeKind.Utc).AddTicks(5692) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 593, DateTimeKind.Utc).AddTicks(1103), new DateTime(2026, 8, 24, 4, 30, 26, 593, DateTimeKind.Utc).AddTicks(1107) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 593, DateTimeKind.Utc).AddTicks(1330), new DateTime(2026, 8, 24, 4, 30, 26, 593, DateTimeKind.Utc).AddTicks(1330) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 593, DateTimeKind.Utc).AddTicks(1332), new DateTime(2026, 8, 24, 4, 30, 26, 593, DateTimeKind.Utc).AddTicks(1332) });

        migrationBuilder.UpdateData(
            table: "warehouse",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(6490), new DateTime(2026, 8, 24, 4, 30, 26, 573, DateTimeKind.Utc).AddTicks(6492) });

        migrationBuilder.CreateIndex(
            name: "IX_category_ParentCategoryId",
            table: "category",
            column: "ParentCategoryId");

        migrationBuilder.CreateIndex(
            name: "IX_category_TenantId_ParentCategoryId_Name",
            table: "category",
            columns: new[] { "TenantId", "ParentCategoryId", "Name" },
            unique: true);

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
            unique: true);

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
            unique: true);
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
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(6317), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(6330) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7051), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7051) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7054), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7054) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7055), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7056) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7057), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7057) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7059), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7059) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7060), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7060) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7062), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7062) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7063), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7063) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7066), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7066) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7067), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7068) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7069), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7069) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7070), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7070) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7072), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7072) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7073), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7073) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7075), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7075) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7084), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7084) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7088), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7088) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7089), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7090) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7091), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7091) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7092), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7093) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7094), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7094) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7095), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7095) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7097), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7097) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7098), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7098) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7101), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7101) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7102), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7102) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7104), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7104) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7105), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7105) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7116), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7117) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7130), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7131) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7132), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7132) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7140), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7141) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7143), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7143) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7145), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7145) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7146), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7146) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7148), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7148) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7149), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7149) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7151), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7151) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7152), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7152) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7153), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7154) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7156), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7156) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7158), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7158) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7159), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7159) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7161), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7161) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7162), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7162) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7164), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7164) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7165), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7165) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7173), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7174) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7176), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7177) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7178), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7178) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7180), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7180) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7181), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7181) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7183), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7183) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7184), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7184) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7186), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7186) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7187), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7187) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7190), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7190) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7191), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7191) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7192), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7193) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7194), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7194) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7195), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7195) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7197), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7197) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7198), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7198) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7206), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7206) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7209), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7209) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7211), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7212) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7213), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7213) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7214), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7214) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7216), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7216) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7217), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7217) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7219), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7219) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7220), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7220) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7223), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7223) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7224), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7224) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7226), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7226) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7227), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7227) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7228), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7228) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7230), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7230) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7231), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7231) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7238), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7239) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7241), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7241) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7243), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7243) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7244), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7244) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7246), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7246) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7247), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7247) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7249), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7249) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7250), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7250) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7252), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7252) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7254), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7254) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7256), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7256) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7257), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7257) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7258), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7259) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7260), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7260) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7261), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7261) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7263), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7263) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7270), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7270) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7272), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7273) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7274), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7274) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7276), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7276) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7277), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7277) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7278), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7279) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7280), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7280) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7281), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7282) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7283), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7283) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7285), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7285) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7287), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7287) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7288), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7288) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7289), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7290) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7291), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7291) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7292), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7292) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7293), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7294) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7301), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7301) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7304), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7304) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7305), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7306) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7307), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7307) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7308), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7309) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7310), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7310) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7311), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7312) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7313), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7313) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7314), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7314) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7317), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7317) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7318), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7318) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7324), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7324) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7325), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7325) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7326), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7327) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7328), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7328) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7329), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7329) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7337), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7337) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7340), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7340) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7341), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7342) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7343), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7343) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7344), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7345) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7346), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7346) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7347), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7347) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7349), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7349) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7350), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7350) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7352), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7353) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7354), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7354) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7355), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7356) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7357), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7357) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7358), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7358) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7359), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7360) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7361), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7361) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7368), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7368) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7371), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7371) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7372), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7372) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7374), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7374) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7375), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7375) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7377), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7377) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7378), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7378) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7380), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7380) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7381), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7381) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7383), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7384) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7385), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7385) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7386), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7386) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7388), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7388) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7389), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7389) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7391), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7391) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7392), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7392) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7399), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7399) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7402), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7402) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7404), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7404) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7405), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7405) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7407), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7407) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7408), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7408) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7409), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7410) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7411), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7411) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7412), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7412) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7415), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7415) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7416), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7416) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7418), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7418) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7419), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7419) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7420), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7420) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7422), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7422) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7423), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7423) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7431), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7431) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7435), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7435) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7436), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7437) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7438), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7438) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7439), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7440) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7441), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7441) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7442), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7442) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7443), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7444) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7445), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7445) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7447), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7448) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7449), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7449) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7450), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7450) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7452), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7452) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7453), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7453) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7454), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7455) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7456), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7456) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7463), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7464) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7467), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7467) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7468), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7469) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7470), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7470) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7471), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7472) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7473), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7473) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7474), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7474) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7476), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7476) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7477), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7477) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7479), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7480) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7481), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7481) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7482), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7483) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7484), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7484) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7485), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7485) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7486), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7487) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7488), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7488) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7496), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7496) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7498), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7498) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7500), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7500) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7501), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7501) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7503), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7503) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7504), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7504) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7506), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7506) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7507), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7507) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7513), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7513) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7515), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7516) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7517), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7517) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7518), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7519) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7520), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7520) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7521), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7521) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7523), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7523) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7524), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7524) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7531), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7532) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7534), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7534) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7535), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7536) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7537), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7537) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7539), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7539) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7540), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7540) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7541), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7542) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7543), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7543) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7545), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7545) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7547), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7547) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7549), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7549) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7550), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7551) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7552), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7552) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7554), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7554) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7555), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7555) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7557), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7557) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7558), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7559) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7561), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7561) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7562), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7562) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7564), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7564) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7565), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7565) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7567), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7567) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7568), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7569) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7570), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7570) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7571), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7572) });

        migrationBuilder.UpdateData(
            table: "manufacturer",
            keyColumn: "Id",
            keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 913, DateTimeKind.Utc).AddTicks(8745), new DateTime(2026, 8, 21, 9, 7, 7, 913, DateTimeKind.Utc).AddTicks(8746) });

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
            column: "ConcurrencyStamp",
            value: "86b29505-ebbd-4e47-87f7-d16ecc3434c6");

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
            column: "ConcurrencyStamp",
            value: "b303743f-14da-4dcc-801e-f2b971008be3");

        migrationBuilder.UpdateData(
            table: "saleschannel",
            keyColumn: "Id",
            keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 925, DateTimeKind.Utc).AddTicks(444), new DateTime(2026, 8, 21, 9, 7, 7, 925, DateTimeKind.Utc).AddTicks(446) });

        migrationBuilder.UpdateData(
            table: "saleschannel_sync_state",
            keyColumn: "Id",
            keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 927, DateTimeKind.Utc).AddTicks(2024), new DateTime(2026, 8, 21, 9, 7, 7, 927, DateTimeKind.Utc).AddTicks(2025) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8232), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8235) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8745), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8746) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8755), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8755) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8757), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8757) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8758), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8758) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8903), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8904) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8905), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8905) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8910), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8910) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8912), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8912) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8760), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8760) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8761), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8761) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8762), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8763) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8764), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8764) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8896), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8896) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8898), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8898) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8899), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8899) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8901), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8901) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8902), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8902) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8906), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8906) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8909), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8909) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 929, DateTimeKind.Utc).AddTicks(1486), new DateTime(2026, 8, 21, 9, 7, 7, 929, DateTimeKind.Utc).AddTicks(1488) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 929, DateTimeKind.Utc).AddTicks(1702), new DateTime(2026, 8, 21, 9, 7, 7, 929, DateTimeKind.Utc).AddTicks(1702) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 929, DateTimeKind.Utc).AddTicks(1704), new DateTime(2026, 8, 21, 9, 7, 7, 929, DateTimeKind.Utc).AddTicks(1704) });

        migrationBuilder.UpdateData(
            table: "warehouse",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 913, DateTimeKind.Utc).AddTicks(2441), new DateTime(2026, 8, 21, 9, 7, 7, 913, DateTimeKind.Utc).AddTicks(2443) });
    }
}
