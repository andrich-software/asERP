using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddSalesChannelPushSalesCancellations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PushSalesCancellations",
                table: "saleschannel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(4660), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(4662) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5749), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5749) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5753), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5754) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5763), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5763) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5765), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5766) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5768), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5768) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5770), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5785), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5786) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5788), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5789) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5791), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5791) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5793), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5793) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5797), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5798) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5800), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5802), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5802) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5804), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5804) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5806), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5806) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5808), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5808) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5810), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5812), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5812) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5816), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5816) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5818), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5818) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5821), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5821) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5823), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5823) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5835), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5836) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5838), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5839) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5840), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5841) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5858), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5858) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5865), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5866) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5868), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5868) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5870), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5872), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5872) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5874), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5874) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5876), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5876) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5878), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5878) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5880), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5884), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5884) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5886), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5886) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5888), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5888) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5890), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5902), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5903) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5906), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5907) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5909), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5909) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5911), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5912) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5916), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5916) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5918), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5918) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5920), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5922), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5922) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5924), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5924) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5926), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5927) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5928), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5929) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5930), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5931) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5934), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5935) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5936), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5937) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5938), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5939) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5940), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5941) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5953), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5954) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5958), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5958) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5961), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5961) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5963), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5963) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5967), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5967) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5969), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5969) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5971), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5972) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5973), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5974) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5976), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5976) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5978), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5978) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5980), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5982), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5982) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5986), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5986) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5988), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5988) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5990), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5992), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(5993) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6004), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6005) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6008), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6008) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6023), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6023) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6025), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6025) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6029), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6029) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6031), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6031) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6033), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6033) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6035), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6035) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6037), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6038) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6040), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6041), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6042) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6043), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6044) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6047), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6048) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6049), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6051), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6052) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6053), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6054) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6065), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6066) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6068), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6069) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6071), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6071) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6073), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6073) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6077), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6077) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6079), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6079) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6081), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6082) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6084), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6084) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6086), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6086) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6088), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6088) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6090), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6092), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6092) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6096), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6096) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6098), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6098) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6100), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6102), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6102) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6114), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6115) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6118), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6119) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6120), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6121) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6123), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6123) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6127), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6127) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6129), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6132), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6132) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6134), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6134) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6136), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6137) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6139), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6139) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6141), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6141) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6143), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6143) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6147), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6147) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6149), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6149) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6151), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6152) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6153), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6154) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6155), new DateTime(2026, 7, 5, 15, 6, 10, 323, DateTimeKind.Utc).AddTicks(6156) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 325, DateTimeKind.Utc).AddTicks(2917), new DateTime(2026, 7, 5, 15, 6, 10, 325, DateTimeKind.Utc).AddTicks(2919) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "e0234318-68d6-49ff-83cb-c6b9e5089418");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "a2066c86-8e0e-423b-a213-e0779558c78c");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified", "PushSalesCancellations" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 343, DateTimeKind.Utc).AddTicks(1046), new DateTime(2026, 7, 5, 15, 6, 10, 343, DateTimeKind.Utc).AddTicks(1049), false });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(6491), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(6495) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7301), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7302) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7307), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7307) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7309), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7310) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7312), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7312) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7355), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7355) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7357), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7358) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7366), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7366) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7368), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7368) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7314), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7314) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7316), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7317) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7318), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7319) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7324), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7325) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7344), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7345) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7346), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7347) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7349), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7349) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7351), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7351) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7353), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7353) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7361), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7362) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7364), new DateTime(2026, 7, 5, 15, 6, 10, 382, DateTimeKind.Utc).AddTicks(7364) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 345, DateTimeKind.Utc).AddTicks(5136), new DateTime(2026, 7, 5, 15, 6, 10, 345, DateTimeKind.Utc).AddTicks(5139) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 345, DateTimeKind.Utc).AddTicks(5435), new DateTime(2026, 7, 5, 15, 6, 10, 345, DateTimeKind.Utc).AddTicks(5435) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 345, DateTimeKind.Utc).AddTicks(5439), new DateTime(2026, 7, 5, 15, 6, 10, 345, DateTimeKind.Utc).AddTicks(5439) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 312, DateTimeKind.Utc).AddTicks(6632), new DateTime(2026, 7, 5, 15, 6, 10, 312, DateTimeKind.Utc).AddTicks(6637) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86ec02a9-906a-4f43-8568-59e9caa80ba0", new DateTime(2026, 7, 5, 15, 6, 10, 255, DateTimeKind.Utc).AddTicks(6491), new DateTime(2026, 7, 5, 15, 6, 10, 255, DateTimeKind.Utc).AddTicks(6495), "AQAAAAIAAYagAAAAEJdVzSxT8rI4RJt8F62DNwS10EZBnP2tRWPbMrl7/lLypkshrK7v3TQKALPO+fvjkA==", "ceb307d7-e0a2-4a55-9303-8dfaa9828ae6" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 320, DateTimeKind.Utc).AddTicks(6897), new DateTime(2026, 7, 5, 15, 6, 10, 320, DateTimeKind.Utc).AddTicks(7078), new Guid("08b68f00-4d8b-473b-9166-fcb74e453b7f") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 6, 10, 324, DateTimeKind.Utc).AddTicks(915), new DateTime(2026, 7, 5, 15, 6, 10, 324, DateTimeKind.Utc).AddTicks(916) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PushSalesCancellations",
                table: "saleschannel");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5073), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5079) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5784), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5784) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5788), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5788) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5790), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5799), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5799) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5801), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5801) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5802), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5803) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5804), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5804) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5805), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5806) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5807), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5807) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5809), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5809) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5811), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5811) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5814), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5814) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5815), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5816) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5828), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5829) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5831), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5831) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5833), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5833) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5834), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5834) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5836), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5836) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5837), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5838) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5840), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5842), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5842) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5843), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5845), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5845) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5846), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5847) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5848), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5848) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5864), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5864) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5867), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5867) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5870), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5871), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5871) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5880), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5881) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5883), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5883) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5885), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5885) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5886), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5887) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5888), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5888) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5890), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5893), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5893) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5894), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5894) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5896), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5896) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5897), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5897) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5899), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5900), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5902), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5902) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5903), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5903) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5906), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5906) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5908), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5908) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5916), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5917) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5919), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5921), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5922) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5923), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5924) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5925), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5925) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5927), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5927) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5929), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5931), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5931) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5932), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5933) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5934), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5934) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5935), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5936) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5937), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5937) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5938), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5939) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5940), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5944), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5944) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5946), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5946) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5947), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5947) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5974), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5974) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5976), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5976) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5978), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5978) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5979), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5979) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5981), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5981) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5984), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5984) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5985), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5985) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5987), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5987) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5988), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5988) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5990), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5991), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5992) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5993), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5993) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5994), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5995) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5997), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5998) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5999), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5999) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6000), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6001) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6009), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6012), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6012) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6013), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6014) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6015), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6015) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6017), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6017) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6019), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6021), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6021) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6022), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6023) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6024), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6024) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6025), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6026) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6027), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6027) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6028), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6029) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6030), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6033), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6033) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6034), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6034) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6036), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6036) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6044), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6045) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6047), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6047) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6049), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6049) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6050), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6052), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6052) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6055), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6056) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6057), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6057) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6059), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6059) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6061), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6061) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6063), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6063) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6064), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6064) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6066), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6066) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6067), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6068) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6070), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6072), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6072) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6073), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6073) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6075), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6075) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6076), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6077) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6078), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6078) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6079), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6081), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6081) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6083), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6084) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6085), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6085) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6086), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6087) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6088), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6088) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 340, DateTimeKind.Utc).AddTicks(6366), new DateTime(2026, 7, 4, 20, 53, 57, 340, DateTimeKind.Utc).AddTicks(6366) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "43504ce8-5a5d-4f3d-ad1a-c0fb66fb17bd");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "263cc9cd-66a4-468e-9493-793f87f042b2");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 357, DateTimeKind.Utc).AddTicks(7311), new DateTime(2026, 7, 4, 20, 53, 57, 357, DateTimeKind.Utc).AddTicks(7314) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1236), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1614), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1614) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1617), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1617) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1618), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1618) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1620), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1620) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1642), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1642) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1643), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1643) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1647), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1647) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1649), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1649) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1621), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1622) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1629), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1630) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1631), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1631) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1632), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1632) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1634), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1634) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1635), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1635) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1636), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1637) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1638), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1638) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1639), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1639) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1645), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1645) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1646), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1646) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 360, DateTimeKind.Utc).AddTicks(1372), new DateTime(2026, 7, 4, 20, 53, 57, 360, DateTimeKind.Utc).AddTicks(1374) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 360, DateTimeKind.Utc).AddTicks(1697), new DateTime(2026, 7, 4, 20, 53, 57, 360, DateTimeKind.Utc).AddTicks(1698) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 360, DateTimeKind.Utc).AddTicks(1701), new DateTime(2026, 7, 4, 20, 53, 57, 360, DateTimeKind.Utc).AddTicks(1701) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 331, DateTimeKind.Utc).AddTicks(2954), new DateTime(2026, 7, 4, 20, 53, 57, 331, DateTimeKind.Utc).AddTicks(2959) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc3732dd-58de-40ed-8e43-09344d93d7c0", new DateTime(2026, 7, 4, 20, 53, 57, 284, DateTimeKind.Utc).AddTicks(268), new DateTime(2026, 7, 4, 20, 53, 57, 284, DateTimeKind.Utc).AddTicks(271), "AQAAAAIAAYagAAAAEO2yosTBmMJF5puDfaTCyMSpWKLfNPACe3dbcn/a/Oguk9sDVajO5uPATde/sxoejA==", "d96ef203-51d7-4f81-8367-56b330c914ce" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 337, DateTimeKind.Utc).AddTicks(1290), new DateTime(2026, 7, 4, 20, 53, 57, 337, DateTimeKind.Utc).AddTicks(1524), new Guid("2d3bece8-33e4-4ae4-b0e0-85cb491527d0") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 340, DateTimeKind.Utc).AddTicks(70), new DateTime(2026, 7, 4, 20, 53, 57, 340, DateTimeKind.Utc).AddTicks(71) });
        }
    }
}
