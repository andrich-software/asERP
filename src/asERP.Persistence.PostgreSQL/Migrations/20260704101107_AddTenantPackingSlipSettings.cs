using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.PostgreSQL.Migrations
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
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PackingSlipShowPrices",
                table: "tenant",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4252), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4254) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4932), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4933) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4936), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4936) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4944), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4945) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4946), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4946) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4948), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4948) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4950), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4952), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4952) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4954), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4954) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4955), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4956) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4957), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4957) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4971), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4972) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4974), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4974) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4976), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4976) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4978), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4978) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4980), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4981), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4982) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4983), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4983) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4985), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4985) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4988), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4988) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4990), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4991), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4992) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4993), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4993) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4995), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4995) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4996), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4997) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4998), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(4998) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5010), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5023), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5024) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5026), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5027) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5028), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5029) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5030), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5032), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5032) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5033), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5034) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5035), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5035) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5037), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5037) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5040), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5042), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5042) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5043), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5043) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5045), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5045) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5047), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5047) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5049), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5049) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5050), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5051) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5052), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5052) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5063), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5064) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5066), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5066) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5068), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5068) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5070), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5071), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5072) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5073), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5073) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5075), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5075) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5077), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5077) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5080), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5082), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5082) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5083), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5083) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5085), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5085) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5087), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5087) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5088), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5088) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5090), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5092), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5092) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5102), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5103) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5105), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5105) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5107), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5107) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5109), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5109) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5111), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5111) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5113), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5113) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5115), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5115) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5125), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5125) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5128), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5128) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5130), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5132), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5132) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5133), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5134) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5135), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5136) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5137), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5137) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5139), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5139) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5140), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5141) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5152), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5152) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5155), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5155) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5157), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5157) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5159), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5159) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5161), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5161) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5162), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5163) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5164), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5164) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5166), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5166) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5169), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5169) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5171), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5171) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5172), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5173) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5174), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5174) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5176), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5176) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5177), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5178) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5179), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5179) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5181), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5181) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5191), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5194), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5195) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5196), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5197) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5198), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5198) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5200), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5202), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5202) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5204), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5204) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5206), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5206) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5209), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5209) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5212), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5212) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5214), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5214) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5216), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5217) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5219), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5219) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5221), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5221) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5223), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5223) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5225), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5225) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5228), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5228) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5230), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5231) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5232), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5232) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5234), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5234) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5236), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5236) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5237), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5238) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5239), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5239) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5241), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5241) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5244), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5244) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5246), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5246) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5248), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5248) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5250), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5251), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(5252) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 129, DateTimeKind.Utc).AddTicks(4767), new DateTime(2026, 7, 4, 10, 11, 7, 129, DateTimeKind.Utc).AddTicks(4768) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "f7eb7358-45b3-4031-8215-5497c104748f");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "4bb15fe9-8e54-457e-9d9e-d752febdf7d2");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 143, DateTimeKind.Utc).AddTicks(8983), new DateTime(2026, 7, 4, 10, 11, 7, 143, DateTimeKind.Utc).AddTicks(8986) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(6961), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(6966) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7323), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7323) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7336), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7336) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7339), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7339) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7341), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7341) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7359), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7359) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7361), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7361) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7366), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7367) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7368), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7368) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7342), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7342) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7344), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7344) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7346), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7346) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7348), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7348) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7350), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7350) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7353), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7353) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7354), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7355) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7356), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7356) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7358), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7358) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7362), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7362) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7363), new DateTime(2026, 7, 4, 10, 11, 7, 164, DateTimeKind.Utc).AddTicks(7364) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 145, DateTimeKind.Utc).AddTicks(8213), new DateTime(2026, 7, 4, 10, 11, 7, 145, DateTimeKind.Utc).AddTicks(8217) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 145, DateTimeKind.Utc).AddTicks(8435), new DateTime(2026, 7, 4, 10, 11, 7, 145, DateTimeKind.Utc).AddTicks(8435) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 145, DateTimeKind.Utc).AddTicks(8438), new DateTime(2026, 7, 4, 10, 11, 7, 145, DateTimeKind.Utc).AddTicks(8438) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified", "PackingSlipPrintByDefault", "PackingSlipShowPrices" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 121, DateTimeKind.Utc).AddTicks(9256), new DateTime(2026, 7, 4, 10, 11, 7, 121, DateTimeKind.Utc).AddTicks(9262), false, false });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0626b446-dee4-42e6-9204-7fdfcad23601", new DateTime(2026, 7, 4, 10, 11, 7, 76, DateTimeKind.Utc).AddTicks(918), new DateTime(2026, 7, 4, 10, 11, 7, 76, DateTimeKind.Utc).AddTicks(920), "AQAAAAIAAYagAAAAEK0imMei94bqLHdxBFcf7DMSvYrY1uYXOaHIgN/XhlK+G4d5KAet0iRA+Op2ZXbWWw==", "c061a797-b423-4c40-a81f-5f1ee00ac855" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 126, DateTimeKind.Utc).AddTicks(3636), new DateTime(2026, 7, 4, 10, 11, 7, 126, DateTimeKind.Utc).AddTicks(3780), new Guid("20eca17c-2d7a-43ca-8ed9-98f23709d2d2") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(8190), new DateTime(2026, 7, 4, 10, 11, 7, 128, DateTimeKind.Utc).AddTicks(8191) });
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
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(1599), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(1600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2201), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2201) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2203), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2204) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2212), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2212) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2214), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2214) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2216), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2216) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2217), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2218) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2219), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2219) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2221), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2221) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2222), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2222) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2224), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2224) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2236), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2236) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2238), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2239) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2240), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2241) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2242), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2242) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2244), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2244) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2245), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2245) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2247), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2247) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2248), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2248) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2251), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2251) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2252), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2253) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2254), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2254) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2255), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2256) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2257), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2257) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2259), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2259) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2260), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2268), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2268) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2282), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2283) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2285), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2285) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2287), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2287) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2288), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2289) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2290), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2292), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2292) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2293), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2293) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2295), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2295) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2297), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2298) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2299), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2299) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2300), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2301) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2302), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2302) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2303), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2304) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2305), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2305) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2306), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2307) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2308), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2308) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2318), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2318) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2320), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2322), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2322) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2324), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2324) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2325), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2326) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2327), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2327) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2328), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2329) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2330), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2333), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2333) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2334), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2334) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2336), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2336) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2337), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2337) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2339), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2339) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2340), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2342), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2342) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2343), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2343) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2360), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2361) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2363), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2364) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2365), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2365) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2367), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2367) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2368), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2369) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2370), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2372), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2372) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2373), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2373) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2376), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2376) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2378), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2378) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2379), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2379) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2381), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2381) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2382), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2382) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2384), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2384) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2385), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2385) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2387), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2387) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2397), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2397) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2399), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2399) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2401), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2401) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2403), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2403) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2404), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2405) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2406), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2406) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2408), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2408) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2409), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2409) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2412), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2412) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2414), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2414) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2415), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2415) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2417), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2417) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2418), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2418) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2420), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2421), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2421) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2423), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2423) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2432), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2432) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2435), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2435) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2436), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2436) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2438), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2438) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2439), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2441), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2442) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2443), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2443) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2445), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2445) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2448), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2448) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2449), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2449) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2451), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2451) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2452), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2453) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2454), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2455) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2456), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2457) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2458), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2458) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2459), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2462), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2462) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2464), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2464) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2465), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2466) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2467), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2467) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2468), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2469) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2470), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2471), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2472) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2473), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2473) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2475), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2476) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2477), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2477) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2478), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2479) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2480), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2482), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(2482) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 567, DateTimeKind.Utc).AddTicks(1291), new DateTime(2026, 7, 3, 21, 46, 10, 567, DateTimeKind.Utc).AddTicks(1291) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "96713f89-7c87-4df1-b9e1-536fb6c8156c");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "dae48619-a9ee-4f93-b495-bcfb0c7a6513");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 579, DateTimeKind.Utc).AddTicks(2193), new DateTime(2026, 7, 3, 21, 46, 10, 579, DateTimeKind.Utc).AddTicks(2196) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 601, DateTimeKind.Utc).AddTicks(9492), new DateTime(2026, 7, 3, 21, 46, 10, 601, DateTimeKind.Utc).AddTicks(9505) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2191), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2191) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2200), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2200) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2204), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2204) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2207), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2207) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2234), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2234) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2236), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2236) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2247), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2247) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2249), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2250) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2209), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2210) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2212), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2212) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2214), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2215) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2217), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2217) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2219), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2220) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2224), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2224) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2227), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2227) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2229), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2229) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2231), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2232) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2238), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2239) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2242), new DateTime(2026, 7, 3, 21, 46, 10, 602, DateTimeKind.Utc).AddTicks(2243) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 581, DateTimeKind.Utc).AddTicks(743), new DateTime(2026, 7, 3, 21, 46, 10, 581, DateTimeKind.Utc).AddTicks(745) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 581, DateTimeKind.Utc).AddTicks(948), new DateTime(2026, 7, 3, 21, 46, 10, 581, DateTimeKind.Utc).AddTicks(948) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 581, DateTimeKind.Utc).AddTicks(951), new DateTime(2026, 7, 3, 21, 46, 10, 581, DateTimeKind.Utc).AddTicks(951) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 559, DateTimeKind.Utc).AddTicks(6014), new DateTime(2026, 7, 3, 21, 46, 10, 559, DateTimeKind.Utc).AddTicks(6018) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "989c8d11-a1b7-40dc-baed-74b38538ede6", new DateTime(2026, 7, 3, 21, 46, 10, 521, DateTimeKind.Utc).AddTicks(2118), new DateTime(2026, 7, 3, 21, 46, 10, 521, DateTimeKind.Utc).AddTicks(2121), "AQAAAAIAAYagAAAAEC8ntku/JBpus90iwF6t0DTXMZnrxCVixfm1v8z2KmQ7Y/qzFG20n0sf4fxkDTkGhw==", "885338b0-6ccb-41e6-bb48-e419d5c6289e" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 564, DateTimeKind.Utc).AddTicks(2329), new DateTime(2026, 7, 3, 21, 46, 10, 564, DateTimeKind.Utc).AddTicks(2449), new Guid("e1491060-4f72-43e9-878f-5f8b973295f8") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(5164), new DateTime(2026, 7, 3, 21, 46, 10, 566, DateTimeKind.Utc).AddTicks(5164) });
        }
    }
}
