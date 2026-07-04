using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.MSSQL.Migrations
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
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductType",
                table: "product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VariantSortOrder",
                table: "product",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(2670), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(2670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3230), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3240), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3240), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3240), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3240), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3250), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3250), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3250), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3260), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3260), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3260), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3270), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3270), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3320), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3320), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3320), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3330), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3330), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3330), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3330), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3340), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3340), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3340), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3350), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3350), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3350), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3350), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3360), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3360), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3360), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3370), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3370), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3370), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3380), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3380), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3380), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3380), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3390), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3390), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3390), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3400), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3400), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3400), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3410), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3410), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3410), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3410), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3420), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3420), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3420), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3430), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3430), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3430), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3430), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3440), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3440), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3440), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3450), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3450), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3450), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3460), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3460), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3460), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3460), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3470), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3470), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3470), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3480), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3480), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3480), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3480), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3490), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3490), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3490), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3500), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3500), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3500), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3510), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3510), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3510), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3510), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3520), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3520), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3520), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3530), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3530), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3530), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3540), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3540), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3540), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3540), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3550), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3550), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3550), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3560), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3560) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3560), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3560) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3560), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3560) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3570), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3570), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3570), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3570), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3580), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3580) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3580), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3580) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3580), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3580) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3590), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3590), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3590), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3600), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3600), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3600), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3610), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3610), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3610), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3620), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3620), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3620), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3620), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3630), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3630), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(3630) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 945, DateTimeKind.Utc).AddTicks(1610), new DateTime(2026, 6, 12, 13, 12, 59, 945, DateTimeKind.Utc).AddTicks(1610) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "fec3d758-94b8-4b9f-8b66-005e5b48b752");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "2543f1a9-de9d-46f5-8380-d9d971b87ac9");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 954, DateTimeKind.Utc).AddTicks(4470), new DateTime(2026, 6, 12, 13, 12, 59, 954, DateTimeKind.Utc).AddTicks(4470) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6660), new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6660) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6880), new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6880) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6890), new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6890) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6890), new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6890) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6890), new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6890) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6900), new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6900) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6920), new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6920) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6930), new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6940), new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6940), new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6900), new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6900) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6900), new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6900) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6910), new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6910) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6910), new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6910) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6910), new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6910) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6910), new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6910) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6920), new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6920) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6920), new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6920) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6920), new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6920) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6930), new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6930), new DateTime(2026, 6, 12, 13, 12, 59, 965, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 955, DateTimeKind.Utc).AddTicks(5130), new DateTime(2026, 6, 12, 13, 12, 59, 955, DateTimeKind.Utc).AddTicks(5130) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 955, DateTimeKind.Utc).AddTicks(5240), new DateTime(2026, 6, 12, 13, 12, 59, 955, DateTimeKind.Utc).AddTicks(5240) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 955, DateTimeKind.Utc).AddTicks(5240), new DateTime(2026, 6, 12, 13, 12, 59, 955, DateTimeKind.Utc).AddTicks(5240) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 938, DateTimeKind.Utc).AddTicks(1030), new DateTime(2026, 6, 12, 13, 12, 59, 938, DateTimeKind.Utc).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41a1cab0-df4d-40de-b7f9-a9b88c1a0cb8", new DateTime(2026, 6, 12, 13, 12, 59, 900, DateTimeKind.Utc).AddTicks(5750), new DateTime(2026, 6, 12, 13, 12, 59, 900, DateTimeKind.Utc).AddTicks(5750), "AQAAAAIAAYagAAAAEGv8EyT/He9E08CRs1mep1v84bzIGJytVvVnt/v87Gl5JLU2ESdDjBa9RuzoK+BqXg==", "570aefe0-1b2d-47ca-9a17-384aeaea05db" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 941, DateTimeKind.Utc).AddTicks(6880), new DateTime(2026, 6, 12, 13, 12, 59, 941, DateTimeKind.Utc).AddTicks(6980), new Guid("aacbc991-a89f-4a6e-aaa5-91de9908c5c8") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(6090), new DateTime(2026, 6, 12, 13, 12, 59, 944, DateTimeKind.Utc).AddTicks(6090) });

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
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6500), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6900), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6910), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6910), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6910), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6920), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6920), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6920), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6930), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6930), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6930), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6930), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6940), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6940), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6940), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6950), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6950), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6950), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6950), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6960), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6960), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6960), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6970), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6970), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6970), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6980), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6980), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6990), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6990), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6990), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(6990), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7000), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7000), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7000), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7010), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7010), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7010), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7020), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7020), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7020), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7020), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7030), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7030), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7030), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7040), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7040), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7040), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7040), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7050), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7050), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7050), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7060), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7060), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7060), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7070), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7070), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7070), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7080), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7080), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7080), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7080), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7090), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7090), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7090), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7100), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7100), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7100), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7100), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7110), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7110), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7110), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7120), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7120), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7120), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7130), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7130), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7130), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7130), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7140), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7140), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7140), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7150), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7150), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7150), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7160), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7160), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7160), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7170), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7170), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7170), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7170), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7180), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7180), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7180), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7190), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7190), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7190), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7190), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7200), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7200), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7200), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7210), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7210), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7210), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7220), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7220), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7220), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7220), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7230), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7230), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7230), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7240), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7240), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7240), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7250), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7250), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7250), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7250), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7260), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7280), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(7280) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 941, DateTimeKind.Utc).AddTicks(3990), new DateTime(2026, 6, 9, 20, 52, 54, 941, DateTimeKind.Utc).AddTicks(3990) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "94ef4b05-1670-49e3-a863-725f9f0e0072");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "ff56f7cd-0dbd-4dc8-aa8b-68fc3afd3124");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 949, DateTimeKind.Utc).AddTicks(8830), new DateTime(2026, 6, 9, 20, 52, 54, 949, DateTimeKind.Utc).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7220), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7220) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7430), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7430), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7440), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7440), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7440), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7470), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7470) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7470), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7470) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7480), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7480) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7480), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7480) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7440), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7450), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7450), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7450), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7460), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7460), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7460), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7460), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7470), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7470) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7480), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7480) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7480), new DateTime(2026, 6, 9, 20, 52, 54, 958, DateTimeKind.Utc).AddTicks(7480) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 950, DateTimeKind.Utc).AddTicks(8950), new DateTime(2026, 6, 9, 20, 52, 54, 950, DateTimeKind.Utc).AddTicks(8950) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 950, DateTimeKind.Utc).AddTicks(9060), new DateTime(2026, 6, 9, 20, 52, 54, 950, DateTimeKind.Utc).AddTicks(9060) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 950, DateTimeKind.Utc).AddTicks(9060), new DateTime(2026, 6, 9, 20, 52, 54, 950, DateTimeKind.Utc).AddTicks(9060) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 934, DateTimeKind.Utc).AddTicks(7380), new DateTime(2026, 6, 9, 20, 52, 54, 934, DateTimeKind.Utc).AddTicks(7380) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd8b7a5d-8484-41f4-9853-551e60978080", new DateTime(2026, 6, 9, 20, 52, 54, 897, DateTimeKind.Utc).AddTicks(3010), new DateTime(2026, 6, 9, 20, 52, 54, 897, DateTimeKind.Utc).AddTicks(3010), "AQAAAAIAAYagAAAAEHznxZcJTi9X1K43uejo7smk2cbvUGwAhyWWB1oVXGi2GYmY7zD5OAN6o2iZirI12A==", "81e4f522-df7f-4191-a878-6f0bb8de18d3" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 938, DateTimeKind.Utc).AddTicks(3280), new DateTime(2026, 6, 9, 20, 52, 54, 938, DateTimeKind.Utc).AddTicks(3380), new Guid("de228155-e032-48ef-afe9-adf44e502b6d") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(8940), new DateTime(2026, 6, 9, 20, 52, 54, 940, DateTimeKind.Utc).AddTicks(8940) });
        }
    }
}
