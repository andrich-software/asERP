using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.SQLite.Migrations
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
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(594), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(595) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1208), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1209) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1212), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1212) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1214), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1214) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1223), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1223) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1224), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1225) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1226), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1226) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1228), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1228) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1230), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1231), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1231) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1233), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1233) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1234), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1235) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1238), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1238) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1239), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1239) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1241), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1241) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1242), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1242) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1244), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1244) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1255), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1256) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1257), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1257) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1259), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1259) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1262), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1262) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1263), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1263) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1265), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1265) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1266), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1267) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1268), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1268) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1270), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1279), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1279) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1284), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1284) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1287), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1287) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1288), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1288) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1289), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1291), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1291) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1293), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1293) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1302), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1303) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1305), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1305) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1307), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1307) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1310), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1312), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1312) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1313), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1314) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1315), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1315) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1317), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1317) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1318), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1318) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1320), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1321), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1321) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1324), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1324) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1325), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1325) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1327), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1327) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1328), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1329) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1330), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1339), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1339) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1340), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1341) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1342), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1342) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1345), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1345) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1347), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1347) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1348), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1348) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1350), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1351), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1351) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1353), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1353) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1354), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1354) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1355), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1356) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1358), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1358) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1360), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1361), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1361) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1363), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1363) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1364), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1364) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1372), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1372) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1374), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1374) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1376), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1376) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1379), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1379) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1381), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1381) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1383), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1383) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1384), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1384) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1385), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1386) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1387), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1387) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1388), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1389) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1390), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1392), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1393) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1394), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1394) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1395), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1395) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1397), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1397) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1398), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1398) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1407), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1407) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1409), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1409) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1411), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1411) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1414), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1414) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1415), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1415) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1417), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1417) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1419), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1419) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1420), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1422), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1422) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1424), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1424) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1425), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1425) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1428), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1428) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1429), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1436), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1436) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1437), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1437) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1439), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1439) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1448), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1448) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1450), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1452), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1452) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1455), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1455) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1457), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1457) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1459), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1459) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1461), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1461) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1463), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1463) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1465), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1465) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1466), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1467) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1468), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1469) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1471), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1472) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1473), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1473) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1475), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1475) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1476), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1476) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1478), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1478) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1479), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1479) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1480), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1481) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1482), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1482) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1485), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1485) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1486), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1486) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1487), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1488) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1489), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(1489) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 56, DateTimeKind.Utc).AddTicks(1504), new DateTime(2026, 7, 2, 14, 10, 6, 56, DateTimeKind.Utc).AddTicks(1506) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "2774e1a9-6b8a-4816-9804-eb908fbaffa6");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "eacfe4ea-2768-48d6-99e0-3620ac9b3d2d");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 70, DateTimeKind.Utc).AddTicks(342), new DateTime(2026, 7, 2, 14, 10, 6, 70, DateTimeKind.Utc).AddTicks(344) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(7679), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(7682) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8032), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8032) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8036), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8037) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8038), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8045), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8045) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8061), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8061) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8062), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8063) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8067), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8067) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8068), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8068) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8047), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8047) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8048), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8049) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8050), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8050) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8051), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8052) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8053), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8053) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8054), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8054) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8056), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8056) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8058), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8059) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8060), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8060) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8064), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8064) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8065), new DateTime(2026, 7, 2, 14, 10, 6, 86, DateTimeKind.Utc).AddTicks(8065) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 71, DateTimeKind.Utc).AddTicks(5815), new DateTime(2026, 7, 2, 14, 10, 6, 71, DateTimeKind.Utc).AddTicks(5816) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 71, DateTimeKind.Utc).AddTicks(6024), new DateTime(2026, 7, 2, 14, 10, 6, 71, DateTimeKind.Utc).AddTicks(6025) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 71, DateTimeKind.Utc).AddTicks(6027), new DateTime(2026, 7, 2, 14, 10, 6, 71, DateTimeKind.Utc).AddTicks(6027) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 47, DateTimeKind.Utc).AddTicks(7358), new DateTime(2026, 7, 2, 14, 10, 6, 47, DateTimeKind.Utc).AddTicks(7361) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbea7973-7637-46ee-bb47-72501ebe367c", new DateTime(2026, 7, 2, 14, 10, 6, 7, DateTimeKind.Utc).AddTicks(8575), new DateTime(2026, 7, 2, 14, 10, 6, 7, DateTimeKind.Utc).AddTicks(8577), "AQAAAAIAAYagAAAAECRi8s1Czxd5q3wUWnUM3S4nEpCRn3D0bdYoNMOLOwvhs6NYssBoXZA1Y2vk4dAYJA==", "05cfeb7b-cf82-4d27-bc97-de88c1535c57" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 53, DateTimeKind.Utc).AddTicks(1326), new DateTime(2026, 7, 2, 14, 10, 6, 53, DateTimeKind.Utc).AddTicks(1448), new Guid("205f3194-3e24-4179-8573-fce3b4ede524") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(4375), new DateTime(2026, 7, 2, 14, 10, 6, 55, DateTimeKind.Utc).AddTicks(4376) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(5115), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(5122) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7630), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7631) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7640), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7640) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7670), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7671) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7677), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7677) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7681), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7681) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7685), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7685) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7689), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7689) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7692), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7693) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7696), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7697) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7700), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7708), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7709) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7712), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7713) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7716), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7716) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7719), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7723), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7724) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7727), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7727) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7762), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7762) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7766), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7766) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7773), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7773) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7777), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7777) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7780), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7781) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7784), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7785) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7788), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7789) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7791), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7792) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7795), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7796) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7845), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7846) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7867), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7868) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7871), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7871) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7875), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7875) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7878), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7879) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7882), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7883) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7886), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7886) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7908), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7909) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7912), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7913) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7919), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7923), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7923) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7927), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7927) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7931), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7931) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7935), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7935) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7938), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7939) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7942), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7942) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7946), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7946) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7952), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7953) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7956), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7956) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7960), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7963), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7964) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7967), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7967) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7970), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7971) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7993), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7994) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7997), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(7998) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8004), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8005) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8008), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8009) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8012), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8013) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8074), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8074) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8077), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8078) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8081), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8082) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8084), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8085) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8088), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8089) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8095), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8096) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8099), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8099) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8102), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8103) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8106), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8107) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8110), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8113), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8114) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8137), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8138) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8141), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8141) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8148), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8148) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8151), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8152) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8155), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8155) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8159), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8163), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8163) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8166), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8167) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8170), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8173), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8174) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8180), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8183), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8184) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8187), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8187) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8190), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8191) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8194), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8194) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8197), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8198) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8221), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8222) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8225), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8226) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8232), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8233) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8236), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8237) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8240), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8244), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8244) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8247), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8248) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8251), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8252) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8255), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8255) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8258), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8259) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8265), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8265) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8268), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8269) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8272), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8273) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8277), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8277) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8280), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8281) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8284), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8284) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8307), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8308) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8310), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8311) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8317), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8318) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8321), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8321) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8324), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8325) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8328), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8329) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8332), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8332) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8335), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8336) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8339), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8343), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8343) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8349), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8353), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8353) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8356), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8357) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8360), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8361) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8363), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8364) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8367), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8367) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8370), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8371) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8374), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8380), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8381) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8384), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8385) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8388), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8388) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8391), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8392) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8395), new DateTime(2026, 7, 2, 6, 28, 53, 886, DateTimeKind.Utc).AddTicks(8395) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 890, DateTimeKind.Utc).AddTicks(9435), new DateTime(2026, 7, 2, 6, 28, 53, 890, DateTimeKind.Utc).AddTicks(9439) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "eb9f4d4d-5a2d-4169-b236-a28cb4a0a17b");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "875df2a4-d6b6-4faa-a38b-a324eac8a803");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 930, DateTimeKind.Utc).AddTicks(1643), new DateTime(2026, 7, 2, 6, 28, 53, 930, DateTimeKind.Utc).AddTicks(1655) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2691), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2692) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2700), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2700) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2704), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2705) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2708), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2709) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2712), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2713) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2765), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2766) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2772), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2773) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2784), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2784) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2790), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2791) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2716), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2720), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2721) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2733), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2733) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2740), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2740) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2746), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2747) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2750), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2751) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2754), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2754) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2758), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2758) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2761), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2762) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2776), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2777) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2780), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(2780) });

            migrationBuilder.InsertData(
                table: "setting",
                columns: new[] { "Id", "DateCreated", "DateModified", "IsEncrypted", "Key", "Value" },
                values: new object[] { new Guid("66666666-6666-6666-6666-666666666614"), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(1251), new DateTime(2026, 7, 2, 6, 28, 53, 997, DateTimeKind.Utc).AddTicks(1257), false, "Jwt.Key", "CHANGE_TO_YOUR_VERY_SECRET_JWT_SIGNING_KEY" });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 935, DateTimeKind.Utc).AddTicks(7734), new DateTime(2026, 7, 2, 6, 28, 53, 935, DateTimeKind.Utc).AddTicks(7740) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 935, DateTimeKind.Utc).AddTicks(8492), new DateTime(2026, 7, 2, 6, 28, 53, 935, DateTimeKind.Utc).AddTicks(8492) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 935, DateTimeKind.Utc).AddTicks(8500), new DateTime(2026, 7, 2, 6, 28, 53, 935, DateTimeKind.Utc).AddTicks(8501) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 863, DateTimeKind.Utc).AddTicks(8097), new DateTime(2026, 7, 2, 6, 28, 53, 863, DateTimeKind.Utc).AddTicks(8101) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52682bba-23ad-41bf-bc76-71420ca4d6a9", new DateTime(2026, 7, 2, 6, 28, 53, 748, DateTimeKind.Utc).AddTicks(4274), new DateTime(2026, 7, 2, 6, 28, 53, 748, DateTimeKind.Utc).AddTicks(4278), "AQAAAAIAAYagAAAAEJwPV2ToTVIk9d2LCFfT5vm8MT69N+PY/QdgQi8hh2A2I4L7vMSynOBH4sPf0CRmLg==", "b949738e-2979-4e75-ba33-2fbcbde9e030" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 879, DateTimeKind.Utc).AddTicks(7881), new DateTime(2026, 7, 2, 6, 28, 53, 879, DateTimeKind.Utc).AddTicks(8411), new Guid("3627f5f1-4e12-412b-b36c-df1cc7d77742") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 53, 888, DateTimeKind.Utc).AddTicks(1722), new DateTime(2026, 7, 2, 6, 28, 53, 888, DateTimeKind.Utc).AddTicks(1723) });
        }
    }
}
