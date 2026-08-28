using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddSalesHistoryLocalizedMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MessageArgs",
                table: "sales_history",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageKey",
                table: "sales_history",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(8371), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(8378) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9204), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9204) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9206), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9207) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9209), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9209) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9216), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9216) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9218), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9218) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9221), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9221) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9222), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9222) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9224), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9224) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9225), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9226) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9227), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9227) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9240), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9243), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9244) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9245), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9245) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9247), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9259) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9260), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9262), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9262) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9263), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9264) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9265), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9265) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9266), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9267) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9269), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9269) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9271), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9271) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9272), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9272) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9274), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9274) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9275), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9276) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9279), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9279) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9281), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9281) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9289), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9292), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9293) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9303), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9303) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9308), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9308) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9309), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9311), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9311) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9313), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9313) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9314), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9315) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9316), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9316) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9319), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9319) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9320), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9322), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9322) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9323), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9323) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9325), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9325) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9326), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9326) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9328), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9328) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9336), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9337) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9340), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9341), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9342) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9343), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9343) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9345), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9345) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9346), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9346) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9348), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9348) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9350), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9351), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9351) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9354), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9354) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9356), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9356) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9358), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9358) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9360), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9361), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9361) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9363), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9363) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9364), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9364) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9372), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9373) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9376), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9376) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9377), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9378) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9379), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9379) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9381), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9381) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9382), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9382) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9384), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9384) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9385), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9385) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9387), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9387) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9389), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9391), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9391) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9392), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9393) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9394), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9394) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9395), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9396) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9397), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9397) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9398), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9399) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9400), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9410), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9412), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9412) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9413), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9414) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9416), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9416) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9417), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9418) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9419), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9419) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9421), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9421) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9422), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9422) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9425), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9425) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9426), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9427) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9428), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9428) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9429), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9431), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9431) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9432), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9433) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9434), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9434) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9435), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9436) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9445), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9445) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9447), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9447) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9452), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9452) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9453), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9454) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9455), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9455) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9456), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9457) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9458), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9458) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9460), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9462), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9463) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9464), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9464) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9465), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9466) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9468), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9468) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9469), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9471), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9471) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9472), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9473) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9474), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9474) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9483), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9484) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9486), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9486) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9487), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9487) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9489), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9489) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9490), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9491) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9492), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9492) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9493), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9494) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9495), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9495) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9498), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9498) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9499), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9501), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9501) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9502), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9503) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9504), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9504) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9505), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9506) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9507), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9507) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9508), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9508) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9518), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9518) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9520), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9521), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9522) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9525), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9526) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9527), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9527) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9528), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9529) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9530), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9531), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9532) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9534), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9534) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9536), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9536) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9537), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9537) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9539), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9539) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9540), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9542), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9542) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9543), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9543) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9545), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9545) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9554), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9554) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9556), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9556) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9558), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9558) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9559), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9560) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9561), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9561) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9562), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9563) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9564), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9564) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9565), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9566) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9568), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9569) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9570), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9572), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9572) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9573), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9573) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9575), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9575) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9576), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9576) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9578), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9578) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9579), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9579) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9588), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9589) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9590), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9592), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9592) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9593), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9593) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9595), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9595) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9596), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9597) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9598), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9598) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9599), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9602), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9602) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9603), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9604) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9605), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9605) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9607), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9607) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9608), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9608) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9609), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9611), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9611) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9612), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9613) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9622), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9623) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9625), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9625) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9626), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9627) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9628), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9628) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9629), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9631), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9631) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9633), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9633) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9634), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9634) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9637), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9637) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9638), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9638) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9640), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9640) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9641), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9641) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9643), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9643) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9644), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9644) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9646), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9646) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9653), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9653) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9664), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9664) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9666), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9666) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9667), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9668) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9669), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9669) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9671), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9671) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9672), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9672) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9674), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9674) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9675), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9675) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9678), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9678) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9681), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9681) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9682), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9682) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9684), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9684) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9685), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9685) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9687), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9687) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9688), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9689) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9690), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9690) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9700), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9702), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9702) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9703), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9703) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9705), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9705) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9706), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9707) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9708), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9708) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9710), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9710) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9711), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9711) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9714), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9714) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9716), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9716) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9717), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9717) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9719), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9719) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9720), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9722), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9722) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9723), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9723) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9725), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9725) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9734), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9734) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9737), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9737) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9738), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9739) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9740), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9742), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9742) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9743), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9743) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9745), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9745) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9746), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9746) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9749), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9749) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9750), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9752), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9752) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9753), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9753) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9755), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9755) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9756), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9756) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9758), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9758) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9759), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9759) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9768), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9769) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9770), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9771) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9772), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9772) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9774), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9774) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9775), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9776) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9777), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9777) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9778), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9779) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9780), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9783), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9784) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9785), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9785) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9787), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9787) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9788), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9788) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9789), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9790) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 664, DateTimeKind.Utc).AddTicks(499), new DateTime(2026, 8, 28, 11, 40, 21, 664, DateTimeKind.Utc).AddTicks(500) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "bf86e4bc-702c-4950-937e-32363dbbbe57");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "cf6a1e64-a706-4a6c-a614-20fbefe9bcb9");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 685, DateTimeKind.Utc).AddTicks(548), new DateTime(2026, 8, 28, 11, 40, 21, 685, DateTimeKind.Utc).AddTicks(554) });

            migrationBuilder.UpdateData(
                table: "saleschannel_sync_state",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 689, DateTimeKind.Utc).AddTicks(4625), new DateTime(2026, 8, 28, 11, 40, 21, 689, DateTimeKind.Utc).AddTicks(4629) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(851), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(854) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2060), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2060) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2064), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2064) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2065), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2066) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2067), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2067) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2328), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2328) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2330), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2330) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2337), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2337) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2338), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2339) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2069), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2069) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2070), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2070) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2072), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2072) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2077), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2077) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2319), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2319) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2321), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2322) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2323), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2323) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2325), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2325) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2326), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2327) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2334), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2334) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2335), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2335) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 694, DateTimeKind.Utc).AddTicks(2108), new DateTime(2026, 8, 28, 11, 40, 21, 694, DateTimeKind.Utc).AddTicks(2111) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 694, DateTimeKind.Utc).AddTicks(2459), new DateTime(2026, 8, 28, 11, 40, 21, 694, DateTimeKind.Utc).AddTicks(2459) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 694, DateTimeKind.Utc).AddTicks(2462), new DateTime(2026, 8, 28, 11, 40, 21, 694, DateTimeKind.Utc).AddTicks(2463) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 662, DateTimeKind.Utc).AddTicks(7977), new DateTime(2026, 8, 28, 11, 40, 21, 662, DateTimeKind.Utc).AddTicks(7978) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageArgs",
                table: "sales_history");

            migrationBuilder.DropColumn(
                name: "MessageKey",
                table: "sales_history");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(557), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(577) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1389), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1389) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1391), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1392) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1397), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1397) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1412), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1413) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1414), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1414) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1416), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1416) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1417), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1417) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1419), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1419) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1420), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1421) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1422), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1422) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1429), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1429) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1432), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1432) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1433), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1434) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1435), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1435) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1436), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1437) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1449), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1449) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1450), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1451) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1452), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1452) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1454), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1454) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1457), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1457) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1461), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1461) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1463), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1463) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1464), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1464) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1466), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1466) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1467), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1468) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1469), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1469) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1470), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1471) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1473), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1474) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1494), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1494) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1501), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1501) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1503), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1503) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1514), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1514) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1515), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1516) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1517), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1517) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1519), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1519) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1521), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1522) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1523), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1523) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1525), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1525) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1526), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1526) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1528), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1528) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1529), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1529) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1531), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1531) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1532), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1532) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1535), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1535) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1540), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1542), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1542) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1544), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1544) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1586), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1586) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1588), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1588) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1590), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1591), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1592) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1594), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1594) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1596), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1596) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1597), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1597) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1599), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1599) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1600), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1602), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1602) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1603), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1603) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1605), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1605) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1607), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1608) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1609), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1609) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1610), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1612), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1612) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1620), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1622), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1622) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1623), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1624) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1625), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1625) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1628), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1628) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1629), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1629) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1631), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1631) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1632), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1633) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1634), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1634) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1635), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1636) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1637), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1637) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1638), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1639) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1641), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1641) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1642), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1643) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1644), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1644) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1645), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1646) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1653), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1655), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1655) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1656), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1657) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1658), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1658) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1661), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1661) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1662), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1663) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1664), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1664) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1665), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1666) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1667), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1667) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1668), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1669) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1670), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1671), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1672) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1674), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1674) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1676), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1676) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1678), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1679) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1680), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1680) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1688), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1688) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1690), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1690) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1691), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1691) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1693), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1693) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1695), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1696) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1697), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1697) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1698), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1699) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1700), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1702), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1702) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1703), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1703) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1705), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1705) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1706), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1706) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1709), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1709) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1710), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1711) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1712), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1712) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1713), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1714) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1721), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1721) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1723), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1723) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1725), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1725) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1726), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1726) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1729), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1729) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1730), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1731) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1732), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1732) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1733), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1734) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1735), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1735) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1736), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1737) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1738), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1738) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1739), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1742), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1742) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1744), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1744) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1745), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1745) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1747), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1747) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1755), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1755) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1757), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1757) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1758), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1759) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1760), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1763), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1763) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1764), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1764) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1766), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1766) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1767), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1767) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1769), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1769) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1770), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1772), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1772) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1773), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1773) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1776), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1776) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1784), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1784) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1785), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1786) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1787), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1788) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1795), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1795) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1797), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1798) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1799), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1799) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1801), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1801) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1803), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1803) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1805), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1805) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1806), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1807) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1808), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1808) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1809), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1811), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1811) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1812), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1813) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1814), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1814) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1817), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1817) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1818), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1819) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1820), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1821), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1822) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1829), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1829) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1831), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1831) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1833), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1833) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1834), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1835) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1838), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1838) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1840), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1841), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1841) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1843), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1843) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1844), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1844) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1846), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1846) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1847), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1847) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1849), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1849) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1852), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1852) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1853), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1853) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1855), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1855) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1856), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1857) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1864), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1864) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1866), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1866) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1867), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1869), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1869) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1872), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1872) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1873), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1873) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1875), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1876), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1876) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1878), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1878) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1879), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1881), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1881) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1882), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1883) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1886), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1887) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1888), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1888) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1889), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1891), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1892) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1899), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1901), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1902) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1903), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1903) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1904), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1905) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1907), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1907) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1909), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1909) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1910), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1912), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1912) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1913), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1913) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1915), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1915) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1916), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1916) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1918), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1918) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1920), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1921) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1922), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1922) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1923), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1924) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1925), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1925) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1933), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1933) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1935), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1935) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1936), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1937) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1938), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1938) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1942), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1942) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1944), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1944) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1945), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1946) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1947), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1947) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1948), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1949) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1950), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1951), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1952) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1953), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1953) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1956), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1956) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1957), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1957) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1959), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1959) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1960), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1968), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1968) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1970), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1972), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1972) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1973), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1974) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1976), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1976) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1978), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1978) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1979), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1981), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1981) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1982), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1983) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1984), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1984) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1990), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1991) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1992), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1992) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1995), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1995) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1996), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1996) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1998), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1998) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1999), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(1999) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2001), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2001) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2002), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2002) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2004), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2004) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2005), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2005) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2008), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2008) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2009), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2009) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2011), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2011) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2012), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2012) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2013), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(2014) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 624, DateTimeKind.Utc).AddTicks(5657), new DateTime(2026, 8, 27, 14, 20, 23, 624, DateTimeKind.Utc).AddTicks(5657) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "4e8e5864-bc4c-4301-916d-6e4cf764eb40");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "2a85b8b3-b786-4927-a86d-e7793c53b436");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 636, DateTimeKind.Utc).AddTicks(7523), new DateTime(2026, 8, 27, 14, 20, 23, 636, DateTimeKind.Utc).AddTicks(7527) });

            migrationBuilder.UpdateData(
                table: "saleschannel_sync_state",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 639, DateTimeKind.Utc).AddTicks(1838), new DateTime(2026, 8, 27, 14, 20, 23, 639, DateTimeKind.Utc).AddTicks(1840) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5155), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5159) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5671), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5671) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5673), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5673) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5675), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5675) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5683), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5684) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5829), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5829) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5830), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5831) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5835), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5835) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5836), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5836) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5685), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5686) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5687), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5687) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5688), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5688) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5690), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5690) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5819), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5819) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5821), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5821) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5822), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5822) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5826), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5826) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5827), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5828) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5832), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5832) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5833), new DateTime(2026, 8, 27, 14, 20, 23, 669, DateTimeKind.Utc).AddTicks(5833) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 641, DateTimeKind.Utc).AddTicks(8621), new DateTime(2026, 8, 27, 14, 20, 23, 641, DateTimeKind.Utc).AddTicks(8622) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 641, DateTimeKind.Utc).AddTicks(8840), new DateTime(2026, 8, 27, 14, 20, 23, 641, DateTimeKind.Utc).AddTicks(8841) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 641, DateTimeKind.Utc).AddTicks(8843), new DateTime(2026, 8, 27, 14, 20, 23, 641, DateTimeKind.Utc).AddTicks(8843) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(8684), new DateTime(2026, 8, 27, 14, 20, 23, 623, DateTimeKind.Utc).AddTicks(8690) });
        }
    }
}
