using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialCustomerImportCompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InitialCustomerImportCompleted",
                table: "saleschannel",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7180), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7710), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7710) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7720), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7720), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7730), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7730), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7730), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7730), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7740), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7740), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7740), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7750), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7750), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7750), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7750), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7760), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7760), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7760), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7770), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7770), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7770), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7770), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7780), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7780), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7780), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7790), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7790), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7790), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7800), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7800), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7800), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7800), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7810), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7810), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7810), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7820), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7820), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7820), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7820), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7830), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7830), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7830), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7840), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7840), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7840), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7850), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7850), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7850), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7850), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7860), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7860), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7860), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7870), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7870), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7870), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7880), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7880), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7880), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7880), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7890), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7890), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7890), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7900), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7900), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7900), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7900), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7910), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7910), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7910), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7920), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7920), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7920), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7930), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7930), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7930), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7930), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7940), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7940), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7940), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7950), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(7950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8000), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8000), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8000), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8010), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8010), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8010), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8020), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8020), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8020), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8020), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8030), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8030), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8030), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8040), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8040), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8040), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8050), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8050), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8050), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8050), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8060), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8060), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8060), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8070), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8070), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8070), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8070), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8080), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8080), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8080), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8090), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8090), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8090), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8090), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8100), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8100), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8100), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8110), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8110), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8110), new DateTime(2026, 6, 9, 20, 53, 15, 453, DateTimeKind.Utc).AddTicks(8110) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 454, DateTimeKind.Utc).AddTicks(6030), new DateTime(2026, 6, 9, 20, 53, 15, 454, DateTimeKind.Utc).AddTicks(6030) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "4232e712-43eb-4a02-8f48-d2484af3ea11");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "45971174-75d5-4194-846f-0931cbfac0c8");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified", "InitialCustomerImportCompleted" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 463, DateTimeKind.Utc).AddTicks(8470), new DateTime(2026, 6, 9, 20, 53, 15, 463, DateTimeKind.Utc).AddTicks(8470), false });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(490), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(490) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(710), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(710) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(710), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(710) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(710), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(710) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(720), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(720) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(720), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(720) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(750), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(750), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(760), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(760) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(760), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(760) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(720), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(720) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(720), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(720) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(730), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(730) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(730), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(730) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(730), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(730) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(730), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(730) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(740), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(740) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(740), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(740) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(740), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(740) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(750), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(750), new DateTime(2026, 6, 9, 20, 53, 15, 473, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 464, DateTimeKind.Utc).AddTicks(8970), new DateTime(2026, 6, 9, 20, 53, 15, 464, DateTimeKind.Utc).AddTicks(8970) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 464, DateTimeKind.Utc).AddTicks(9080), new DateTime(2026, 6, 9, 20, 53, 15, 464, DateTimeKind.Utc).AddTicks(9080) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 464, DateTimeKind.Utc).AddTicks(9090), new DateTime(2026, 6, 9, 20, 53, 15, 464, DateTimeKind.Utc).AddTicks(9090) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 447, DateTimeKind.Utc).AddTicks(7740), new DateTime(2026, 6, 9, 20, 53, 15, 447, DateTimeKind.Utc).AddTicks(7740) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "183b5ca0-bf51-4203-a9bb-2a9028ac2dc2", new DateTime(2026, 6, 9, 20, 53, 15, 411, DateTimeKind.Utc).AddTicks(1060), new DateTime(2026, 6, 9, 20, 53, 15, 411, DateTimeKind.Utc).AddTicks(1060), "AQAAAAIAAYagAAAAEOX7FnUVsehNt/CUs87bTVwSBAzhm+S8ZQ+tz+xg8F8uWqKrEc1udg85gMLM0fTuOQ==", "1a02e488-2d58-41a2-8b3f-f445013e3d33" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 451, DateTimeKind.Utc).AddTicks(2940), new DateTime(2026, 6, 9, 20, 53, 15, 451, DateTimeKind.Utc).AddTicks(3030), new Guid("2d921394-8486-4ff1-951f-ecc0494f7c3c") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 20, 53, 15, 454, DateTimeKind.Utc).AddTicks(720), new DateTime(2026, 6, 9, 20, 53, 15, 454, DateTimeKind.Utc).AddTicks(720) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InitialCustomerImportCompleted",
                table: "saleschannel");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2530), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2910), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2920), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2920), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2920), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2930), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2930), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2930), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2930), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2940), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2940), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2940), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2950), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2950), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2950), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2950), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2960), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2960), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2960), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2970), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2970), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2970), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2980), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2980), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2980), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2980), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2990), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2990), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2990), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(2990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3000), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3000), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3000), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3000), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3010), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3010), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3010), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3010), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3020), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3020), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3020), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3030), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3030), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3030), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3040), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3040), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3040), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3040), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3050), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3050), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3050), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3060), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3060), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3060), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3060), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3070), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3070), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3070), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3080), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3080), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3080), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3080), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3090), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3090), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3090), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3100), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3100), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3100), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3100), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3110), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3110), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3110), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3120), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3120), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3120), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3120), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3130), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3130), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3140), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3140), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3140), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3150), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3150), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3150), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3150), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3160), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3160), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3160), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3170), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3170), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3170), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3180), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3180), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3180), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3180), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3190), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3190), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3190), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3200), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3200), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3200), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3200), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3210), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3210), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3210), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3220), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3220), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3220), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3220), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3230), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3230), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3230), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3240), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3240), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3240), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3240), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3250), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3250), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3250), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3260), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3260), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(3260) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(9390), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(9390) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "192c8994-76a1-4d7e-acb6-27844d9d22da");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "feb3269f-d5bf-47d4-823b-cdc866dbfc75");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 430, DateTimeKind.Utc).AddTicks(6490), new DateTime(2026, 6, 9, 12, 53, 25, 430, DateTimeKind.Utc).AddTicks(6490) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5250), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5250) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5430), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5430), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5430), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5430) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5440), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5440), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5460), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5470), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5470), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5480), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5480) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5440), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5440), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5450), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5450), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5450), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5450) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5450), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5460), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5460), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5460), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5470), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5470), new DateTime(2026, 6, 9, 12, 53, 25, 438, DateTimeKind.Utc).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 431, DateTimeKind.Utc).AddTicks(5420), new DateTime(2026, 6, 9, 12, 53, 25, 431, DateTimeKind.Utc).AddTicks(5420) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 431, DateTimeKind.Utc).AddTicks(5520), new DateTime(2026, 6, 9, 12, 53, 25, 431, DateTimeKind.Utc).AddTicks(5520) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 431, DateTimeKind.Utc).AddTicks(5520), new DateTime(2026, 6, 9, 12, 53, 25, 431, DateTimeKind.Utc).AddTicks(5520) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 417, DateTimeKind.Utc).AddTicks(2990), new DateTime(2026, 6, 9, 12, 53, 25, 417, DateTimeKind.Utc).AddTicks(2990) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d5830a9-93ec-468d-84ea-4d6f7e3341ea", new DateTime(2026, 6, 9, 12, 53, 25, 383, DateTimeKind.Utc).AddTicks(3730), new DateTime(2026, 6, 9, 12, 53, 25, 383, DateTimeKind.Utc).AddTicks(3730), "AQAAAAIAAYagAAAAENpzcjuOlhNJ/eTRpylfocV8FbRIMuPgXO/0E1JpZifySnNSQ2RQXh2yVYi7Ot1R/w==", "4a534ec2-8d94-47a3-acbf-fa16de40d9a0" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 420, DateTimeKind.Utc).AddTicks(700), new DateTime(2026, 6, 9, 12, 53, 25, 420, DateTimeKind.Utc).AddTicks(780), new Guid("c1d9af72-62ff-48c3-898e-d98458613357") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(4720), new DateTime(2026, 6, 9, 12, 53, 25, 422, DateTimeKind.Utc).AddTicks(4720) });
        }
    }
}
