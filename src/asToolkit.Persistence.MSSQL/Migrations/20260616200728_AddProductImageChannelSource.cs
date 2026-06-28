using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asToolkit.Persistence.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddProductImageChannelSource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RemoteImageId",
                table: "product_image",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SalesChannelId",
                table: "product_image",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(680), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(680) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1130), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1130), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1140), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1140), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1140), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1150), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1150), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1150), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1160), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1160), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1160), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1160), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1170), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1170), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1170), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1180), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1180), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1180), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1190), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1190), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1190), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1190), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1200), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1200), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1200), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1210), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1220), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1230), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1230), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1230), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1240), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1240), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1240), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1240), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1250), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1250), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1250), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1260), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1260), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1260), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1260), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1270), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1270), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1270), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1280), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1280), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1280), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1290), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1290), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1290), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1300), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1300), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1300), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1310), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1310), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1310), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1310), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1320), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1320), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1320), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1330), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1330), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1330), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1340), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1340), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1340), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1340), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1350), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1350), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1350), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1360), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1360), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1360), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1370), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1370), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1370), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1370), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1380), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1380), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1380), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1390), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1390), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1390), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1400), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1400), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1400), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1400), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1410), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1410), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1410), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1420), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1420), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1420), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1420), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1430), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1430), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1430), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1440), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1440), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1440), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1450), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1450), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1450), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1450), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1460), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1460), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1460), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1470), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1470), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1470), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1470), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1480), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1480), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1480), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1490), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1490), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1490), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1500), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1500), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(1500) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(8550), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(8550) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "779f6b2e-b036-4f7d-a5bf-9d526a5c42e9");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "3e13475e-f280-4cae-b002-be3a16e839b8");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 363, DateTimeKind.Utc).AddTicks(8430), new DateTime(2026, 6, 16, 20, 7, 13, 363, DateTimeKind.Utc).AddTicks(8430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8190), new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8190) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8400), new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8400) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8410), new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8410) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8410), new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8410) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8410), new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8410) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8420), new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8420) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8440), new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8450), new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8460), new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8460), new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8420), new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8420) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8420), new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8420) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8420), new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8420) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8430), new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8430), new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8430), new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8440), new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8440), new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8440), new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8450), new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8450), new DateTime(2026, 6, 16, 20, 7, 13, 375, DateTimeKind.Utc).AddTicks(8450) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 364, DateTimeKind.Utc).AddTicks(8960), new DateTime(2026, 6, 16, 20, 7, 13, 364, DateTimeKind.Utc).AddTicks(8960) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 364, DateTimeKind.Utc).AddTicks(9080), new DateTime(2026, 6, 16, 20, 7, 13, 364, DateTimeKind.Utc).AddTicks(9080) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 364, DateTimeKind.Utc).AddTicks(9080), new DateTime(2026, 6, 16, 20, 7, 13, 364, DateTimeKind.Utc).AddTicks(9080) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 347, DateTimeKind.Utc).AddTicks(6650), new DateTime(2026, 6, 16, 20, 7, 13, 347, DateTimeKind.Utc).AddTicks(6650) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "218e45ed-64aa-4293-921a-84c8e6c1d2af", new DateTime(2026, 6, 16, 20, 7, 13, 310, DateTimeKind.Utc).AddTicks(6640), new DateTime(2026, 6, 16, 20, 7, 13, 310, DateTimeKind.Utc).AddTicks(6640), "AQAAAAIAAYagAAAAEGzgvG23jhmVWM8tC/xzTvv7yN5OH1z4KrjatQADxYUHiJUQjV5Kfd1MH8eEKZh2KA==", "e7bc7fc1-a9e8-4d14-8365-54f41442f600" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 351, DateTimeKind.Utc).AddTicks(7390), new DateTime(2026, 6, 16, 20, 7, 13, 351, DateTimeKind.Utc).AddTicks(7480), new Guid("dddd3c44-3e11-4b84-9d00-de765716a774") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(3320), new DateTime(2026, 6, 16, 20, 7, 13, 354, DateTimeKind.Utc).AddTicks(3320) });

            migrationBuilder.CreateIndex(
                name: "IX_product_image_ProductId_SalesChannelId_RemoteImageId",
                table: "product_image",
                columns: new[] { "ProductId", "SalesChannelId", "RemoteImageId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_product_image_ProductId_SalesChannelId_RemoteImageId",
                table: "product_image");

            migrationBuilder.DropColumn(
                name: "RemoteImageId",
                table: "product_image");

            migrationBuilder.DropColumn(
                name: "SalesChannelId",
                table: "product_image");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(8830), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9250), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9260), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9260), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9260), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9270), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9270), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9270), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9280), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9280), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9280), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9290), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9290), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9290), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9290), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9300), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9300), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9300), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9310), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9310), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9310), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9310), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9320), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9320), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9320), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9330), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9330), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9330), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9340), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9340), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9340), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9340), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9350), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9350), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9350), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9360), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9360), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9360), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9360), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9370), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9370), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9370), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9380), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9380), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9380), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9390), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9390), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9450), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9450), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9450), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9450), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9460), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9460), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9460), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9470), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9470), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9470), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9470), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9480), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9480), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9480), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9490), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9490), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9490), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9500), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9500), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9500), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9500), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9510), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9510), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9510), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9520), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9520), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9520), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9530), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9530), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9530), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9530), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9540), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9540), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9540), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9550), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9550), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9550), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9550), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9560), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9560) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9560), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9560) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9560), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9560) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9570), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9570), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9570), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9570), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9580), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9580) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9580), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9580) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9580), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9580) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9590), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9590), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9590), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9600), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9600), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9600), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9600), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9610), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9610), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9610), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9620), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9620), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9620), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9630), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9630), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9630), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9630), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9640), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9640) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9640), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9640) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9640), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9640) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9650), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9650), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9650), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9650), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9660), new DateTime(2026, 6, 16, 15, 14, 7, 423, DateTimeKind.Utc).AddTicks(9660) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 424, DateTimeKind.Utc).AddTicks(6690), new DateTime(2026, 6, 16, 15, 14, 7, 424, DateTimeKind.Utc).AddTicks(6690) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "a1e8b22c-cf87-4787-b2ef-5eae6e434089");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "bb5e6860-b74f-487a-8186-b176b33a7a18");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 433, DateTimeKind.Utc).AddTicks(4890), new DateTime(2026, 6, 16, 15, 14, 7, 433, DateTimeKind.Utc).AddTicks(4890) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3410), new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3410) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3660), new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3660) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3670), new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3670), new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3670), new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3680), new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3680) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3700), new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3700) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3710), new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3710), new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3720), new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3720) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3680), new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3680) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3680), new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3680) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3680), new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3680) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3690), new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3690) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3690), new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3690) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3690), new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3690) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3690), new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3700) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3700), new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3700) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3700), new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3700) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3710), new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3710), new DateTime(2026, 6, 16, 15, 14, 7, 445, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 434, DateTimeKind.Utc).AddTicks(4900), new DateTime(2026, 6, 16, 15, 14, 7, 434, DateTimeKind.Utc).AddTicks(4900) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 434, DateTimeKind.Utc).AddTicks(5010), new DateTime(2026, 6, 16, 15, 14, 7, 434, DateTimeKind.Utc).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 434, DateTimeKind.Utc).AddTicks(5020), new DateTime(2026, 6, 16, 15, 14, 7, 434, DateTimeKind.Utc).AddTicks(5020) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 417, DateTimeKind.Utc).AddTicks(5460), new DateTime(2026, 6, 16, 15, 14, 7, 417, DateTimeKind.Utc).AddTicks(5460) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1144a153-60f7-48c2-933d-1aedfb97eb53", new DateTime(2026, 6, 16, 15, 14, 7, 380, DateTimeKind.Utc).AddTicks(4600), new DateTime(2026, 6, 16, 15, 14, 7, 380, DateTimeKind.Utc).AddTicks(4610), "AQAAAAIAAYagAAAAEDDZ6/Kb3vsrPZsGkSrTBUqnrdtxCTzpcD1egp/lmXm6oeXvPFoauWvlo8ohYPfmVw==", "1bdc4c21-5573-4d3f-aa93-2274e747cfae" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 421, DateTimeKind.Utc).AddTicks(4990), new DateTime(2026, 6, 16, 15, 14, 7, 421, DateTimeKind.Utc).AddTicks(5090), new Guid("75805dca-85f6-420e-bf6c-47c2226ba0a3") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 7, 424, DateTimeKind.Utc).AddTicks(1490), new DateTime(2026, 6, 16, 15, 14, 7, 424, DateTimeKind.Utc).AddTicks(1490) });
        }
    }
}
