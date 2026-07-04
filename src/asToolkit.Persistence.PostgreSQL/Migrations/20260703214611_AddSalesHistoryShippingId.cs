using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asToolkit.Persistence.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddSalesHistoryShippingId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ShippingId",
                table: "sales_history",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(1599), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(1600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2201), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2201) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2203), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2204) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2212), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2212) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2214), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2214) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2216), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2216) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2217), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2218) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2219), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2219) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2221), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2221) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2222), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2222) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2224), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2224) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2236), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2236) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2238), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2239) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2240), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2241) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2242), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2242) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2244), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2244) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2245), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2245) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2247), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2247) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2248), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2248) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2251), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2251) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2252), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2253) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2254), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2254) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2255), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2256) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2257), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2257) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2259), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2259) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2260), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2268), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2268) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2282), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2283) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2285), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2285) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2287), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2287) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2288), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2289) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2290), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2292), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2292) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2293), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2293) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2295), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2295) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2297), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2298) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2299), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2299) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2300), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2301) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2302), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2302) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2303), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2304) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2305), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2305) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2306), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2307) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2308), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2308) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2318), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2318) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2320), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2322), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2322) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2324), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2324) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2325), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2326) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2327), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2327) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2328), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2329) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2330), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2333), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2333) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2334), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2334) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2336), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2336) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2337), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2337) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2339), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2339) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2340), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2342), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2342) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2343), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2343) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2360), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2361) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2363), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2364) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2365), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2365) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2367), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2367) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2368), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2369) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2370), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2372), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2372) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2373), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2373) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2376), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2376) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2378), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2378) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2379), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2379) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2381), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2381) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2382), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2382) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2384), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2384) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2385), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2385) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2387), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2387) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2397), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2397) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2399), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2399) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2401), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2401) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2403), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2403) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2404), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2405) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2406), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2406) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2408), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2408) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2409), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2409) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2412), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2412) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2414), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2414) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2415), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2415) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2417), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2417) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2418), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2418) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2420), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2421), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2421) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2423), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2423) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2432), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2432) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2435), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2435) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2436), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2436) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2438), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2438) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2439), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2441), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2442) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2443), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2443) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2445), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2445) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2448), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2448) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2449), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2449) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2451), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2451) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2452), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2453) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2454), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2455) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2456), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2457) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2458), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2458) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2459), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2462), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2462) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2464), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2464) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2465), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2466) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2467), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2467) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2468), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2469) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2470), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2471), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2472) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2473), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2473) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2475), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2476) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2477), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2477) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2478), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2479) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2480), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2482), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2482) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 567, DateTimeKind.Utc).AddTicks(1291), new DateTime(2026, 7, 3, 21, 46, 10, 567, DateTimeKind.Utc).AddTicks(1291) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "96713f89-7c87-4df1-b9e1-536fb6c8156c");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "dae48619-a9ee-4f93-b495-bcfb0c7a6513");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 579, DateTimeKind.Utc).AddTicks(2193), new DateTime(2026, 7, 3, 21, 46, 10, 579, DateTimeKind.Utc).AddTicks(2196) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 601, DateTimeKind.Utc).AddTicks(9492), new DateTime(2026, 7, 3, 21, 46, 10, 601, DateTimeKind.Utc).AddTicks(9505) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2191), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2191) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2200), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2200) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2204), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2204) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2207), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2207) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2234), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2234) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2236), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2236) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2247), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2247) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2249), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2250) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2209), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2210) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2212), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2212) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2214), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2215) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2217), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2217) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2219), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2220) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2224), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2224) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2227), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2227) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2229), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2229) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2231), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2232) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2238), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2239) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2242), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2243) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 581, DateTimeKind.Utc).AddTicks(743), new DateTime(2026, 7, 3, 21, 46, 10, 581, DateTimeKind.Utc).AddTicks(745) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 581, DateTimeKind.Utc).AddTicks(948), new DateTime(2026, 7, 3, 21, 46, 10, 581, DateTimeKind.Utc).AddTicks(948) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 581, DateTimeKind.Utc).AddTicks(951), new DateTime(2026, 7, 3, 21, 46, 10, 581, DateTimeKind.Utc).AddTicks(951) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 559, DateTimeKind.Utc).AddTicks(6014), new DateTime(2026, 7, 3, 21, 46, 10, 559, DateTimeKind.Utc).AddTicks(6018) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "989c8d11-a1b7-40dc-baed-74b38538ede6", new DateTime(2026, 7, 3, 21, 46, 10, 521, DateTimeKind.Utc).AddTicks(2118), new DateTime(2026, 7, 3, 21, 46, 10, 521, DateTimeKind.Utc).AddTicks(2121), "AQAAAAIAAYagAAAAEC8ntku/JBpus90iwF6t0DTXMZnrxCVixfm1v8z2KmQ7Y/qzFG20n0sf4fxkDTkGhw==", "885338b0-6ccb-41e6-bb48-e419d5c6289e" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 564, DateTimeKind.Utc).AddTicks(2329), new DateTime(2026, 7, 3, 21, 46, 10, 564, DateTimeKind.Utc).AddTicks(2449), new Guid("e1491060-4f72-43e9-878f-5f8b973295f8") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(5164), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(5164) });

            migrationBuilder.CreateIndex(
                name: "IX_sales_history_ShippingId",
                table: "sales_history",
                column: "ShippingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_sales_history_ShippingId",
                table: "sales_history");

            migrationBuilder.DropColumn(
                name: "ShippingId",
                table: "sales_history");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(8479), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(8480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9072), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9072) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9074), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9074) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9076), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9076) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9077), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9077) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9079), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9079) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9086), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9086) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9087), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9088) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9089), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9089) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9091), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9091) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9092), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9092) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9102), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9102) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9103), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9104) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9105), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9105) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9108), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9108) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9110), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9111), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9111) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9113), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9113) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9114), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9114) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9116), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9116) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9117), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9117) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9119), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9119) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9121), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9121) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9123), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9123) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9124), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9124) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9126), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9126) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9140), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9149), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9152), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9152) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9153), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9153) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9156), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9156) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9158), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9158) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9159), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9159) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9160), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9161) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9162), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9162) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9163), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9163) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9165), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9165) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9166), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9166) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9169), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9169) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9170), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9171) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9172), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9172) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9173), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9173) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9175), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9175) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9183), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9183) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9185), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9185) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9187), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9187) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9189), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9191), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9191) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9192), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9193) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9194), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9194) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9195), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9196) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9197), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9197) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9198), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9198) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9200), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9202), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9202) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9204), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9204) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9205), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9205) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9206), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9207) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9208), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9208) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9216), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9216) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9218), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9219) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9220), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9222), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9223) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9224), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9224) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9225), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9226) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9227), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9227) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9228), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9228) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9230), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9231), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9231) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9233), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9233) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9235), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9235) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9236), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9237) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9238), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9238) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9239), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9239) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9240), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9241) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9249), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9249) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9251), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9252) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9253), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9253) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9256), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9256) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9258), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9258) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9259), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9259) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9260), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9261) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9268), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9268) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9270), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9271), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9271) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9272), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9273) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9275), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9275) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9276), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9276) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9278), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9278) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9279), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9279) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9280), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9288), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9289) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9291), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9291) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9293), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9293) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9295), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9295) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9297), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9297) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9298), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9298) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9299), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9301), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9301) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9302), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9302) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9304), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9304) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9305), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9306) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9308), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9308) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9310), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9311), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9312) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9313), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9313) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9314), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9314) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9316), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9316) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9317), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9317) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9319), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9319) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9321), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9321) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9323), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9323) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9324), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9324) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9326), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9326) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9327), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9327) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9328), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9329) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9330), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9331), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9331) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9334), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9334) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9335), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9335) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 7, DateTimeKind.Utc).AddTicks(8101), new DateTime(2026, 7, 3, 20, 57, 45, 7, DateTimeKind.Utc).AddTicks(8101) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "011cafbd-7dc3-4ab9-b61a-3b924e844be4");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "bee76d34-4982-40b1-a233-538f8609c9ab");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 19, DateTimeKind.Utc).AddTicks(258), new DateTime(2026, 7, 3, 20, 57, 45, 19, DateTimeKind.Utc).AddTicks(260) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3279), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3282) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3759), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3760) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3763), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3763) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3764), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3765) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3766), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3766) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3783), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3783) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3784), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3784) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3789), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3790) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3791), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3791) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3768), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3768) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3769), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3769) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3770), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3770) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3775), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3775) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3776), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3776) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3777), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3778) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3779), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3779) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3780), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3780) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3781), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3781) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3787), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3787) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3788), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3788) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 20, DateTimeKind.Utc).AddTicks(6733), new DateTime(2026, 7, 3, 20, 57, 45, 20, DateTimeKind.Utc).AddTicks(6735) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 20, DateTimeKind.Utc).AddTicks(6937), new DateTime(2026, 7, 3, 20, 57, 45, 20, DateTimeKind.Utc).AddTicks(6938) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 20, DateTimeKind.Utc).AddTicks(6940), new DateTime(2026, 7, 3, 20, 57, 45, 20, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 0, DateTimeKind.Utc).AddTicks(9606), new DateTime(2026, 7, 3, 20, 57, 45, 0, DateTimeKind.Utc).AddTicks(9611) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86a62128-6636-4a60-802a-a66d71a3ff50", new DateTime(2026, 7, 3, 20, 57, 44, 962, DateTimeKind.Utc).AddTicks(4025), new DateTime(2026, 7, 3, 20, 57, 44, 962, DateTimeKind.Utc).AddTicks(4028), "AQAAAAIAAYagAAAAEAhCScJjOVJmQbySJu58eNeWkDY1K6WaMja+awlYJY8sjK9wZHrLd3HeKix3CE1ROw==", "b9e564d0-1dc0-42d1-812c-e0d7b78b0f23" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 5, DateTimeKind.Utc).AddTicks(33), new DateTime(2026, 7, 3, 20, 57, 45, 5, DateTimeKind.Utc).AddTicks(149), new Guid("dcd90797-2f07-4f7d-83fc-28d08e873c33") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 7, DateTimeKind.Utc).AddTicks(2035), new DateTime(2026, 7, 3, 20, 57, 45, 7, DateTimeKind.Utc).AddTicks(2035) });
        }
    }
}
