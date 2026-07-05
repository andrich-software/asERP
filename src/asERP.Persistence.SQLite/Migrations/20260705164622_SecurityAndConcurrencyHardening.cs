using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class SecurityAndConcurrencyHardening : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ConcurrencyToken",
                table: "shipping",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ConcurrencyToken",
                table: "saleschannel",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ConcurrencyToken",
                table: "sales",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ConcurrencyToken",
                table: "product",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(1962), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(1969) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4497), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4498) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4512), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4512) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4516), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4516) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4563), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4564) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4568), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4568) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4571), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4572) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4575), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4576) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4579), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4579) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4583), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4583) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4586), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4602) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "CountryCode", "DateCreated", "DateModified" },
                values: new object[] { "AQ", new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4606), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4606) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4653), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4653) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4656), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4657) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4660), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4663), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4664) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4667), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4667) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4676), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4676) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4680), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4681) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4684), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4684) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4690), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4691) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4694), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4694) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4697), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4698) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4701), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4702) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4714), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4715) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "CountryCode", "DateCreated", "DateModified" },
                values: new object[] { "CC", new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4723), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4723) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4727), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4727) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4730), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4731) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4757), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4757) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4761), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4761) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4764), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4764) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4767), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4768) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4772), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4772) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4775), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4776) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4779), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4779) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4782), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4783) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4789), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4789) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4792), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4793) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4796), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4797) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4800), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4803), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4804) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4806), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4807) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4810), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4813), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4814) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4838), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4839) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4842), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4842) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4845), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4846) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4849), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4849) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4852), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4853) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4856), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4856) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4859), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4863), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4863) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4870), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4873), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4874) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4877), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4877) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4880), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4881) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4884), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4884) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4887), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4888) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4891), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4891) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4894), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4895) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4919), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4923), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4923) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4926), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4926) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4929), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4933), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4933) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4937), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4937) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4940), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4941) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4944), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4944) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4950), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4951) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4954), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4954) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4958), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4958) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4961), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4962) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4965), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4965) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4968), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4969) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4972), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4972) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4975), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4976) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(4999), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5004), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5004) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5007), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5008) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5011), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5011) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5014), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5015) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5018), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5018) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5021), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5022) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5024), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5025) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5031), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5032) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5035), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5036) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5039), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5039) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5042), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5043) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5046), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5046) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5049), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5053), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5053) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5056), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5057) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5080), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5083), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5084) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5086), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5087) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5090), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5093), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5094) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5109), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5113), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5113) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5116), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5117) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5123), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5123) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5126), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5127) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5130), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5133), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5133) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5137), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5137) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5140), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5141) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5143), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5144) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5147), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5147) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5172), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5172) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5175), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5175) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5178), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5179) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5182), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5182) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5185), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5186) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5189), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5189) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5192), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5193) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5196), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5196) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5202), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5203) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5206), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5206) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5209), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5213), new DateTime(2026, 7, 5, 16, 46, 18, 223, DateTimeKind.Utc).AddTicks(5213) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 226, DateTimeKind.Utc).AddTicks(8327), new DateTime(2026, 7, 5, 16, 46, 18, 226, DateTimeKind.Utc).AddTicks(8331) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "d8dcd887-ef61-4b88-95ac-5b54135c4a7d");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "a45b8146-5118-466d-9bbe-1f571194a188");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "ConcurrencyToken", "DateCreated", "DateModified" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2026, 7, 5, 16, 46, 18, 268, DateTimeKind.Utc).AddTicks(2045), new DateTime(2026, 7, 5, 16, 46, 18, 268, DateTimeKind.Utc).AddTicks(2055) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(6752), new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(6761) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(8353), new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(8355) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(8381), new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(8382) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(8387), new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(8387) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(8391), new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(8392) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(9113), new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(9114) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(9119), new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(9119) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(9136), new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(9136) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(9140), new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(9140) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(8395), new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(8396) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(8399), new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(8400) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(8403), new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(8403) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified", "IsEncrypted" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(8446), new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(8447), true });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(9082), new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(9083) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(9094), new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(9095) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(9099), new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(9099) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified", "IsEncrypted" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(9104), new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(9105), true });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(9109), new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(9109) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(9123), new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(9124) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(9127), new DateTime(2026, 7, 5, 16, 46, 18, 366, DateTimeKind.Utc).AddTicks(9128) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 273, DateTimeKind.Utc).AddTicks(6854), new DateTime(2026, 7, 5, 16, 46, 18, 273, DateTimeKind.Utc).AddTicks(6858) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 273, DateTimeKind.Utc).AddTicks(7541), new DateTime(2026, 7, 5, 16, 46, 18, 273, DateTimeKind.Utc).AddTicks(7542) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 273, DateTimeKind.Utc).AddTicks(7549), new DateTime(2026, 7, 5, 16, 46, 18, 273, DateTimeKind.Utc).AddTicks(7551) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 202, DateTimeKind.Utc).AddTicks(9576), new DateTime(2026, 7, 5, 16, 46, 18, 202, DateTimeKind.Utc).AddTicks(9582) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f476a43d-8659-4f00-a7d5-ced07b4fce7d", new DateTime(2026, 7, 5, 16, 46, 18, 84, DateTimeKind.Utc).AddTicks(352), new DateTime(2026, 7, 5, 16, 46, 18, 84, DateTimeKind.Utc).AddTicks(366), "AQAAAAIAAYagAAAAEIzAAtefWzNSBIXHJSnbfsmCGEPjQd0QREcdexVWyBDCqV6Re0e/nu5RFVLZD5q+UQ==", "79341a5a-f490-408e-85a9-babf35d5c33b" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("77777777-7777-7777-7777-777777777701") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 16, 46, 18, 224, DateTimeKind.Utc).AddTicks(8985), new DateTime(2026, 7, 5, 16, 46, 18, 224, DateTimeKind.Utc).AddTicks(8990) });

            migrationBuilder.CreateIndex(
                name: "IX_user_tenant_Id",
                table: "user_tenant",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_stock_movement_TenantId",
                table: "stock_movement",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_saleschannel_TenantId",
                table: "saleschannel",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_item_TenantId",
                table: "sales_item",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_history_TenantId",
                table: "sales_history",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_item_TenantId",
                table: "invoice_item",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_TenantId",
                table: "invoice",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_goods_receipt_TenantId",
                table: "goods_receipt",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_country_CountryCode_TenantId",
                table: "country",
                columns: new[] { "CountryCode", "TenantId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_tenant_Id",
                table: "user_tenant");

            migrationBuilder.DropIndex(
                name: "IX_stock_movement_TenantId",
                table: "stock_movement");

            migrationBuilder.DropIndex(
                name: "IX_saleschannel_TenantId",
                table: "saleschannel");

            migrationBuilder.DropIndex(
                name: "IX_sales_item_TenantId",
                table: "sales_item");

            migrationBuilder.DropIndex(
                name: "IX_sales_history_TenantId",
                table: "sales_history");

            migrationBuilder.DropIndex(
                name: "IX_invoice_item_TenantId",
                table: "invoice_item");

            migrationBuilder.DropIndex(
                name: "IX_invoice_TenantId",
                table: "invoice");

            migrationBuilder.DropIndex(
                name: "IX_goods_receipt_TenantId",
                table: "goods_receipt");

            migrationBuilder.DropIndex(
                name: "IX_country_CountryCode_TenantId",
                table: "country");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "shipping");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "saleschannel");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "sales");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "product");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(8476), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(8481) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9450), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9452) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9454), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9455) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9457), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9457) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9459), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9459) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9461), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9462) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9472), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9472) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9474), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9474) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9476), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9477) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9479), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9479) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9481), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9481) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "CountryCode", "DateCreated", "DateModified" },
                values: new object[] { "AT", new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9483), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9483) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9485), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9486) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9488), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9488) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9492), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9493) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9495), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9495) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9513), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9514) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9516), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9516) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9519), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9519) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9521), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9522) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9524), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9524) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9526), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9526) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9530), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9532), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9533) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9535), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9535) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "CountryCode", "DateCreated", "DateModified" },
                values: new object[] { "CH", new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9537), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9537) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9558), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9559) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9563), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9563) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9565), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9565) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9567), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9567) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9571), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9572) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9573), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9574) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9586), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9587) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9590), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9593), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9593) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9595), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9595) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9597), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9598) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9600), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9604), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9604) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9606), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9607) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9609), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9609) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9611), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9611) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9613), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9613) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9615), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9615) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9617), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9618) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9619), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9624), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9624) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9626), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9626) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9638), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9639) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9642), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9643) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9645), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9646) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9648), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9648) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9650), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9652), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9653) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9657), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9657) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9659), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9659) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9661), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9662) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9664), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9664) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9666), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9666) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9668), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9668) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9670), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9672), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9673) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9676), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9676) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9678), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9679) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9690), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9691) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9694), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9695) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9697), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9698) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9700), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9702), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9702) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9724), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9724) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9728), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9728) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9730), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9731) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9733), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9733) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9735), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9735) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9737), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9737) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9739), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9741), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9742) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9743), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9744) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9747), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9747) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9749), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9761), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9762) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9765), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9766) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9768), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9768) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9770), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9773), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9773) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9775), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9775) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9779), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9779) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9781), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9781) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9783), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9784) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9785), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9786) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9788), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9788) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9790), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9792), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9792) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9794), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9795) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9798), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9799) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9800), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9801) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9812), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9812) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9815), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9816) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9818), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9818) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9820), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9821) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9823), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9823) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9826), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9826) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9831), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9832) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9834), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9834) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9836), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9836) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9838), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9839) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9841), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9841) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9844), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9844) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9846), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9847) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9849), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9849) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9852), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9853) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9854), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9855) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9857), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9857) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9859), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9859) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9861), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9862) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9863), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9864) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9865), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9866) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9868), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9868) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9872), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9872) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9874), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9874) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 387, DateTimeKind.Utc).AddTicks(4293), new DateTime(2026, 7, 5, 15, 7, 10, 387, DateTimeKind.Utc).AddTicks(4294) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "58ddeadd-65d6-46b5-ba5d-119c803dfa0d");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "17a4eb20-2414-483d-95e0-2e65033802b2");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 406, DateTimeKind.Utc).AddTicks(4472), new DateTime(2026, 7, 5, 15, 7, 10, 406, DateTimeKind.Utc).AddTicks(4476) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7284), new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7288) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7783), new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7784) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7789), new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7790) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7792), new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7793) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7811), new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7811) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7834), new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7834) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7836), new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7836) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7844), new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7845) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7846), new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7847) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7814), new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7814) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7816), new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7816) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7818), new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7818) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified", "IsEncrypted" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7820), new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7820), false });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7822), new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7822) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7824), new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7824) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7826), new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7826) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified", "IsEncrypted" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7830), new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7830), false });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7832), new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7832) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7838), new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7838) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7841), new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7841) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 408, DateTimeKind.Utc).AddTicks(7796), new DateTime(2026, 7, 5, 15, 7, 10, 408, DateTimeKind.Utc).AddTicks(7799) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 408, DateTimeKind.Utc).AddTicks(8095), new DateTime(2026, 7, 5, 15, 7, 10, 408, DateTimeKind.Utc).AddTicks(8095) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 408, DateTimeKind.Utc).AddTicks(8098), new DateTime(2026, 7, 5, 15, 7, 10, 408, DateTimeKind.Utc).AddTicks(8098) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 375, DateTimeKind.Utc).AddTicks(4605), new DateTime(2026, 7, 5, 15, 7, 10, 375, DateTimeKind.Utc).AddTicks(4611) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "336ea201-22f4-4082-aea3-c11d6ba9ba3b", new DateTime(2026, 7, 5, 15, 7, 10, 318, DateTimeKind.Utc).AddTicks(2434), new DateTime(2026, 7, 5, 15, 7, 10, 318, DateTimeKind.Utc).AddTicks(2439), "AQAAAAIAAYagAAAAEHBexgODm4W8Qu9SyztZYZv3t72yk3XXbR0a0+JFgfMeOIB/TgD2+LuAvOeLl0Qt6g==", "07000ab1-63ee-482e-9a5b-202d68c6da1e" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 382, DateTimeKind.Utc).AddTicks(6864), new DateTime(2026, 7, 5, 15, 7, 10, 382, DateTimeKind.Utc).AddTicks(7044), new Guid("cb0fc6ff-f7be-4a51-a7b2-f13786abd396") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 386, DateTimeKind.Utc).AddTicks(5108), new DateTime(2026, 7, 5, 15, 7, 10, 386, DateTimeKind.Utc).AddTicks(5109) });
        }
    }
}
