using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddSalesBackfillCursor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InitialSalesImportCompleted",
                table: "saleschannel",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SalesImportBackfillCursor",
                table: "saleschannel",
                type: "timestamp with time zone",
                nullable: true);

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
                columns: new[] { "DateCreated", "DateModified", "InitialSalesImportCompleted", "SalesImportBackfillCursor" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 0, 979, DateTimeKind.Utc).AddTicks(3120), new DateTime(2026, 6, 18, 19, 12, 0, 979, DateTimeKind.Utc).AddTicks(3120), false, null });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InitialSalesImportCompleted",
                table: "saleschannel");

            migrationBuilder.DropColumn(
                name: "SalesImportBackfillCursor",
                table: "saleschannel");

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
        }
    }
}
