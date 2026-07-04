using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.SQLite.Migrations
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
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(5710), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(5710) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6190), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6190), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6200), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6200), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6200), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6210), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6210), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6210), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6210), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6220), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6220), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6220), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6220), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6230), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6230), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6230), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6240), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6240), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6240), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6240), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6250), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6250), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6250), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6250), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6260), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6260), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6260), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6260), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6270), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6270), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6270), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6270), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6280), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6280), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6280), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6290), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6290), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6290), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6300), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6300), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6300), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6300), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6310), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6310), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6310), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6310), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6320), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6320), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6320), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6320), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6330), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6330), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6330), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6330), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6340), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6340), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6340), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6360), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6360), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6370), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6370), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6370), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6380), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6380), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6380), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6380), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6390), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6390), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6390), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6400), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6400), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6400), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6410), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6410), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6410), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6410), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6420), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6420), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6420), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6430), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6430), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6430), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6430), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6440), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6440), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6440), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6450), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6450), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6450), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6450), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6460), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6460), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6460), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6470), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6470), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6470), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6470), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6480), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6480), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6480), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6490), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6490), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6490), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6490), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6500), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6500), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6500), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6510), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6510), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6510), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6510), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6520), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6520), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6520), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6530), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6530), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6530), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6540), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6540), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(6540) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 441, DateTimeKind.Utc).AddTicks(4280), new DateTime(2026, 7, 1, 15, 25, 6, 441, DateTimeKind.Utc).AddTicks(4280) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "2dee38fd-9758-4668-8fe0-7ca3b37a78f4");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "786aaee9-8c8d-4f92-90a4-551eb5dc9805");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "CustomerImportPageCursor", "DateCreated", "DateModified" },
                values: new object[] { 0, new DateTime(2026, 7, 1, 15, 25, 6, 449, DateTimeKind.Utc).AddTicks(8740), new DateTime(2026, 7, 1, 15, 25, 6, 449, DateTimeKind.Utc).AddTicks(8740) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(10), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(10) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(200), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(200) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(200), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(200) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(210), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(210) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(210), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(210) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(210), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(210) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(240), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(240) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(240), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(240) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(250), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(250) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(250), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(250) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(210), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(210) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(220), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(220) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(220), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(220) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(220), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(220) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(220), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(220) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(230), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(230) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(230), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(230) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(230), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(230) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(240), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(240) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(240), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(240) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(250), new DateTime(2026, 7, 1, 15, 25, 6, 461, DateTimeKind.Utc).AddTicks(250) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 450, DateTimeKind.Utc).AddTicks(8650), new DateTime(2026, 7, 1, 15, 25, 6, 450, DateTimeKind.Utc).AddTicks(8650) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 450, DateTimeKind.Utc).AddTicks(8760), new DateTime(2026, 7, 1, 15, 25, 6, 450, DateTimeKind.Utc).AddTicks(8760) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 450, DateTimeKind.Utc).AddTicks(8760), new DateTime(2026, 7, 1, 15, 25, 6, 450, DateTimeKind.Utc).AddTicks(8760) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 434, DateTimeKind.Utc).AddTicks(8370), new DateTime(2026, 7, 1, 15, 25, 6, 434, DateTimeKind.Utc).AddTicks(8370) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30ab4ca7-54cb-46ab-96d3-d6de027de61f", new DateTime(2026, 7, 1, 15, 25, 6, 399, DateTimeKind.Utc).AddTicks(7020), new DateTime(2026, 7, 1, 15, 25, 6, 399, DateTimeKind.Utc).AddTicks(7020), "AQAAAAIAAYagAAAAEBPOYJ6H/ATFH64nayW2wknB8EJLBz/S35vcXLFpiVpf/Kr87tCa/XdNGcfu7Zp2nQ==", "488cfa40-a758-40ee-8fd6-378705bc0fc5" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 437, DateTimeKind.Utc).AddTicks(6520), new DateTime(2026, 7, 1, 15, 25, 6, 437, DateTimeKind.Utc).AddTicks(6620), new Guid("ccd93e6d-a23e-42b0-841b-40eeeceb514d") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(9020), new DateTime(2026, 7, 1, 15, 25, 6, 440, DateTimeKind.Utc).AddTicks(9020) });
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
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(8660), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(8660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9070), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9070), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9070), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9080), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9080), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9080), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9090), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9100), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9100), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9100), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9110), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9110), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9110), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9120), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9120), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9120), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9130), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9130), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9130), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9130), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9140), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9140), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9140), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9150), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9150), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9150), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9160), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9170), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9170), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9170), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9180), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9180), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9180), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9190), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9190), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9190), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9190), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9200), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9200), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9200), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9210), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9210), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9210), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9210), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9220), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9220), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9220), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9230), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9230), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9230), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9240), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9240), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9240), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9240), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9250), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9250), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9250), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9260), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9260), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9260), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9260), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9270), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9270), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9270), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9280), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9280), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9280), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9290), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9290), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9320), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9320), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9320), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9320), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9330), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9330), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9330), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9340), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9340), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9340), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9350), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9350), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9350), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9350), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9360), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9360), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9360), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9370), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9370), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9370), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9380), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9380), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9380), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9380), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9390), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9390), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9390), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9400), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9400), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9400), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9400), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9410), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9410), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9410), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9420), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9420), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9420), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9430), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9430), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9430), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9430), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9440), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9440), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9440), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9450), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9450), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9450), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9460), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9460), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9460), new DateTime(2026, 7, 1, 10, 53, 54, 400, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 401, DateTimeKind.Utc).AddTicks(6150), new DateTime(2026, 7, 1, 10, 53, 54, 401, DateTimeKind.Utc).AddTicks(6150) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "ba76b219-8c3a-45e8-9367-e8994d710099");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "6a4df78c-2911-45ad-b702-16a031d267a6");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 409, DateTimeKind.Utc).AddTicks(9360), new DateTime(2026, 7, 1, 10, 53, 54, 409, DateTimeKind.Utc).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(670), new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(670) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(870), new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(870), new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(880), new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(880), new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(880), new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(910), new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(910), new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(960), new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(960), new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(890), new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(890) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(890), new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(890) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(890), new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(890) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(890), new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(890) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(900), new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(900), new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(900), new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(910), new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(910), new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(920), new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(920), new DateTime(2026, 7, 1, 10, 53, 54, 421, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 410, DateTimeKind.Utc).AddTicks(9330), new DateTime(2026, 7, 1, 10, 53, 54, 410, DateTimeKind.Utc).AddTicks(9330) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 410, DateTimeKind.Utc).AddTicks(9430), new DateTime(2026, 7, 1, 10, 53, 54, 410, DateTimeKind.Utc).AddTicks(9430) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 410, DateTimeKind.Utc).AddTicks(9430), new DateTime(2026, 7, 1, 10, 53, 54, 410, DateTimeKind.Utc).AddTicks(9430) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 395, DateTimeKind.Utc).AddTicks(3000), new DateTime(2026, 7, 1, 10, 53, 54, 395, DateTimeKind.Utc).AddTicks(3000) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbeae0bc-a78c-4ed6-9bac-6fe72aade6af", new DateTime(2026, 7, 1, 10, 53, 54, 358, DateTimeKind.Utc).AddTicks(8400), new DateTime(2026, 7, 1, 10, 53, 54, 358, DateTimeKind.Utc).AddTicks(8400), "AQAAAAIAAYagAAAAEBul/+GJ3hd48JSM1EXRrOb3tDEmhBzTmiTzZyihilEfzGSvG8Ipt6kV0aVV9Ku9Qg==", "5fa05e20-7f13-4fd7-9784-90d67f8bf781" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 398, DateTimeKind.Utc).AddTicks(5730), new DateTime(2026, 7, 1, 10, 53, 54, 398, DateTimeKind.Utc).AddTicks(5820), new Guid("917b57f6-b170-4ee4-818e-11c963fa8339") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 54, 401, DateTimeKind.Utc).AddTicks(1040), new DateTime(2026, 7, 1, 10, 53, 54, 401, DateTimeKind.Utc).AddTicks(1040) });
        }
    }
}
