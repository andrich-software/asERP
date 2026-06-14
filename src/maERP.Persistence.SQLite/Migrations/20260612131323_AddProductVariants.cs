using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace maERP.Persistence.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class AddProductVariants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentProductId",
                table: "product",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductType",
                table: "product",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VariantSortOrder",
                table: "product",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(3920), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(3920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4340), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4350), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4350), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4350), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4360), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4360), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4360), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4360), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4370), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4370), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4370), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4380), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4380), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4380), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4380), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4390), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4390), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4390), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4400), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4400), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4400), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4400), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4410), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4410), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4410), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4420), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4420), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4420), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4430), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4430), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4430), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4430), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4440), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4440), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4440), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4450), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4450), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4450), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4450), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4460), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4460), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4460), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4470), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4470), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4470), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4470), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4480), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4480), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4480), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4490), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4490), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4490), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4490), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4500), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4500), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4500), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4510), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4510), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4510), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4520), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4520), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4520), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4520), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4530), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4530), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4530), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4540), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4540), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4540), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4550), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4550), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4550), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4580), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4580) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4580), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4580) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4590), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4590), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4590), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4590), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4600), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4600), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4600), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4610), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4610), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4610), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4620), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4620), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4620), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4620), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4630), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4630), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4630), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4640), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4640) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4640), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4640) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4640), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4640) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4640), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4650), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4650), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4650), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4660), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4660), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4660), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4670), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4670), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4670), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4670), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4680), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4680) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4680), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4680) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4680), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4680) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4690), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4690) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4690), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4690) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4690), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4690) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4700), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4700), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4700), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4700), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4710), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4710) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4710), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4710) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4710), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4710) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4720), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(4720) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 991, DateTimeKind.Utc).AddTicks(1980), new DateTime(2026, 6, 12, 13, 13, 22, 991, DateTimeKind.Utc).AddTicks(1980) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "8b9a8d4e-6733-4ff4-8e68-0a8afde13b09");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "2b77336c-0f03-425a-8e3d-1d118b92e202");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 999, DateTimeKind.Utc).AddTicks(7870), new DateTime(2026, 6, 12, 13, 13, 22, 999, DateTimeKind.Utc).AddTicks(7870) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(3930), new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(3930) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4130), new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4130), new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4140), new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4140), new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4140), new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4170), new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4170) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4170), new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4170) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4180), new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4180) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4180), new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4180) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4150), new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4150) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4150), new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4150) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4150), new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4150) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4150), new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4150) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4160), new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4160), new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4160), new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4160), new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4170), new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4170) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4180), new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4180) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4180), new DateTime(2026, 6, 12, 13, 13, 23, 9, DateTimeKind.Utc).AddTicks(4180) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 0, DateTimeKind.Utc).AddTicks(7680), new DateTime(2026, 6, 12, 13, 13, 23, 0, DateTimeKind.Utc).AddTicks(7680) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 0, DateTimeKind.Utc).AddTicks(7790), new DateTime(2026, 6, 12, 13, 13, 23, 0, DateTimeKind.Utc).AddTicks(7790) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 23, 0, DateTimeKind.Utc).AddTicks(7790), new DateTime(2026, 6, 12, 13, 13, 23, 0, DateTimeKind.Utc).AddTicks(7790) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 984, DateTimeKind.Utc).AddTicks(6960), new DateTime(2026, 6, 12, 13, 13, 22, 984, DateTimeKind.Utc).AddTicks(6960) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ab7cd0e-84fe-463c-a771-b37457f3dd78", new DateTime(2026, 6, 12, 13, 13, 22, 948, DateTimeKind.Utc).AddTicks(6980), new DateTime(2026, 6, 12, 13, 13, 22, 948, DateTimeKind.Utc).AddTicks(6980), "AQAAAAIAAYagAAAAEKM/fTUkiPd2EWFCMDRCuPt5SQ7GfFvE1HhhDbprG71HutenfLAdJEz0aVoxzktN5Q==", "bcb0a12d-e1ed-4727-b66a-ea36a647cdb3" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 988, DateTimeKind.Utc).AddTicks(450), new DateTime(2026, 6, 12, 13, 13, 22, 988, DateTimeKind.Utc).AddTicks(550), new Guid("4d1ac22f-7a2d-4092-89c0-143ca42e6055") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(6670), new DateTime(2026, 6, 12, 13, 13, 22, 990, DateTimeKind.Utc).AddTicks(6670) });

            migrationBuilder.CreateIndex(
                name: "IX_product_ParentProductId",
                table: "product",
                column: "ParentProductId");

            migrationBuilder.CreateIndex(
                name: "IX_product_ProductType",
                table: "product",
                column: "ProductType");

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

            migrationBuilder.AddForeignKey(
                name: "FK_product_product_ParentProductId",
                table: "product",
                column: "ParentProductId",
                principalTable: "product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_product_ParentProductId",
                table: "product");

            migrationBuilder.DropTable(
                name: "product_variant_axis");

            migrationBuilder.DropTable(
                name: "product_variant_option");

            migrationBuilder.DropTable(
                name: "product_attribute_value");

            migrationBuilder.DropTable(
                name: "product_attribute");

            migrationBuilder.DropIndex(
                name: "IX_product_ParentProductId",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_ProductType",
                table: "product");

            migrationBuilder.DropColumn(
                name: "ParentProductId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "product");

            migrationBuilder.DropColumn(
                name: "VariantSortOrder",
                table: "product");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7180), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7710), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7710) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7720), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7720), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7730), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7730), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7730), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7730), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7740), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7740), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7740), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7750), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7750), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7750), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7750), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7760), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7760), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7760), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7770), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7770), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7770), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7770), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7780), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7780), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7780), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7790), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7790), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7790), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7800), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7800), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7800), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7800), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7810), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7810), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7810), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7820), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7820), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7820), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7820), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7830), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7830), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7830), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7840), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7840), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7840), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7850), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7850), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7850), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7850), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7860), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7860), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7860), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7870), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7870), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7870), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7880), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7880), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7880), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7880), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7890), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7890), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7890), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7900), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7900), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7900), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7900), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7910), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7910), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7910), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7920), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7920), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7920), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7930), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7930), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7930), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7930), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7940), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7940), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7940), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7950), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8000), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8000), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8000), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8010), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8010), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8010), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8020), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8020), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8020), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8020), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8030), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8030), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8030), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8040), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8040), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8040), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8050), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8050), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8050), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8050), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8060), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8060), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8060), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8070), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8070), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8070), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8070), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8080), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8080), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8080), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8090), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8090), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8090), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8090), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8100), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8100), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8100), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8110), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8110), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8110), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8110) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 454, DateTimeKind.Utc).AddTicks(6030), new DateTime(2026, 6, 9, 20, 53, 15, 454, DateTimeKind.Utc).AddTicks(6030) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "4232e712-43eb-4a02-8f48-d2484af3ea11");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "45971174-75d5-4194-846f-0931cbfac0c8");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 463, DateTimeKind.Utc).AddTicks(8470), new DateTime(2026, 6, 9, 20, 53, 15, 463, DateTimeKind.Utc).AddTicks(8470) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(490), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(490) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(710), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(710) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(710), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(710) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(710), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(710) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(720), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(720) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(720), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(720) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(750), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(750), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(760), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(760) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(760), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(760) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(720), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(720) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(720), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(720) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(730), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(730) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(730), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(730) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(730), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(730) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(730), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(730) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(740), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(740) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(740), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(740) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(740), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(740) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(750), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(750), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 464, DateTimeKind.Utc).AddTicks(8970), new DateTime(2026, 6, 9, 20, 53, 15, 464, DateTimeKind.Utc).AddTicks(8970) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 464, DateTimeKind.Utc).AddTicks(9080), new DateTime(2026, 6, 9, 20, 53, 15, 464, DateTimeKind.Utc).AddTicks(9080) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 464, DateTimeKind.Utc).AddTicks(9090), new DateTime(2026, 6, 9, 20, 53, 15, 464, DateTimeKind.Utc).AddTicks(9090) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 447, DateTimeKind.Utc).AddTicks(7740), new DateTime(2026, 6, 9, 20, 53, 15, 447, DateTimeKind.Utc).AddTicks(7740) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "183b5ca0-bf51-4203-a9bb-2a9028ac2dc2", new DateTime(2026, 6, 9, 20, 53, 15, 411, DateTimeKind.Utc).AddTicks(1060), new DateTime(2026, 6, 9, 20, 53, 15, 411, DateTimeKind.Utc).AddTicks(1060), "AQAAAAIAAYagAAAAEOX7FnUVsehNt/CUs87bTVwSBAzhm+S8ZQ+tz+xg8F8uWqKrEc1udg85gMLM0fTuOQ==", "1a02e488-2d58-41a2-8b3f-f445013e3d33" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 451, DateTimeKind.Utc).AddTicks(2940), new DateTime(2026, 6, 9, 20, 53, 15, 451, DateTimeKind.Utc).AddTicks(3030), new Guid("2d921394-8486-4ff1-951f-ecc0494f7c3c") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 454, DateTimeKind.Utc).AddTicks(720), new DateTime(2026, 6, 9, 20, 53, 15, 454, DateTimeKind.Utc).AddTicks(720) });
        }
    }
}
