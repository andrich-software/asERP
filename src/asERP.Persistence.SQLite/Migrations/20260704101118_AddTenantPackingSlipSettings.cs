using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class AddTenantPackingSlipSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PackingSlipPrintByDefault",
                table: "tenant",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PackingSlipShowPrices",
                table: "tenant",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(6310), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(6311) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7022), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7023) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7026), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7026) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7028), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7028) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7030), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7037), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7037) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7039), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7039) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7052), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7052) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7066), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7066) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7068), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7069) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7070), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7072), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7072) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7074), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7074) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7078), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7078) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7080), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7083), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7084) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7086), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7086) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7087), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7087) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7089), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7089) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7091), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7091) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7092), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7093) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7096), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7096) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7097), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7098) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7108), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7109) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7111), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7112) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7114), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7114) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7119), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7119) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7122), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7123) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7124), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7125) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7127), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7128) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7129), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7129) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7131), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7131) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7133), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7133) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7134), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7135) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7136), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7136) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7138), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7138) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7139), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7143), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7143) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7144), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7145) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7154), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7155) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7157), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7157) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7159), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7159) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7161), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7161) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7162), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7163) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7164), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7164) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7167), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7168) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7169), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7169) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7171), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7171) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7173), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7173) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7174), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7176), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7177) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7178), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7178) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7180), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7183), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7183) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7185), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7185) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7195), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7196) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7198), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7198) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7200), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7202), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7202) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7204), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7204) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7206), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7206) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7209), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7209) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7211), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7211) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7212), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7213) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7214), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7214) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7216), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7216) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7218), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7218) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7220), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7234), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7234) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7238), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7238) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7239), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7249), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7252), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7252) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7254), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7255) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7257), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7257) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7258), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7259) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7260), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7263), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7264) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7265), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7265) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7267), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7267) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7269), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7269) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7271), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7271) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7272), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7272) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7274), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7274) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7276), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7276) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7279), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7279) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7280), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7281) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7290), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7291) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7294), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7294) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7296), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7296) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7298), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7298) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7299), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7301), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7302) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7305), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7305) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7307), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7307) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7308), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7309) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7310), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7312), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7312) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7314), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7314) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7315), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7316) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7317), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7317) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7320), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7322), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7322) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7332), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7333) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7335), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7335) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7337), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7337) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7339), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7339) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7341), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7341) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7343), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7343) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7346), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7346) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7348), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7348) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7350), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7352), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7352) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7353), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7353) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7355), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7355) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7357), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7357) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7358), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7359) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7362), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7362) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7363), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7364) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7365), new DateTime(2026, 7, 4, 10, 11, 17, 44, DateTimeKind.Utc).AddTicks(7366) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 45, DateTimeKind.Utc).AddTicks(7941), new DateTime(2026, 7, 4, 10, 11, 17, 45, DateTimeKind.Utc).AddTicks(7942) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "95d95e44-b800-4b2c-9f3a-6051acbc364e");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "facf0ca3-06cd-4897-99b3-d386f17131b7");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 59, DateTimeKind.Utc).AddTicks(62), new DateTime(2026, 7, 4, 10, 11, 17, 59, DateTimeKind.Utc).AddTicks(66) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9489), new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9490) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9870), new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9871) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9874), new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9874) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9876), new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9876) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9878), new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9878) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9901), new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9902) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9905), new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9905) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9909), new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9909) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9911), new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9911) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9879), new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9879) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9881), new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9881) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9890), new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9890) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9892), new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9892) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9893), new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9894) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9895), new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9895) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9897), new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9897) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9898), new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9899) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9900), new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9900) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9906), new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9906) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9908), new DateTime(2026, 7, 4, 10, 11, 17, 81, DateTimeKind.Utc).AddTicks(9908) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 60, DateTimeKind.Utc).AddTicks(8354), new DateTime(2026, 7, 4, 10, 11, 17, 60, DateTimeKind.Utc).AddTicks(8355) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 60, DateTimeKind.Utc).AddTicks(8589), new DateTime(2026, 7, 4, 10, 11, 17, 60, DateTimeKind.Utc).AddTicks(8590) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 60, DateTimeKind.Utc).AddTicks(8603), new DateTime(2026, 7, 4, 10, 11, 17, 60, DateTimeKind.Utc).AddTicks(8603) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified", "PackingSlipPrintByDefault", "PackingSlipShowPrices" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 37, DateTimeKind.Utc).AddTicks(4463), new DateTime(2026, 7, 4, 10, 11, 17, 37, DateTimeKind.Utc).AddTicks(4467), false, false });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "112a1561-31bd-4885-8d51-7bec837e97d2", new DateTime(2026, 7, 4, 10, 11, 16, 993, DateTimeKind.Utc).AddTicks(3538), new DateTime(2026, 7, 4, 10, 11, 16, 993, DateTimeKind.Utc).AddTicks(3543), "AQAAAAIAAYagAAAAEHq2DyQZEFzMhb15qRs7XALz6an8B93BxP7Tw7fKE4XXecZ6tc3hbW/OvlWHna52rg==", "f2c40fd6-904f-47b2-bcc6-797686553345" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 42, DateTimeKind.Utc).AddTicks(4381), new DateTime(2026, 7, 4, 10, 11, 17, 42, DateTimeKind.Utc).AddTicks(4520), new Guid("21df051d-2c82-4848-82d3-4c566b900d51") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 45, DateTimeKind.Utc).AddTicks(677), new DateTime(2026, 7, 4, 10, 11, 17, 45, DateTimeKind.Utc).AddTicks(678) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PackingSlipPrintByDefault",
                table: "tenant");

            migrationBuilder.DropColumn(
                name: "PackingSlipShowPrices",
                table: "tenant");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8184), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8186) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8789), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8789) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8791), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8792) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8793), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8793) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8795), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8795) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8797), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8797) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8798), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8799) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8800), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8801), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8802) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8805), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8805) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8806), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8806) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8821), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8821) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8822), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8822) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8824), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8824) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8825), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8825) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8826), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8826) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8837), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8837) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8839), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8839) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8841), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8841) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8842), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8842) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8844), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8844) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8845), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8846) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8847), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8847) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8848), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8849) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8850), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8853), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8853) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8868), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8868) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8871), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8872) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8873), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8873) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8874), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8875) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8876), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8876) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8877), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8878) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8885), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8886) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8889), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8889) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8891), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8891) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8893), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8893) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8894), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8895) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8896), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8896) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8897), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8897) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8899), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8899) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8900), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8903), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8903) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8905), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8905) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8906), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8906) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8908), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8908) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8909), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8909) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8910), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8912), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8912) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8919), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8923), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8923) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8925), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8925) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8927), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8927) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8928), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8929) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8930), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8932), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8932) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8933), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8933) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8934), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8935) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8937), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8937) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8939), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8939) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8940), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8941), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8942) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8943), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8943) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8944), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8944) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8946), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8946) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8954), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8954) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8957), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8958) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8959), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8959) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8961), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8961) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8962), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8963) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8964), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8964) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8966), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8966) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8967), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8967) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8969), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8969) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8971), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8971) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8973), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8973) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8974), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8974) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8976), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8976) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8977), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8977) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8979), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8979) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8980), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8988), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8988) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8991), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8991) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8993), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8993) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8995), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8995) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8997), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8997) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8998), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(8998) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9000), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9001), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9002) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9003), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9003) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9006), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9006) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9007), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9008) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9009), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9009) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9010), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9012), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9012) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9013), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9013) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9014), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9015) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9022), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9023) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9026), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9026) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9028), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9028) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9029), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9031), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9031) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9032), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9033) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9034), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9034) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9036), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9036) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9037), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9037) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9045), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9045) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9046), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9046) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9048), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9048) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9049), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9051), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9051) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9053), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9053) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9054), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9054) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9055), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9055) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9058), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9058) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9059), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9061), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9061) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9062), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9062) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9064), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9064) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9065), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9065) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9067), new DateTime(2026, 7, 3, 21, 46, 19, 494, DateTimeKind.Utc).AddTicks(9067) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 495, DateTimeKind.Utc).AddTicks(8082), new DateTime(2026, 7, 3, 21, 46, 19, 495, DateTimeKind.Utc).AddTicks(8083) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "c253747d-1850-4dcc-aa04-ab40b6edc006");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "a05d8621-e0a8-4a15-8c0c-4cf2ddea5c9f");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 506, DateTimeKind.Utc).AddTicks(4960), new DateTime(2026, 7, 3, 21, 46, 19, 506, DateTimeKind.Utc).AddTicks(4961) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(3906), new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(3908) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4224), new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4225) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4227), new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4227) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4235), new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4235) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4236), new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4236) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4252), new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4252) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4253), new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4253) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4257), new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4257) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4259), new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4259) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4238), new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4238) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4239), new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4239) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4240), new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4240) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4242), new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4242) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4243), new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4243) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4244), new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4245) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4247), new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4248) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4249), new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4249) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4250), new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4250) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4254), new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4254) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4255), new DateTime(2026, 7, 3, 21, 46, 19, 525, DateTimeKind.Utc).AddTicks(4256) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 507, DateTimeKind.Utc).AddTicks(9092), new DateTime(2026, 7, 3, 21, 46, 19, 507, DateTimeKind.Utc).AddTicks(9093) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 507, DateTimeKind.Utc).AddTicks(9283), new DateTime(2026, 7, 3, 21, 46, 19, 507, DateTimeKind.Utc).AddTicks(9283) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 507, DateTimeKind.Utc).AddTicks(9285), new DateTime(2026, 7, 3, 21, 46, 19, 507, DateTimeKind.Utc).AddTicks(9285) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 488, DateTimeKind.Utc).AddTicks(4147), new DateTime(2026, 7, 3, 21, 46, 19, 488, DateTimeKind.Utc).AddTicks(4152) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd295485-d7b7-4725-bcc5-ec86773dcadd", new DateTime(2026, 7, 3, 21, 46, 19, 447, DateTimeKind.Utc).AddTicks(3821), new DateTime(2026, 7, 3, 21, 46, 19, 447, DateTimeKind.Utc).AddTicks(3824), "AQAAAAIAAYagAAAAEHTUePG3b8pckdaTFiELLj9FPBCj+PkIMKIgZuUMCN6EtGt4N+YHnAw30JS5lMZMqQ==", "c729b363-7ed0-4fdb-b3df-3ff3968c8afd" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 492, DateTimeKind.Utc).AddTicks(8570), new DateTime(2026, 7, 3, 21, 46, 19, 492, DateTimeKind.Utc).AddTicks(8696), new Guid("b20857e1-6709-4da2-b552-936739823b15") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 19, 495, DateTimeKind.Utc).AddTicks(2208), new DateTime(2026, 7, 3, 21, 46, 19, 495, DateTimeKind.Utc).AddTicks(2208) });
        }
    }
}
