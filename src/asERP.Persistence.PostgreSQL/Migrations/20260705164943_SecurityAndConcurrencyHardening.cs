using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.PostgreSQL.Migrations
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
                type: "character varying(4096)",
                maxLength: 4096,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "M365ClientSecret",
                table: "tenant_email_settings",
                type: "character varying(4096)",
                maxLength: 4096,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConcurrencyToken",
                table: "shipping",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ConcurrencyToken",
                table: "saleschannel",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ConcurrencyToken",
                table: "sales",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ConcurrencyToken",
                table: "product",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(4327), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(4332) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6226), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6226) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6233), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6233) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6237), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6237) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6252), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6253) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6256), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6256) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6259), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6259) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6262), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6262) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6265), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6266) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6292), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6292) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6295), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6296) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "CountryCode", "DateCreated", "DateModified" },
                values: new object[] { "AQ", new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6298), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6299) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6305), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6305) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6308), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6308) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6311), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6311) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6314), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6314) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6317), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6317) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6319), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6322), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6323) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6325), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6326) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6331), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6332) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6334), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6335) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6337), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6337) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6340), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6364), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6364) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "CountryCode", "DateCreated", "DateModified" },
                values: new object[] { "CC", new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6395), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6396) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6398), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6399) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6401), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6402) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6407), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6407) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6410), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6413), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6413) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6416), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6416) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6419), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6419) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6421), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6422) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6424), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6425) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6427), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6427) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6432), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6433) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6435), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6436) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6438), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6438) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6441), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6441) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6444), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6444) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6461), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6461) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6464), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6464) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6467), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6467) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6472), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6472) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6475), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6475) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6478), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6478) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6481), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6481) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6483), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6484) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6488), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6488) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6490), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6491) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6493), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6494) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6499), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6499) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6501), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6502) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6504), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6505) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6508), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6508) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6511), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6512) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6530), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6531) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6533), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6534) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6536), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6537) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6541), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6542) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6544), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6545) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6547), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6548) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6550), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6552), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6553) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6555), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6556) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6558), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6558) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6561), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6561) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6566), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6567) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6569), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6572), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6572) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6575), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6575) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6578), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6578) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6594), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6595) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6599), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6599) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6630), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6635), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6635) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6638), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6638) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6641), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6641) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6644), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6644) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6647), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6647) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6650), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6653), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6653) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6655), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6656) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6661), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6661) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6664), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6664) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6667), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6667) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6670), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6672), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6673) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6691), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6691) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6694), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6694) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6697), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6697) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6702), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6702) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6705), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6705) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6708), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6708) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6710), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6711) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6713), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6714) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6716), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6716) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6721), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6721) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6724), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6724) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6729), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6729) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6732), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6732) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6734), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6735) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6737), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6738) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6740), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6741) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6758), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6758) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6761), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6761) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6763), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6764) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6769), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6769) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6772), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6772) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6775), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6775) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6777), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6778) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6780), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6781) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6783), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6784) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6786), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6786) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6789), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6789) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6794), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6795) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6797), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6797) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6800), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6803), new DateTime(2026, 7, 5, 16, 49, 41, 917, DateTimeKind.Utc).AddTicks(6803) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 920, DateTimeKind.Utc).AddTicks(1686), new DateTime(2026, 7, 5, 16, 49, 41, 920, DateTimeKind.Utc).AddTicks(1687) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "14014d03-9074-4c1c-bd13-4d7949c6c4fb");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "6a67536f-4289-4e85-b741-b6310f46b305");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "ConcurrencyToken", "DateCreated", "DateModified" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2026, 7, 5, 16, 49, 41, 950, DateTimeKind.Utc).AddTicks(5148), new DateTime(2026, 7, 5, 16, 49, 41, 950, DateTimeKind.Utc).AddTicks(5153) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(6920), new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(6924) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(7987), new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(7988) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8011), new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8011) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8015), new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8016) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8018), new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8019) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8522), new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8523) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8525), new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8526) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8537), new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8538) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8540), new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8541) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8021), new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8022) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8025), new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8025) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8028), new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8028) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified", "IsEncrypted" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8031), new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8031), true });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8499), new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8500) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8509), new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8509) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8512), new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8513) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified", "IsEncrypted" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8515), new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8516), true });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8519), new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8519) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8528), new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8529) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8531), new DateTime(2026, 7, 5, 16, 49, 42, 26, DateTimeKind.Utc).AddTicks(8532) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 955, DateTimeKind.Utc).AddTicks(3397), new DateTime(2026, 7, 5, 16, 49, 41, 955, DateTimeKind.Utc).AddTicks(3399) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 955, DateTimeKind.Utc).AddTicks(3993), new DateTime(2026, 7, 5, 16, 49, 41, 955, DateTimeKind.Utc).AddTicks(3994) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 955, DateTimeKind.Utc).AddTicks(3999), new DateTime(2026, 7, 5, 16, 49, 41, 955, DateTimeKind.Utc).AddTicks(4000) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 901, DateTimeKind.Utc).AddTicks(9733), new DateTime(2026, 7, 5, 16, 49, 41, 901, DateTimeKind.Utc).AddTicks(9737) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6c04570-5cb9-456d-b361-d024a5260937", new DateTime(2026, 7, 5, 16, 49, 41, 814, DateTimeKind.Utc).AddTicks(1145), new DateTime(2026, 7, 5, 16, 49, 41, 814, DateTimeKind.Utc).AddTicks(1150), "AQAAAAIAAYagAAAAELedKDZaLxynh6pSXbBgscIFyaUx2OWWEYwjT3XBLKAaiN3/Wdb8n5QC+T9TJIUzSQ==", "b9306290-c8b8-4d95-99c1-6065d90865ba" });

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
                values: new object[] { new DateTime(2026, 7, 5, 16, 49, 41, 918, DateTimeKind.Utc).AddTicks(6883), new DateTime(2026, 7, 5, 16, 49, 41, 918, DateTimeKind.Utc).AddTicks(6885) });

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
                unique: true);
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
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(4096)",
                oldMaxLength: 4096,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "M365ClientSecret",
                table: "tenant_email_settings",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(4096)",
                oldMaxLength: 4096,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 750, DateTimeKind.Utc).AddTicks(9150), new DateTime(2026, 7, 5, 15, 6, 48, 750, DateTimeKind.Utc).AddTicks(9154) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(23), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(23) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(27), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(27) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(30), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(30) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(33), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(34) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(47), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(47) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(49), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(49) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(51), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(51) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(53), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(53) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(55), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(55) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(57), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(57) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "CountryCode", "DateCreated", "DateModified" },
                values: new object[] { "AT", new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(59), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(59) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(61), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(61) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(65), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(65) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(67), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(67) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(68), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(69) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(91), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(91) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(105), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(105) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(108), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(108) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(110), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(112), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(112) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(115), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(116) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(117), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(118) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(119), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(121), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(121) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "CountryCode", "DateCreated", "DateModified" },
                values: new object[] { "CH", new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(123), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(123) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(149), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(149) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(154), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(155) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(156), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(157) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(160), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(162), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(162) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(164), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(164) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(166), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(166) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(177), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(178) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(180), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(182), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(182) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(184), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(184) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(188), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(188) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(190), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(192), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(192) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(194), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(194) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(195), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(196) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(197), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(198) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(199), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(199) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(201), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(201) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(204), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(205) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(207), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(207) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(208), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(209) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(210), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(211) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(220), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(221) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(224), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(224) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(226), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(226) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(228), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(228) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(231), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(232) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(233), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(234) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(235), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(236) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(237), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(237) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(239), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(239) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(241), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(241) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(243), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(243) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(245), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(245) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(248), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(249) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(250), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(252), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(252) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(254), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(254) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(265), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(266) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(270), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(272), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(272) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(274), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(274) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(278), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(278) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(280), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(281), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(282) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(283), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(284) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(285), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(285) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(287), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(287) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(289), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(289) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(291), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(291) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(295), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(295) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(297), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(297) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(299), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(299) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(301), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(301) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(311), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(312) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(315), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(316) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(318), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(318) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(320), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(324), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(324) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(325), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(326) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(327), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(328) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(329), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(331), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(332) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(334), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(335) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(336), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(337) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(338), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(339) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(342), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(342) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(344), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(344) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(346), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(346) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(348), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(348) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(359), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(359) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(362), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(362) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(364), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(364) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(366), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(366) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(369), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(372), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(372) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(374), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(374) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(376), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(376) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(378), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(379) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(380), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(381) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(382), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(383) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(384), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(385) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(388), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(388) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(394), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(395) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(397), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(397) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(399), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(399) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(400), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(401) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(402), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(403) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(404), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(405) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(406), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(406) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(410), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(412), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(412) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(414), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(414) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 752, DateTimeKind.Utc).AddTicks(4272), new DateTime(2026, 7, 5, 15, 6, 48, 752, DateTimeKind.Utc).AddTicks(4273) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "d3cd3c35-3592-4850-97b4-6945594b27c1");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "5a24e0ba-9898-40ca-ad69-73e05c6caf2c");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 768, DateTimeKind.Utc).AddTicks(6907), new DateTime(2026, 7, 5, 15, 6, 48, 768, DateTimeKind.Utc).AddTicks(6910) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9299), new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9303) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9746), new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9746) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9749), new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9750) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9752), new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9753) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9762), new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9762) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9782), new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9783) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9784), new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9785) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9790), new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9790) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9791), new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9792) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9764), new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9764) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9766), new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9766) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9768), new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9768) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified", "IsEncrypted" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9770), new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9770), false });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9772), new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9772) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9774), new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9774) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9775), new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9776) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified", "IsEncrypted" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9779), new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9779), false });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9781), new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9781) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9786), new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9786) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9788), new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9788) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 770, DateTimeKind.Utc).AddTicks(8460), new DateTime(2026, 7, 5, 15, 6, 48, 770, DateTimeKind.Utc).AddTicks(8462) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 770, DateTimeKind.Utc).AddTicks(8723), new DateTime(2026, 7, 5, 15, 6, 48, 770, DateTimeKind.Utc).AddTicks(8724) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 770, DateTimeKind.Utc).AddTicks(8735), new DateTime(2026, 7, 5, 15, 6, 48, 770, DateTimeKind.Utc).AddTicks(8736) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 741, DateTimeKind.Utc).AddTicks(2950), new DateTime(2026, 7, 5, 15, 6, 48, 741, DateTimeKind.Utc).AddTicks(2955) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "919e7e05-a037-43d2-b935-dd50292e46d7", new DateTime(2026, 7, 5, 15, 6, 48, 688, DateTimeKind.Utc).AddTicks(8308), new DateTime(2026, 7, 5, 15, 6, 48, 688, DateTimeKind.Utc).AddTicks(8313), "AQAAAAIAAYagAAAAEMBnV581MXcCsswhbDDwdYhzx6NCziNGadRaWdAfvGxkVBI4hJPrxPvbzg1rtE58+Q==", "a20f2e10-5293-467e-9332-b72c1307dcae" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 747, DateTimeKind.Utc).AddTicks(3815), new DateTime(2026, 7, 5, 15, 6, 48, 747, DateTimeKind.Utc).AddTicks(4118), new Guid("0a47d7ed-05d9-4261-8a17-8d89d7cc2997") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(5493), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(5494) });
        }
    }
}
