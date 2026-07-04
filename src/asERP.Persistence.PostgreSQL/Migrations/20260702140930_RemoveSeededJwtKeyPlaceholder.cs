using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSeededJwtKeyPlaceholder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666614"));

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(6588), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(6589) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7193), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7193) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7196), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7196) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7198), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7199) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7208), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7210), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7211), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7212) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7213), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7213) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7214), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7215) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7216), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7216) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7218), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7218) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7219), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7219) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7223), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7223) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7224), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7225) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7226), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7226) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7227), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7228) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7229), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7229) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7240), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7241) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7243), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7244) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7246), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7246) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7249), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7249) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7251), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7251) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7252), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7252) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7254), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7254) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7255), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7255) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7257), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7257) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7269), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7269) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7273), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7273) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7276), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7276) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7278), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7278) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7279), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7279) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7281), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7281) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7282), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7282) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7291), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7292) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7294), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7294) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7296), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7296) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7299), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7299) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7300), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7301) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7302), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7302) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7303), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7304) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7305), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7305) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7306), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7307) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7308), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7308) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7309), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7312), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7312) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7314), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7314) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7315), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7315) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7316), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7317) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7318), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7318) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7327), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7328) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7330), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7332), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7332) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7334), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7335) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7336), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7336) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7338), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7338) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7339), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7339) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7341), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7341) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7343), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7343) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7344), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7344) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7346), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7346) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7348), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7348) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7350), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7351), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7351) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7353), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7353) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7354), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7355) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7363), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7363) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7365), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7366) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7367), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7367) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7370), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7371), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7371) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7373), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7373) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7374), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7374) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7376), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7376) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7377), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7377) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7379), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7379) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7388), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7389) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7391), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7391) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7392), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7393) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7394), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7394) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7395), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7396) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7397), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7397) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7405), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7406) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7407), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7407) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7409), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7409) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7412), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7412) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7413), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7415), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7415) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7416), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7416) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7418), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7418) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7419), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7419) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7421), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7421) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7422), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7422) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7425), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7425) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7426), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7426) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7428), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7428) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7429), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7429) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7431), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7431) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7439), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7442), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7442) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7443), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7443) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7446), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7446) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7447), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7448) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7449), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7449) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7451), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7451) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7453), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7453) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7455), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7455) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7456), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7456) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7458), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7458) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7461), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7461) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7463), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7463) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7464), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7464) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7466), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7466) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7467), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7468) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7469), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7469) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7470), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7472), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7472) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7474), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7474) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7476), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7476) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7477), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7477) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7479), new DateTime(2026, 7, 2, 14, 9, 30, 2, DateTimeKind.Utc).AddTicks(7479) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 3, DateTimeKind.Utc).AddTicks(6689), new DateTime(2026, 7, 2, 14, 9, 30, 3, DateTimeKind.Utc).AddTicks(6689) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "0b18fa7e-f199-45fa-a009-5c53e6e65dc6");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "8f0555ac-9247-4b2a-aece-b84fe03e53bf");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 15, DateTimeKind.Utc).AddTicks(2007), new DateTime(2026, 7, 2, 14, 9, 30, 15, DateTimeKind.Utc).AddTicks(2009) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2474), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2477) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2847), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2847) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2850), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2850) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2852), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2852) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2853), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2854) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2875), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2875) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2878), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2878) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2883), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2883) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2884), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2884) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2855), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2855) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2856), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2857) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2865), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2865) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2866), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2866) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2868), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2868) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2869), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2869) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2871), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2871) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2872), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2872) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2874), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2874) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2880), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2880) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2881), new DateTime(2026, 7, 2, 14, 9, 30, 35, DateTimeKind.Utc).AddTicks(2881) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 16, DateTimeKind.Utc).AddTicks(8078), new DateTime(2026, 7, 2, 14, 9, 30, 16, DateTimeKind.Utc).AddTicks(8079) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 16, DateTimeKind.Utc).AddTicks(8280), new DateTime(2026, 7, 2, 14, 9, 30, 16, DateTimeKind.Utc).AddTicks(8281) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 16, DateTimeKind.Utc).AddTicks(8283), new DateTime(2026, 7, 2, 14, 9, 30, 16, DateTimeKind.Utc).AddTicks(8283) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 29, 996, DateTimeKind.Utc).AddTicks(3677), new DateTime(2026, 7, 2, 14, 9, 29, 996, DateTimeKind.Utc).AddTicks(3679) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62728db9-5a44-406f-b73c-6824d90aa2e2", new DateTime(2026, 7, 2, 14, 9, 29, 957, DateTimeKind.Utc).AddTicks(3055), new DateTime(2026, 7, 2, 14, 9, 29, 957, DateTimeKind.Utc).AddTicks(3058), "AQAAAAIAAYagAAAAEOyettKwYvYJRPaVhkhiHZGeaQlf5/F/CbT3jyWmpxgpl27hJrr0Nh59r1qylCLlaw==", "82e03d67-2987-4bc2-9f97-7889469a91fe" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 0, DateTimeKind.Utc).AddTicks(7559), new DateTime(2026, 7, 2, 14, 9, 30, 0, DateTimeKind.Utc).AddTicks(7670), new Guid("a56be791-567b-43e0-9203-6deee5c0097d") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 9, 30, 3, DateTimeKind.Utc).AddTicks(406), new DateTime(2026, 7, 2, 14, 9, 30, 3, DateTimeKind.Utc).AddTicks(407) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(2356), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(2365) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5108), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5108) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5117), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5117) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5121), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5122) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5127), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5128) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5160), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5161) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5164), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5165) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5233), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5234) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5237), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5238) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5248), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5248) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5252), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5252) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5255), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5256) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5259), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5259) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5262), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5263) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5266), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5266) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5269), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5269) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5273), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5273) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5279), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5285), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5286) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5288), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5289) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5292), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5293) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5316), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5316) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5319), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5323), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5323) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5326), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5327) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5333), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5334) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5384), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5385) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5400), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5403), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5404) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5407), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5407) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5410), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5411) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5414), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5414) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5417), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5418) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5424), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5425) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5428), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5428) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5431), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5432) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5435), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5435) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5455), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5456) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5459), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5462), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5463) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5466), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5466) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5472), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5473) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5476), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5477) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5480), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5483), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5484) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5487), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5487) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5490), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5491) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5494), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5494) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5497), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5498) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5504), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5504) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5507), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5508) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5511), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5511) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5514), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5515) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5537), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5538) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5541), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5541) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5544), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5545) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5548), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5548) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5554), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5555) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5558), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5559) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5562), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5562) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5565), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5566) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5571), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5571) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5574), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5575) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5578), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5578) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5581), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5582) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5588), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5588) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5593), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5593) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5596), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5597) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5600), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5620), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5621) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5624), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5624) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5627), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5628) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5630), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5631) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5637), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5637) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5640), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5641) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5644), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5644) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5647), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5648) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5650), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5651) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5654), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5654) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5657), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5657) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5660), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5661) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5666), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5667) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5670), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5673), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5674) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5676), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5677) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5698), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5698) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5701), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5702) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5705), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5705) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5708), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5709) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5715), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5715) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5718), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5719) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5721), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5722) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5725), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5726) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5728), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5729) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5732), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5733) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5735), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5736) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5739), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5739) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5745), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5746) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5749), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5749) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5752), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5752) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5786), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5787) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5808), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5809) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5812), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5812) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5815), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5815) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5818), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5819) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5825), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5825) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5828), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5829) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5832), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5832) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5835), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5836) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5839), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5839) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5842), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5842) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5848), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5848) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5851), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5852) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5857), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5858) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5861), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5861) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5864), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5865) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5867), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5868) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5871), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5871) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5874), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5875) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5878), new DateTime(2026, 7, 2, 6, 28, 36, 658, DateTimeKind.Utc).AddTicks(5878) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 661, DateTimeKind.Utc).AddTicks(9534), new DateTime(2026, 7, 2, 6, 28, 36, 661, DateTimeKind.Utc).AddTicks(9540) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "9da46ab0-f0ba-4bd5-af05-e0f19083b216");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "e766aa39-229b-4bf3-af38-fcc938f2ea40");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 701, DateTimeKind.Utc).AddTicks(9715), new DateTime(2026, 7, 2, 6, 28, 36, 701, DateTimeKind.Utc).AddTicks(9724) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6209), new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6209) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6217), new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6218) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6222), new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6223) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6227), new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6228) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6231), new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6232) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6294), new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6294) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6298), new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6298) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6311), new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6312) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6316), new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6317) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6236), new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6236) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6256), new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6257) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6261), new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6261) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6265), new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6265) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6269), new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6269) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6273), new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6273) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6277), new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6277) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6281), new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6281) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6285), new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6285) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6302), new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6302) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6306), new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(6306) });

            migrationBuilder.InsertData(
                table: "setting",
                columns: new[] { "Id", "DateCreated", "DateModified", "IsEncrypted", "Key", "Value" },
                values: new object[] { new Guid("66666666-6666-6666-6666-666666666614"), new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(4570), new DateTime(2026, 7, 2, 6, 28, 36, 774, DateTimeKind.Utc).AddTicks(4573), false, "Jwt.Key", "CHANGE_TO_YOUR_VERY_SECRET_JWT_SIGNING_KEY" });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 708, DateTimeKind.Utc).AddTicks(3119), new DateTime(2026, 7, 2, 6, 28, 36, 708, DateTimeKind.Utc).AddTicks(3128) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 708, DateTimeKind.Utc).AddTicks(3945), new DateTime(2026, 7, 2, 6, 28, 36, 708, DateTimeKind.Utc).AddTicks(3946) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 708, DateTimeKind.Utc).AddTicks(3954), new DateTime(2026, 7, 2, 6, 28, 36, 708, DateTimeKind.Utc).AddTicks(3954) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 636, DateTimeKind.Utc).AddTicks(6020), new DateTime(2026, 7, 2, 6, 28, 36, 636, DateTimeKind.Utc).AddTicks(6026) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d3230c2-db48-4d23-957d-aaddd926b279", new DateTime(2026, 7, 2, 6, 28, 36, 524, DateTimeKind.Utc).AddTicks(948), new DateTime(2026, 7, 2, 6, 28, 36, 524, DateTimeKind.Utc).AddTicks(953), "AQAAAAIAAYagAAAAECfl2WPDrOt5SxTMbE8upoPYwhXT41ZSnaOzhBLtTdgaMEq8ZK+UDqXebifiwOjG9Q==", "fb0fd211-65b2-4428-98c4-7cb41908a075" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 651, DateTimeKind.Utc).AddTicks(5053), new DateTime(2026, 7, 2, 6, 28, 36, 651, DateTimeKind.Utc).AddTicks(6924), new Guid("45fe26ac-9015-4341-a1a4-3e83adcbb94f") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 36, 659, DateTimeKind.Utc).AddTicks(7885), new DateTime(2026, 7, 2, 6, 28, 36, 659, DateTimeKind.Utc).AddTicks(7887) });
        }
    }
}
