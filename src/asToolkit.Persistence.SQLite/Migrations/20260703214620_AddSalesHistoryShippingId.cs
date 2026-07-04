using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asToolkit.Persistence.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class AddSalesHistoryShippingId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ShippingId",
                table: "sales_history",
                type: "TEXT",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_sales_history_ShippingId",
                table: "sales_history",
                column: "ShippingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_sales_history_ShippingId",
                table: "sales_history");

            migrationBuilder.DropColumn(
                name: "ShippingId",
                table: "sales_history");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3018), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3019) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3667), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3667) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3670), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3672), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3672) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3673), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3674) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3675), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3676) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3685), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3685) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3686), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3687) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3688), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3688) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3690), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3690) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3691), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3691) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3693), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3693) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3694), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3695) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3696), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3696) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3699), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3701), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3701) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3713), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3713) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3715), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3715) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3716), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3717) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3718), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3718) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3720), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3721), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3721) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3724), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3724) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3726), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3726) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3727), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3727) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3729), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3729) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3738), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3738) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3742), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3742) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3743), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3743) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3745), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3745) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3747), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3748) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3749), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3749) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3758), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3759) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3760), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3761) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3762), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3763) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3764), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3765) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3766), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3766) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3768), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3768) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3771), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3771) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3772), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3773) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3774), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3774) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3776), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3776) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3788), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3788) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3790), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3791), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3791) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3793), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3793) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3795), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3796) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3797), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3797) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3806), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3806) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3808), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3808) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3810), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3812), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3812) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3814), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3814) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3815), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3815) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3818), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3818) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3820), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3822), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3822) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3823), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3823) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3825), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3825) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3826), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3826) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3828), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3828) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3829), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3829) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3832), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3832) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3833), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3834) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3842), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3842) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3844), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3844) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3846), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3846) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3847), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3848) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3849), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3849) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3850), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3851) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3853), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3853) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3855), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3855) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3856), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3856) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3858), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3858) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3859), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3861), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3861) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3862), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3862) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3864), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3864) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3866), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3867) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3868), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3868) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3876), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3877) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3879), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3879) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3881), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3881) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3883), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3883) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3884), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3885) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3886), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3886) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3889), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3889) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3891), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3891) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3892), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3893) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3894), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3894) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3895), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3896) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3897), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3897) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3898), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3899) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3900), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3903), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3903) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3904), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3904) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3913), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3913) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3915), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3915) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3916), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3916) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3918), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3918) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3920), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3922), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3922) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3924), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3925) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3927), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3927) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3929), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3929) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3930), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3931) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3932), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3932) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3934), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3934) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3936), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3936) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3937), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3937) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3940), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3941), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3942) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3943), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3943) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3945), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3945) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3946), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3947) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3948), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3948) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3949), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3951), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3951) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3954), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3954) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3955), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(3955) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 864, DateTimeKind.Utc).AddTicks(3554), new DateTime(2026, 7, 3, 20, 57, 56, 864, DateTimeKind.Utc).AddTicks(3555) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "78f9ca01-5752-42e0-9ef1-c06b897bd052");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "749bccb6-21d5-4be1-966c-aa1d24a36709");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 879, DateTimeKind.Utc).AddTicks(298), new DateTime(2026, 7, 3, 20, 57, 56, 879, DateTimeKind.Utc).AddTicks(301) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9457), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9813), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9814) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9817), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9817) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9819), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9820) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9829), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9829) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9852), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9852) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9853), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9854) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9858), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9858) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9859), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9859) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9831), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9831) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9832), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9833) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9834), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9834) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9835), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9836) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9837), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9837) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9845), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9845) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9846), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9847) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9849), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9849) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9851), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9851) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9855), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9855) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9856), new DateTime(2026, 7, 3, 20, 57, 56, 899, DateTimeKind.Utc).AddTicks(9856) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 880, DateTimeKind.Utc).AddTicks(7023), new DateTime(2026, 7, 3, 20, 57, 56, 880, DateTimeKind.Utc).AddTicks(7024) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 880, DateTimeKind.Utc).AddTicks(7227), new DateTime(2026, 7, 3, 20, 57, 56, 880, DateTimeKind.Utc).AddTicks(7227) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 880, DateTimeKind.Utc).AddTicks(7229), new DateTime(2026, 7, 3, 20, 57, 56, 880, DateTimeKind.Utc).AddTicks(7229) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 856, DateTimeKind.Utc).AddTicks(1858), new DateTime(2026, 7, 3, 20, 57, 56, 856, DateTimeKind.Utc).AddTicks(1859) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a254cd74-6799-48f1-902f-0d0d31b73312", new DateTime(2026, 7, 3, 20, 57, 56, 814, DateTimeKind.Utc).AddTicks(390), new DateTime(2026, 7, 3, 20, 57, 56, 814, DateTimeKind.Utc).AddTicks(393), "AQAAAAIAAYagAAAAEPQloBXVxOJE3xmwpGSbxV8UkxxTlie6Dj/t5Cc89byunMIiePLs6uHReqoW2I3ZjQ==", "204c6310-31b3-42e0-96e9-934e59b9420d" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 861, DateTimeKind.Utc).AddTicks(2370), new DateTime(2026, 7, 3, 20, 57, 56, 861, DateTimeKind.Utc).AddTicks(2573), new Guid("df0ae092-ad6a-4486-b17b-292065973647") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(7262), new DateTime(2026, 7, 3, 20, 57, 56, 863, DateTimeKind.Utc).AddTicks(7263) });
        }
    }
}
