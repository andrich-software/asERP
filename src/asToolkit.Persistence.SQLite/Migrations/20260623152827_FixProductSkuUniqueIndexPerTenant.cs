using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asToolkit.Persistence.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class FixProductSkuUniqueIndexPerTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_product_Sku",
                table: "product");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(7154), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(7157) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8309), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8309) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8313), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8313) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8315), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8316) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8319), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8319) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8322), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8322) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8324), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8325) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8327), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8328) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8333), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8333) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8335), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8335) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8338), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8338) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8341), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8341) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8356), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8358), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8359) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8361), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8361) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8363), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8363) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8367), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8367) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8369), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8372), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8373) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8376), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8376) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8379), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8379) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8381), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8381) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8383), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8383) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8385), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8385) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8389), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8389) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8391), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8391) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8404), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8405) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8409), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8409) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8420), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8422), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8422) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8424), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8424) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8426), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8426) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8430), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8431), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8432) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8433), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8433) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8435), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8435) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8437), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8437) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8438), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8438) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8440), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8442), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8442) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8445), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8445) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8447), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8447) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8449), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8449) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8450), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8461), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8461) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8463), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8463) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8465), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8465) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8467), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8467) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8471), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8471) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8472), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8472) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8474), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8474) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8492), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8492) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8494), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8494) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8495), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8496) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8497), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8497) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8499), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8499) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8502), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8502) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8504), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8504) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8505), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8506) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8507), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8507) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8518), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8518) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8519), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8521), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8521) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8523), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8523) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8526), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8526) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8527), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8528) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8529), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8529) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8531), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8531) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8533), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8533) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8534), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8534) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8536), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8536) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8538), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8538) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8541), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8541) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8543), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8543) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8544), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8545) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8546), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8546) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8556), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8557) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8558), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8558) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8560), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8560) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8561), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8562) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8565), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8565) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8566), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8567) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8568), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8568) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8570), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8572), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8572) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8573), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8573) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8575), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8575) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8577), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8577) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8580), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8580) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8581), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8582) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8583), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8583) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8585), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8585) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8596), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8596) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8598), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8598) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8599), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8603), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8603) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8607), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8607) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8609), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8609) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8610), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8611) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8612), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8612) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8614), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8614) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8616), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8616) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8617), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8618) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8619), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8619) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8622), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8622) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8624), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8624) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8626), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8626) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8627), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8628) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8629), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8629) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8631), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8631) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8632), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8633) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8634), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8634) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8637), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8638) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8639), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8639) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8641), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8641) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8643), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8643) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8644), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8644) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8646), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8646) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8648), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8648) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8649), new DateTime(2026, 6, 23, 15, 28, 21, 218, DateTimeKind.Utc).AddTicks(8650) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 220, DateTimeKind.Utc).AddTicks(1761), new DateTime(2026, 6, 23, 15, 28, 21, 220, DateTimeKind.Utc).AddTicks(1762) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "b9caf2e1-263e-4319-83c9-e53562280408");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "693889e8-2f6b-4c37-a3ba-af925383b6b4");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 237, DateTimeKind.Utc).AddTicks(3114), new DateTime(2026, 6, 23, 15, 28, 21, 237, DateTimeKind.Utc).AddTicks(3116) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7238), new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7241) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7814), new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7815) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7818), new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7819) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7820), new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7821) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7822), new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7822) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7824), new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7824) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7845), new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7845) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7848), new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7848) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7854), new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7854) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7856), new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7856) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7825), new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7826) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7827), new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7827) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7832), new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7832) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7833), new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7834) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7836), new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7836) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7838), new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7838) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7839), new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7839) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7841), new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7841) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7843), new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7843) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7850), new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7850) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7852), new DateTime(2026, 6, 23, 15, 28, 21, 259, DateTimeKind.Utc).AddTicks(7852) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 240, DateTimeKind.Utc).AddTicks(3770), new DateTime(2026, 6, 23, 15, 28, 21, 240, DateTimeKind.Utc).AddTicks(3772) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 240, DateTimeKind.Utc).AddTicks(4149), new DateTime(2026, 6, 23, 15, 28, 21, 240, DateTimeKind.Utc).AddTicks(4149) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 240, DateTimeKind.Utc).AddTicks(4154), new DateTime(2026, 6, 23, 15, 28, 21, 240, DateTimeKind.Utc).AddTicks(4154) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 209, DateTimeKind.Utc).AddTicks(2508), new DateTime(2026, 6, 23, 15, 28, 21, 209, DateTimeKind.Utc).AddTicks(2513) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d2d780b-5b23-467f-8dfb-7d0197027a64", new DateTime(2026, 6, 23, 15, 28, 21, 163, DateTimeKind.Utc).AddTicks(7187), new DateTime(2026, 6, 23, 15, 28, 21, 163, DateTimeKind.Utc).AddTicks(7190), "AQAAAAIAAYagAAAAEF6xpMuYuWCLq9tptPdMa32DLDhD/SKujy2rO7ObsCMaUJAnGUP7GY0dkofazVwEoQ==", "7b37a696-8ab0-4d19-95c0-bf046479a4ba" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 215, DateTimeKind.Utc).AddTicks(9060), new DateTime(2026, 6, 23, 15, 28, 21, 215, DateTimeKind.Utc).AddTicks(9288), new Guid("1614e07d-3f04-4633-af0c-b798ccf9dad8") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 28, 21, 219, DateTimeKind.Utc).AddTicks(3122), new DateTime(2026, 6, 23, 15, 28, 21, 219, DateTimeKind.Utc).AddTicks(3123) });

            migrationBuilder.CreateIndex(
                name: "IX_product_TenantId_Sku",
                table: "product",
                columns: new[] { "TenantId", "Sku" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_product_TenantId_Sku",
                table: "product");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3350), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3770), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3770), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3770), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3780), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3780), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3780), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3800), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3800), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3810), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3810), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3810), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3810), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3820), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3820), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3820), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3830), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3830), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3830), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3830), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3840), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3840), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3840), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3850), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3850), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3850), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3850), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3860), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3860), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3860), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3860), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3870), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3870), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3870), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3870), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3880), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3880), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3880), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3880), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3890), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3890), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3890), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3900), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3900), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3900), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3900), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3910), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3910), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3910), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3910), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3920), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3920), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3920), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3920), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3930), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3930), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3930), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3930), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3940), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3940), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3940), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3950), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3950), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3950), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3950), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3960), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3960), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3960), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3960), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3970), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3970), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3970), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3970), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3980), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3980), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3980), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3980), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3990), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3990), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3990), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(3990), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4000), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4000), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4000), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4010), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4010), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4010), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4010), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4020), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4020), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4020), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4020), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4030), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4030), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4030), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4030), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4040), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4040), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4040), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4040), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4070), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4070), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4070), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4070), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4080), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4080), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4080), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4080), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4090), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4090), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4090), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4090), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4100), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4100), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4100), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4110), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4110), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4110), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4110), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4120), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(4120) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 730, DateTimeKind.Utc).AddTicks(1360), new DateTime(2026, 6, 19, 16, 5, 30, 730, DateTimeKind.Utc).AddTicks(1360) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "d577876a-e299-42b9-b268-0e07955365d5");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "60b95697-9010-45af-8dc9-6791feb0c8d2");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 738, DateTimeKind.Utc).AddTicks(9360), new DateTime(2026, 6, 19, 16, 5, 30, 738, DateTimeKind.Utc).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4050), new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4050) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4300), new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4300) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4300), new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4310) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4310), new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4310) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4310), new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4310) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4310), new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4310) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4340), new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4340) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4340), new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4340) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4350), new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4350) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4350), new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4350) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4320), new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4320) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4320), new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4320) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4320), new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4320) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4320), new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4320) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4320), new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4330) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4330), new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4330) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4330), new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4330) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4330), new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4330) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4330), new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4340) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4340), new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4340) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4340), new DateTime(2026, 6, 19, 16, 5, 30, 750, DateTimeKind.Utc).AddTicks(4350) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 739, DateTimeKind.Utc).AddTicks(9620), new DateTime(2026, 6, 19, 16, 5, 30, 739, DateTimeKind.Utc).AddTicks(9620) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 739, DateTimeKind.Utc).AddTicks(9720), new DateTime(2026, 6, 19, 16, 5, 30, 739, DateTimeKind.Utc).AddTicks(9720) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 739, DateTimeKind.Utc).AddTicks(9730), new DateTime(2026, 6, 19, 16, 5, 30, 739, DateTimeKind.Utc).AddTicks(9730) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 723, DateTimeKind.Utc).AddTicks(4920), new DateTime(2026, 6, 19, 16, 5, 30, 723, DateTimeKind.Utc).AddTicks(4920) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78914769-709d-4bbd-8596-349ce0e0e32f", new DateTime(2026, 6, 19, 16, 5, 30, 687, DateTimeKind.Utc).AddTicks(8400), new DateTime(2026, 6, 19, 16, 5, 30, 687, DateTimeKind.Utc).AddTicks(8400), "AQAAAAIAAYagAAAAEDzpdF3AbvSJsD8NbCYS6qwUuFa0LuA8XWw4XPu28sBrtoGAKMI0HjFR0FbeQv6VBA==", "5a593510-0d3a-4106-a74a-05fb4e8f2f7c" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 727, DateTimeKind.Utc).AddTicks(460), new DateTime(2026, 6, 19, 16, 5, 30, 727, DateTimeKind.Utc).AddTicks(630), new Guid("5ca2df55-2a7a-47b1-ae33-d1f2c8da511d") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(6190), new DateTime(2026, 6, 19, 16, 5, 30, 729, DateTimeKind.Utc).AddTicks(6190) });

            migrationBuilder.CreateIndex(
                name: "IX_product_Sku",
                table: "product",
                column: "Sku",
                unique: true);
        }
    }
}
