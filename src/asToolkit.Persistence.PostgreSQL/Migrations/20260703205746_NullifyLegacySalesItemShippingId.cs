using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asToolkit.Persistence.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class NullifyLegacySalesItemShippingId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Hand-edited data fix: legacy rows carry Guid.Empty because sales_item.ShippingId was
            // non-nullable before AddShippingFeature — NULL now means "not assigned to a parcel".
            migrationBuilder.Sql("UPDATE sales_item SET \"ShippingId\" = NULL WHERE \"ShippingId\" = '00000000-0000-0000-0000-000000000000'");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(8479), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(8480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9072), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9072) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9074), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9074) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9076), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9076) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9077), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9077) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9079), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9079) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9086), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9086) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9087), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9088) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9089), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9089) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9091), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9091) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9092), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9092) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9102), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9102) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9103), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9104) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9105), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9105) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9108), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9108) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9110), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9111), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9111) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9113), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9113) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9114), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9114) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9116), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9116) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9117), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9117) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9119), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9119) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9121), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9121) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9123), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9123) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9124), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9124) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9126), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9126) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9140), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9149), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9152), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9152) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9153), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9153) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9156), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9156) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9158), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9158) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9159), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9159) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9160), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9161) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9162), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9162) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9163), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9163) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9165), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9165) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9166), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9166) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9169), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9169) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9170), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9171) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9172), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9172) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9173), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9173) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9175), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9175) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9183), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9183) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9185), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9185) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9187), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9187) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9189), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9191), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9191) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9192), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9193) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9194), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9194) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9195), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9196) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9197), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9197) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9198), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9198) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9200), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9202), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9202) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9204), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9204) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9205), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9205) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9206), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9207) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9208), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9208) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9216), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9216) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9218), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9219) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9220), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9222), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9223) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9224), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9224) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9225), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9226) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9227), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9227) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9228), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9228) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9230), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9231), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9231) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9233), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9233) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9235), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9235) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9236), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9237) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9238), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9238) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9239), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9239) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9240), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9241) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9249), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9249) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9251), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9252) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9253), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9253) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9256), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9256) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9258), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9258) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9259), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9259) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9260), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9261) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9268), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9268) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9270), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9271), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9271) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9272), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9273) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9275), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9275) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9276), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9276) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9278), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9278) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9279), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9279) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9280), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9288), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9289) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9291), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9291) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9293), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9293) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9295), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9295) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9297), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9297) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9298), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9298) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9299), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9301), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9301) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9302), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9302) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9304), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9304) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9305), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9306) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9308), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9308) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9310), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9311), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9312) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9313), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9313) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9314), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9314) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9316), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9316) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9317), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9317) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9319), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9319) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9321), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9321) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9323), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9323) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9324), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9324) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9326), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9326) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9327), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9327) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9328), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9329) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9330), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9331), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9331) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9334), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9334) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9335), new DateTime(2026, 7, 3, 20, 57, 45, 6, DateTimeKind.Utc).AddTicks(9335) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 7, DateTimeKind.Utc).AddTicks(8101), new DateTime(2026, 7, 3, 20, 57, 45, 7, DateTimeKind.Utc).AddTicks(8101) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "011cafbd-7dc3-4ab9-b61a-3b924e844be4");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "bee76d34-4982-40b1-a233-538f8609c9ab");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 19, DateTimeKind.Utc).AddTicks(258), new DateTime(2026, 7, 3, 20, 57, 45, 19, DateTimeKind.Utc).AddTicks(260) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3279), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3282) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3759), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3760) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3763), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3763) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3764), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3765) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3766), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3766) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3783), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3783) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3784), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3784) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3789), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3790) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3791), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3791) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3768), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3768) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3769), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3769) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3770), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3770) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3775), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3775) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3776), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3776) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3777), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3778) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3779), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3779) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3780), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3780) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3781), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3781) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3787), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3787) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3788), new DateTime(2026, 7, 3, 20, 57, 45, 42, DateTimeKind.Utc).AddTicks(3788) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 20, DateTimeKind.Utc).AddTicks(6733), new DateTime(2026, 7, 3, 20, 57, 45, 20, DateTimeKind.Utc).AddTicks(6735) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 20, DateTimeKind.Utc).AddTicks(6937), new DateTime(2026, 7, 3, 20, 57, 45, 20, DateTimeKind.Utc).AddTicks(6938) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 20, DateTimeKind.Utc).AddTicks(6940), new DateTime(2026, 7, 3, 20, 57, 45, 20, DateTimeKind.Utc).AddTicks(6940) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 0, DateTimeKind.Utc).AddTicks(9606), new DateTime(2026, 7, 3, 20, 57, 45, 0, DateTimeKind.Utc).AddTicks(9611) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86a62128-6636-4a60-802a-a66d71a3ff50", new DateTime(2026, 7, 3, 20, 57, 44, 962, DateTimeKind.Utc).AddTicks(4025), new DateTime(2026, 7, 3, 20, 57, 44, 962, DateTimeKind.Utc).AddTicks(4028), "AQAAAAIAAYagAAAAEAhCScJjOVJmQbySJu58eNeWkDY1K6WaMja+awlYJY8sjK9wZHrLd3HeKix3CE1ROw==", "b9e564d0-1dc0-42d1-812c-e0d7b78b0f23" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 5, DateTimeKind.Utc).AddTicks(33), new DateTime(2026, 7, 3, 20, 57, 45, 5, DateTimeKind.Utc).AddTicks(149), new Guid("dcd90797-2f07-4f7d-83fc-28d08e873c33") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 20, 57, 45, 7, DateTimeKind.Utc).AddTicks(2035), new DateTime(2026, 7, 3, 20, 57, 45, 7, DateTimeKind.Utc).AddTicks(2035) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(3365), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(3367) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4138), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4139) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4142), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4142) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4143), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4144) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4145), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4146) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4147), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4147) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4149), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4149) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4170), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4172), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4172) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4174), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4174) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4176), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4176) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4178), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4178) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4179), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4179) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4181), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4181) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4183), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4183) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4186), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4187) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4188), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4188) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4190), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4191), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4192) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4193), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4195), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4195) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4196), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4197) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4198), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4198) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4210), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4212), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4212) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4214), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4214) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4223), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4224) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4232), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4232) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4234), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4234) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4235), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4236) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4237), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4237) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4240), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4242), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4242) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4244), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4244) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4245), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4245) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4247), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4247) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4248), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4249) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4250), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4252), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4252) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4262), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4263) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4265), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4265) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4267), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4267) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4268), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4269) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4270), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4272), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4272) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4273), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4274) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4275), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4275) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4278), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4278) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4280), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4282), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4282) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4283), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4283) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4285), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4285) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4286), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4288), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4288) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4290), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4301), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4301) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4303), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4304) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4305), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4305) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4307), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4307) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4309), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4309) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4311), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4311) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4312), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4313) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4314), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4314) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4317), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4317) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4319), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4319) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4320), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4321) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4322), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4322) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4324), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4324) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4325), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4326) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4327), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4327) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4329), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4329) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4339), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4339) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4342), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4342) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4344), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4344) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4345), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4346) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4347), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4347) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4349), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4349) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4350), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4351) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4352), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4352) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4355), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4355) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4357), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4357) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4359), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4359) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4361), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4361) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4362), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4362) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4364), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4364) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4366), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4366) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4367), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4368) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4378), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4378) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4389), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4389) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4391), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4391) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4392), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4393) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4394), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4394) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4396), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4396) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4398), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4398) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4399), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4399) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4402), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4402) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4404), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4404) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4406), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4406) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4407), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4408) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4409), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4409) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4411), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4412), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4413) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4414), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4414) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4424), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4425) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4427), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4427) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4429), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4431), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4431) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4433), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4434) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4435), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4436) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4437), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4437) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4439), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4439) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4443), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4443) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4445), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4445) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4447), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4447) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4448), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4448) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4450), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4451), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4452) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4453), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4453) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4455), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4455) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4458), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(4458) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 184, DateTimeKind.Utc).AddTicks(3872), new DateTime(2026, 7, 3, 19, 26, 1, 184, DateTimeKind.Utc).AddTicks(3873) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "7820520e-5846-4272-878b-dadb5a84cf1a");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "f02c90c0-fe9a-4809-90e0-8614ed9cdea0");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 196, DateTimeKind.Utc).AddTicks(7381), new DateTime(2026, 7, 3, 19, 26, 1, 196, DateTimeKind.Utc).AddTicks(7384) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7065), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7069) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7605), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7605) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7615), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7616) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7618), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7619) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7620), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7620) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7637), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7637) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7638), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7639) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7645), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7645) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7646), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7647) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7621), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7622) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7623), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7623) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7625), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7625) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7626), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7626) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7628), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7628) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7631), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7631) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7632), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7633) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7634), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7634) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7635), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7636) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7640), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7640) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7642), new DateTime(2026, 7, 3, 19, 26, 1, 217, DateTimeKind.Utc).AddTicks(7642) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 198, DateTimeKind.Utc).AddTicks(4802), new DateTime(2026, 7, 3, 19, 26, 1, 198, DateTimeKind.Utc).AddTicks(4804) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 198, DateTimeKind.Utc).AddTicks(5007), new DateTime(2026, 7, 3, 19, 26, 1, 198, DateTimeKind.Utc).AddTicks(5007) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 198, DateTimeKind.Utc).AddTicks(5009), new DateTime(2026, 7, 3, 19, 26, 1, 198, DateTimeKind.Utc).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 176, DateTimeKind.Utc).AddTicks(1170), new DateTime(2026, 7, 3, 19, 26, 1, 176, DateTimeKind.Utc).AddTicks(1175) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d41a5d8a-478d-4b9b-829f-93106348868e", new DateTime(2026, 7, 3, 19, 26, 1, 135, DateTimeKind.Utc).AddTicks(1663), new DateTime(2026, 7, 3, 19, 26, 1, 135, DateTimeKind.Utc).AddTicks(1668), "AQAAAAIAAYagAAAAEHniyIwFxc0AM2SJVv8x/LBpafuuScvjFHp2f3boofF5cHGlzbwH1V31Ui6V29DlEw==", "a59bf377-486c-4161-aec6-025e095eca5b" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 181, DateTimeKind.Utc).AddTicks(355), new DateTime(2026, 7, 3, 19, 26, 1, 181, DateTimeKind.Utc).AddTicks(479), new Guid("83afdc03-1703-4588-b265-6db2bb36637c") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(7612), new DateTime(2026, 7, 3, 19, 26, 1, 183, DateTimeKind.Utc).AddTicks(7614) });
        }
    }
}
