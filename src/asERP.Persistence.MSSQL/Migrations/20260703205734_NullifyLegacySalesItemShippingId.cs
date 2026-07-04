using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class NullifyLegacySalesItemShippingId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Hand-edited data fix: legacy rows carry Guid.Empty because sales_item.ShippingId was
            // non-nullable before AddShippingFeature — NULL now means "not assigned to a parcel".
            migrationBuilder.Sql("UPDATE sales_item SET [ShippingId] = NULL WHERE [ShippingId] = '00000000-0000-0000-0000-000000000000'");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(3438), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(3440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4039), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4052), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4052) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4054), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4054) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4055), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4056) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4057), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4057) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4059), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4059) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4060), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4064), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4064) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4066), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4066) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4067), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4068) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4069), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4069) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4070), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4072), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4072) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4073), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4073) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4075), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4075) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4078), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4079), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4079) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4088), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4089) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4090), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4091) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4093), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4093) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4094), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4094) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4096), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4096) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4097), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4097) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4100), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4101), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4102) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4113), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4113) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4116), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4116) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4117), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4117) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4119), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4119) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4120), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4122), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4122) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4124), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4124) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4126), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4126) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4134), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4134) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4137), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4137) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4138), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4138) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4139), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4141), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4141) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4142), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4143) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4145), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4145) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4146), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4147) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4148), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4148) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4149), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4151), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4151) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4152), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4152) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4154), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4154) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4155), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4156) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4158), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4158) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4159), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4167), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4167) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4169), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4171), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4171) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4172), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4173) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4174), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4174) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4175), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4176) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4178), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4178) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4180), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4181), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4181) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4183), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4183) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4184), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4184) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4185), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4186) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4187), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4187) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4188), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4188) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4191), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4191) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4192), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4200), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4201) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4203), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4203) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4204), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4204) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4206), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4206) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4207), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4207) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4208), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4209) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4211), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4211) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4212), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4213) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4214), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4214) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4215), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4216) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4217), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4217) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4218), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4218) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4229), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4229) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4230), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4231) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4233), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4233) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4235), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4235) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4243), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4244) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4245), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4245) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4247), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4247) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4248), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4249) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4250), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4251), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4251) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4254), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4254) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4255), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4256) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4257), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4257) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4258), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4258) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4260), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4261), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4261) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4262), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4263) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4264), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4264) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4266), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4267) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4268), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4268) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4276), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4277) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4279), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4281), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4281) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4283), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4283) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4284), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4285) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4286), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4286) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4289), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4289) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4291), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4291) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4292), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4292) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4294), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4295) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4296), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4296) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4297), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4297) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4299), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4299) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4300), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4303), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4303) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4304), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4304) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4306), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4306) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4307), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4307) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4308), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4308) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4310), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4311), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4311) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4312), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(4313) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 234, DateTimeKind.Utc).AddTicks(3155), new DateTime(2026, 7, 3, 20, 57, 18, 234, DateTimeKind.Utc).AddTicks(3155) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "4df72fa1-9290-449a-bc42-0754bc1ca637");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "155c8811-b525-4506-9bb5-db9a1c4f7ebc");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 247, DateTimeKind.Utc).AddTicks(4915), new DateTime(2026, 7, 3, 20, 57, 18, 247, DateTimeKind.Utc).AddTicks(4917) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(4554), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(4556) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5025), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5026) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5028), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5029) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5031), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5032) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5041), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5041) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5057), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5057) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5058), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5058) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5075), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5075) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5076), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5076) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5043), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5043) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5044), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5044) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5045), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5046) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5047), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5047) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5049), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5049) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5050), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5051), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5051) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5054), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5054) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5056), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5056) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5072), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5072) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5073), new DateTime(2026, 7, 3, 20, 57, 18, 269, DateTimeKind.Utc).AddTicks(5074) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 249, DateTimeKind.Utc).AddTicks(748), new DateTime(2026, 7, 3, 20, 57, 18, 249, DateTimeKind.Utc).AddTicks(749) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 249, DateTimeKind.Utc).AddTicks(950), new DateTime(2026, 7, 3, 20, 57, 18, 249, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 249, DateTimeKind.Utc).AddTicks(953), new DateTime(2026, 7, 3, 20, 57, 18, 249, DateTimeKind.Utc).AddTicks(953) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 225, DateTimeKind.Utc).AddTicks(6832), new DateTime(2026, 7, 3, 20, 57, 18, 225, DateTimeKind.Utc).AddTicks(6834) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d6f8b6b-6328-4087-952c-11fdd69ff001", new DateTime(2026, 7, 3, 20, 57, 18, 187, DateTimeKind.Utc).AddTicks(2899), new DateTime(2026, 7, 3, 20, 57, 18, 187, DateTimeKind.Utc).AddTicks(2902), "AQAAAAIAAYagAAAAEJhkT3eGOeMjYIaTDTSDFR/LhlsAbyNlPcOHyetSo+LupPoTP2Ay+H62S8NbYe5+TQ==", "a1deda5d-ab57-4cf9-86f2-43b1fd07ddd0" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 231, DateTimeKind.Utc).AddTicks(4121), new DateTime(2026, 7, 3, 20, 57, 18, 231, DateTimeKind.Utc).AddTicks(4242), new Guid("0bdb7627-3f8b-4150-9513-289bf153c75c") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(7042), new DateTime(2026, 7, 3, 20, 57, 18, 233, DateTimeKind.Utc).AddTicks(7043) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2227), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2228) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2824), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2824) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2828), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2829), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2838), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2839) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2840), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2842), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2842) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2843), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2844) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2845), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2845) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2847), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2847) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2848), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2849) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2850), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2853), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2853) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2854), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2855) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2866), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2867) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2868), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2869) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2870), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2872), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2872) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2874), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2874) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2875), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2876) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2878), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2878) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2880), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2881), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2881) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2892), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2892) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2894), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2894) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2895), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2895) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2903), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2903) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2912), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2912) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2915), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2915) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2916), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2916) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2925), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2926) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2928), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2928) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2929), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2929) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2931), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2932) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2933), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2933) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2935), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2935) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2938), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2938) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2940), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2941), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2941) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2942), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2943) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2944), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2944) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2946), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2946) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2947), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2947) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2949), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2949) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2951), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2951) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2953), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2953) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2961), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2962) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2964), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2965) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2967), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2967) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2968), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2968) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2970), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2971), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2971) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2974), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2974) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2975), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2976) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2977), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2977) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2979), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2979) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2980), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2982), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2982) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2983), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2983) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2984), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2985) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2987), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2987) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2989), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2989) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2997), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(2997) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3000), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3001), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3001) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3003), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3003) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3005), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3005) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3006), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3006) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3009), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3009) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3011), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3011) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3012), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3012) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3014), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3014) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3016), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3016) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3017), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3017) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3019), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3019) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3020), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3023), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3023) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3024), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3025) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3033), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3033) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3036), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3036) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3037), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3037) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3039), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3039) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3041), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3041) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3042), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3042) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3045), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3045) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3047), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3047) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3048), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3049) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3050), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3052), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3052) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3053), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3053) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3055), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3055) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3056), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3056) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3059), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3059) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3060), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3069), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3069) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3072), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3072) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3073), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3073) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3075), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3075) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3076), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3077) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3078), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3078) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3081), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3081) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3083), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3084) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3085), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3086) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3087), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3087) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3089), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3089) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3091), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3091) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3093), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3093) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3095), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3095) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3097), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3098) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3099), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3099) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3100), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3101) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3102), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3102) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3103), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3103) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3105), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3105) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3106), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3106) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3108), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3108) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3114), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3114) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3115), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3115) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3117), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3117) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3118), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(3118) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 821, DateTimeKind.Utc).AddTicks(2213), new DateTime(2026, 7, 3, 19, 25, 28, 821, DateTimeKind.Utc).AddTicks(2214) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "8e71e8e0-2915-49e6-945d-43efc1781b65");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "829fadb0-0aeb-4741-a310-6ec041f66f88");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 832, DateTimeKind.Utc).AddTicks(7052), new DateTime(2026, 7, 3, 19, 25, 28, 832, DateTimeKind.Utc).AddTicks(7056) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4477), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4479) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4915), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4915) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4918), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4918) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4920), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4920) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4921), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4922) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4944), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4944) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4946), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4946) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4950), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4950) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4952), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4952) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4923), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4923) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4931), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4931) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4933), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4933) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4934), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4934) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4935), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4936) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4937), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4937) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4939), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4939) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4940), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4940) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4941), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4942) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4947), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4947) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4949), new DateTime(2026, 7, 3, 19, 25, 28, 853, DateTimeKind.Utc).AddTicks(4949) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 834, DateTimeKind.Utc).AddTicks(3092), new DateTime(2026, 7, 3, 19, 25, 28, 834, DateTimeKind.Utc).AddTicks(3094) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 834, DateTimeKind.Utc).AddTicks(3303), new DateTime(2026, 7, 3, 19, 25, 28, 834, DateTimeKind.Utc).AddTicks(3304) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 834, DateTimeKind.Utc).AddTicks(3306), new DateTime(2026, 7, 3, 19, 25, 28, 834, DateTimeKind.Utc).AddTicks(3306) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 813, DateTimeKind.Utc).AddTicks(4304), new DateTime(2026, 7, 3, 19, 25, 28, 813, DateTimeKind.Utc).AddTicks(4308) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a75d9d13-eb9d-446b-a79e-045e2c3ba148", new DateTime(2026, 7, 3, 19, 25, 28, 774, DateTimeKind.Utc).AddTicks(1818), new DateTime(2026, 7, 3, 19, 25, 28, 774, DateTimeKind.Utc).AddTicks(1821), "AQAAAAIAAYagAAAAEL4XxQI3HHUkm08zg0alyEc7A4YlxGTo/+Mb6yY7F/bFeTh1vc/CRe9YZ0yNnU+f/g==", "a87e5690-3e7f-4f7b-a2da-452c1a6ccfe3" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 818, DateTimeKind.Utc).AddTicks(3153), new DateTime(2026, 7, 3, 19, 25, 28, 818, DateTimeKind.Utc).AddTicks(3280), new Guid("1528bed9-5ea6-4c6c-b274-9e5e569aca1f") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(5911), new DateTime(2026, 7, 3, 19, 25, 28, 820, DateTimeKind.Utc).AddTicks(5911) });
        }
    }
}
