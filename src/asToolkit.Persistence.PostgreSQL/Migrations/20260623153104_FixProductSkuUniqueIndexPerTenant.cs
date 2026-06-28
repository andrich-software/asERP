using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asToolkit.Persistence.PostgreSQL.Migrations
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
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(5539), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(5543) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6655), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6655) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6658), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6658) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6660), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6662), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6662) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6664), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6664) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6681), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6681) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6682), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6683) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6687), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6687) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6689), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6689) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6690), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6691) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6692), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6692) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6694), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6694) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6695), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6696) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6697), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6697) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6699), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6699) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6702), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6702) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6703), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6704) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6705), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6705) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6707), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6707) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6708), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6709) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6710), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6710) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6722), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6722) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6724), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6725) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6729), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6729) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6730), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6732), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6732) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6734), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6734) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6735), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6736) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6737), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6737) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6739), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6739) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6740), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6741) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6744), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6744) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6745), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6746) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6747), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6747) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6749), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6749) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6750), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6751) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6752), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6752) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6763), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6764) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6765), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6765) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6768), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6769) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6770), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6772), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6772) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6773), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6774) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6775), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6775) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6776), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6777) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6778), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6778) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6781), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6781) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6784), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6785) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6786), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6786) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6788), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6788) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6789), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6791), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6792) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6793), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6793) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6805), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6805) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6806), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6806) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6809), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6811), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6811) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6813), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6813) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6814), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6814) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6816), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6816) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6817), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6818) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6819), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6819) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6821), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6821) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6824), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6824) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6825), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6826) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6827), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6827) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6829), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6829) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6830), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6831) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6832), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6832) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6842), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6843) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6844), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6844) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6848), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6848) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6849), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6851), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6851) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6853), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6853) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6854), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6855) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6856), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6857) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6858), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6859) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6860), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6863), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6863) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6865), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6866) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6867), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6867) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6881), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6882) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6883), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6883) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6885), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6885) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6896), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6896) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6898), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6898) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6901), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6901) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6902), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6903) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6904), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6904) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6906), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6906) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6907), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6908) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6909), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6909) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6911), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6911) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6912), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6913) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6915), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6916) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6917), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6917) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6919), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6919) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6920), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6921) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6922), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6922) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6924), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6924) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6934), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6934) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6936), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6936) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6939), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6939) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6940), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6941) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6942), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6942) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6944), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6944) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6945), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6946) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6947), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6947) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6949), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6949) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6950), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6951) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6953), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6954) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6955), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6955) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6957), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6957) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6958), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6959) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6960), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6962), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6962) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6963), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6964) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6965), new DateTime(2026, 6, 23, 15, 30, 59, 462, DateTimeKind.Utc).AddTicks(6965) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 463, DateTimeKind.Utc).AddTicks(9161), new DateTime(2026, 6, 23, 15, 30, 59, 463, DateTimeKind.Utc).AddTicks(9162) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "5e3622a8-e436-489e-bdee-6556a02c9482");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "213e8caf-4591-4bdd-abd9-028c8d2335f0");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 475, DateTimeKind.Utc).AddTicks(4367), new DateTime(2026, 6, 23, 15, 30, 59, 475, DateTimeKind.Utc).AddTicks(4368) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(685), new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(688) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1045), new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1045) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1047), new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1048) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1050), new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1050) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1051), new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1052) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1053), new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1053) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1069), new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1069) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1071), new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1072) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1076), new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1076) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1077), new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1077) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1054), new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1054) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1056), new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1056) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1059), new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1059) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1060), new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1060) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1062), new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1062) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1063), new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1063) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1065), new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1065) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1066), new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1066) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1067), new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1068) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1073), new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1073) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1074), new DateTime(2026, 6, 23, 15, 30, 59, 492, DateTimeKind.Utc).AddTicks(1074) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 477, DateTimeKind.Utc).AddTicks(83), new DateTime(2026, 6, 23, 15, 30, 59, 477, DateTimeKind.Utc).AddTicks(84) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 477, DateTimeKind.Utc).AddTicks(339), new DateTime(2026, 6, 23, 15, 30, 59, 477, DateTimeKind.Utc).AddTicks(340) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 477, DateTimeKind.Utc).AddTicks(342), new DateTime(2026, 6, 23, 15, 30, 59, 477, DateTimeKind.Utc).AddTicks(342) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 454, DateTimeKind.Utc).AddTicks(8642), new DateTime(2026, 6, 23, 15, 30, 59, 454, DateTimeKind.Utc).AddTicks(8648) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24ed81aa-9f80-4298-a5e0-14be781ea895", new DateTime(2026, 6, 23, 15, 30, 59, 414, DateTimeKind.Utc).AddTicks(8692), new DateTime(2026, 6, 23, 15, 30, 59, 414, DateTimeKind.Utc).AddTicks(8696), "AQAAAAIAAYagAAAAEKMbT0B1b4IybVLfWZUIFIQTtpgyqwHS+Ak9WWF4YviOFtbSpyqu6YDOW/IotNYIMg==", "4f863bf3-7bf3-47c5-9bf2-37feb39e9638" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 459, DateTimeKind.Utc).AddTicks(8817), new DateTime(2026, 6, 23, 15, 30, 59, 459, DateTimeKind.Utc).AddTicks(8946), new Guid("e03ae4a0-7323-4df4-bd22-ed08f588815b") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 23, 15, 30, 59, 463, DateTimeKind.Utc).AddTicks(2398), new DateTime(2026, 6, 23, 15, 30, 59, 463, DateTimeKind.Utc).AddTicks(2399) });

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
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4340), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4730), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4730), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4730), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4740), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4740), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4740), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4740), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4750), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4750), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4750), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4760), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4760), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4760), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4760), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4770), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4770), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4770), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4780), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4780), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4780), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4790), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4790), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4790), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4790), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4800), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4800), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4800), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4810), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4810), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4810), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4810), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4820), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4820), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4820), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4830), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4830), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4830), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4830), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4840), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4840), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4840), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4850), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4850), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4850), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4860), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4860), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4860), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4860), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4870), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4870), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4870), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4880), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4880), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4880), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4880), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4890), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4890), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4890), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4900), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4900), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4900), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4900), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4910), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4910), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4910), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4920), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4920), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4920), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4920), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4930), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4930), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4930), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4940), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4940), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4940), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4940), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4950), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4950), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4950), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4960), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4970), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4970), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4970), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4970), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4980), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4980), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4980), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4990), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4990), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4990), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(4990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5000), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5000), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5000), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5000), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5010), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5010), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5010), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5020), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5020), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5020), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5020), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5030), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5030), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5030), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5040), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5040), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5040), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5040), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5050), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5050), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5050), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5060), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5060), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5060), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5060), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5070), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5070), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5070), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5080), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(5080) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 472, DateTimeKind.Utc).AddTicks(2870), new DateTime(2026, 6, 19, 16, 5, 26, 472, DateTimeKind.Utc).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "ef11e39a-6b0e-4102-945e-a670882f141f");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "db34c408-e3b6-4d3a-bb03-a3d54ec1e294");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 481, DateTimeKind.Utc).AddTicks(2770), new DateTime(2026, 6, 19, 16, 5, 26, 481, DateTimeKind.Utc).AddTicks(2770) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6530), new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6830), new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6830) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6840), new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6840) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6840), new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6840) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6840), new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6840) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6850), new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6850) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6870), new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6870) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6880), new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6880) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6890), new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6890) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6890), new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6890) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6850), new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6850) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6850), new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6850) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6850), new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6850) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6860), new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6860) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6860), new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6860) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6860), new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6860) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6870), new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6870) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6870), new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6870) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6870), new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6870) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6880), new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6880) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6880), new DateTime(2026, 6, 19, 16, 5, 26, 492, DateTimeKind.Utc).AddTicks(6880) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 482, DateTimeKind.Utc).AddTicks(3930), new DateTime(2026, 6, 19, 16, 5, 26, 482, DateTimeKind.Utc).AddTicks(3930) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 482, DateTimeKind.Utc).AddTicks(4050), new DateTime(2026, 6, 19, 16, 5, 26, 482, DateTimeKind.Utc).AddTicks(4050) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 482, DateTimeKind.Utc).AddTicks(4050), new DateTime(2026, 6, 19, 16, 5, 26, 482, DateTimeKind.Utc).AddTicks(4050) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 466, DateTimeKind.Utc).AddTicks(1630), new DateTime(2026, 6, 19, 16, 5, 26, 466, DateTimeKind.Utc).AddTicks(1630) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40d14506-ce55-47ae-848f-a385af407030", new DateTime(2026, 6, 19, 16, 5, 26, 430, DateTimeKind.Utc).AddTicks(2160), new DateTime(2026, 6, 19, 16, 5, 26, 430, DateTimeKind.Utc).AddTicks(2160), "AQAAAAIAAYagAAAAEIsQSLjJJCor6tyFO9KBFnBsT+lsgiBjGOS5EbajIDsNAKQRaLQZmjUY+Pr5DMMwFg==", "7c81d9ce-0ba3-4e07-81e4-548d3371bc2f" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 469, DateTimeKind.Utc).AddTicks(1740), new DateTime(2026, 6, 19, 16, 5, 26, 469, DateTimeKind.Utc).AddTicks(1830), new Guid("8a19ccdf-dc86-484f-b288-7e17e35c7d02") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(6750), new DateTime(2026, 6, 19, 16, 5, 26, 471, DateTimeKind.Utc).AddTicks(6750) });

            migrationBuilder.CreateIndex(
                name: "IX_product_Sku",
                table: "product",
                column: "Sku",
                unique: true);
        }
    }
}
