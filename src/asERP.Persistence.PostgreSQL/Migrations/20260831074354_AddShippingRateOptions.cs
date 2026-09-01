using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.PostgreSQL.Migrations
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
                type: "character varying(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarrierProcedure",
                table: "shipping_provider_rate",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarrierProduct",
                table: "shipping_provider_rate",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "shipping_provider_rate",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "shipping_provider_rate",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "shipping_provider_rate",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(7876), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(7891) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8748), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8748) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8751), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8751) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8752), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8753) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8754), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8754) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8763), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8763) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8765), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8765) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8766), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8767) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8768), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8768) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8769), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8771), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8771) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8773), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8773) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8774), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8774) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8777), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8778) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8779), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8779) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8780), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8781) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8789), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8791), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8791) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8793), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8793) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8794), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8794) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8796), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8796) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8798), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8799) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8800), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8801), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8802) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8803), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8803) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8820), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8821), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8822) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8823), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8823) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8824), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8825) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8827), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8827) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8829), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8829) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8830), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8838), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8838) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8840), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8841), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8842) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8843), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8843) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8844), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8845) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8847), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8848) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8849), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8849) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8851), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8851) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8852), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8852) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8853), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8854) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8855), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8855) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8856), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8856) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8858), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8858) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8860), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8862), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8862) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8863), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8863) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8871), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8871) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8872), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8872) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8874), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8874) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8875), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8876) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8877), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8877) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8880), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8881), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8881) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8883), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8883) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8884), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8884) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8885), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8886) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8887), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8887) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8888), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8888) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8889), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8893), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8893) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8895), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8895) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8896), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8896) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8904), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8904) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8906), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8906) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8907), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8908) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8909), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8909) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8910), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8911) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8913), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8914) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8915), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8915) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8916), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8916) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8918), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8918) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8919), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8919) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8921), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8921) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8922), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8922) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8923), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8924) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8926), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8926) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8928), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8928) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8929), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8929) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8937), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8937) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8938), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8939) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8940), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8941), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8942) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8943), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8943) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8946), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8946) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8947), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8948) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8949), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8949) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8950), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8951) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8952), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8952) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8953), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8954) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8955), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8955) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8956), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8957) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8959), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8959) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8961), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8961) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8962), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8962) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8970), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8971) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8972), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8972) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8974), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8974) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8975), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8975) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8977), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8977) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8980), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8981), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8981) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8983), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8983) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8984), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8985) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8986), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8986) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8987), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8987) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8989), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8989) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8990), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8993), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8993) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8994), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8994) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8996), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(8996) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9004), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9004) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9006), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9006) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9007), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9008) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9009), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9009) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9011), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9011) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9013), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9014) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9019), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9021), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9021) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9023), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9023) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9024), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9024) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9025), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9026) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9027), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9027) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9028), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9028) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9031), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9031) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9032), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9033) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9034), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9034) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9042), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9043) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9044), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9044) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9046), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9046) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9047), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9047) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9049), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9049) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9051), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9052) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9053), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9053) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9054), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9055) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9056), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9056) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9057), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9057) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9059), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9059) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9060), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9062), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9062) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9064), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9064) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9066), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9066) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9067), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9067) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9075), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9075) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9076), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9077) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9078), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9078) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9079), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9081), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9081) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9083), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9084) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9085), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9085) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9086), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9087) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9088), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9088) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9089), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9089) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9091), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9091) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9092), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9092) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9093), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9094) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9097), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9097) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9098), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9098) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9100), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9108), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9108) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9110), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9112), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9112) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9113), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9113) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9115), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9115) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9117), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9117) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9119), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9119) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9120), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9122), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9122) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9123), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9123) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9124), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9125) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9126), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9126) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9127), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9127) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9130), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9131), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9131) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9132), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9133) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9140), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9141) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9143), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9143) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9144), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9144) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9146), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9146) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9147), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9147) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9150), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9151), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9151) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9153), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9153) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9154), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9154) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9155), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9156) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9157), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9157) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9158), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9159) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9160), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9163), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9163) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9164), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9165) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9166), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9166) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9174), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9174) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9176), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9176) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9177), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9178) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9179), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9179) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9180), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9181) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9183), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9183) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9185), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9185) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9186), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9186) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9188), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9188) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9189), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9189) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9190), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9191) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9192), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9192) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9194), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9194) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9197), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9197) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9198), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9198) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9200), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9207), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9208) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9209), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9209) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9211), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9211) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9212), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9212) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9217), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9218) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9220), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9222), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9222) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9223), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9223) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9225), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9225) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9226), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9226) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9227), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9228) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9229), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9229) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9230), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9233), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9233) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9234), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9234) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9235), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9236) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9243), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9243) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9245), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9245) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9247), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9247) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9248), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9249) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9250), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9253), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9253) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9254), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9254) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9256), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9256) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9257), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9257) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9258), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9259) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9260), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9261), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9261) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9263), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9263) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9265), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9265) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9267), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9267) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9268), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9268) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9269), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9271), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9271) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9272), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9272) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9274), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9274) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9275), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9275) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9277), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9278) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9279), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9279) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9280), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9281), new DateTime(2026, 8, 31, 7, 43, 51, 989, DateTimeKind.Utc).AddTicks(9282) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 991, DateTimeKind.Utc).AddTicks(1585), new DateTime(2026, 8, 31, 7, 43, 51, 991, DateTimeKind.Utc).AddTicks(1586) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "6516b2a9-192b-49ff-848a-84f4ece20ac7");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "b94791e8-495c-4121-bc85-05028bb00932");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 3, DateTimeKind.Utc).AddTicks(6215), new DateTime(2026, 8, 31, 7, 43, 52, 3, DateTimeKind.Utc).AddTicks(6218) });

            migrationBuilder.UpdateData(
                table: "saleschannel_sync_state",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 6, DateTimeKind.Utc).AddTicks(737), new DateTime(2026, 8, 31, 7, 43, 52, 6, DateTimeKind.Utc).AddTicks(738) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 37, DateTimeKind.Utc).AddTicks(9220), new DateTime(2026, 8, 31, 7, 43, 52, 37, DateTimeKind.Utc).AddTicks(9223) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 37, DateTimeKind.Utc).AddTicks(9793), new DateTime(2026, 8, 31, 7, 43, 52, 37, DateTimeKind.Utc).AddTicks(9793) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 37, DateTimeKind.Utc).AddTicks(9797), new DateTime(2026, 8, 31, 7, 43, 52, 37, DateTimeKind.Utc).AddTicks(9798) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 37, DateTimeKind.Utc).AddTicks(9800), new DateTime(2026, 8, 31, 7, 43, 52, 37, DateTimeKind.Utc).AddTicks(9800) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 37, DateTimeKind.Utc).AddTicks(9801), new DateTime(2026, 8, 31, 7, 43, 52, 37, DateTimeKind.Utc).AddTicks(9802) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 38, DateTimeKind.Utc).AddTicks(264), new DateTime(2026, 8, 31, 7, 43, 52, 38, DateTimeKind.Utc).AddTicks(264) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 38, DateTimeKind.Utc).AddTicks(265), new DateTime(2026, 8, 31, 7, 43, 52, 38, DateTimeKind.Utc).AddTicks(265) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 38, DateTimeKind.Utc).AddTicks(269), new DateTime(2026, 8, 31, 7, 43, 52, 38, DateTimeKind.Utc).AddTicks(269) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 38, DateTimeKind.Utc).AddTicks(271), new DateTime(2026, 8, 31, 7, 43, 52, 38, DateTimeKind.Utc).AddTicks(271) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 37, DateTimeKind.Utc).AddTicks(9810), new DateTime(2026, 8, 31, 7, 43, 52, 37, DateTimeKind.Utc).AddTicks(9810) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 37, DateTimeKind.Utc).AddTicks(9812), new DateTime(2026, 8, 31, 7, 43, 52, 37, DateTimeKind.Utc).AddTicks(9812) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 37, DateTimeKind.Utc).AddTicks(9813), new DateTime(2026, 8, 31, 7, 43, 52, 37, DateTimeKind.Utc).AddTicks(9813) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 37, DateTimeKind.Utc).AddTicks(9815), new DateTime(2026, 8, 31, 7, 43, 52, 37, DateTimeKind.Utc).AddTicks(9815) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 38, DateTimeKind.Utc).AddTicks(250), new DateTime(2026, 8, 31, 7, 43, 52, 38, DateTimeKind.Utc).AddTicks(250) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 38, DateTimeKind.Utc).AddTicks(254), new DateTime(2026, 8, 31, 7, 43, 52, 38, DateTimeKind.Utc).AddTicks(254) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 38, DateTimeKind.Utc).AddTicks(255), new DateTime(2026, 8, 31, 7, 43, 52, 38, DateTimeKind.Utc).AddTicks(255) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 38, DateTimeKind.Utc).AddTicks(257), new DateTime(2026, 8, 31, 7, 43, 52, 38, DateTimeKind.Utc).AddTicks(257) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 38, DateTimeKind.Utc).AddTicks(262), new DateTime(2026, 8, 31, 7, 43, 52, 38, DateTimeKind.Utc).AddTicks(262) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 38, DateTimeKind.Utc).AddTicks(266), new DateTime(2026, 8, 31, 7, 43, 52, 38, DateTimeKind.Utc).AddTicks(267) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 38, DateTimeKind.Utc).AddTicks(268), new DateTime(2026, 8, 31, 7, 43, 52, 38, DateTimeKind.Utc).AddTicks(268) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 9, DateTimeKind.Utc).AddTicks(5597), new DateTime(2026, 8, 31, 7, 43, 52, 9, DateTimeKind.Utc).AddTicks(5599) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 9, DateTimeKind.Utc).AddTicks(5856), new DateTime(2026, 8, 31, 7, 43, 52, 9, DateTimeKind.Utc).AddTicks(5856) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 52, 9, DateTimeKind.Utc).AddTicks(5859), new DateTime(2026, 8, 31, 7, 43, 52, 9, DateTimeKind.Utc).AddTicks(5859) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 31, 7, 43, 51, 990, DateTimeKind.Utc).AddTicks(4571), new DateTime(2026, 8, 31, 7, 43, 51, 990, DateTimeKind.Utc).AddTicks(4574) });
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
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(3717), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(3722) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4440), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4465), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4465) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4467), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4467) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4469), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4469) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4472), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4472) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4473), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4473) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4476), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4476) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4478), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4478) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4479), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4479) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4482), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4483) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4484), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4485) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4497), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4497) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4499), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4499) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4500), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4511) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4512), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4513) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4514), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4514) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4515), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4515) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4518), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4518) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4519), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4519) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4521), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4521) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4522), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4522) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4523), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4524) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4525), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4525) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4527), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4527) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4531), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4532) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4534), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4534) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4536), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4536) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4544), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4544) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4553), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4553) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4559), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4560) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4561), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4561) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4562), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4562) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4564), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4564) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4566), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4567) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4568), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4568) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4569), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4569) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4571), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4571) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4572), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4572) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4573), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4573) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4575), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4575) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4576), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4576) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4578), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4579) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4580), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4580) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4587), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4588) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4589), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4589) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4590), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4591) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4592), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4592) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4593), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4593) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4596), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4596) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4598), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4599) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4600), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4601), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4601) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4603), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4603) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4604), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4604) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4605), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4606) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4607), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4607) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4608), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4609) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4611), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4611) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4613), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4613) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4620), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4621) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4622), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4622) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4623), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4623) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4625), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4625) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4626), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4626) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4628), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4628) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4630), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4631), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4632) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4633), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4633) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4634), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4634) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4636), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4636) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4637), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4637) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4638), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4639) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4641), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4641) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4643), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4644) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4645), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4645) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4652), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4652) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4654), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4654) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4655), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4655) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4657), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4657) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4658), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4658) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4659), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4662), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4662) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4663), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4664) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4665), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4665) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4666), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4666) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4667), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4668) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4669), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4669) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4670), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4672), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4672) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4674), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4674) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4676), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4676) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4683), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4683) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4685), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4685) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4686), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4686) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4692), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4692) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4693), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4694) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4695), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4695) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4698), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4699) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4700), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4701), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4701) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4703), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4703) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4704), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4704) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4705), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4706) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4707), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4707) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4708), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4708) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4711), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4711) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4712), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4712) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4720), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4721), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4722) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4723), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4723) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4724), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4724) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4726), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4726) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4727), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4727) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4730), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4732), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4732) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4733), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4733) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4734), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4734) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4736), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4736) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4737), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4737) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4738), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4738) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4740), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4743), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4744) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4745), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4745) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4753), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4753) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4755), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4755) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4756), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4757) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4758), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4758) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4759), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4759) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4761), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4761) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4763), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4763) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4764), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4764) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4766), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4766) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4767), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4767) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4768), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4769) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4770), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4771), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4771) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4773), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4773) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4775), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4775) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4776), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4777) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4784), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4785) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4786), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4786) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4788), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4788) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4790), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4791), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4791) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4793), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4794) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4796), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4796) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4797), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4798) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4799), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4799) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4800), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4801), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4802) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4803), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4803) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4804), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4804) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4805), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4806) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4808), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4808) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4810), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4817), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4817) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4819), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4819) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4820), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4821) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4822), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4822) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4823), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4823) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4825), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4825) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4827), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4827) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4829), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4829) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4830), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4831), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4832) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4833), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4833) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4834), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4834) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4837), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4837) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4838), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4838) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4841), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4841) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4842), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4842) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4850), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4851), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4851) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4853), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4853) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4854), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4854) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4855), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4856) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4857), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4857) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4859), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4861), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4861) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4862), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4862) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4864), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4864) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4865), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4865) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4866), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4867) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4868), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4868) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4869), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4872), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4872) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4873), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4873) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4878), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4879) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4886), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4886) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4888), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4888) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4889), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4889) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4892), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4892) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4893), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4893) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4895), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4896) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4897), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4897) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4898), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4898) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4900), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4901), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4901) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4902), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4902) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4904), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4904) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4905), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4905) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4908), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4908) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4909), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4909) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4910), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4911) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4918), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4918) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4920), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4921), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4921) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4922), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4923) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4924), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4924) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4926), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4927) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4928), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4928) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4929), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4929) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4931), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4931) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4932), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4932) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4933), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4934) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4936), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4936) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4937), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4937) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4940), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4941), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4941) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4942), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4943) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4950), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4952), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4952) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4953), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4953) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4955), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4955) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4956), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4956) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4959), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4959) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4960), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4962), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4962) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4963), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4963) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4964), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4964) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4966), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4966) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4967), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4967) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4968), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4969) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4971), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4971) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4972), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4972) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4974), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4974) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4982), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4982) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4983), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4983) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4986), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4986) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4987), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4987) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4988), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4989) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4991), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4991) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4992), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4993) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4994), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4994) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4995), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4995) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4997), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4997) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4998), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4998) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4999), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4999) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 498, DateTimeKind.Utc).AddTicks(6957), new DateTime(2026, 8, 28, 12, 23, 58, 498, DateTimeKind.Utc).AddTicks(6959) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "0495864f-a111-4bc7-a32b-169fc8a65775");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "4a4b0a59-d947-45ba-9699-539effa0ef6d");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 511, DateTimeKind.Utc).AddTicks(6909), new DateTime(2026, 8, 28, 12, 23, 58, 511, DateTimeKind.Utc).AddTicks(6912) });

            migrationBuilder.UpdateData(
                table: "saleschannel_sync_state",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 514, DateTimeKind.Utc).AddTicks(8958), new DateTime(2026, 8, 28, 12, 23, 58, 514, DateTimeKind.Utc).AddTicks(8961) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(8734), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(8737) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9276), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9277) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9280), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9281) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9289), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9289) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9291), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9291) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9436), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9437) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9438), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9438) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9442), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9442) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9445), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9445) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9292), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9292) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9294), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9294) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9295), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9295) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9296), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9297) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9426), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9426) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9428), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9428) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9431), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9432) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9433), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9433) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9435), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9435) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9439), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9441), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9441) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 518, DateTimeKind.Utc).AddTicks(3699), new DateTime(2026, 8, 28, 12, 23, 58, 518, DateTimeKind.Utc).AddTicks(3700) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 518, DateTimeKind.Utc).AddTicks(3898), new DateTime(2026, 8, 28, 12, 23, 58, 518, DateTimeKind.Utc).AddTicks(3898) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 518, DateTimeKind.Utc).AddTicks(3901), new DateTime(2026, 8, 28, 12, 23, 58, 518, DateTimeKind.Utc).AddTicks(3901) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 498, DateTimeKind.Utc).AddTicks(614), new DateTime(2026, 8, 28, 12, 23, 58, 498, DateTimeKind.Utc).AddTicks(616) });
        }
    }
}
