using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class AddShippingRateOptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarrierParticipation",
                table: "shipping_provider_rate",
                type: "TEXT",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarrierProcedure",
                table: "shipping_provider_rate",
                type: "TEXT",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarrierProduct",
                table: "shipping_provider_rate",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "shipping_provider_rate",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "shipping_provider_rate",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "shipping_provider_rate",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(6377), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(6384) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7337), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7337) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7341), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7341) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7344), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7344) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7346), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7346) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7348), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7348) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7350), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7375), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7375) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7380), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7382), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7382) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7384), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7384) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7387), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7387) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7389), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7389) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7407), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7407) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7409), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7409) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7410), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7411) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7414), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7414) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7416), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7416) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7418), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7418) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7420), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7422), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7422) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7424), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7424) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7425), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7426) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7436), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7436) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7442), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7442) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7444), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7444) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7446), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7446) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7448), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7448) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7449), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7456), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7457) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7461), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7461) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7463), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7463) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7466), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7466) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7468), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7468) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7470), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7473), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7473) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7474), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7475) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7476), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7476) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7478), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7479) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7489), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7489) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7492), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7492) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7494), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7494) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7495), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7496) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7497), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7498) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7499), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7501), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7501) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7523), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7523) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7525), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7525) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7528), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7528) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7530), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7532), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7532) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7534), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7534) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7535), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7536) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7537), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7537) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7539), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7539) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7549), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7549) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7552), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7552) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7554), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7554) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7556), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7556) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7558), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7559) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7560), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7561) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7562), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7562) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7564), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7564) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7565), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7566) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7569), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7569) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7570), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7571) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7572), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7572) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7574), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7574) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7575), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7576) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7577), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7577) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7579), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7579) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7589), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7589) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7592), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7593) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7594), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7594) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7596), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7596) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7598), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7598) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7600), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7601), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7602) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7603), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7603) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7605), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7605) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7608), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7609) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7610), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7612), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7612) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7614), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7614) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7616), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7618), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7618) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7620), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7629), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7633), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7633) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7635), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7635) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7636), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7637) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7638), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7639) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7640), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7640) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7642), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7642) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7644), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7644) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7645), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7646) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7649), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7649) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7651), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7651) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7652), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7653) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7654), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7654) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7656), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7656) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7657), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7658) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7659), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7659) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7669), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7669) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7672), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7672) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7674), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7674) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7676), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7676) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7678), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7678) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7681), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7681) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7683), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7683) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7685), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7685) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7686), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7687) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7689), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7690) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7691), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7692) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7693), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7693) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7695), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7695) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7696), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7697) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7698), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7698) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7699), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7709), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7709) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7712), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7712) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7714), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7714) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7716), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7716) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7718), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7718) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7719), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7721), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7722) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7723), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7724) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7725), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7725) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7728), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7728) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7730), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7732), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7732) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7733), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7734) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7736), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7736) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7738), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7738) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7740), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7750), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7753), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7753) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7755), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7756) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7757), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7757) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7763), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7763) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7765), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7765) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7767), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7767) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7769), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7769) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7771), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7771) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7774), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7774) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7776), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7776) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7777), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7777) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7779), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7779) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7781), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7781) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7782), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7784), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7784) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7794), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7794) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7797), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7797) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7799), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7799) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7801), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7801) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7803), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7804) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7805), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7805) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7807), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7807) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7809), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7809) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7810), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7813), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7814) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7815), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7815) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7817), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7817) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7819), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7819) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7821), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7821) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7822), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7823) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7824), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7824) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7834), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7834) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7837), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7837) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7839), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7839) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7840), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7841) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7842), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7842) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7844), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7844) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7846), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7846) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7848), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7848) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7849), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7852), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7853) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7854), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7854) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7857), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7857) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7859), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7859) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7861), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7861) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7862), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7862) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7864), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7864) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7874), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7874) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7877), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7877) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7879), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7879) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7881), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7881) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7882), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7883) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7884), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7884) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7886), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7886) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7888), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7888) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7889), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7889) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7892), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7893) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7894), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7894) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7896), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7896) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7897), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7898) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7899), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7899) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7901), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7901) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7902), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7903) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7912), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7912) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7915), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7915) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7917), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7917) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7920), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7922), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7922) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7924), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7924) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7925), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7926) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7927), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7927) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7929), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7933), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7933) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7934), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7934) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7936), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7936) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7937), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7937) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7939), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7939) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7940), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7942), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7942) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7950), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7953), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7953) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7955), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7955) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7956), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7957) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7958), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7958) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7960), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7961), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7962) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7963), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7963) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7965), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7965) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7968), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7968) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7969), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7969) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7971), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7971) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7972), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7973) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7974), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7974) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7975), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7976) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7977), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7977) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7985), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7986) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7988), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7988) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7994), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7995) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7996), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7996) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7998), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7998) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7999), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(7999) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8001), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8001) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8002), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8003) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8004), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8004) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8007), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8007) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8008), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8008) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8010), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8011), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8011) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8013), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8013) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8014), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8015) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8016), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8016) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8017), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8017) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8020), new DateTime(2026, 8, 31, 7, 46, 14, 76, DateTimeKind.Utc).AddTicks(8020) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 78, DateTimeKind.Utc).AddTicks(585), new DateTime(2026, 8, 31, 7, 46, 14, 78, DateTimeKind.Utc).AddTicks(586) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "b32f1a8d-63e9-4f73-9fdb-f78d0790cbe7");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "041f445d-dfdb-4aef-ad4c-0efc81c7765f");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 91, DateTimeKind.Utc).AddTicks(1800), new DateTime(2026, 8, 31, 7, 46, 14, 91, DateTimeKind.Utc).AddTicks(1803) });

            migrationBuilder.UpdateData(
                table: "saleschannel_sync_state",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 93, DateTimeKind.Utc).AddTicks(7530), new DateTime(2026, 8, 31, 7, 46, 14, 93, DateTimeKind.Utc).AddTicks(7532) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(3878), new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(3881) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4420), new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4420) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4422), new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4423) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4426), new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4426) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4427), new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4427) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4581), new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4581) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4582), new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4582) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4588), new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4588) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4589), new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4590) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4429), new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4429) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4431), new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4431) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4432), new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4432) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4436), new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4436) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4573), new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4573) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4575), new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4575) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4576), new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4576) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4578), new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4578) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4579), new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4579) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4585), new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4585) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4586), new DateTime(2026, 8, 31, 7, 46, 14, 128, DateTimeKind.Utc).AddTicks(4587) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 97, DateTimeKind.Utc).AddTicks(2078), new DateTime(2026, 8, 31, 7, 46, 14, 97, DateTimeKind.Utc).AddTicks(2080) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 97, DateTimeKind.Utc).AddTicks(2312), new DateTime(2026, 8, 31, 7, 46, 14, 97, DateTimeKind.Utc).AddTicks(2312) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 97, DateTimeKind.Utc).AddTicks(2314), new DateTime(2026, 8, 31, 7, 46, 14, 97, DateTimeKind.Utc).AddTicks(2314) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 46, 14, 77, DateTimeKind.Utc).AddTicks(3689), new DateTime(2026, 8, 31, 7, 46, 14, 77, DateTimeKind.Utc).AddTicks(3691) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarrierParticipation",
                table: "shipping_provider_rate");

            migrationBuilder.DropColumn(
                name: "CarrierProcedure",
                table: "shipping_provider_rate");

            migrationBuilder.DropColumn(
                name: "CarrierProduct",
                table: "shipping_provider_rate");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "shipping_provider_rate");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "shipping_provider_rate");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "shipping_provider_rate");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 571, DateTimeKind.Utc).AddTicks(9605), new DateTime(2026, 8, 28, 12, 25, 10, 571, DateTimeKind.Utc).AddTicks(9611) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(380), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(391), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(391) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(393), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(393) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(395), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(395) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(397), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(397) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(408), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(408) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(411), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(411) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(413), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(413) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(415), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(415) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(419), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(419) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(421), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(421) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(422), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(423) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(424), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(424) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(425), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(427), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(427) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(429), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(429) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(430), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(433), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(435), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(435) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(436), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(436) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(438), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(438) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(446), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(446) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(448), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(448) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(449), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(452), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(452) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(455), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(455) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(456), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(457) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(458), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(458) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(476), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(477) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(480), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(482), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(482) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(483), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(483) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(485), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(485) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(487), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(488) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(489), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(489) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(491), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(491) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(492), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(492) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(501), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(501) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(503), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(503) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(504), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(505) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(506), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(506) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(628), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(629) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(630), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(631) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(632), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(632) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(634), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(634) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(636), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(636) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(637), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(638) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(639), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(639) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(642), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(642) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(645), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(645) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(646), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(648), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(648) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(649), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(658), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(658) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(660), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(661), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(662) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(663), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(663) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(666), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(666) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(667), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(668) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(669), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(669) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(671), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(671) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(672), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(672) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(674), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(674) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(675), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(675) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(677), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(677) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(679), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(680) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(681), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(681) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(682), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(682) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(684), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(684) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(692), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(692) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(694), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(694) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(695), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(696) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(697), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(697) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(700), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(701), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(701) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(703), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(703) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(704), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(705) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(706), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(706) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(708), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(708) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(709), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(709) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(711), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(711) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(713), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(714) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(715), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(715) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(716), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(717) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(718), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(718) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(726), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(726) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(728), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(728) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(730), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(731), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(731) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(734), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(734) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(736), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(736) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(737), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(737) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(739), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(739) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(740), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(742), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(742) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(743), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(743) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(746), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(746) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(749), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(749) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(750), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(752), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(752) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(753), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(753) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(762), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(762) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(764), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(764) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(765), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(766) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(767), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(767) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(770), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(771), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(772) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(773), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(773) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(774), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(775) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(776), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(776) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(778), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(778) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(779), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(779) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(781), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(781) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(783), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(784) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(785), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(785) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(786), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(787) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(788), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(788) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(796), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(796) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(798), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(798) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(799), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(799) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(802), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(802) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(806), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(806) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(807), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(807) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(809), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(809) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(810), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(811) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(813), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(813) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(815), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(815) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(816), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(816) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(818), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(818) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(821), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(821) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(822), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(822) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(823), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(824) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(825), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(825) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(833), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(834) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(841), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(841) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(842), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(843) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(844), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(844) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(847), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(847) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(849), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(849) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(850), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(852), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(852) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(853), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(853) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(855), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(855) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(857), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(857) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(858), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(859) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(861), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(861) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(863), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(863) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(864), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(865) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(866), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(866) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(874), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(875) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(876), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(876) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(878), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(878) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(879), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(879) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(882), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(882) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(884), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(884) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(885), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(885) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(887), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(887) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(888), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(888) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(890), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(891), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(891) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(893), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(893) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(896), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(896) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(897), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(897) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(898), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(899) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(900), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(909), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(909) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(912), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(912) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(913), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(914) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(915), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(915) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(918), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(918) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(919), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(921), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(921) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(922), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(923) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(924), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(924) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(926), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(926) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(927), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(927) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(929), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(929) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(931), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(932) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(933), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(933) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(934), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(935) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(936), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(936) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(944), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(944) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(946), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(946) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(947), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(948) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(949), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(949) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(952), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(952) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(953), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(954) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(955), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(955) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(957), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(957) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(958), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(958) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(961), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(961) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(962), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(962) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(964), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(964) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(967), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(967) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(968), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(968) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(970), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(971), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(971) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(979), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(979) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(981), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(981) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(982), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(983) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(984), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(984) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(987), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(987) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(988), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(989) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(990), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(991), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(992) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(993), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(993) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(994), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(995) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(996), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(996) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(998), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(998) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1000), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1001) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1002), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1002) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1003), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1003) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1005), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1005) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1013), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1013) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1015), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1015) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1016), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1017) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1018), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1018) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1021), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1021) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1022), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1023) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1024), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1024) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1026), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1026) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1027), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1027) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1029), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1029) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1030), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1032), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1032) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1034), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1035) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1036), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1036) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1043), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1043) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1045), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1045) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1053), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1054) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1056), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1056) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1057), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1058) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1059), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1059) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1062), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1062) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1063), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1063) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1065), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1065) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1066), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1066) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1069), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1069) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1070), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1072), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1072) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1073), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1073) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1076), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1076) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1078), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1079), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1079) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1081), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1081) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1082), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1083), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1084) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1085), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1085) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 573, DateTimeKind.Utc).AddTicks(4029), new DateTime(2026, 8, 28, 12, 25, 10, 573, DateTimeKind.Utc).AddTicks(4031) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "7369fd7c-7a1d-4a08-9840-b9faf76fd9ee");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "852a57d6-0f25-4d90-bd43-5f96dea9655e");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 584, DateTimeKind.Utc).AddTicks(9078), new DateTime(2026, 8, 28, 12, 25, 10, 584, DateTimeKind.Utc).AddTicks(9082) });

            migrationBuilder.UpdateData(
                table: "saleschannel_sync_state",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 587, DateTimeKind.Utc).AddTicks(4049), new DateTime(2026, 8, 28, 12, 25, 10, 587, DateTimeKind.Utc).AddTicks(4053) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3214), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3218) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3790), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3790) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3794), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3794) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3796), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3796) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3804), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3804) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3961), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3962) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3963), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3963) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3967), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3968) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3969), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3969) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3805), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3806) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3807), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3807) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3808), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3809) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3810), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3810) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3950), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3951) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3952), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3953) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3954), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3955) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3958), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3958) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3960), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3960) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3964), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3965) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3966), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3966) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 590, DateTimeKind.Utc).AddTicks(8730), new DateTime(2026, 8, 28, 12, 25, 10, 590, DateTimeKind.Utc).AddTicks(8731) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 590, DateTimeKind.Utc).AddTicks(8951), new DateTime(2026, 8, 28, 12, 25, 10, 590, DateTimeKind.Utc).AddTicks(8951) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 590, DateTimeKind.Utc).AddTicks(8953), new DateTime(2026, 8, 28, 12, 25, 10, 590, DateTimeKind.Utc).AddTicks(8953) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(7143), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(7146) });
        }
    }
}
