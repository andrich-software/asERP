using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.SQLite.Migrations
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
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

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
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9483), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9483) });

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
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9537), new DateTime(2026, 7, 5, 15, 7, 10, 385, DateTimeKind.Utc).AddTicks(9537) });

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
                columns: new[] { "DateCreated", "DateModified", "PushSalesCancellations" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 406, DateTimeKind.Utc).AddTicks(4472), new DateTime(2026, 7, 5, 15, 7, 10, 406, DateTimeKind.Utc).AddTicks(4476), false });

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
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7820), new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7820) });

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
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7830), new DateTime(2026, 7, 5, 15, 7, 10, 444, DateTimeKind.Utc).AddTicks(7830) });

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
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(856), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(859) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1550), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1553), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1553) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1565), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1565) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1568), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1568) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1570), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1572), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1572) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1574), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1574) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1575), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1576) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1577), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1577) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1579), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1579) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1582), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1582) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1583), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1584) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1585), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1585) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1586), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1586) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1588), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1588) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1602), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1603) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1605), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1605) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1607), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1607) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1610), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1611), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1612) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1613), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1613) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1615), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1615) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1616), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1617) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1618), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1618) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1620), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1637), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1637) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1644), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1645) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1647), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1647) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1648), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1648) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1651), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1651) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1652), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1652) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1662), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1663) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1665), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1665) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1666), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1666) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1669), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1671), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1671) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1673), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1673) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1674), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1675) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1676), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1676) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1677), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1678) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1679), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1679) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1681), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1681) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1683), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1684) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1685), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1686), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1687) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1688), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1688) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1689), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1690) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1698), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1699) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1701), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1701) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1704), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1704) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1707), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1707) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1708), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1709) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1710), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1710) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1713), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1713) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1714), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1714) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1716), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1716) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1718), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1718) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1719), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1719) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1722), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1723) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1724), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1724) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1725), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1726) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1727), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1727) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1728), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1729) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1737), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1737) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1740), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1741), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1741) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1744), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1744) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1746), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1746) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1748), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1748) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1749), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1749) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1751), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1751) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1752), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1753) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1754), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1754) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1756), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1756) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1759), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1759) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1760), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1762), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1762) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1763), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1764) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1781), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1781) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1789), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1789) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1791), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1792) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1794), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1794) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1797), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1797) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1798), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1799) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1800), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1802), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1802) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1803), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1804) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1805), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1805) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1807), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1807) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1808), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1808) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1811), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1811) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1813), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1813) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1814), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1814) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1816), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1816) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1817), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1817) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1826), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1826) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1828), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1828) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1829), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1833), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1833) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1834), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1835) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1836), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1837) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1838), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1839) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1841), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1842) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1843), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1844) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1845), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1845) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1847), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1847) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1851), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1851) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1852), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1853) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1854), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1854) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1856), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1856) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1857), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1857) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1859), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1859) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1860), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1861), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1862) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1864), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1864) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1865), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1865) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1867), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1867) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1869), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(1870) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 138, DateTimeKind.Utc).AddTicks(2680), new DateTime(2026, 7, 4, 20, 54, 54, 138, DateTimeKind.Utc).AddTicks(2681) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "85111f70-cade-4cac-b9d8-08e49591a514");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "634a5aa6-f3a4-48b0-8606-abf7ca9d7d86");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 149, DateTimeKind.Utc).AddTicks(7698), new DateTime(2026, 7, 4, 20, 54, 54, 149, DateTimeKind.Utc).AddTicks(7701) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2437), new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2810), new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2811) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2813), new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2814) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2816), new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2816) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2824), new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2824) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2840), new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2841) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2842), new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2842) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2854), new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2854) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2855), new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2855) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2826), new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2826) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2827), new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2827) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2829), new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2829) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2830), new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2831) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2832), new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2832) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2833), new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2833) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2835), new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2835) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2837), new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2838) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2839), new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2839) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2851), new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2851) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2852), new DateTime(2026, 7, 4, 20, 54, 54, 177, DateTimeKind.Utc).AddTicks(2853) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 151, DateTimeKind.Utc).AddTicks(3617), new DateTime(2026, 7, 4, 20, 54, 54, 151, DateTimeKind.Utc).AddTicks(3618) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 151, DateTimeKind.Utc).AddTicks(3815), new DateTime(2026, 7, 4, 20, 54, 54, 151, DateTimeKind.Utc).AddTicks(3815) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 151, DateTimeKind.Utc).AddTicks(3818), new DateTime(2026, 7, 4, 20, 54, 54, 151, DateTimeKind.Utc).AddTicks(3818) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 130, DateTimeKind.Utc).AddTicks(6239), new DateTime(2026, 7, 4, 20, 54, 54, 130, DateTimeKind.Utc).AddTicks(6244) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "688c663c-d642-4da9-8ab5-7f73ebfccfbf", new DateTime(2026, 7, 4, 20, 54, 54, 87, DateTimeKind.Utc).AddTicks(6862), new DateTime(2026, 7, 4, 20, 54, 54, 87, DateTimeKind.Utc).AddTicks(6866), "AQAAAAIAAYagAAAAEDh1hQKjo73g2W5LcvGK7gXp+GVKPv3clD7V1D12m6t+FrZjZC2kn2mMaKQY8aCzhw==", "060bcce2-0d5b-42aa-91a7-79c37a1a47e5" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 135, DateTimeKind.Utc).AddTicks(108), new DateTime(2026, 7, 4, 20, 54, 54, 135, DateTimeKind.Utc).AddTicks(233), new Guid("67a2e7bf-29cd-49e0-8088-0dde33483141") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(5594), new DateTime(2026, 7, 4, 20, 54, 54, 137, DateTimeKind.Utc).AddTicks(5596) });
        }
    }
}
