using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asToolkit.Persistence.MSSQL.Migrations
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
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1268), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1269) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1958), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1958) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1961), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1961) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1974), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1975) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1977), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1977) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1979), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1979) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1986), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1986) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1988), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1988) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1990), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1991), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1991) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1993), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1993) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1995), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1995) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1996), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1997) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1998), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(1998) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2001), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2002) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2003), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2003) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2005), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2005) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2006), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2007) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2008), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2008) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2018), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2019) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2021), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2021) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2023), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2023) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2026), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2026) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2027), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2028) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2029), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2029) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2031), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2031) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2043), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2043) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2046), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2047) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2048), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2048) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2050), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2053), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2053) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2055), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2055) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2056), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2056) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2058), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2058) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2059), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2069), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2072), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2072) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2074), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2074) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2077), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2077) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2078), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2079) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2080), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2082), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2082) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2083), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2084) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2085), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2085) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2087), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2087) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2088), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2089) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2091), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2092) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2093), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2093) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2095), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2095) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2096), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2097) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2098), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2098) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2107), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2108) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2110), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2111) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2112), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2112) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2115), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2116) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2117), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2117) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2119), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2119) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2121), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2121) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2122), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2123) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2124), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2124) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2126), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2126) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2136), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2136) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2139), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2141), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2141) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2143), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2143) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2145), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2145) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2146), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2146) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2156), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2156) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2158), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2159) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2161), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2161) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2164), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2164) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2166), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2167) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2168), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2168) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2170), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2172), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2172) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2174), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2174) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2175), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2176) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2178), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2178) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2181), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2181) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2183), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2183) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2185), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2185) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2186), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2187) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2188), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2188) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2197), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2198) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2200), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2200) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2202), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2202) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2205), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2205) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2206), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2207) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2208), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2208) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2210), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2212), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2212) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2213), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2213) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2215), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2215) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2216), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2217) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2219), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2221), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2221) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2223), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2223) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2224), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2225) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2226), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2226) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2235), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2236) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2238), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2239) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2241), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2241) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2245), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2245) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2247), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2248) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2249), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2251), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2251) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2253), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2253) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2255), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2255) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2257), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2257) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2259), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2259) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2262), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2262) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2264), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2264) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2265), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2266) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2267), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2267) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2269), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2269) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2270), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2271) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2272), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2272) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2274), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2274) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2277), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2277) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2279), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(2279) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 37, DateTimeKind.Utc).AddTicks(2728), new DateTime(2026, 7, 2, 14, 8, 15, 37, DateTimeKind.Utc).AddTicks(2729) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "159a6658-de1d-407b-9db5-024a8c5c1173");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "cd2844cb-5888-4ed7-b687-6a4e919b47ae");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 49, DateTimeKind.Utc).AddTicks(5714), new DateTime(2026, 7, 2, 14, 8, 15, 49, DateTimeKind.Utc).AddTicks(5715) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9538), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9542) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9924), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9924) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9927), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9928) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9930), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9930) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9932), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9932) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9949), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9950) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9951), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9951) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9957), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9957) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9959), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9959) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9934), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9934) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9935), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9935) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9937), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9937) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9941), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9941) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9942), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9942) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9944), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9944) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9945), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9945) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9947), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9947) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9948), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9948) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9954), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9954) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9955), new DateTime(2026, 7, 2, 14, 8, 15, 67, DateTimeKind.Utc).AddTicks(9956) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 51, DateTimeKind.Utc).AddTicks(2126), new DateTime(2026, 7, 2, 14, 8, 15, 51, DateTimeKind.Utc).AddTicks(2128) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 51, DateTimeKind.Utc).AddTicks(2343), new DateTime(2026, 7, 2, 14, 8, 15, 51, DateTimeKind.Utc).AddTicks(2343) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 51, DateTimeKind.Utc).AddTicks(2346), new DateTime(2026, 7, 2, 14, 8, 15, 51, DateTimeKind.Utc).AddTicks(2346) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 28, DateTimeKind.Utc).AddTicks(8520), new DateTime(2026, 7, 2, 14, 8, 15, 28, DateTimeKind.Utc).AddTicks(8524) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d6e5726-6a77-46ac-80fd-a7f525bc3e77", new DateTime(2026, 7, 2, 14, 8, 14, 984, DateTimeKind.Utc).AddTicks(6633), new DateTime(2026, 7, 2, 14, 8, 14, 984, DateTimeKind.Utc).AddTicks(6636), "AQAAAAIAAYagAAAAEFLRo9HgcxCO+rclSRzdC8fVqrPysGclru2CRWeROo3SV2AjWe++LiSstZQq8RAZNw==", "42c7635e-b3f7-40af-9d25-f802b1b3b36d" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 34, DateTimeKind.Utc).AddTicks(151), new DateTime(2026, 7, 2, 14, 8, 15, 34, DateTimeKind.Utc).AddTicks(279), new Guid("311018f1-fd56-42c1-b812-1d8822db31f2") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(5411), new DateTime(2026, 7, 2, 14, 8, 15, 36, DateTimeKind.Utc).AddTicks(5412) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 133, DateTimeKind.Utc).AddTicks(9747), new DateTime(2026, 7, 2, 6, 28, 0, 133, DateTimeKind.Utc).AddTicks(9760) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2374), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2375) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2383), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2384) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2416), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2417) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2445), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2445) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2450), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2453), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2454) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2457), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2458) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2461), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2461) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2465), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2466) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2469), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2469) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2473), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2473) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2483), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2484) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2487), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2488) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2491), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2491) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2494), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2495) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2498), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2498) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2501), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2502) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2505), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2506) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2531), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2531) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2538), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2538) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2541), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2542) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2609), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2613), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2614) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2617), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2617) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2621), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2621) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2666), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2666) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2687), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2687) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2694), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2695) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2698), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2699) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2701), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2702) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2705), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2706) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2709), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2709) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2715), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2716) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2720), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2744), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2745) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2754), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2755) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2758), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2758) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2761), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2762) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2765), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2766) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2769), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2769) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2772), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2773) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2776), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2777) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2780), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2786), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2787) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2790), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2793), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2793) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2797), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2797) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2800), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2803), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2804) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2807), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2807) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2827), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2834), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2834) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2837), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2838) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2841), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2841) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2844), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2845) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2848), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2848) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2851), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2852) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2855), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2855) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2859), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2859) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2865), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2865) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2868), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2869) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2872), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2872) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2875), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2876) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2879), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2879) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2882), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2883) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2886), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2886) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2906), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2907) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2913), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2913) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2917), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2917) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2920), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2921) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2924), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2924) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2927), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2928) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2931), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2932) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2934), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2935) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2938), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2939) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2945), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2945) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2948), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2949) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2952), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2952) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2955), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2956) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2959), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2959) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2963), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2963) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2966), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2967) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2987), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2987) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2993), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(2993) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3000), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3000) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3003), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3003) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3008), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3008) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3012), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3013) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3017), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3017) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3020), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3024), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3024) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3030), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3033), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3034) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3037), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3037) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3041), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3041) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3046), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3046) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3050), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3053), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3054) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3076), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3077) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3083), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3084) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3087), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3087) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3090), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3094), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3094) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3097), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3098) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3101), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3101) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3104), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3104) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3108), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3108) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3114), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3114) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3119), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3122), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3123) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3126), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3127) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3129), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3133), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3133) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3136), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3137) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3140), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3166), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3166) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3170), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3173), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3174) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3176), new DateTime(2026, 7, 2, 6, 28, 0, 134, DateTimeKind.Utc).AddTicks(3177) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 137, DateTimeKind.Utc).AddTicks(8640), new DateTime(2026, 7, 2, 6, 28, 0, 137, DateTimeKind.Utc).AddTicks(8649) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "c1c4da35-3af1-45a1-ab34-a9edbc02e501");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "d87e3347-9e2b-4be5-b580-40118bd8c686");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 178, DateTimeKind.Utc).AddTicks(2866), new DateTime(2026, 7, 2, 6, 28, 0, 178, DateTimeKind.Utc).AddTicks(2872) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(654), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(656) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(663), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(664) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(696), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(697) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(700), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(701) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(704), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(705) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(759), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(762), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(763) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(776), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(777) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(780), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(780) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(709), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(709) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(713), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(714) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(717), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(718) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(722), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(722) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(726), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(726) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(734), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(735) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(741), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(741) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(748), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(748) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(753), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(754) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(766), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(766) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(769), new DateTime(2026, 7, 2, 6, 28, 0, 247, DateTimeKind.Utc).AddTicks(770) });

            migrationBuilder.InsertData(
                table: "setting",
                columns: new[] { "Id", "DateCreated", "DateModified", "IsEncrypted", "Key", "Value" },
                values: new object[] { new Guid("66666666-6666-6666-6666-666666666614"), new DateTime(2026, 7, 2, 6, 28, 0, 246, DateTimeKind.Utc).AddTicks(9367), new DateTime(2026, 7, 2, 6, 28, 0, 246, DateTimeKind.Utc).AddTicks(9373), false, "Jwt.Key", "CHANGE_TO_YOUR_VERY_SECRET_JWT_SIGNING_KEY" });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 183, DateTimeKind.Utc).AddTicks(5895), new DateTime(2026, 7, 2, 6, 28, 0, 183, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 183, DateTimeKind.Utc).AddTicks(6623), new DateTime(2026, 7, 2, 6, 28, 0, 183, DateTimeKind.Utc).AddTicks(6624) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 183, DateTimeKind.Utc).AddTicks(6646), new DateTime(2026, 7, 2, 6, 28, 0, 183, DateTimeKind.Utc).AddTicks(6647) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 109, DateTimeKind.Utc).AddTicks(972), new DateTime(2026, 7, 2, 6, 28, 0, 109, DateTimeKind.Utc).AddTicks(978) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d238fd7-da42-40f3-9849-be6bcad145a2", new DateTime(2026, 7, 2, 6, 27, 59, 988, DateTimeKind.Utc).AddTicks(7138), new DateTime(2026, 7, 2, 6, 27, 59, 988, DateTimeKind.Utc).AddTicks(7148), "AQAAAAIAAYagAAAAENpcxnClpBkKFLoUqmf0ck/ihHvcsqa1j0YpsPqrJDzRu11HYoAB/DXBd3bgBTOt0A==", "e40ede75-7a53-4fae-a86c-3a8ef175b124" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 126, DateTimeKind.Utc).AddTicks(3775), new DateTime(2026, 7, 2, 6, 28, 0, 126, DateTimeKind.Utc).AddTicks(4305), new Guid("1203e739-0a90-4909-a756-0cf49a6949a4") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 2, 6, 28, 0, 135, DateTimeKind.Utc).AddTicks(5481), new DateTime(2026, 7, 2, 6, 28, 0, 135, DateTimeKind.Utc).AddTicks(5484) });
        }
    }
}
