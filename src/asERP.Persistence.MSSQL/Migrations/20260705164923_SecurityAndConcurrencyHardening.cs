using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class SecurityAndConcurrencyHardening : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SmtpPassword",
                table: "tenant_email_settings",
                type: "nvarchar(max)",
                maxLength: 4096,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "M365ClientSecret",
                table: "tenant_email_settings",
                type: "nvarchar(max)",
                maxLength: 4096,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConcurrencyToken",
                table: "shipping",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ConcurrencyToken",
                table: "saleschannel",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ConcurrencyToken",
                table: "sales",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ConcurrencyToken",
                table: "product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "country",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(7250), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(7254) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9191), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9192) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9198), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9198) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9201), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9201) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9204), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9205) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9207), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9207) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9210), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9213), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9213) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9216), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9216) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9221), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9222) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9224), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9225) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "CountryCode", "DateCreated", "DateModified" },
                values: new object[] { "AQ", new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9227), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9227) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9230), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9232), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9233) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9235), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9235) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9272), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9272) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9293), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9293) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9299), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9299) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9302), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9302) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9304), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9304) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9307), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9307) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9309), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9312), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9313) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9315), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9315) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9327), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9327) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "CountryCode", "DateCreated", "DateModified" },
                values: new object[] { "CC", new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9336), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9337) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9339), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9339) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9342), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9342) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9345), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9345) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9347), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9347) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9350), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9353), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9353) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9368), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9368) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9372), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9373) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9375), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9376) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9378), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9378) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9380), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9381) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9383), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9383) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9386), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9386) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9388), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9389) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9391), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9392) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9396), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9396) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9399), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9399) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9401), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9402) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9404), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9404) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9407), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9407) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9409), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9412), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9412) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9427), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9427) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9432), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9432) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9434), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9435) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9437), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9437) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9440), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9442), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9442) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9445), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9445) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9447), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9448) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9450), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9455), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9455) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9458), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9458) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9461), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9461) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9463), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9464) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9466), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9466) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9468), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9469) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9471), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9472) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9486), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9487) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9491), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9491) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9494), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9494) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9496), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9497) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9499), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9502), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9502) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9504), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9505) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9507), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9507) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9510), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9515), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9515) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9518), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9518) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9520), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9521) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9523), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9523) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9525), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9526) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9528), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9528) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9531), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9531) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9545), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9545) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9550), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9552), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9553) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9555), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9555) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9557), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9558) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9560), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9561) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9563), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9563) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9565), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9566) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9568), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9568) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9573), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9573) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9575), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9576) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9578), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9578) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9580), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9581) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9583), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9583) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9586), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9586) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9588), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9589) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9603), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9603) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9607), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9608) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9610), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9612), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9613) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9615), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9615) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9618), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9618) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9620), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9621) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9623), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9623) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9625), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9626) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9630), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9633), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9633) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9635), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9636) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9648), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9649) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9651), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9651) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9654), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9654) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9656), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9657) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9659), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9659) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9663), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9664) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9666), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9666) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9669), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9669) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9671), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9671) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9673), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9674) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9676), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9676) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9678), new DateTime(2026, 7, 5, 16, 49, 21, 665, DateTimeKind.Utc).AddTicks(9679) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 668, DateTimeKind.Utc).AddTicks(5330), new DateTime(2026, 7, 5, 16, 49, 21, 668, DateTimeKind.Utc).AddTicks(5331) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "0a72ce9a-f874-43b0-8055-c96ee6534bac");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "3a6e3993-80f3-40b2-9cd3-7dc61f605ea0");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "ConcurrencyToken", "DateCreated", "DateModified" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2026, 7, 5, 16, 49, 21, 694, DateTimeKind.Utc).AddTicks(7805), new DateTime(2026, 7, 5, 16, 49, 21, 694, DateTimeKind.Utc).AddTicks(7806) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(4836), new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(4839) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(5990), new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(5991) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6010), new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6010) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6014), new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6014) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6018), new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6019) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6548), new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6549) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6552), new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6552) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6565), new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6565) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6568), new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6569) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6021), new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6022) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6025), new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6025) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6028), new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6029) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified", "IsEncrypted" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6032), new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6032), true });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6524), new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6525) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6534), new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6535) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6538), new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6539) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified", "IsEncrypted" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6541), new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6542), true });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6545), new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6546) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6555), new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6556) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6558), new DateTime(2026, 7, 5, 16, 49, 21, 760, DateTimeKind.Utc).AddTicks(6559) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 698, DateTimeKind.Utc).AddTicks(3042), new DateTime(2026, 7, 5, 16, 49, 21, 698, DateTimeKind.Utc).AddTicks(3043) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 698, DateTimeKind.Utc).AddTicks(3497), new DateTime(2026, 7, 5, 16, 49, 21, 698, DateTimeKind.Utc).AddTicks(3498) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 698, DateTimeKind.Utc).AddTicks(3502), new DateTime(2026, 7, 5, 16, 49, 21, 698, DateTimeKind.Utc).AddTicks(3503) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 648, DateTimeKind.Utc).AddTicks(4032), new DateTime(2026, 7, 5, 16, 49, 21, 648, DateTimeKind.Utc).AddTicks(4036) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a370ebe-6f80-421f-b90a-18f7e37b118e", new DateTime(2026, 7, 5, 16, 49, 21, 565, DateTimeKind.Utc).AddTicks(169), new DateTime(2026, 7, 5, 16, 49, 21, 565, DateTimeKind.Utc).AddTicks(174), "AQAAAAIAAYagAAAAEDWk1SKZwH7fF80dZCI4S0bnWgddkoDmqnuTPvykfLVcNlo+Mw3y2/+7OlCL1u/eMQ==", "e1ccd3ee-2f13-43d3-b173-b635fbffe061" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("77777777-7777-7777-7777-777777777701") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 21, 666, DateTimeKind.Utc).AddTicks(9610), new DateTime(2026, 7, 5, 16, 49, 21, 666, DateTimeKind.Utc).AddTicks(9611) });

            migrationBuilder.CreateIndex(
                name: "IX_user_tenant_Id",
                table: "user_tenant",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_stock_movement_TenantId",
                table: "stock_movement",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_saleschannel_TenantId",
                table: "saleschannel",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_item_TenantId",
                table: "sales_item",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_history_TenantId",
                table: "sales_history",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_item_TenantId",
                table: "invoice_item",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_TenantId",
                table: "invoice",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_goods_receipt_TenantId",
                table: "goods_receipt",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_country_CountryCode_TenantId",
                table: "country",
                columns: new[] { "CountryCode", "TenantId" },
                unique: true,
                filter: "[TenantId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_tenant_Id",
                table: "user_tenant");

            migrationBuilder.DropIndex(
                name: "IX_stock_movement_TenantId",
                table: "stock_movement");

            migrationBuilder.DropIndex(
                name: "IX_saleschannel_TenantId",
                table: "saleschannel");

            migrationBuilder.DropIndex(
                name: "IX_sales_item_TenantId",
                table: "sales_item");

            migrationBuilder.DropIndex(
                name: "IX_sales_history_TenantId",
                table: "sales_history");

            migrationBuilder.DropIndex(
                name: "IX_invoice_item_TenantId",
                table: "invoice_item");

            migrationBuilder.DropIndex(
                name: "IX_invoice_TenantId",
                table: "invoice");

            migrationBuilder.DropIndex(
                name: "IX_goods_receipt_TenantId",
                table: "goods_receipt");

            migrationBuilder.DropIndex(
                name: "IX_country_CountryCode_TenantId",
                table: "country");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "shipping");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "saleschannel");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "sales");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "product");

            migrationBuilder.AlterColumn<string>(
                name: "SmtpPassword",
                table: "tenant_email_settings",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 4096,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "M365ClientSecret",
                table: "tenant_email_settings",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 4096,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "country",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(4660), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(4662) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5749), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5749) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5753), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5754) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5763), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5763) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5765), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5766) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5768), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5768) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5770), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5785), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5786) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5788), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5789) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5791), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5791) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5793), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5793) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "CountryCode", "DateCreated", "DateModified" },
                values: new object[] { "AT", new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5797), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5798) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5800), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5802), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5802) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5804), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5804) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5806), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5806) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5808), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5808) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5810), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5812), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5812) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5816), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5816) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5818), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5818) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5821), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5821) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5823), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5823) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5835), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5836) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5838), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5839) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "CountryCode", "DateCreated", "DateModified" },
                values: new object[] { "CH", new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5840), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5841) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5858), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5858) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5865), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5866) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5868), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5868) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5870), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5872), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5872) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5874), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5874) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5876), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5876) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5878), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5878) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5880), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5884), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5884) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5886), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5886) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5888), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5888) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5890), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5902), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5903) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5906), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5907) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5909), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5909) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5911), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5912) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5916), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5916) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5918), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5918) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5920), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5922), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5922) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5924), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5924) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5926), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5927) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5928), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5929) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5930), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5931) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5934), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5935) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5936), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5937) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5938), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5939) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5940), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5941) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5953), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5954) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5958), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5958) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5961), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5961) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5963), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5963) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5967), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5967) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5969), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5969) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5971), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5972) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5973), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5974) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5976), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5976) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5978), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5978) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5980), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5982), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5982) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5986), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5986) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5988), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5988) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5990), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5992), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5993) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6004), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6005) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6008), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6008) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6023), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6023) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6025), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6025) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6029), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6029) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6031), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6031) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6033), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6033) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6035), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6035) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6037), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6038) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6040), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6041), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6042) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6043), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6044) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6047), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6048) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6049), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6051), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6052) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6053), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6054) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6065), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6066) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6068), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6069) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6071), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6071) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6073), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6073) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6077), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6077) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6079), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6079) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6081), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6082) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6084), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6084) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6086), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6086) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6088), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6088) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6090), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6092), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6092) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6096), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6096) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6098), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6098) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6100), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6102), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6102) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6114), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6115) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6118), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6119) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6120), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6121) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6123), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6123) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6127), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6127) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6129), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6132), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6132) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6134), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6134) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6136), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6137) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6139), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6139) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6141), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6141) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6143), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6143) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6147), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6147) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6149), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6149) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6151), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6152) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6153), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6154) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6155), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6156) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 325, DateTimeKind.Utc).AddTicks(2917), new DateTime(2026, 7, 5, 15, 6, 10, 325, DateTimeKind.Utc).AddTicks(2919) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "e0234318-68d6-49ff-83cb-c6b9e5089418");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "a2066c86-8e0e-423b-a213-e0779558c78c");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 343, DateTimeKind.Utc).AddTicks(1046), new DateTime(2026, 7, 5, 15, 6, 10, 343, DateTimeKind.Utc).AddTicks(1049) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(6491), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(6495) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7301), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7302) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7307), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7307) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7309), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7310) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7312), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7312) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7355), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7355) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7357), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7358) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7366), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7366) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7368), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7368) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7314), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7314) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7316), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7317) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7318), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7319) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified", "IsEncrypted" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7324), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7325), false });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7344), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7345) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7346), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7347) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7349), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7349) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified", "IsEncrypted" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7351), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7351), false });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7353), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7353) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7361), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7362) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7364), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7364) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 345, DateTimeKind.Utc).AddTicks(5136), new DateTime(2026, 7, 5, 15, 6, 10, 345, DateTimeKind.Utc).AddTicks(5139) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 345, DateTimeKind.Utc).AddTicks(5435), new DateTime(2026, 7, 5, 15, 6, 10, 345, DateTimeKind.Utc).AddTicks(5435) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 345, DateTimeKind.Utc).AddTicks(5439), new DateTime(2026, 7, 5, 15, 6, 10, 345, DateTimeKind.Utc).AddTicks(5439) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 312, DateTimeKind.Utc).AddTicks(6632), new DateTime(2026, 7, 5, 15, 6, 10, 312, DateTimeKind.Utc).AddTicks(6637) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86ec02a9-906a-4f43-8568-59e9caa80ba0", new DateTime(2026, 7, 5, 15, 6, 10, 255, DateTimeKind.Utc).AddTicks(6491), new DateTime(2026, 7, 5, 15, 6, 10, 255, DateTimeKind.Utc).AddTicks(6495), "AQAAAAIAAYagAAAAEJdVzSxT8rI4RJt8F62DNwS10EZBnP2tRWPbMrl7/lLypkshrK7v3TQKALPO+fvjkA==", "ceb307d7-e0a2-4a55-9303-8dfaa9828ae6" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 320, DateTimeKind.Utc).AddTicks(6897), new DateTime(2026, 7, 5, 15, 6, 10, 320, DateTimeKind.Utc).AddTicks(7078), new Guid("08b68f00-4d8b-473b-9166-fcb74e453b7f") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 324, DateTimeKind.Utc).AddTicks(915), new DateTime(2026, 7, 5, 15, 6, 10, 324, DateTimeKind.Utc).AddTicks(916) });
        }
    }
}
