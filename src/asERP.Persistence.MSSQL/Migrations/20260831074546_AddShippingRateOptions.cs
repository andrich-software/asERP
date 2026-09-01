using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.MSSQL.Migrations
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
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarrierProcedure",
                table: "shipping_provider_rate",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarrierProduct",
                table: "shipping_provider_rate",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "shipping_provider_rate",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "shipping_provider_rate",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "shipping_provider_rate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6112), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6115) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6830), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6831) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6833), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6833) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6846), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6846) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6848), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6848) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6856), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6856) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6857), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6858) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6859), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6859) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6860), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6861) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6862), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6862) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6874), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6875) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6876), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6876) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6878), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6878) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6881), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6881) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6882), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6883) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6884), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6884) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6885), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6885) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6887), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6887) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6888), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6889), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6891), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6891) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6893), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6894) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6895), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6895) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6896), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6896) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6898), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6898) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6899), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6899) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6907), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6907) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6909), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6909) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6911), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6911) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6926), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6927) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6930), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6931), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6932) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6933), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6933) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6934), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6934) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6936), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6936) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6937), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6937) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6938), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6938) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6941), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6941) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6942), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6943) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6944), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6944) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6945), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6945) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6947), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6947) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6955), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6956) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6957), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6957) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6958), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6959) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6961), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6961) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6963), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6963) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6964), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6965) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6966), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6966) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6967), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6967) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6968), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6969) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6970), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6971), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6971) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6974), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6974) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6975), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6975) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6977), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6977) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6978), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6978) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6979), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6988), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6988) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6990), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6992), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6992) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6994), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6994) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6996), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6996) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6997), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6997) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6999), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(6999) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7000), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7002), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7002) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7003), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7003) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7004), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7005) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7007), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7007) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7008), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7009) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7010), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7011), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7011) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7013), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7013) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7020), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7022), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7022) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7023), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7024) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7026), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7026) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7027), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7028) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7029), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7029) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7030), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7032), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7032) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7033), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7033) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7034), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7035) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7036), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7036) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7038), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7039) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7040), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7041), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7041) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7042), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7043) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7044), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7044) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7052), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7052) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7054), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7054) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7055), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7055) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7058), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7058) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7059), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7061), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7061) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7068), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7068) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7069), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7071), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7071) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7072), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7072) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7074), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7074) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7076), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7076) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7078), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7078) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7079), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7079) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7080), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7082), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7082) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7089), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7089) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7091), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7091) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7093), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7093) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7095), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7095) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7097), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7097) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7098), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7099) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7100), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7101), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7101) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7103), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7103) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7104), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7104) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7105), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7106) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7108), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7108) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7109), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7111), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7111) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7112), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7112) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7113), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7114) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7121), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7122) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7123), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7124) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7125), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7125) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7128), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7128) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7129), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7131), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7131) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7132), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7132) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7134), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7134) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7135), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7135) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7136), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7137) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7138), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7138) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7141), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7141) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7142), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7142) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7144), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7144) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7145), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7145) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7147), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7147) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7154), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7154) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7155), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7156) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7157), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7157) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7160), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7162), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7162) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7163), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7163) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7164), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7165) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7166), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7166) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7167), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7168) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7169), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7169) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7170), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7172), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7173) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7174), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7174) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7175), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7176) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7177), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7177) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7178), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7178) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7185), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7186) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7187), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7188) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7189), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7189) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7192), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7192) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7193), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7193) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7194), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7195) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7196), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7196) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7197), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7197) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7199), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7199) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7200), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7201), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7202) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7204), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7205) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7206), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7206) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7207), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7207) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7208), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7209) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7210), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7217), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7217) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7218), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7219) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7220), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7223), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7223) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7224), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7224) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7226), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7226) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7227), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7227) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7228), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7229) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7230), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7231), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7232) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7233), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7233) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7235), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7236) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7237), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7237) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7238), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7238) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7239), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7241), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7241) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7248), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7249) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7251), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7251) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7253), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7253) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7261), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7261) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7262), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7262) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7264), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7264) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7265), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7265) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7266), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7267) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7268), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7268) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7269), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7269) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7271), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7271) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7273), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7273) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7274), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7275) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7276), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7276) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7277), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7277) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7278), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7279) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7286), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7287) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7288), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7288) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7289), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7292), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7292) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7294), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7294) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7295), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7295) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7296), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7297) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7298), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7298) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7299), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7299) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7301), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7301) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7302), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7302) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7305), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7305) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7306), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7306) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7307), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7307) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7309), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7309) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7310), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7318), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7318) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7319), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7319) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7321), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7321) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7324), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7324) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7325), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7326) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7327), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7327) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7328), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7328) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7330), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7331), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7331) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7332), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7333) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7334), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7334) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7336), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7337) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7338), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7338) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7339), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7339) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7340), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7341) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7342), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7342) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7349), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7349) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7351), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7351) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7352), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7353) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7355), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7355) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7356), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7357) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7358), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7358) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7359), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7359) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7361), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7361) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7362), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7362) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7363), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7364) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7365), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7365) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7367), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7367) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7369), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7369) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7370), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7371), new DateTime(2026, 8, 31, 7, 45, 46, 18, DateTimeKind.Utc).AddTicks(7372) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 19, DateTimeKind.Utc).AddTicks(9081), new DateTime(2026, 8, 31, 7, 45, 46, 19, DateTimeKind.Utc).AddTicks(9083) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "61bc8879-e199-496f-947c-3eab8d62c7f0");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "08f2b623-8e34-46e9-85d0-8b0d3173d53f");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 32, DateTimeKind.Utc).AddTicks(8658), new DateTime(2026, 8, 31, 7, 45, 46, 32, DateTimeKind.Utc).AddTicks(8660) });

            migrationBuilder.UpdateData(
                table: "saleschannel_sync_state",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 35, DateTimeKind.Utc).AddTicks(1537), new DateTime(2026, 8, 31, 7, 45, 46, 35, DateTimeKind.Utc).AddTicks(1538) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(1761), new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(1765) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2347), new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2347) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2349), new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2350) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2352), new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2352) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2353), new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2354) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2513), new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2513) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2514), new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2515) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2519), new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2519) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2521), new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2521) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2355), new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2355) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2363), new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2364) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2365), new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2365) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2366), new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2367) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2503), new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2504) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2505), new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2505) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2507), new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2507) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2508), new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2508) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2510), new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2510) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2516), new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2516) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2517), new DateTime(2026, 8, 31, 7, 45, 46, 68, DateTimeKind.Utc).AddTicks(2517) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 38, DateTimeKind.Utc).AddTicks(6288), new DateTime(2026, 8, 31, 7, 45, 46, 38, DateTimeKind.Utc).AddTicks(6289) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 38, DateTimeKind.Utc).AddTicks(6521), new DateTime(2026, 8, 31, 7, 45, 46, 38, DateTimeKind.Utc).AddTicks(6521) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 38, DateTimeKind.Utc).AddTicks(6524), new DateTime(2026, 8, 31, 7, 45, 46, 38, DateTimeKind.Utc).AddTicks(6524) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 45, 46, 19, DateTimeKind.Utc).AddTicks(2237), new DateTime(2026, 8, 31, 7, 45, 46, 19, DateTimeKind.Utc).AddTicks(2239) });
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
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(2887), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(2894) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3670), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3672), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3672) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3674), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3675) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3677), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3677) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3679), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3679) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3680), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3680) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3682), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3682) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3686), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3686) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3688), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3688) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3706), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3706) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3710), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3712), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3712) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3713), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3713) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3715), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3715) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3716), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3717) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3720), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3721), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3722) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3723), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3723) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3724), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3725) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3726), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3726) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3727), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3728) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3729), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3729) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3730), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3731) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3733), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3733) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3735), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3735) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3745), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3745) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3747), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3747) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3748), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3748) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3770), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3776), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3776) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3778), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3778) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3781), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3781) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3782), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3782) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3784), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3784) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3787), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3787) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3788), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3788) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3790), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3792), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3792) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3793), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3794) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3796), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3796) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3798), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3798) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3806), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3807) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3808), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3809) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3810), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3812), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3812) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3813), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3813) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3815), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3815) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3817), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3818) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3819), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3819) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3820), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3821) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3822), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3822) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3823), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3824) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3825), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3825) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3826), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3826) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3828), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3828) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3831), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3831) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3833), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3833) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3842), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3843) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3846), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3846) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3847), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3847) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3849), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3849) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3850), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3852), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3852) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3855), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3855) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3856), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3856) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3858), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3858) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3859), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3882), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3882) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3884), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3884) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3885), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3885) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3886), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3887) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3889), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3889) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3891), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3891) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3899), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3901), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3901) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3903), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3903) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3904), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3904) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3906), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3906) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3907), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3907) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3910), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3911), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3911) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3913), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3913) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3915), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3916) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3917), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3917) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3919), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3919) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3920), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3922), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3922) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3925), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3925) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3926), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3926) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3934), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3934) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3936), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3936) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3937), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3937) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3939), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3939) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3940), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3941) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3942), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3942) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3945), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3945) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3946), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3947) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3948), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3948) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3950), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3951), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3951) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3952), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3953) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3954), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3954) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3955), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3956) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3958), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3958) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3960), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3968), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3968) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3971), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3971) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3972), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3973) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3974), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3974) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3975), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3976) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3977), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3977) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3980), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3981), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3981) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3983), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3983) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3984), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3985) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3986), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3986) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3988), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3988) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3989), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3989) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3991), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3991) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3994), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3994) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3995), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3995) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4003), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4003) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4005), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4005) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4006), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4007) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4008), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4008) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4009), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4011), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4011) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4013), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4014) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4015), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4015) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4017), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4017) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4019), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4019) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4021), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4021) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4022), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4022) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4024), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4024) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4025), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4025) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4028), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4028) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4030), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4037), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4038) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4039), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4039) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4041), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4041) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4042), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4043) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4044), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4044) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4045), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4046) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4048), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4048) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4049), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4051), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4051) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4052), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4053) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4054), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4054) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4055), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4056) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4057), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4057) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4058), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4059) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4061), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4061) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4062), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4063) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4071), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4071) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4072), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4073) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4074), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4074) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4075), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4076) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4077), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4077) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4078), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4079) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4081), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4081) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4082), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4083) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4089), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4091), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4091) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4093), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4093) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4094), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4094) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4096), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4096) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4097), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4097) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4100), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4101), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4101) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4109), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4109) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4111), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4111) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4113), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4113) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4114), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4115) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4116), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4116) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4117), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4118) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4120), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4122), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4122) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4124), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4124) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4125), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4125) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4127), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4127) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4128), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4128) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4130), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4131), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4131) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4134), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4134) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4135), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4135) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4144), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4145) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4147), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4147) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4148), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4149) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4150), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4152), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4152) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4153), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4153) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4156), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4156) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4157), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4158) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4159), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4159) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4160), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4162), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4162) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4163), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4163) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4165), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4165) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4166), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4166) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4169), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4169) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4172), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4172) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4180), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4182), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4182) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4184), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4184) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4185), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4186) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4187), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4187) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4189), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4189) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4191), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4191) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4193), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4208), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4208) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4210), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4211), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4212) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4213), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4213) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4214), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4215) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4216), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4216) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4219), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4219) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4220), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4229), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4229) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4231), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4231) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4232), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4233) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4234), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4234) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4235), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4236) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4237), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4237) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4240), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4241), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4241) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4243), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4243) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4244), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4244) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4246), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4246) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4247), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4247) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4249), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4249) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4250), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4252), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4253) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4254), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4254) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4262), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4262) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4264), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4264) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4266), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4266) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4267), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4267) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4269), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4269) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4270), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4271) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4273), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4273) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4275), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4275) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4276), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4276) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4278), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4278) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4279), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4279) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4281), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4281) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4282), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4282) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4283), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4284) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4287), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 195, DateTimeKind.Utc).AddTicks(8308), new DateTime(2026, 8, 28, 12, 24, 54, 195, DateTimeKind.Utc).AddTicks(8309) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "56e23761-b31b-4dbb-8068-8c9bdd58b6b6");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "2b45f7c7-4836-4361-975e-7d5178e59d48");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 213, DateTimeKind.Utc).AddTicks(9527), new DateTime(2026, 8, 28, 12, 24, 54, 213, DateTimeKind.Utc).AddTicks(9531) });

            migrationBuilder.UpdateData(
                table: "saleschannel_sync_state",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 216, DateTimeKind.Utc).AddTicks(5039), new DateTime(2026, 8, 28, 12, 24, 54, 216, DateTimeKind.Utc).AddTicks(5040) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(1972), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(1974) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2863), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2863) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2866), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2867) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2868), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2868) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2882), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2882) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3157), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3157) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3159), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3159) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3164), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3164) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3165), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3166) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2884), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2884) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2885), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2886) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2887), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2887) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2889), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2889) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3144), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3145) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3147), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3147) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3149), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3149) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3154), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3154) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3156), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3156) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3160), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3161) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3162), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3162) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 222, DateTimeKind.Utc).AddTicks(3023), new DateTime(2026, 8, 28, 12, 24, 54, 222, DateTimeKind.Utc).AddTicks(3024) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 222, DateTimeKind.Utc).AddTicks(3411), new DateTime(2026, 8, 28, 12, 24, 54, 222, DateTimeKind.Utc).AddTicks(3411) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 222, DateTimeKind.Utc).AddTicks(3415), new DateTime(2026, 8, 28, 12, 24, 54, 222, DateTimeKind.Utc).AddTicks(3415) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 194, DateTimeKind.Utc).AddTicks(6493), new DateTime(2026, 8, 28, 12, 24, 54, 194, DateTimeKind.Utc).AddTicks(6496) });
        }
    }
}
