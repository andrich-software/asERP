using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddSalesChannelPushSalesCancellations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PushSalesCancellations",
                table: "saleschannel",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(59), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(59) });

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
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(123), new DateTime(2026, 7, 5, 15, 6, 48, 751, DateTimeKind.Utc).AddTicks(123) });

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
                columns: new[] { "DateCreated", "DateModified", "PushSalesCancellations" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 768, DateTimeKind.Utc).AddTicks(6907), new DateTime(2026, 7, 5, 15, 6, 48, 768, DateTimeKind.Utc).AddTicks(6910), false });

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
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9770), new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9770) });

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
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9779), new DateTime(2026, 7, 5, 15, 6, 48, 802, DateTimeKind.Utc).AddTicks(9779) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PushSalesCancellations",
                table: "saleschannel");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(3465), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4079), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4079) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4082), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4083) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4084), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4084) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4086), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4086) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4087), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4088) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4089), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4089) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4091), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4091) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4095), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4095) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4096), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4096) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4098), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4098) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4099), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4101), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4101) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4102), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4103) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4104), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4104) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4105), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4106) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4108), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4108) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4121), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4121) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4123), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4123) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4125), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4125) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4127), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4127) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4128), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4129) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4130), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4132), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4132) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4134), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4135) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4136), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4136) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4148), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4149) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4152), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4152) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4154), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4154) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4155), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4156) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4157), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4157) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4158), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4159) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4161), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4162) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4170), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4171) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4173), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4173) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4174), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4174) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4176), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4176) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4178), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4178) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4179), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4179) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4180), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4181) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4183), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4183) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4185), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4185) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4186), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4187) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4188), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4188) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4189), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4191), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4191) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4192), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4194), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4194) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4197), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4197) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4205), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4206) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4208), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4208) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4210), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4211), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4211) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4213), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4213) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4214), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4215) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4216), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4216) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4219), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4219) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4220), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4222), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4222) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4223), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4224) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4225), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4225) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4226), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4227) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4228), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4228) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4229), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4232), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4232) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4243), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4243) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4246), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4246) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4247), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4247) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4249), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4249) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4250), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4251) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4252), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4252) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4254), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4254) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4256), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4257) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4258), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4258) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4260), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4261), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4261) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4263), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4263) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4264), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4264) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4266), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4266) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4267), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4267) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4270), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4278), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4279) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4280), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4281) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4289), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4289) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4291), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4291) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4292), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4292) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4294), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4294) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4295), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4296) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4298), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4298) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4300), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4301), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4302) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4303), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4303) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4304), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4305) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4306), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4306) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4307), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4308) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4309), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4309) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4312), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4312) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4321), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4321) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4323), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4324) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4325), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4325) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4327), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4327) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4329), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4329) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4331), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4331) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4333), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4333) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4336), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4336) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4338), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4338) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4340), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4342), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4342) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4344), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4344) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4345), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4346) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4347), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4347) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4348), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4349) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4351), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4351) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4353), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4353) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4354), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4354) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4356), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4356) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4357), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4357) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4359), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4359) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4360), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4362), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4362) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 486, DateTimeKind.Utc).AddTicks(4051), new DateTime(2026, 7, 4, 20, 54, 32, 486, DateTimeKind.Utc).AddTicks(4053) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "768b5a5b-a7ad-4cf5-92a1-50ad9ad60b27");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "729c0cd2-374c-4ee8-aacc-6cd07e99ea45");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 498, DateTimeKind.Utc).AddTicks(9827), new DateTime(2026, 7, 4, 20, 54, 32, 498, DateTimeKind.Utc).AddTicks(9829) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1409), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1412) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1767), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1767) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1778), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1778) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1780), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1781) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1782), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1782) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1798), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1798) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1799), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1800) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1805), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1805) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1813), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1813) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1783), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1784) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1785), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1785) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1786), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1786) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1788), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1788) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1789), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1789) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1792), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1793) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1794), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1794) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1795), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1795) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1797), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1797) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1801), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1801) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1802), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1802) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 500, DateTimeKind.Utc).AddTicks(5892), new DateTime(2026, 7, 4, 20, 54, 32, 500, DateTimeKind.Utc).AddTicks(5893) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 500, DateTimeKind.Utc).AddTicks(6096), new DateTime(2026, 7, 4, 20, 54, 32, 500, DateTimeKind.Utc).AddTicks(6097) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 500, DateTimeKind.Utc).AddTicks(6099), new DateTime(2026, 7, 4, 20, 54, 32, 500, DateTimeKind.Utc).AddTicks(6099) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 479, DateTimeKind.Utc).AddTicks(2350), new DateTime(2026, 7, 4, 20, 54, 32, 479, DateTimeKind.Utc).AddTicks(2355) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "233ceafa-cfa6-4f89-9203-32f83077e7b5", new DateTime(2026, 7, 4, 20, 54, 32, 439, DateTimeKind.Utc).AddTicks(7374), new DateTime(2026, 7, 4, 20, 54, 32, 439, DateTimeKind.Utc).AddTicks(7379), "AQAAAAIAAYagAAAAEJQVsTPvQlDsxdjN2r5xKTkr0BrsRIr8PMb33F3f87aUx5Bdp4sEF95ak2ejBgYAyQ==", "3455084c-2610-400c-8ef3-41d1a466f7de" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 483, DateTimeKind.Utc).AddTicks(4167), new DateTime(2026, 7, 4, 20, 54, 32, 483, DateTimeKind.Utc).AddTicks(4290), new Guid("9971bf12-acb8-41a3-badd-0792bba64408") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(7527), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(7528) });
        }
    }
}
