using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.PostgreSQL.Migrations
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
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(3620), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(3620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4040), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4040), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4050), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4050), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4050), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4050), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4060), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4060), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4060), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4070), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4070), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4070), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4080), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4080), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4080), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4080), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4090), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4090), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4090), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4100), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4100), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4100), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4100), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4110), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4110), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4110), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4120), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4120), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4120), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4120), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4130), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4130), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4130), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4140), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4140), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4140), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4140), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4150), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4150), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4150), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4160), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4160), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4160), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4210), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4220), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4220), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4220), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4230), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4230), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4230), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4240), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4240), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4240), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4240), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4250), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4250), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4250), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4260), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4260), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4260), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4260), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4270), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4270), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4270), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4280), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4280), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4280), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4290), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4290), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4290), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4290), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4300), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4300), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4300), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4310), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4310), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4310), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4310), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4320), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4320), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4320), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4330), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4330), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4330), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4340), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4340), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4340), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4340), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4350), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4350), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4350), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4360), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4360), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4360), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4360), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4370), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4370), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4370), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4380), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4380), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4380), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4380), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4390), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4390), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4390), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4400), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4400), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4400), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4400), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4410), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4410), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4410), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4420), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4420), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4420), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4420), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4430), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4430), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4430), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(4430) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 488, DateTimeKind.Utc).AddTicks(1480), new DateTime(2026, 7, 1, 15, 25, 2, 488, DateTimeKind.Utc).AddTicks(1480) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "684a687f-eef6-45e6-8267-164a628a70db");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "ba2f5baa-8a05-43db-8b9c-b6dc18308af0");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "CustomerImportPageCursor", "DateCreated", "DateModified" },
                values: new object[] { 0, new DateTime(2026, 7, 1, 15, 25, 2, 496, DateTimeKind.Utc).AddTicks(5000), new DateTime(2026, 7, 1, 15, 25, 2, 496, DateTimeKind.Utc).AddTicks(5000) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2090), new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2090) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2330), new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2330) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2330), new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2330) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2340), new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2340) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2340), new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2340) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2340), new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2340) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2390), new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2390) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2390), new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2390) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2400), new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2400) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2400), new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2400) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2350), new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2350) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2350), new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2350) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2350), new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2350) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2350), new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2350) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2360), new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2360) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2360), new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2360) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2360), new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2360) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2380), new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2380) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2390), new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2390) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2400), new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2400) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2400), new DateTime(2026, 7, 1, 15, 25, 2, 508, DateTimeKind.Utc).AddTicks(2400) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 497, DateTimeKind.Utc).AddTicks(6640), new DateTime(2026, 7, 1, 15, 25, 2, 497, DateTimeKind.Utc).AddTicks(6640) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 497, DateTimeKind.Utc).AddTicks(6750), new DateTime(2026, 7, 1, 15, 25, 2, 497, DateTimeKind.Utc).AddTicks(6750) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 497, DateTimeKind.Utc).AddTicks(6760), new DateTime(2026, 7, 1, 15, 25, 2, 497, DateTimeKind.Utc).AddTicks(6760) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 481, DateTimeKind.Utc).AddTicks(9860), new DateTime(2026, 7, 1, 15, 25, 2, 481, DateTimeKind.Utc).AddTicks(9860) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6cf8265-1649-41af-a456-f78fc9c374da", new DateTime(2026, 7, 1, 15, 25, 2, 447, DateTimeKind.Utc).AddTicks(1800), new DateTime(2026, 7, 1, 15, 25, 2, 447, DateTimeKind.Utc).AddTicks(1800), "AQAAAAIAAYagAAAAEChJCcrPVZBI8oyEmmh/o+65gvATbjO14VtUsV6ojFbjBb6X0X6HrnghDGdoEQIVxQ==", "b7028dac-1c64-4396-ba54-0ebf38c0b4f7" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 484, DateTimeKind.Utc).AddTicks(9750), new DateTime(2026, 7, 1, 15, 25, 2, 484, DateTimeKind.Utc).AddTicks(9840), new Guid("3ce4653e-cd35-411d-950d-7b663437c27d") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(6370), new DateTime(2026, 7, 1, 15, 25, 2, 487, DateTimeKind.Utc).AddTicks(6370) });
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
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3430), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3830), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3830), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3830), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3840), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3840), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3840), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3850), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3850), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3850), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3860), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3860), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3860), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3860), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3870), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3870), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3870), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3880), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3880), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3880), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3880), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3890), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3890), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3890), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3900), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3900), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3900), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3910), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3910), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3910), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3910), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3920), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3920), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3920), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3930), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3930), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3930), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3930), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3940), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3940), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3940), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3950), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3950), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3950), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3950), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3960), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3960), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3960), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3970), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3970), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3970), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3970), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3980), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3980), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3980), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3990), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3990), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3990), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(3990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4000), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4010), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4010), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4010), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4010), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4020), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4020), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4020), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4030), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4030), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4030), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4030), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4040), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4040), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4040), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4050), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4050), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4050), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4050), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4060), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4060), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4060), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4070), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4070), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4070), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4080), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4080), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4080), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4080), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4090), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4090), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4090), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4100), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4100), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4100), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4100), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4110), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4110), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4110), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4120), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4120), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4120), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4120), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4130), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4130), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4130), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4140), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4140), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4140), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4140), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4150), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4150), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4150), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4160), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4160), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4160), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4160), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4170), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4170), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4170), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4180), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4180), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(4180) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 322, DateTimeKind.Utc).AddTicks(2290), new DateTime(2026, 7, 1, 10, 53, 50, 322, DateTimeKind.Utc).AddTicks(2290) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "9fac39d8-714c-4b09-98e7-925dc4c25613");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "f527c069-3a91-4bc4-935b-8c866f57e01f");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 331, DateTimeKind.Utc).AddTicks(5490), new DateTime(2026, 7, 1, 10, 53, 50, 331, DateTimeKind.Utc).AddTicks(5490) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1520), new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1520) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1730), new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1730) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1730), new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1730) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1730), new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1730) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1740), new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1740) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1740), new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1740) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1770), new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1770) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1770), new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1770) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1780), new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1780) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1780), new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1780) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1740), new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1740) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1740), new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1740) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1750), new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1750) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1750), new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1750) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1750), new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1750) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1750), new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1750) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1760), new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1760) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1760), new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1760) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1760), new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1760) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1770), new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1770) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1770), new DateTime(2026, 7, 1, 10, 53, 50, 343, DateTimeKind.Utc).AddTicks(1770) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 332, DateTimeKind.Utc).AddTicks(6530), new DateTime(2026, 7, 1, 10, 53, 50, 332, DateTimeKind.Utc).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 332, DateTimeKind.Utc).AddTicks(6630), new DateTime(2026, 7, 1, 10, 53, 50, 332, DateTimeKind.Utc).AddTicks(6630) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 332, DateTimeKind.Utc).AddTicks(6630), new DateTime(2026, 7, 1, 10, 53, 50, 332, DateTimeKind.Utc).AddTicks(6630) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 315, DateTimeKind.Utc).AddTicks(9060), new DateTime(2026, 7, 1, 10, 53, 50, 315, DateTimeKind.Utc).AddTicks(9060) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e335b39-e762-489d-b93f-a6aa0582946a", new DateTime(2026, 7, 1, 10, 53, 50, 279, DateTimeKind.Utc).AddTicks(6600), new DateTime(2026, 7, 1, 10, 53, 50, 279, DateTimeKind.Utc).AddTicks(6600), "AQAAAAIAAYagAAAAEOXyjSzWECjKsxk1GouQ3aaaq+aaFxis709QkqlXt6DzzoqMXQUso7bxv3ZtpxSWIw==", "af65fa78-1989-4379-a057-25778d39df47" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 319, DateTimeKind.Utc).AddTicks(10), new DateTime(2026, 7, 1, 10, 53, 50, 319, DateTimeKind.Utc).AddTicks(110), new Guid("0183a28b-eb0a-4b75-b23e-ecf6919502ec") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(5790), new DateTime(2026, 7, 1, 10, 53, 50, 321, DateTimeKind.Utc).AddTicks(5790) });
        }
    }
}
