using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asToolkit.Persistence.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddSalesChannelTrackingKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TrackingEnabled",
                table: "saleschannel",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TrackingToken",
                table: "saleschannel",
                type: "character varying(4096)",
                maxLength: 4096,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrackingTokenHash",
                table: "saleschannel",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true);

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
                columns: new[] { "DateCreated", "DateModified", "TrackingEnabled", "TrackingToken", "TrackingTokenHash" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 26, 481, DateTimeKind.Utc).AddTicks(2770), new DateTime(2026, 6, 19, 16, 5, 26, 481, DateTimeKind.Utc).AddTicks(2770), false, null, null });

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
                name: "IX_saleschannel_TrackingTokenHash",
                table: "saleschannel",
                column: "TrackingTokenHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_saleschannel_TrackingTokenHash",
                table: "saleschannel");

            migrationBuilder.DropColumn(
                name: "TrackingEnabled",
                table: "saleschannel");

            migrationBuilder.DropColumn(
                name: "TrackingToken",
                table: "saleschannel");

            migrationBuilder.DropColumn(
                name: "TrackingTokenHash",
                table: "saleschannel");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(2660), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(2660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3070), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3080), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3080), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3080), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3090), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3090), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3090), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3100), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3100), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3100), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3100), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3110), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3110), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3110), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3120), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3120), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3120), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3120), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3130), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3130), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3130), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3140), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3140), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3140), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3140), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3150), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3150), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3150), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3160), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3160), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3160), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3160), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3170), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3170), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3170), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3180), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3180), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3180), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3180), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3190), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3190), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3190), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3200), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3200), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3200), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3230), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3230), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3230), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3230), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3240), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3240), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3240), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3250), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3250), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3250), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3250), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3260), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3260), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3260), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3270), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3270), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3270), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3270), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3280), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3280), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3280), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3290), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3290), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3290), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3290), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3300), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3300), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3300), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3310), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3310), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3310), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3310), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3320), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3320), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3320), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3330), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3330), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3330), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3330), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3340), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3340), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3340), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3350), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3350), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3350), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3360), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3360), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3360), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3360), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3370), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3370), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3370), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3380), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3380), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3380), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3380), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3390), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3390), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3390), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3400), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3400), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3400), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3400), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3410), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3410), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3410), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3420), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3420), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3420), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3420), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3430), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3430), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3430), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3440), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(3440) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 971, DateTimeKind.Utc).AddTicks(210), new DateTime(2026, 6, 18, 19, 12, 0, 971, DateTimeKind.Utc).AddTicks(210) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "11c2a846-fcb1-428f-a0a5-f89c03e99c25");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "8da2f087-6efa-4e48-aa08-7c6dbc0b20a1");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 979, DateTimeKind.Utc).AddTicks(3120), new DateTime(2026, 6, 18, 19, 12, 0, 979, DateTimeKind.Utc).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6520), new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6520) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6700), new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6710) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6710), new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6710) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6710), new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6710) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6710), new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6710) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6720), new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6720) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6740), new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6740) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6750), new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6750) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6760), new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6760) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6760), new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6760) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6720), new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6720) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6720), new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6720) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6730), new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6730) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6730), new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6730) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6730), new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6730) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6730), new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6730) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6740), new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6740) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6740), new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6740) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6740), new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6740) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6750), new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6750) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6750), new DateTime(2026, 6, 18, 19, 12, 0, 989, DateTimeKind.Utc).AddTicks(6750) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 980, DateTimeKind.Utc).AddTicks(2870), new DateTime(2026, 6, 18, 19, 12, 0, 980, DateTimeKind.Utc).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 980, DateTimeKind.Utc).AddTicks(3010), new DateTime(2026, 6, 18, 19, 12, 0, 980, DateTimeKind.Utc).AddTicks(3010) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 980, DateTimeKind.Utc).AddTicks(3010), new DateTime(2026, 6, 18, 19, 12, 0, 980, DateTimeKind.Utc).AddTicks(3010) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 964, DateTimeKind.Utc).AddTicks(6870), new DateTime(2026, 6, 18, 19, 12, 0, 964, DateTimeKind.Utc).AddTicks(6870) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b51d9b8b-c50a-405f-98b4-6cc0e51303f7", new DateTime(2026, 6, 18, 19, 12, 0, 931, DateTimeKind.Utc).AddTicks(1730), new DateTime(2026, 6, 18, 19, 12, 0, 931, DateTimeKind.Utc).AddTicks(1730), "AQAAAAIAAYagAAAAEOpXUn4dzxvUsfhK0NGNqSrJc67OLvcS67O4fnHaizsl88e/na2fDxHw+qA/ePm9gw==", "a700044f-d786-4967-a123-9e26c5d523e6" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 967, DateTimeKind.Utc).AddTicks(9640), new DateTime(2026, 6, 18, 19, 12, 0, 967, DateTimeKind.Utc).AddTicks(9740), new Guid("2f55ae0f-d16c-4d6f-a0d2-26b9d8f2847e") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(5240), new DateTime(2026, 6, 18, 19, 12, 0, 970, DateTimeKind.Utc).AddTicks(5240) });
        }
    }
}
