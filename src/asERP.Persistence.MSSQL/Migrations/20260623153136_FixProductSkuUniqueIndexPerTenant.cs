using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.MSSQL.Migrations
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
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(1646), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(1648) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2252), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2252) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2255), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2255) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2257), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2257) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2259), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2259) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2260), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2261) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2262), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2262) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2267), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2268) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2269), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2269) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2270), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2271) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2272), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2272) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2274), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2274) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2275), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2275) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2285), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2285) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2287), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2287) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2300), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2302), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2303) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2304), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2304) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2306), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2306) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2307), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2308) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2309), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2309) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2310), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2312), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2312) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2315), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2315) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2316), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2316) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2317), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2318) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2327), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2327) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2332), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2332) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2334), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2334) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2335), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2335) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2336), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2337) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2347), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2347) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2349), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2349) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2351), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2351) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2352), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2352) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2354), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2354) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2355), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2355) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2357), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2357) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2358), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2358) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2361), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2361) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2362), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2362) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2364), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2364) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2365), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2365) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2366), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2367) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2368), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2368) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2369), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2371), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2371) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2380), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2381) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2382), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2383) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2384), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2384) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2386), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2386) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2387), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2387) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2389), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2389) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2390), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2392), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2392) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2394), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2394) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2396), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2396) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2397), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2397) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2399), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2399) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2400), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2401), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2402) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2403), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2403) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2404), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2405) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2414), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2415) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2417), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2417) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2419), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2419) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2421), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2421) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2422), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2422) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2424), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2424) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2425), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2425) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2427), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2427) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2429), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2431), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2431) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2432), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2432) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2434), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2434) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2435), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2435) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2437), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2437) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2438), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2438) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2439), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2439) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2448), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2449) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2451), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2451) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2453), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2453) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2454), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2455) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2456), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2456) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2457), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2458) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2459), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2459) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2460), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2461) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2463), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2463) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2464), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2465) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2466), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2466) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2467), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2467) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2469), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2469) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2470), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2471), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2472) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2473), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2473) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2482), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2482) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2485), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2485) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2486), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2486) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2488), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2488) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2489), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2491), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2492) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2493), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2493) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2495), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2495) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2497), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2497) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2499), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2499) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2501), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2501) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2507), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2507) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2509), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2509) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2510), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2511), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2512) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2513), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2513) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2515), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2516) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2517), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2517) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2518), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2519) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2520), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2521), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2521) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2523), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2523) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2524), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2524) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2525), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2526) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2528), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(2528) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 631, DateTimeKind.Utc).AddTicks(1484), new DateTime(2026, 6, 23, 15, 31, 19, 631, DateTimeKind.Utc).AddTicks(1485) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "bfa10250-a212-4f4a-a49e-092700a78222");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "7198d884-5482-4374-a56b-d2ef529599e8");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 644, DateTimeKind.Utc).AddTicks(5739), new DateTime(2026, 6, 23, 15, 31, 19, 644, DateTimeKind.Utc).AddTicks(5743) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3390), new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3393) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3739), new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3739) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3742), new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3742) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3744), new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3744) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3746), new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3746) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3747), new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3748) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3764), new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3764) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3765), new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3765) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3771), new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3771) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3772), new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3773) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3749), new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3749) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3751), new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3751) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3752), new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3752) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3755), new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3755) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3757), new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3757) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3758), new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3758) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3759), new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3760) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3761), new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3761) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3762), new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3763) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3768), new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3768) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3770), new DateTime(2026, 6, 23, 15, 31, 19, 660, DateTimeKind.Utc).AddTicks(3770) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 646, DateTimeKind.Utc).AddTicks(764), new DateTime(2026, 6, 23, 15, 31, 19, 646, DateTimeKind.Utc).AddTicks(766) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 646, DateTimeKind.Utc).AddTicks(961), new DateTime(2026, 6, 23, 15, 31, 19, 646, DateTimeKind.Utc).AddTicks(961) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 646, DateTimeKind.Utc).AddTicks(963), new DateTime(2026, 6, 23, 15, 31, 19, 646, DateTimeKind.Utc).AddTicks(964) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 623, DateTimeKind.Utc).AddTicks(5589), new DateTime(2026, 6, 23, 15, 31, 19, 623, DateTimeKind.Utc).AddTicks(5593) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf741530-ec83-4bfb-b301-9d603cce95b6", new DateTime(2026, 6, 23, 15, 31, 19, 581, DateTimeKind.Utc).AddTicks(9674), new DateTime(2026, 6, 23, 15, 31, 19, 581, DateTimeKind.Utc).AddTicks(9678), "AQAAAAIAAYagAAAAEITJpw1V+e6VyeyEMRZC7cy/YFXlbrKlMs1wB+Z0xiM4M6zKJTkGSX0fw+UKHy0HnQ==", "2e4700fb-8fb9-4dfa-8546-f84155b605a1" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 628, DateTimeKind.Utc).AddTicks(2276), new DateTime(2026, 6, 23, 15, 31, 19, 628, DateTimeKind.Utc).AddTicks(2428), new Guid("08852837-5d63-4b0a-b45f-e44b9a710bba") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(5363), new DateTime(2026, 6, 23, 15, 31, 19, 630, DateTimeKind.Utc).AddTicks(5364) });

            migrationBuilder.CreateIndex(
                name: "IX_product_TenantId_Sku",
                table: "product",
                columns: new[] { "TenantId", "Sku" },
                unique: true,
                filter: "[TenantId] IS NOT NULL");
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
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 802, DateTimeKind.Utc).AddTicks(9550), new DateTime(2026, 6, 19, 16, 5, 7, 802, DateTimeKind.Utc).AddTicks(9550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(70), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(70) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(80), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(80) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(80), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(80) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(90), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(90) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(90), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(90) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(90), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(90) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(90), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(100), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(100), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(100), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(110), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(110), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(110), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(120), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(120), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(120), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(120), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(130), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(130), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(130), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(140), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(140), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(140), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(150), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(150), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(150), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(150), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(160), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(160), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(160), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(170), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(170), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(170), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(170), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(180), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(180), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(180), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(190), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(190), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(190), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(200), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(200), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(200), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(200), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(210), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(210), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(210), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(220), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(220), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(220), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(230), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(230), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(230), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(230), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(240), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(240), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(240), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(250), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(250), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(290), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(290), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(290), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(300), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(300), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(300), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(300), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(310), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(310), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(310), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(320), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(320), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(320), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(330), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(330), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(330), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(330), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(340), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(340), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(340), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(350), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(350), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(350), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(360), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(360), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(360), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(360), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(370), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(370), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(370), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(380), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(380), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(380), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(380), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(390), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(390), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(390), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(400), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(400), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(400), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(410), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(410), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(410), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(410), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(420), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(420), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(420), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(430), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(430), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(430), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(440), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(440), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(440), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(440), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(450), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(450), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(450), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(460), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(460), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(460), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(460) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(8170), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(8170) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "18c98bdd-f8af-4387-8bef-075d12634862");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "d7440abc-068c-4fd6-8b3f-4ca4843e0a3c");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 812, DateTimeKind.Utc).AddTicks(7820), new DateTime(2026, 6, 19, 16, 5, 7, 812, DateTimeKind.Utc).AddTicks(7820) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(2950), new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(2950) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3180), new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3190), new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3190) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3190), new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3190) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3190), new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3190) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3190), new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3190) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3220), new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3230), new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3230), new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3240), new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3200), new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3200) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3200), new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3200) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3200), new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3200) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3210), new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3210) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3210), new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3210) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3210), new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3210) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3210), new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3210) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3220), new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3220), new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3230), new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3230), new DateTime(2026, 6, 19, 16, 5, 7, 825, DateTimeKind.Utc).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 813, DateTimeKind.Utc).AddTicks(9360), new DateTime(2026, 6, 19, 16, 5, 7, 813, DateTimeKind.Utc).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 813, DateTimeKind.Utc).AddTicks(9510), new DateTime(2026, 6, 19, 16, 5, 7, 813, DateTimeKind.Utc).AddTicks(9510) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 813, DateTimeKind.Utc).AddTicks(9510), new DateTime(2026, 6, 19, 16, 5, 7, 813, DateTimeKind.Utc).AddTicks(9510) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 796, DateTimeKind.Utc).AddTicks(6920), new DateTime(2026, 6, 19, 16, 5, 7, 796, DateTimeKind.Utc).AddTicks(6920) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05f9f07b-b4dc-4af3-88e7-1a7a3be30af0", new DateTime(2026, 6, 19, 16, 5, 7, 759, DateTimeKind.Utc).AddTicks(4660), new DateTime(2026, 6, 19, 16, 5, 7, 759, DateTimeKind.Utc).AddTicks(4660), "AQAAAAIAAYagAAAAEIaVoaA0HRZ+f0+qNE+97jGcKPVJTIlHIREI9khwo3z2TSmvdyhlAvjlitbK8cML9A==", "58c7deb0-7e0d-4abf-9975-3dca91c51378" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 800, DateTimeKind.Utc).AddTicks(2640), new DateTime(2026, 6, 19, 16, 5, 7, 800, DateTimeKind.Utc).AddTicks(2730), new Guid("f4e2303f-7628-47d1-83f3-f71b3e6f8217") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(2670), new DateTime(2026, 6, 19, 16, 5, 7, 803, DateTimeKind.Utc).AddTicks(2670) });

            migrationBuilder.CreateIndex(
                name: "IX_product_Sku",
                table: "product",
                column: "Sku",
                unique: true);
        }
    }
}
