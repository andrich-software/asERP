using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.SQLite.Migrations;

/// <inheritdoc />
public partial class AddCategories : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<bool>(
            name: "InitialCategoryImportCompleted",
            table: "saleschannel_sync_state",
            type: "INTEGER",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<bool>(
            name: "ExportCategories",
            table: "saleschannel",
            type: "INTEGER",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<bool>(
            name: "ImportCategories",
            table: "saleschannel",
            type: "INTEGER",
            nullable: false,
            defaultValue: false);

        migrationBuilder.CreateTable(
            name: "category",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                Slug = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                Description = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                SortOrder = table.Column<int>(type: "INTEGER", nullable: false),
                ParentCategoryId = table.Column<Guid>(type: "TEXT", nullable: true),
                DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
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
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                CategoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                SalesChannelId = table.Column<Guid>(type: "TEXT", nullable: false),
                IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                RemoteCategoryId = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                LastSyncedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                LastErrorMessage = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
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
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                CategoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
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
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(1193), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(1198) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4216), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4220) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4230), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4230) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4232), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4232) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4235), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4235) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4237), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4238) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4240), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4240) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4243), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4243) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4245), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4245) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4250), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4251) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4253), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4253) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4255), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4255) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4258), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4258) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4278), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4279) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4281), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4281) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4283), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4284) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4286), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4286) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4301), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4301) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4303), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4304) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4306), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4306) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4308), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4308) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4310), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4311) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4313), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4313) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4315), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4315) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4320), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4320) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4325), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4325) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4327), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4328) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4330), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4330) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4332), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4333) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4340), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4340) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4346), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4346) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4348), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4348) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4351), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4351) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4365), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4365) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4368), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4368) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4370), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4370) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4372), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4373) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4375), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4375) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4377), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4378) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4380), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4380) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4383), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4383) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4387), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4387) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4389), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4390) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4392), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4392) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4394), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4394) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4396), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4396) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4398), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4398) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4400), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4401) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4403), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4403) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4416), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4417) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4442), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4442) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4445), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4445) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4447), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4448) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4450), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4450) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4452), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4452) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4454), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4455) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4457), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4457) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4461), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4461) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4463), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4464) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4466), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4466) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4468), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4468) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4470), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4471) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4473), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4473) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4475), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4475) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4477), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4478) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4491), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4491) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4493), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4494) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4496), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4496) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4498), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4498) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4500), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4500) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4502), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4503) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4505), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4505) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4507), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4507) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4511), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4511) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4513), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4514) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4515), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4516) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4518), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4518) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4520), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4521) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4522), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4523) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4524), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4525) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4527), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4527) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4540), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4541) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4543), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4543) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4545), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4545) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4547), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4547) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4549), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4549) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4551), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4552) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4553), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4554) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4555), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4556) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4560), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4560) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4562), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4562) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4564), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4564) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4566), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4566) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4568), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4568) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4570), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4571) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4573), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4573) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4575), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4575) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4589), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4590) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4591), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4592) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4594), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4594) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4596), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4597) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4598), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4599) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4600), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4601) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4603), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4603) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4605), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4605) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4609), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4609) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4611), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4611) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4613), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4613) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4615), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4615) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4617), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4618) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4619), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4620) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4621), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4622) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4624), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4624) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4638), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4638) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4640), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4641) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4643), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4643) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4645), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4645) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4647), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4647) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4649), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4650) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4652), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4652) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4654), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4654) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4658), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4658) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4660), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4660) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4662), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4663) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4667), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4667) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4669), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4669) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4671), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4672) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4673), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4674) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4676), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4676) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4690), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4690) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4692), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4692) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4694), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4695) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4697), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4697) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4699), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4699) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4701), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4702) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4704), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4704) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4706), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4706) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4710), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4710) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4712), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4712) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4714), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4714) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4716), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4717) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4718), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4719) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4720), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4721) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4729), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4729) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4731), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4731) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4745), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4746) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4748), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4748) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4751), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4752) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4753), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4754) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4756), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4756) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4758), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4758) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4760), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4761) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4762), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4763) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4766), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4767) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4769), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4769) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4771), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4771) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4773), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4773) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4775), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4775) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4777), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4777) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4779), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4780) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4781), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4782) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4795), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4795) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4797), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4797) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4799), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4799) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4801), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4801) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4803), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4804) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4805), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4806) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4807), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4808) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4810), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4810) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4814), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4814) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4817), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4817) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4819), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4820) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4821), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4822) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4823), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4824) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4826), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4826) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4828), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4828) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4830), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4830) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4845), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4846) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4847), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4848) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4850), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4850) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4852), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4852) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4854), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4854) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4856), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4856) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4858), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4858) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4860), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4861) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4864), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4865) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4866), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4867) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4869), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4869) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4871), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4871) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4873), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4873) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4875), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4875) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4877), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4877) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4879), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4879) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4883), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4883) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4896), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4896) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4898), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4898) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4900), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4900) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4902), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4902) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4904), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4905) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4906), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4907) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4909), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4909) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4912), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4913) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4914), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4915) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4917), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4917) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4919), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4919) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4921), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4921) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4923), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4923) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4925), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4925) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4927), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4927) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4931), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4931) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4943), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4944) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4945), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4946) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4947), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4948) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4950), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4950) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4952), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4952) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4954), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4954) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4956), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4956) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4960), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4960) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4963), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4963) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4965), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4965) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4967), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4968) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4969), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4970) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4972), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4972) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4974), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4974) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4976), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4977) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4980), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4981) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4993), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4994) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4995), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4996) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4998), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(4998) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5000), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5000) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5002), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5002) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5004), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5005) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5006), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5007) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5010), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5011) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5012), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5013) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5015), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5015) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5023), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5023) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5025), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5025) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5027), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5028) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5029), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5029) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5031), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5031) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5034), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5034) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5035), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5035) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5037), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5037) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5038), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5038) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5039), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5039) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5041), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5041) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5042), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5042) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5043), new DateTime(2026, 8, 24, 4, 30, 12, 688, DateTimeKind.Utc).AddTicks(5044) });

        migrationBuilder.UpdateData(
            table: "manufacturer",
            keyColumn: "Id",
            keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 689, DateTimeKind.Utc).AddTicks(7706), new DateTime(2026, 8, 24, 4, 30, 12, 689, DateTimeKind.Utc).AddTicks(7707) });

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
            column: "ConcurrencyStamp",
            value: "a17bf52e-042d-467b-8f3e-3a03204d181e");

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
            column: "ConcurrencyStamp",
            value: "1e4b0b53-f47f-42ad-8414-8f9d8b110d49");

        migrationBuilder.UpdateData(
            table: "saleschannel",
            keyColumn: "Id",
            keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
            columns: new[] { "DateCreated", "DateModified", "ExportCategories", "ImportCategories" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 702, DateTimeKind.Utc).AddTicks(8127), new DateTime(2026, 8, 24, 4, 30, 12, 702, DateTimeKind.Utc).AddTicks(8131), false, false });

        migrationBuilder.UpdateData(
            table: "saleschannel_sync_state",
            keyColumn: "Id",
            keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
            columns: new[] { "DateCreated", "DateModified", "InitialCategoryImportCompleted" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 705, DateTimeKind.Utc).AddTicks(2453), new DateTime(2026, 8, 24, 4, 30, 12, 705, DateTimeKind.Utc).AddTicks(2455), false });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(722), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(725) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1238), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1239) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1242), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1242) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1244), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1244) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1246), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1246) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1394), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1395) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1396), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1396) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1408), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1408) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1409), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1410) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1247), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1247) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1248), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1249) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1250), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1250) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1251), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1251) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1387), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1387) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1389), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1389) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1390), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1390) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1391), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1392) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1393), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1393) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1397), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1398) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1400), new DateTime(2026, 8, 24, 4, 30, 12, 737, DateTimeKind.Utc).AddTicks(1400) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 707, DateTimeKind.Utc).AddTicks(4913), new DateTime(2026, 8, 24, 4, 30, 12, 707, DateTimeKind.Utc).AddTicks(4918) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 707, DateTimeKind.Utc).AddTicks(5142), new DateTime(2026, 8, 24, 4, 30, 12, 707, DateTimeKind.Utc).AddTicks(5142) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 707, DateTimeKind.Utc).AddTicks(5144), new DateTime(2026, 8, 24, 4, 30, 12, 707, DateTimeKind.Utc).AddTicks(5144) });

        migrationBuilder.UpdateData(
            table: "warehouse",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 24, 4, 30, 12, 689, DateTimeKind.Utc).AddTicks(638), new DateTime(2026, 8, 24, 4, 30, 12, 689, DateTimeKind.Utc).AddTicks(639) });

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
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1194), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1198) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1887), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1887) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1889), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1890) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1891), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1891) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1893), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1893) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1894), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1895) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1901), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1901) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1903), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1903) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1904), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1904) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1906), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1906) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1907), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1907) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1908), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1909) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1910), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1910) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1921), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1921) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1924), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1929) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1930), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1931) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1932), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1932) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1933), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1934) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1935), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1935) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1937), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1937) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1938), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1939) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1940), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1940) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1942), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1943) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1944), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1944) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1945), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1945) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1949), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1949) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1951), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1951) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1952), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1952) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1954), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1954) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1967), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1968) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1971), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1972) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1973), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1973) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1975), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1975) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1976), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1976) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1978), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1978) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1979), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1979) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1980), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1981) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1982), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1982) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1984), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1985) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1986), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1986) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1987), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1987) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1989), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1989) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1990), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1990) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1991), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1992) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1993), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1993) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2001), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2001) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2004), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2004) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2005), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2005) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2007), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2007) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2008), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2008) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2009), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2010) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2011), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2011) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2012), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2013) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2014), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2014) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2017), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2017) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2018), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2018) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2019), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2020) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2021), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2021) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2022), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2022) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2024), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2024) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2025), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2025) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2032), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2033) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2035), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2036) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2037), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2037) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2038), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2039) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2040), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2040) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2041), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2042) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2043), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2043) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2044), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2044) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2046), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2046) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2048), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2048) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2050), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2050) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2051), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2051) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2053), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2053) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2054), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2054) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2056), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2056) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2057), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2057) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2064), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2065) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2067), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2067) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2069), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2069) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2070), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2070) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2072), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2072) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2073), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2073) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2074), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2075) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2076), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2076) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2083), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2084) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2086), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2086) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2088), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2088) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2089), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2089) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2090), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2091) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2092), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2092) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2093), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2093) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2095), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2095) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2102), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2103) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2106), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2106) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2107), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2108) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2109), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2109) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2110), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2110) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2112), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2112) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2113), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2113) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2115), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2115) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2116), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2116) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2118), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2119) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2120), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2120) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2121), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2122) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2123), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2123) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2124), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2124) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2126), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2126) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2127), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2127) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2135), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2135) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2137), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2138) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2139), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2139) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2141), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2141) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2142), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2142) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2143), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2144) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2145), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2145) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2146), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2147) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2148), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2148) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2150), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2151) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2152), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2152) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2153), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2153) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2155), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2155) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2156), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2156) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2157), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2158) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2159), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2159) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2166), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2167) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2170), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2170) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2171), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2171) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2173), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2173) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2174), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2174) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2175), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2176) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2177), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2177) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2178), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2179) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2180), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2180) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2182), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2182) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2184), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2184) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2185), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2185) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2186), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2187) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2188), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2188) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2189), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2189) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2191), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2191) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2198), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2199) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2201), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2201) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2202), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2203) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2204), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2204) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2205), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2205) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2207), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2207) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2208), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2208) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2210), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2210) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2211), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2211) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2214), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2214) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2215), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2215) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2217), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2217) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2218), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2218) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2220), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2220) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2221), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2221) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2222), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2223) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2230), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2231) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2234), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2234) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2235), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2236) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2237), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2237) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2238), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2238) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2240), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2240) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2241), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2241) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2243), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2243) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2244), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2244) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2247), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2247) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2248), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2248) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2249), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2250) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2251), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2251) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2252), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2253) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2254), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2254) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2255), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2255) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2263), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2263) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2266), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2266) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2267), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2267) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2269), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2269) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2270), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2270) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2272), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2272) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2277), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2277) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2279), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2279) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2280), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2280) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2283), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2283) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2284), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2284) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2286), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2286) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2287), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2287) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2288), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2289) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2290), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2290) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2291), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2291) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2299), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2299) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2302), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2302) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2303), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2304) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2305), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2305) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2306), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2307) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2308), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2308) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2309), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2309) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2311), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2311) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2312), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2312) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2315), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2315) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2316), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2316) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2317), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2318) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2319), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2319) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2320), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2320) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2322), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2322) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2323), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2323) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2331), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2331) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2333), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2333) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2335), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2335) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2336), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2336) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2338), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2338) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2339), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2339) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2341), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2341) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2342), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2342) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2344), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2344) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2346), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2346) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2348), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2348) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2349), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2349) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2350), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2351) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2352), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2352) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2353), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2353) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2355), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2355) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2362), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2363) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2366), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2366) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2367), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2367) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2369), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2369) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2370), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2370) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2372), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2372) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2373), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2373) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2375), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2375) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2376), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2376) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2379), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2379) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2380), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2381) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2382), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2382) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2383), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2383) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2385), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2385) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2386), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2386) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2387), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2388) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2389), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2389) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2398), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2398) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2399), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2399) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2401), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2401) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2402), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2402) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2403), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2404) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2405), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2405) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2406), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2407) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2408), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2408) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2410), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2411) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2412), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2412) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2413), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2413) });

        migrationBuilder.UpdateData(
            table: "manufacturer",
            keyColumn: "Id",
            keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 79, DateTimeKind.Utc).AddTicks(2562), new DateTime(2026, 8, 21, 9, 7, 3, 79, DateTimeKind.Utc).AddTicks(2562) });

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
            column: "ConcurrencyStamp",
            value: "c03a4032-ee46-4faa-b0fd-768ec433c72e");

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
            column: "ConcurrencyStamp",
            value: "5bb83e90-08c0-41b9-95ab-dcfc4b70993f");

        migrationBuilder.UpdateData(
            table: "saleschannel",
            keyColumn: "Id",
            keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 91, DateTimeKind.Utc).AddTicks(1440), new DateTime(2026, 8, 21, 9, 7, 3, 91, DateTimeKind.Utc).AddTicks(1444) });

        migrationBuilder.UpdateData(
            table: "saleschannel_sync_state",
            keyColumn: "Id",
            keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 93, DateTimeKind.Utc).AddTicks(4878), new DateTime(2026, 8, 21, 9, 7, 3, 93, DateTimeKind.Utc).AddTicks(4879) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(8913), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(8916) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9414), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9414) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9416), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9417) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9419), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9419) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9420), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9420) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9599), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9599) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9601), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9601) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9605), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9605) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9606), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9606) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9422), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9422) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9430), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9430) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9431), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9431) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9433), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9433) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9589), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9590) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9591), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9592) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9593), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9593) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9594), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9594) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9596), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9596) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9602), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9602) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9603), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9603) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 95, DateTimeKind.Utc).AddTicks(4442), new DateTime(2026, 8, 21, 9, 7, 3, 95, DateTimeKind.Utc).AddTicks(4445) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 95, DateTimeKind.Utc).AddTicks(4664), new DateTime(2026, 8, 21, 9, 7, 3, 95, DateTimeKind.Utc).AddTicks(4664) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 95, DateTimeKind.Utc).AddTicks(4666), new DateTime(2026, 8, 21, 9, 7, 3, 95, DateTimeKind.Utc).AddTicks(4667) });

        migrationBuilder.UpdateData(
            table: "warehouse",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(6417), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(6419) });
    }
}
