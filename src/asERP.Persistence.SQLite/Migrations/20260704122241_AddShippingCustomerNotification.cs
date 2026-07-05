using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class AddShippingCustomerNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SendDeliveryNotificationEmails",
                table: "tenant",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SendShippingNotificationEmails",
                table: "tenant",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CustomerDeliveryNotifiedAt",
                table: "shipping",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CustomerNotifiedAt",
                table: "shipping",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(7636), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(7637) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8236), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8236) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8245), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8245) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8247), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8247) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8249), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8249) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8260), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8263), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8263) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8265), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8265) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8272), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8272) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8274), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8274) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8277), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8277) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8279), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8279) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8280), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8282), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8282) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8292), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8292) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8295), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8296) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8297), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8297) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8299), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8299) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8302), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8303) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8304), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8304) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8305), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8306) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8314), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8315) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8317), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8317) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8319), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8319) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8321), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8321) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8322), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8323) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8330), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8333), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8333) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8335), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8335) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8336), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8337) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8338), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8338) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8340), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8341), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8343), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8343) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8346), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8346) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8347), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8347) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8349), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8349) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8357), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8358) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8360), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8361) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8362), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8362) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8364), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8364) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8365), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8365) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8368), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8368) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8370), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8371), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8371) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8373), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8373) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8374), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8376), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8376) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8377), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8378) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8379), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8379) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8382), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8382) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8383), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8383) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8384), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8385) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8392), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8393) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8394), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8395) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8396), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8397) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8398), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8398) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8400), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8402), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8403) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8404), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8404) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8406), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8406) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8407), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8407) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8409), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8409) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8410), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8411) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8412), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8412) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8413), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8414) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8416), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8416) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8417), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8418) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8419), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8419) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8427), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8428) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8430), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8432), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8432) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8433), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8434) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8435), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8435) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8438), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8438) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8440), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8441), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8441) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8443), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8443) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8444), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8445) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8446), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8446) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8447), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8448) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8449), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8449) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8451), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8452) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8453), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8453) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8455), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8455) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8464), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8464) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8467), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8467) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8468), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8469) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8470), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8472), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8472) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8474), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8474) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8476), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8476) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8477), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8478) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8479), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8479) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8480), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8481) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8482), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8482) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8484), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8484) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8485), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8486) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8488), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8488) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8490), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8491), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8491) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8499), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8502), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8502) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8503), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8504) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8505), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8505) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8506), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8507) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8510), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8515), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8515) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8517), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8517) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8519), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8519) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8520), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8521) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8522), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8522) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8523), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8524) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8525), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8525) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8528), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8528) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8529), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8529) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8531), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8531) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8532), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8532) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8534), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8534) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8535), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8536) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 934, DateTimeKind.Utc).AddTicks(7536), new DateTime(2026, 7, 4, 12, 22, 38, 934, DateTimeKind.Utc).AddTicks(7536) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "61be762a-5512-4099-93f1-88a7f584b066");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "9d478fd8-fa42-44d0-974c-5bd117d2c622");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 946, DateTimeKind.Utc).AddTicks(7170), new DateTime(2026, 7, 4, 12, 22, 38, 946, DateTimeKind.Utc).AddTicks(7171) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6445), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6448) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6804), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6805) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6808), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6809) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6810), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6811) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6812), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6812) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6842), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6842) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6843), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6843) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6847), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6847) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6849), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6849) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6819), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6819) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6821), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6821) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6822), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6822) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6824), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6824) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6833), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6833) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6834), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6834) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6836), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6836) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6837), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6837) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6840), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6840) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6844), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6845) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6846), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6846) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 948, DateTimeKind.Utc).AddTicks(5872), new DateTime(2026, 7, 4, 12, 22, 38, 948, DateTimeKind.Utc).AddTicks(5873) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 948, DateTimeKind.Utc).AddTicks(6070), new DateTime(2026, 7, 4, 12, 22, 38, 948, DateTimeKind.Utc).AddTicks(6071) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 948, DateTimeKind.Utc).AddTicks(6073), new DateTime(2026, 7, 4, 12, 22, 38, 948, DateTimeKind.Utc).AddTicks(6073) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified", "SendDeliveryNotificationEmails", "SendShippingNotificationEmails" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 925, DateTimeKind.Utc).AddTicks(8180), new DateTime(2026, 7, 4, 12, 22, 38, 925, DateTimeKind.Utc).AddTicks(8187), false, false });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "256175bc-fe7e-40f9-bffe-ff425baec831", new DateTime(2026, 7, 4, 12, 22, 38, 886, DateTimeKind.Utc).AddTicks(8428), new DateTime(2026, 7, 4, 12, 22, 38, 886, DateTimeKind.Utc).AddTicks(8431), "AQAAAAIAAYagAAAAEKkEHBwbddSWIk9t6w9PQSMjmTzrkhk8ZMf7uhB5qIk8lgBpeDkusi9yg4Bb8MGrKg==", "972a717e-483f-4e67-8a8e-ecce39dd3e1e" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 931, DateTimeKind.Utc).AddTicks(7989), new DateTime(2026, 7, 4, 12, 22, 38, 931, DateTimeKind.Utc).AddTicks(8112), new Guid("4e729ad3-4a29-4176-a8eb-a0608b683ea9") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 934, DateTimeKind.Utc).AddTicks(1269), new DateTime(2026, 7, 4, 12, 22, 38, 934, DateTimeKind.Utc).AddTicks(1270) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendDeliveryNotificationEmails",
                table: "tenant");

            migrationBuilder.DropColumn(
                name: "SendShippingNotificationEmails",
                table: "tenant");

            migrationBuilder.DropColumn(
                name: "CustomerDeliveryNotifiedAt",
                table: "shipping");

            migrationBuilder.DropColumn(
                name: "CustomerNotifiedAt",
                table: "shipping");

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
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 10, 11, 17, 37, DateTimeKind.Utc).AddTicks(4463), new DateTime(2026, 7, 4, 10, 11, 17, 37, DateTimeKind.Utc).AddTicks(4467) });

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
    }
}
