using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.MSSQL.Migrations
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
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TrackingToken",
                table: "saleschannel",
                type: "nvarchar(max)",
                maxLength: 4096,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrackingTokenHash",
                table: "saleschannel",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

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
                columns: new[] { "DateCreated", "DateModified", "TrackingEnabled", "TrackingToken", "TrackingTokenHash" },
                values: new object[] { new DateTime(2026, 6, 19, 16, 5, 7, 812, DateTimeKind.Utc).AddTicks(7820), new DateTime(2026, 6, 19, 16, 5, 7, 812, DateTimeKind.Utc).AddTicks(7820), false, null, null });

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
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(5960), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(5960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6480), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6490), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6490), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6490), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6500), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6500), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6500), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6500), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6510), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6510), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6510), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6520), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6520), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6520), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6530), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6530), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6530), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6530), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6540), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6540), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6540), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6550), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6550), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6550), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6550), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6560), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6560) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6560), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6560) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6560), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6560) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6570), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6570), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6570), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6580), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6580) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6580), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6580) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6580), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6580) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6580), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6580) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6590), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6590), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6590), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6600), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6600), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6600), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6600), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6610), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6610), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6610), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6620), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6620), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6620), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6630), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6630), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6630), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6630), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6640), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6640) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6640), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6640) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6640), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6640) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6650), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6650), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6650), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6650), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6660), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6660), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6660), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6670), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6670), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6670), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6680), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6680) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6680), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6680) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6680), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6680) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6680), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6680) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6690), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6690) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6690), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6690) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6690), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6690) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6700), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6700), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6700), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6700), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6750), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6750), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6750), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6760), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6760), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6760), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6760), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6770), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6770), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6770), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6780), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6780), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6780), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6790), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6790), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6790), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6790), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6800), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6800), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6800), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6810), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6810), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6810), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6810), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6820), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6820), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6820), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6830), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6830), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6830), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6840), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6840), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6840), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6840), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6850), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6850), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6850), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6860), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6860), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6860), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6860), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6870), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6870), new DateTime(2026, 6, 18, 19, 11, 40, 262, DateTimeKind.Utc).AddTicks(6870) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 263, DateTimeKind.Utc).AddTicks(7750), new DateTime(2026, 6, 18, 19, 11, 40, 263, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "e26e4d60-cafd-4e44-b1e5-2e43fbcab9b3");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "1b39ed50-fb47-4bcd-ae61-f6276af31cf9");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 274, DateTimeKind.Utc).AddTicks(470), new DateTime(2026, 6, 18, 19, 11, 40, 274, DateTimeKind.Utc).AddTicks(470) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5200), new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5200) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5430), new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5440), new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5440), new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5440), new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5440), new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5480), new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5480) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5490), new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5490) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5490), new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5490) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5500), new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5500) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5450), new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5450), new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5460), new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5470), new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5470), new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5470), new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5470), new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5480), new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5480) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5480), new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5480) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5490), new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5490) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5490), new DateTime(2026, 6, 18, 19, 11, 40, 286, DateTimeKind.Utc).AddTicks(5490) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 275, DateTimeKind.Utc).AddTicks(5510), new DateTime(2026, 6, 18, 19, 11, 40, 275, DateTimeKind.Utc).AddTicks(5510) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 275, DateTimeKind.Utc).AddTicks(5650), new DateTime(2026, 6, 18, 19, 11, 40, 275, DateTimeKind.Utc).AddTicks(5650) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 275, DateTimeKind.Utc).AddTicks(5650), new DateTime(2026, 6, 18, 19, 11, 40, 275, DateTimeKind.Utc).AddTicks(5650) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 255, DateTimeKind.Utc).AddTicks(6270), new DateTime(2026, 6, 18, 19, 11, 40, 255, DateTimeKind.Utc).AddTicks(6270) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9821bbdb-f6e2-4d2e-b0ac-938a29e75e69", new DateTime(2026, 6, 18, 19, 11, 40, 217, DateTimeKind.Utc).AddTicks(6990), new DateTime(2026, 6, 18, 19, 11, 40, 217, DateTimeKind.Utc).AddTicks(7000), "AQAAAAIAAYagAAAAEJkSj5zBvtaIaqqIhcR8b+3ePLjoS8AkAoSQtYiBLy7vRlIqOzI4SXmtVC5lcLPPgw==", "bd886513-7b90-4cc9-a8fa-28450d78c500" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 259, DateTimeKind.Utc).AddTicks(9430), new DateTime(2026, 6, 18, 19, 11, 40, 259, DateTimeKind.Utc).AddTicks(9530), new Guid("eb2277c6-daa6-43b3-9cb4-a5b7ed5c97a1") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 11, 40, 263, DateTimeKind.Utc).AddTicks(110), new DateTime(2026, 6, 18, 19, 11, 40, 263, DateTimeKind.Utc).AddTicks(110) });
        }
    }
}
