using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.MSSQL.Migrations
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
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(7447), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(7449) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8106), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8106) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8108), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8108) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8109), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8121), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8122) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8123), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8123) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8125), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8125) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8127), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8127) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8132), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8132) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8133), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8133) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8135), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8135) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8136), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8138), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8138) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8139), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8141), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8141) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8143), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8143) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8146), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8146) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8147), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8147) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8149), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8149) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8150), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8159), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8159) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8161), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8162) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8164), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8164) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8165), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8165) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8168), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8168) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8170), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8180), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8182), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8183) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8193), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8193) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8195), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8195) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8196), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8197) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8198), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8198) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8201), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8201) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8202), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8202) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8204), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8204) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8205), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8206) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8215), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8216) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8217), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8218) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8219), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8219) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8221), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8221) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8224), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8224) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8225), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8225) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8227), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8227) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8228), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8229) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8230), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8231), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8232) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8233), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8233) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8234), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8235) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8237), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8238) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8239), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8239) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8240), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8241) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8242), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8242) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8250), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8251) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8253), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8254) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8256), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8256) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8258), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8258) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8260), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8261) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8262), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8263) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8264), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8264) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8265), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8266) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8267), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8267) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8269), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8269) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8270), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8271), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8272) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8274), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8275) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8276), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8276) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8277), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8278) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8279), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8279) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8281), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8281) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8290), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8293), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8293) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8294), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8294) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8297), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8297) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8299), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8299) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8300), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8301) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8302), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8302) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8303), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8304) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8305), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8305) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8306), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8307) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8308), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8308) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8311), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8311) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8312), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8312) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8314), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8314) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8315), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8315) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8317), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8317) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8325), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8326) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8328), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8328) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8330), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8333), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8333) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8335), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8335) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8336), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8336) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8338), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8338) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8339), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8339) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8341), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8341) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8342), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8344), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8344) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8347), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8347) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8348), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8348) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8350), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8351), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8351) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8353), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8353) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8362), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8362) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8364), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8364) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8366), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8367) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8369), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8371), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8372) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8373), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8373) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8375), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8375) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8377), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8377) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8379), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8379) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8380), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8382), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8382) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8384), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8385) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8386), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8386) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8387), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8388) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8389), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8389) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8390), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8391) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8392), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8392) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8393), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8393) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8395), new DateTime(2026, 7, 3, 21, 45, 46, 453, DateTimeKind.Utc).AddTicks(8395) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 454, DateTimeKind.Utc).AddTicks(7892), new DateTime(2026, 7, 3, 21, 45, 46, 454, DateTimeKind.Utc).AddTicks(7893) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "6f857e15-abdd-47af-869d-5061cc8c3bcd");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "2a8ab580-6b40-4954-9d53-f2e06941428e");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 466, DateTimeKind.Utc).AddTicks(7491), new DateTime(2026, 7, 3, 21, 45, 46, 466, DateTimeKind.Utc).AddTicks(7493) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3431), new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3435) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3802), new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3802) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3811), new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3812) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3813), new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3813) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3815), new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3815) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3830), new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3831) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3832), new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3832) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3837), new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3837) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3839), new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3839) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3816), new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3816) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3818), new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3818) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3819), new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3819) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3821), new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3821) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3822), new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3822) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3825), new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3825) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3826), new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3826) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3828), new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3828) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3829), new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3829) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3833), new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3833) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3834), new DateTime(2026, 7, 3, 21, 45, 46, 488, DateTimeKind.Utc).AddTicks(3835) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 468, DateTimeKind.Utc).AddTicks(4172), new DateTime(2026, 7, 3, 21, 45, 46, 468, DateTimeKind.Utc).AddTicks(4173) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 468, DateTimeKind.Utc).AddTicks(4394), new DateTime(2026, 7, 3, 21, 45, 46, 468, DateTimeKind.Utc).AddTicks(4395) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 468, DateTimeKind.Utc).AddTicks(4397), new DateTime(2026, 7, 3, 21, 45, 46, 468, DateTimeKind.Utc).AddTicks(4397) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 446, DateTimeKind.Utc).AddTicks(7618), new DateTime(2026, 7, 3, 21, 45, 46, 446, DateTimeKind.Utc).AddTicks(7622) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "064f3d9d-992b-45a4-8207-795deac874fe", new DateTime(2026, 7, 3, 21, 45, 46, 405, DateTimeKind.Utc).AddTicks(8745), new DateTime(2026, 7, 3, 21, 45, 46, 405, DateTimeKind.Utc).AddTicks(8748), "AQAAAAIAAYagAAAAEEyo9a2k/tJCbX6my3ohc+AUISpcpxbrD4wRMOcvQ2DuPYb145R40MMMZJF4BTQqBQ==", "0a46b853-6d83-40f6-830d-4594f62667d9" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 451, DateTimeKind.Utc).AddTicks(7047), new DateTime(2026, 7, 3, 21, 45, 46, 451, DateTimeKind.Utc).AddTicks(7178), new Guid("bb30392b-2503-4002-b3f6-fd46c0989817") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 45, 46, 454, DateTimeKind.Utc).AddTicks(1351), new DateTime(2026, 7, 3, 21, 45, 46, 454, DateTimeKind.Utc).AddTicks(1352) });

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
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(3438), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(3440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4039), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4052), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4052) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4054), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4054) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4055), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4056) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4057), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4057) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4059), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4059) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4060), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4064), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4064) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4066), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4066) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4067), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4068) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4069), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4069) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4070), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4072), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4072) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4073), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4073) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4075), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4075) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4078), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4079), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4079) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4088), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4089) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4090), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4091) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4093), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4093) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4094), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4094) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4096), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4096) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4097), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4097) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4100), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4101), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4102) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4113), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4113) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4116), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4116) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4117), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4117) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4119), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4119) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4120), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4122), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4122) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4124), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4124) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4126), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4126) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4134), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4134) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4137), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4137) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4138), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4138) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4139), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4141), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4141) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4142), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4143) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4145), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4145) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4146), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4147) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4148), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4148) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4149), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4151), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4151) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4152), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4152) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4154), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4154) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4155), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4156) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4158), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4158) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4159), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4167), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4167) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4169), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4171), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4171) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4172), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4173) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4174), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4174) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4175), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4176) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4178), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4178) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4180), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4181), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4181) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4183), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4183) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4184), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4184) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4185), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4186) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4187), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4187) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4188), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4188) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4191), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4191) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4192), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4200), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4201) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4203), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4203) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4204), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4204) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4206), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4206) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4207), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4207) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4208), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4209) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4211), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4211) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4212), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4213) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4214), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4214) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4215), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4216) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4217), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4217) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4218), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4218) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4229), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4229) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4230), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4231) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4233), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4233) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4235), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4235) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4243), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4244) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4245), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4245) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4247), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4247) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4248), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4249) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4250), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4251), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4251) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4254), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4254) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4255), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4256) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4257), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4257) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4258), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4258) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4260), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4261), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4261) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4262), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4263) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4264), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4264) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4266), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4267) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4268), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4268) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4276), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4277) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4279), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4281), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4281) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4283), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4283) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4284), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4285) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4286), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4286) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4289), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4289) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4291), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4291) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4292), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4292) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4294), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4295) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4296), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4296) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4297), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4297) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4299), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4299) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4300), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4303), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4303) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4304), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4304) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4306), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4306) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4307), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4307) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4308), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4308) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4310), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4311), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4311) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4312), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4313) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 234, DateTimeKind.Utc).AddTicks(3155), new DateTime(2026, 7, 3, 20, 57, 18, 234, DateTimeKind.Utc).AddTicks(3155) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "4df72fa1-9290-449a-bc42-0754bc1ca637");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "155c8811-b525-4506-9bb5-db9a1c4f7ebc");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 247, DateTimeKind.Utc).AddTicks(4915), new DateTime(2026, 7, 3, 20, 57, 18, 247, DateTimeKind.Utc).AddTicks(4917) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(4554), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(4556) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5025), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5026) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5028), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5029) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5031), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5032) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5041), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5041) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5057), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5057) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5058), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5058) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5075), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5075) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5076), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5076) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5043), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5043) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5044), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5044) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5045), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5046) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5047), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5047) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5049), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5049) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5050), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5051), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5051) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5054), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5054) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5056), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5056) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5072), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5072) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5073), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5074) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 249, DateTimeKind.Utc).AddTicks(748), new DateTime(2026, 7, 3, 20, 57, 18, 249, DateTimeKind.Utc).AddTicks(749) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 249, DateTimeKind.Utc).AddTicks(950), new DateTime(2026, 7, 3, 20, 57, 18, 249, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 249, DateTimeKind.Utc).AddTicks(953), new DateTime(2026, 7, 3, 20, 57, 18, 249, DateTimeKind.Utc).AddTicks(953) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 225, DateTimeKind.Utc).AddTicks(6832), new DateTime(2026, 7, 3, 20, 57, 18, 225, DateTimeKind.Utc).AddTicks(6834) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d6f8b6b-6328-4087-952c-11fdd69ff001", new DateTime(2026, 7, 3, 20, 57, 18, 187, DateTimeKind.Utc).AddTicks(2899), new DateTime(2026, 7, 3, 20, 57, 18, 187, DateTimeKind.Utc).AddTicks(2902), "AQAAAAIAAYagAAAAEJhkT3eGOeMjYIaTDTSDFR/LhlsAbyNlPcOHyetSo+LupPoTP2Ay+H62S8NbYe5+TQ==", "a1deda5d-ab57-4cf9-86f2-43b1fd07ddd0" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 231, DateTimeKind.Utc).AddTicks(4121), new DateTime(2026, 7, 3, 20, 57, 18, 231, DateTimeKind.Utc).AddTicks(4242), new Guid("0bdb7627-3f8b-4150-9513-289bf153c75c") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(7042), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(7043) });
        }
    }
}
