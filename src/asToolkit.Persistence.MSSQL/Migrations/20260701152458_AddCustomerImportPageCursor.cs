using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asToolkit.Persistence.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerImportPageCursor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerImportPageCursor",
                table: "saleschannel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(620), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1030), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1040), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1040), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1040), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1040), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1050), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1050), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1050), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1060), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1060), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1060), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1070), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1070), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1070), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1070), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1080), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1080), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1080), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1090), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1090), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1090), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1090), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1100), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1100), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1100), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1110), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1110), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1110), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1120), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1120), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1120), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1120), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1130), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1130), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1130), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1140), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1140), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1140), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1140), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1150), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1150), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1150), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1160), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1160), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1160), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1160), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1170), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1170), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1170), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1180), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1200), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1200), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1210), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1210), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1210), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1220), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1220), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1220), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1230), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1230), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1230), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1230), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1240), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1240), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1240), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1250), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1250), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1250), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1250), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1260), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1260), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1260), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1270), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1270), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1270), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1280), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1280), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1280), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1280), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1290), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1290), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1290), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1300), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1300), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1300), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1300), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1310), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1310), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1310), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1320), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1320), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1320), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1320), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1330), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1330), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1330), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1340), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1340), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1340), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1350), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1350), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1350), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1350), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1360), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1360), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1360), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1370), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1370), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1370), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1370), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1380), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1380), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1380), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1390), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1390), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1390), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1390), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1400), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1400), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(1400) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(8530), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(8530) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "f3a52634-7fdc-42b2-853e-86c7a3b5775b");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "4ff7713d-35fd-4fdb-b84c-75001d4c291b");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "CustomerImportPageCursor", "DateCreated", "DateModified" },
                values: new object[] { 0, new DateTime(2026, 7, 1, 15, 24, 43, 619, DateTimeKind.Utc).AddTicks(8480), new DateTime(2026, 7, 1, 15, 24, 43, 619, DateTimeKind.Utc).AddTicks(8490) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2250), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2250) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2820), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2820) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2820), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2820) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2820), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2820) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2830), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2830) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2830), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2830) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2860), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2860) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2860), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2860) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2870), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2880), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2880) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2830), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2830) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2840), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2840) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2840), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2840) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2840), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2840) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2850), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2850) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2850), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2850) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2850), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2850) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2850), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2860) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2860), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2860) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2870), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2870), new DateTime(2026, 7, 1, 15, 24, 43, 632, DateTimeKind.Utc).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 620, DateTimeKind.Utc).AddTicks(9050), new DateTime(2026, 7, 1, 15, 24, 43, 620, DateTimeKind.Utc).AddTicks(9050) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 620, DateTimeKind.Utc).AddTicks(9160), new DateTime(2026, 7, 1, 15, 24, 43, 620, DateTimeKind.Utc).AddTicks(9160) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 620, DateTimeKind.Utc).AddTicks(9170), new DateTime(2026, 7, 1, 15, 24, 43, 620, DateTimeKind.Utc).AddTicks(9170) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 604, DateTimeKind.Utc).AddTicks(770), new DateTime(2026, 7, 1, 15, 24, 43, 604, DateTimeKind.Utc).AddTicks(770) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c4b0c28-d336-49ad-9021-f755ed71b4da", new DateTime(2026, 7, 1, 15, 24, 43, 567, DateTimeKind.Utc).AddTicks(5550), new DateTime(2026, 7, 1, 15, 24, 43, 567, DateTimeKind.Utc).AddTicks(5550), "AQAAAAIAAYagAAAAEBeQGYQNm8+LoQ0P9d1cdOcZCXcMdZ/zyOwl/NMhnxDHyOV0m6ggOxiEJQXMNmh12g==", "d8c1bf08-f678-4366-8f5f-9f405db7b3a2" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 607, DateTimeKind.Utc).AddTicks(6900), new DateTime(2026, 7, 1, 15, 24, 43, 607, DateTimeKind.Utc).AddTicks(7000), new Guid("340ff6ba-beef-4408-93fb-7e71cbc7307e") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(3230), new DateTime(2026, 7, 1, 15, 24, 43, 610, DateTimeKind.Utc).AddTicks(3230) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerImportPageCursor",
                table: "saleschannel");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4370), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4780), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4780), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4790), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4790), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4790), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4800), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4800), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4800), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4800), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4810), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4810), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4810), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4820), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4820), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4820), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4820), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4830), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4830), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4830), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4840), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4840), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4840), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4840), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4850), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4850), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4850), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4860), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4860), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4860), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4860), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4870), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4880), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4880), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4880), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4890), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4890), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4890), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4890), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4900), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4900), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4900), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4910), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4910), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4910), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4910), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4920), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4920), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4920), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4930), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4930), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4930), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4940), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4940), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4940), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4940), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4950), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4950), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4950), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4960), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4960), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4960), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4960), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4970), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4970), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4970), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4980), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4980), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4980), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4990), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4990), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4990), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4990), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(4990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5000), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5000), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5000), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5010), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5010), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5010), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5010), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5020), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5020), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5020), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5030), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5030), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5030), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5030), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5040), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5040), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5040), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5050), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5050), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5050), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5050), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5060), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5060), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5060), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5070), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5070), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5070), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5080), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5080), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5080), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5080), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5090), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5090), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5090), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5100), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5100), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5100), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5100), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5110), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5110), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5160), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5160), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5160), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5170), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5170), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5170), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5170), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(5170) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 668, DateTimeKind.Utc).AddTicks(1980), new DateTime(2026, 7, 1, 10, 53, 31, 668, DateTimeKind.Utc).AddTicks(1980) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "c5b77921-7bdb-4ce8-8d41-107cbc49c497");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "aece6cc8-ec1d-4a6d-93fd-f94be61e6dca");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 677, DateTimeKind.Utc).AddTicks(540), new DateTime(2026, 7, 1, 10, 53, 31, 677, DateTimeKind.Utc).AddTicks(540) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1190), new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1190) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1500), new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1500) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1500), new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1500) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1500), new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1500) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1510), new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1510) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1510), new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1510) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1540), new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1540) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1540), new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1540) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1550), new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1550) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1550), new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1550) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1510), new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1510) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1520), new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1520) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1520), new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1520) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1520), new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1520) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1520), new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1520) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1530), new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1530) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1530), new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1530) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1530), new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1530) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1540), new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1540) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1540), new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1540) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1550), new DateTime(2026, 7, 1, 10, 53, 31, 689, DateTimeKind.Utc).AddTicks(1550) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 678, DateTimeKind.Utc).AddTicks(1000), new DateTime(2026, 7, 1, 10, 53, 31, 678, DateTimeKind.Utc).AddTicks(1000) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 678, DateTimeKind.Utc).AddTicks(1110), new DateTime(2026, 7, 1, 10, 53, 31, 678, DateTimeKind.Utc).AddTicks(1110) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 678, DateTimeKind.Utc).AddTicks(1110), new DateTime(2026, 7, 1, 10, 53, 31, 678, DateTimeKind.Utc).AddTicks(1110) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 661, DateTimeKind.Utc).AddTicks(1280), new DateTime(2026, 7, 1, 10, 53, 31, 661, DateTimeKind.Utc).AddTicks(1280) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "535c0298-5192-4466-923d-447a546cdc89", new DateTime(2026, 7, 1, 10, 53, 31, 624, DateTimeKind.Utc).AddTicks(3200), new DateTime(2026, 7, 1, 10, 53, 31, 624, DateTimeKind.Utc).AddTicks(3230), "AQAAAAIAAYagAAAAEIWFKyeS+ZaXh/gNUIwQqB+Zlh+N82ji82ZRqqUR7GcM7BDhqKRubaDm9CKJIBrCSw==", "844048df-b860-4e34-9639-46c4b3996a8b" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 665, DateTimeKind.Utc).AddTicks(910), new DateTime(2026, 7, 1, 10, 53, 31, 665, DateTimeKind.Utc).AddTicks(1000), new Guid("13cec220-f6c6-4d05-b2b2-2438c56ecd15") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(6880), new DateTime(2026, 7, 1, 10, 53, 31, 667, DateTimeKind.Utc).AddTicks(6880) });
        }
    }
}
