using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.SQLite.Migrations
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
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SalesImportBackfillCursor",
                table: "saleschannel",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(2570), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(2570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(2970), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(2970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(2980), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(2980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(2980), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(2980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(2980), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(2980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(2990), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(2990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(2990), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(2990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(2990), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(2990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(2990), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(2990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3000), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3000), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3000), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3010), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3010), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3010), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3020), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3020), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3020), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3020), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3030), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3030), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3030), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3040), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3040), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3040), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3040), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3050), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3050), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3050), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3060), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3060), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3060), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3060), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3070), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3070), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3070), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3080), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3080), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3080), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3090), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3090), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3090), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3090), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3100), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3100), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3110), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3120), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3120), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3120), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3130), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3130), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3130), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3140), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3140), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3140), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3140), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3150), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3150), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3150), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3160), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3160), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3160), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3170), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3170), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3170), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3170), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3180), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3180), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3180), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3190), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3190), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3190), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3190), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3200), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3200), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3200), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3210), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3210), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3210), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3220), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3220), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3220), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3220), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3230), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3230), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3230), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3240), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3240), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3240), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3240), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3250), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3250), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3250), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3260), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3260), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3260), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3270), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3270), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3270), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3270), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3280), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3280), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3280), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3290), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3290), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3290), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3290), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3300), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3300), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3300), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3310), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3310), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3310), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3310), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3320), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3320), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3320), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3330), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3330), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3330), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(9810), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(9810) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "c7a930fe-d07f-495e-a2d1-2f5701b94e9a");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "87f0dab1-91e9-4120-a0c2-e2207f003637");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified", "InitialSalesImportCompleted", "SalesImportBackfillCursor" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 151, DateTimeKind.Utc).AddTicks(2440), new DateTime(2026, 6, 18, 19, 12, 5, 151, DateTimeKind.Utc).AddTicks(2440), false, null });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(7960), new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(7960) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8170), new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8170) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8170), new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8170) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8170), new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8170) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8180), new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8180) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8180), new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8180) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8220), new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8220) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8230), new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8230) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8230), new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8230) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8240), new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8240) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8180), new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8180) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8180), new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8180) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8190), new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8190) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8190), new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8190) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8190), new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8190) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8190), new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8190) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8200), new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8200) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8200), new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8200) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8200), new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8200) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8230), new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8230) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8230), new DateTime(2026, 6, 18, 19, 12, 5, 161, DateTimeKind.Utc).AddTicks(8230) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 152, DateTimeKind.Utc).AddTicks(2100), new DateTime(2026, 6, 18, 19, 12, 5, 152, DateTimeKind.Utc).AddTicks(2100) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 152, DateTimeKind.Utc).AddTicks(2210), new DateTime(2026, 6, 18, 19, 12, 5, 152, DateTimeKind.Utc).AddTicks(2210) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 152, DateTimeKind.Utc).AddTicks(2220), new DateTime(2026, 6, 18, 19, 12, 5, 152, DateTimeKind.Utc).AddTicks(2220) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 137, DateTimeKind.Utc).AddTicks(260), new DateTime(2026, 6, 18, 19, 12, 5, 137, DateTimeKind.Utc).AddTicks(260) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59e6e474-6f34-42e6-9a8a-ea6fe516f55d", new DateTime(2026, 6, 18, 19, 12, 5, 102, DateTimeKind.Utc).AddTicks(1970), new DateTime(2026, 6, 18, 19, 12, 5, 102, DateTimeKind.Utc).AddTicks(1970), "AQAAAAIAAYagAAAAEClV78SS/fBDzd2ooamJhtT7Yj7O/fku6RX2rEdZQbGZaGVzG9Eou4dBe3xm6ou8Sw==", "b15c5089-8035-497e-81c6-e80f7b1790d1" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 139, DateTimeKind.Utc).AddTicks(9300), new DateTime(2026, 6, 18, 19, 12, 5, 139, DateTimeKind.Utc).AddTicks(9400), new Guid("7bbaef66-4510-48d0-8e9b-c2e3b7bee47a") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(4910), new DateTime(2026, 6, 18, 19, 12, 5, 142, DateTimeKind.Utc).AddTicks(4910) });
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
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(330), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(740), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(750), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(750), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(750), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(760), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(760), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(760), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(760), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(770), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(770), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(770), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(780), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(780), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(780), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(790), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(790), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(790), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(800), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(800), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(800), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(800), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(810), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(810), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(810), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(820), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(820), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(820), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(820), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(830), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(830), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(830), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(840), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(840), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(840), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(850), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(850), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(850), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(850), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(860), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(860), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(860), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(870), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(870), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(870), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(880), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(880), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(880), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(880), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(890), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(890), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(890), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(900), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(900), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(900), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(910), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(910), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(910), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(910), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(920), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(920), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(920), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(930), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(930), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(930), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(940), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(940), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(940), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(940), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(950), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(950), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(950), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(960), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(960), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(960), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(970), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(970), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(980), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(980), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(980), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(990), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(990), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(990), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1000), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1000), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1000), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1000), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1010), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1010), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1010), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1020), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1020), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1020), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1030), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1030), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1030), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1030), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1040), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1040), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1040), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1050), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1050), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1050), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1060), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1060), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1060), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1060), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1070), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1070), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1070), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1080), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1080), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1080), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1090), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1090), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1090), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1090), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1100), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1100), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1100), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(1100) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 648, DateTimeKind.Utc).AddTicks(1770), new DateTime(2026, 6, 16, 20, 7, 36, 648, DateTimeKind.Utc).AddTicks(1770) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "7565dfe0-f55a-4228-abe3-9c2c91d17b88");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "a292cd4e-248f-4893-a213-76f99a06a32b");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 657, DateTimeKind.Utc).AddTicks(2790), new DateTime(2026, 6, 16, 20, 7, 36, 657, DateTimeKind.Utc).AddTicks(2790) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7200), new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7200) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7400), new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7400) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7400), new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7400) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7410), new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7410) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7410), new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7410) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7410), new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7410) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7440), new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7440), new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7450), new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7450), new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7420), new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7420) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7420), new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7420) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7420), new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7420) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7420), new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7420) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7430), new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7430), new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7430), new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7430), new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7440), new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7450), new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7450), new DateTime(2026, 6, 16, 20, 7, 36, 668, DateTimeKind.Utc).AddTicks(7450) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 658, DateTimeKind.Utc).AddTicks(3100), new DateTime(2026, 6, 16, 20, 7, 36, 658, DateTimeKind.Utc).AddTicks(3100) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 658, DateTimeKind.Utc).AddTicks(3210), new DateTime(2026, 6, 16, 20, 7, 36, 658, DateTimeKind.Utc).AddTicks(3210) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 658, DateTimeKind.Utc).AddTicks(3220), new DateTime(2026, 6, 16, 20, 7, 36, 658, DateTimeKind.Utc).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 641, DateTimeKind.Utc).AddTicks(3900), new DateTime(2026, 6, 16, 20, 7, 36, 641, DateTimeKind.Utc).AddTicks(3900) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64c5958a-3849-4b1e-9ecf-ec7e39092843", new DateTime(2026, 6, 16, 20, 7, 36, 605, DateTimeKind.Utc).AddTicks(6120), new DateTime(2026, 6, 16, 20, 7, 36, 605, DateTimeKind.Utc).AddTicks(6120), "AQAAAAIAAYagAAAAEN5Fw7QM0rB0eOmAj0Ga9iYx4P31P+F+XbtZVckDcsqbKfl7iuPANJGtT1M6FxbOLw==", "4151404b-0e9d-47fa-9ce7-6dcbac93d69f" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 644, DateTimeKind.Utc).AddTicks(6900), new DateTime(2026, 6, 16, 20, 7, 36, 644, DateTimeKind.Utc).AddTicks(6990), new Guid("9a6e08d5-b7b9-42d7-9808-5d81f754e82c") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(3920), new DateTime(2026, 6, 16, 20, 7, 36, 647, DateTimeKind.Utc).AddTicks(3920) });
        }
    }
}
