using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace maERP.Persistence.PostgreSQL.Migrations
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
                type: "character varying(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SalesChannelId",
                table: "product_image",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3210), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3610), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3620), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3620), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3620), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3630), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3630), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3630), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3640), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3640) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3640), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3640) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3640), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3640) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3640), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3640) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3650), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3650), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3650), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3660), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3660), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3660), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3670), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3670), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3670), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3670), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3680), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3680) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3680), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3680) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3680), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3680) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3690), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3690) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3690), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3690) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3690), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3690) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3690), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3690) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3700), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3700), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3700), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3710), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3710), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3710), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3710), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3720), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3720), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3720), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3730), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3730), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3730), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3740), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3740), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3740), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3740), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3750), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3750), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3750), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3760), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3760), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3760), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3760), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3770), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3770), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3770), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3780), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3780), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3780), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3780), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3790), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3790), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3790), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3800), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3800), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3800), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3800), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3810), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3810), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3820), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3820), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3820), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3830), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3830), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3830), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3840), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3840), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3840), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3840), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3850), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3850), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3850), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3860), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3860), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3860), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3870), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3870), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3870), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3870), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3880), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3880), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3880), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3890), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3890), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3890), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3890), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3900), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3900), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3900), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3910), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3910), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3910), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3910), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3920), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3920), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3920), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3930), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3930), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3930), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3940), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3940), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3940), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3940), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3950), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3950), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3950), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3960), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3960), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3960), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3960), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(3960) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 361, DateTimeKind.Utc).AddTicks(540), new DateTime(2026, 6, 16, 20, 7, 32, 361, DateTimeKind.Utc).AddTicks(540) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "f87a9916-c172-4401-ad0d-b1e81a1d7cd6");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "cb0fd906-e2fb-406a-9b20-f590084e6f7c");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 370, DateTimeKind.Utc).AddTicks(10), new DateTime(2026, 6, 16, 20, 7, 32, 370, DateTimeKind.Utc).AddTicks(10) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8430), new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8710), new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8710) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8710), new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8720) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8720), new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8720) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8720), new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8720) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8720), new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8720) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8750), new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8750) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8750), new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8750) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8760), new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8760) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8770), new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8770) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8730), new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8730) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8730), new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8730) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8730), new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8730) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8730), new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8730) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8740), new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8740) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8740), new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8740) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8740), new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8740) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8750), new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8750) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8750), new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8750) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8760), new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8760) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8760), new DateTime(2026, 6, 16, 20, 7, 32, 381, DateTimeKind.Utc).AddTicks(8760) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 371, DateTimeKind.Utc).AddTicks(1140), new DateTime(2026, 6, 16, 20, 7, 32, 371, DateTimeKind.Utc).AddTicks(1140) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 371, DateTimeKind.Utc).AddTicks(1250), new DateTime(2026, 6, 16, 20, 7, 32, 371, DateTimeKind.Utc).AddTicks(1250) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 371, DateTimeKind.Utc).AddTicks(1260), new DateTime(2026, 6, 16, 20, 7, 32, 371, DateTimeKind.Utc).AddTicks(1260) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 354, DateTimeKind.Utc).AddTicks(8970), new DateTime(2026, 6, 16, 20, 7, 32, 354, DateTimeKind.Utc).AddTicks(8970) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "925a47e1-798c-410a-9c7d-93d38b073025", new DateTime(2026, 6, 16, 20, 7, 32, 318, DateTimeKind.Utc).AddTicks(5920), new DateTime(2026, 6, 16, 20, 7, 32, 318, DateTimeKind.Utc).AddTicks(5920), "AQAAAAIAAYagAAAAELXw3nr9XxcaFMDEOp/H4hbpUe6NgUMl+wFwSYKyzNUcSgoDZsLgjI1T18BvZw3ZNA==", "046b9fe1-2c8d-4fd8-bb69-86c635ce12e6" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 358, DateTimeKind.Utc).AddTicks(440), new DateTime(2026, 6, 16, 20, 7, 32, 358, DateTimeKind.Utc).AddTicks(540), new Guid("db095d68-4655-4bd1-ba61-121ec8674020") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(5560), new DateTime(2026, 6, 16, 20, 7, 32, 360, DateTimeKind.Utc).AddTicks(5560) });

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
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 881, DateTimeKind.Utc).AddTicks(9800), new DateTime(2026, 6, 16, 15, 14, 27, 881, DateTimeKind.Utc).AddTicks(9800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(230), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(230), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(240), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(240), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(240), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(250), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(250), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(260), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(260), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(260), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(270), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(270), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(270), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(280), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(280), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(280), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(290), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(290), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(300), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(300), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(300), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(310), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(310), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(310), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(320), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(320), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(320), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(330), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(330), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(330), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(340), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(340), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(350), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(350), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(350), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(360), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(360), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(360), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(370), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(370), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(370), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(370), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(380), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(380), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(380), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(400), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(400), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(400), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(410), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(410), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(410), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(410), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(420), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(420), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(420), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(430), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(430), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(430), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(430), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(440), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(440), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(440), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(450), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(450), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(450), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(450), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(460), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(460), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(460), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(470), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(470), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(470), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(480), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(480), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(480), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(480), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(490), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(490), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(490), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(500), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(500), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(500), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(500), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(510), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(510), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(510), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(520), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(520), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(520), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(520), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(530), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(530), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(530), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(540), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(540), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(540), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(550), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(550), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(550), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(550), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(560), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(560) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(560), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(560) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(560), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(560) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(570), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(570), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(570), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(570), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(580), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(580) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(580), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(580) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(580), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(580) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(590), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(590), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(590), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(590), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(600), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(600), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(600), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(610), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(610), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(610) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(8920), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(8920) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "0cc5ef7c-4137-49b9-a93e-9f43969de37f");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "0f0363e8-7bb7-4106-ad35-31c087eea5d2");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 891, DateTimeKind.Utc).AddTicks(8420), new DateTime(2026, 6, 16, 15, 14, 27, 891, DateTimeKind.Utc).AddTicks(8420) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7620), new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7620) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7880), new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7880) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7880), new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7880) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7890), new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7890) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7890), new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7890) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7890), new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7890) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7950), new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7950) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7950), new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7950) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7960), new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7960) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7970), new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7970) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7930), new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7930) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7930), new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7930) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7930), new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7930) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7940), new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7940) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7940), new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7940) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7940), new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7940) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7940), new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7940) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7950), new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7950) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7950), new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7950) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7960), new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7960) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7960), new DateTime(2026, 6, 16, 15, 14, 27, 903, DateTimeKind.Utc).AddTicks(7960) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 893, DateTimeKind.Utc).AddTicks(1040), new DateTime(2026, 6, 16, 15, 14, 27, 893, DateTimeKind.Utc).AddTicks(1040) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 893, DateTimeKind.Utc).AddTicks(1190), new DateTime(2026, 6, 16, 15, 14, 27, 893, DateTimeKind.Utc).AddTicks(1190) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 893, DateTimeKind.Utc).AddTicks(1190), new DateTime(2026, 6, 16, 15, 14, 27, 893, DateTimeKind.Utc).AddTicks(1190) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 876, DateTimeKind.Utc).AddTicks(8370), new DateTime(2026, 6, 16, 15, 14, 27, 876, DateTimeKind.Utc).AddTicks(8370) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "471110b4-4389-4933-bf9c-3aea3ae9d765", new DateTime(2026, 6, 16, 15, 14, 27, 841, DateTimeKind.Utc).AddTicks(4320), new DateTime(2026, 6, 16, 15, 14, 27, 841, DateTimeKind.Utc).AddTicks(4320), "AQAAAAIAAYagAAAAEBsMYdkIrulLxcJmvaO99jtkwXbVHsKpkyfdJH+1N2xG2J56HWhPN6wz9zhc8BxjSA==", "eb251833-5e47-48ed-9b93-8308b6c2d00f" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 879, DateTimeKind.Utc).AddTicks(7280), new DateTime(2026, 6, 16, 15, 14, 27, 879, DateTimeKind.Utc).AddTicks(7370), new Guid("75d11d75-7525-4e19-b3e2-601a7a292310") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(2570), new DateTime(2026, 6, 16, 15, 14, 27, 882, DateTimeKind.Utc).AddTicks(2570) });
        }
    }
}
