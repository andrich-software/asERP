using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.SQLite.Migrations;

/// <inheritdoc />
public partial class AddShopDomain : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "shop_domain",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                SalesChannelId = table.Column<Guid>(type: "TEXT", nullable: false),
                Host = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                Port = table.Column<int>(type: "INTEGER", nullable: false),
                IsPrimary = table.Column<bool>(type: "INTEGER", nullable: false),
                RedirectToPrimary = table.Column<bool>(type: "INTEGER", nullable: false),
                DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_shop_domain", x => x.Id);
                table.ForeignKey(
                    name: "FK_shop_domain_saleschannel_SalesChannelId",
                    column: x => x.SalesChannelId,
                    principalTable: "saleschannel",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1194), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1198) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1887), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1887) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1889), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1890) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1891), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1891) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1893), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1893) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1894), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1895) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1901), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1901) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1903), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1903) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1904), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1904) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1906), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1906) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1907), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1907) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1908), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1909) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1910), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1910) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1921), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1921) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1924), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1929) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1930), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1931) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1932), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1932) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1933), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1934) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1935), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1935) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1937), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1937) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1938), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1939) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1940), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1940) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1942), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1943) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1944), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1944) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1945), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1945) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1949), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1949) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1951), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1951) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1952), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1952) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1954), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1954) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1967), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1968) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1971), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1972) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1973), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1973) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1975), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1975) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1976), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1976) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1978), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1978) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1979), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1979) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1980), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1981) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1982), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1982) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1984), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1985) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1986), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1986) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1987), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1987) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1989), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1989) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1990), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1990) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1991), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1992) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1993), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(1993) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2001), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2001) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2004), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2004) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2005), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2005) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2007), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2007) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2008), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2008) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2009), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2010) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2011), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2011) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2012), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2013) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2014), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2014) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2017), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2017) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2018), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2018) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2019), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2020) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2021), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2021) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2022), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2022) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2024), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2024) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2025), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2025) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2032), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2033) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2035), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2036) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2037), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2037) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2038), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2039) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2040), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2040) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2041), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2042) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2043), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2043) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2044), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2044) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2046), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2046) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2048), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2048) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2050), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2050) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2051), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2051) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2053), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2053) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2054), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2054) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2056), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2056) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2057), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2057) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2064), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2065) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2067), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2067) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2069), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2069) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2070), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2070) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2072), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2072) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2073), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2073) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2074), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2075) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2076), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2076) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2083), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2084) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2086), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2086) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2088), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2088) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2089), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2089) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2090), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2091) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2092), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2092) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2093), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2093) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2095), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2095) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2102), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2103) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2106), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2106) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2107), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2108) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2109), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2109) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2110), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2110) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2112), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2112) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2113), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2113) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2115), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2115) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2116), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2116) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2118), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2119) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2120), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2120) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2121), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2122) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2123), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2123) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2124), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2124) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2126), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2126) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2127), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2127) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2135), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2135) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2137), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2138) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2139), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2139) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2141), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2141) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2142), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2142) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2143), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2144) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2145), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2145) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2146), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2147) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2148), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2148) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2150), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2151) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2152), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2152) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2153), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2153) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2155), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2155) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2156), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2156) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2157), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2158) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2159), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2159) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2166), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2167) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2170), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2170) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2171), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2171) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2173), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2173) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2174), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2174) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2175), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2176) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2177), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2177) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2178), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2179) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2180), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2180) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2182), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2182) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2184), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2184) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2185), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2185) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2186), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2187) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2188), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2188) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2189), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2189) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2191), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2191) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2198), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2199) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2201), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2201) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2202), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2203) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2204), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2204) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2205), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2205) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2207), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2207) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2208), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2208) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2210), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2210) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2211), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2211) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2214), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2214) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2215), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2215) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2217), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2217) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2218), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2218) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2220), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2220) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2221), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2221) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2222), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2223) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2230), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2231) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2234), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2234) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2235), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2236) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2237), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2237) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2238), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2238) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2240), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2240) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2241), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2241) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2243), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2243) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2244), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2244) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2247), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2247) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2248), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2248) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2249), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2250) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2251), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2251) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2252), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2253) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2254), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2254) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2255), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2255) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2263), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2263) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2266), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2266) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2267), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2267) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2269), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2269) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2270), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2270) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2272), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2272) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2277), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2277) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2279), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2279) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2280), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2280) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2283), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2283) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2284), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2284) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2286), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2286) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2287), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2287) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2288), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2289) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2290), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2290) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2291), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2291) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2299), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2299) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2302), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2302) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2303), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2304) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2305), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2305) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2306), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2307) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2308), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2308) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2309), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2309) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2311), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2311) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2312), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2312) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2315), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2315) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2316), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2316) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2317), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2318) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2319), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2319) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2320), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2320) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2322), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2322) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2323), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2323) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2331), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2331) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2333), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2333) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2335), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2335) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2336), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2336) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2338), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2338) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2339), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2339) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2341), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2341) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2342), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2342) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2344), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2344) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2346), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2346) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2348), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2348) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2349), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2349) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2350), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2351) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2352), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2352) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2353), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2353) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2355), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2355) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2362), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2363) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2366), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2366) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2367), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2367) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2369), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2369) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2370), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2370) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2372), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2372) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2373), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2373) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2375), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2375) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2376), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2376) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2379), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2379) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2380), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2381) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2382), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2382) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2383), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2383) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2385), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2385) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2386), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2386) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2387), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2388) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2389), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2389) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2398), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2398) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2399), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2399) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2401), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2401) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2402), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2402) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2403), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2404) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2405), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2405) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2406), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2407) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2408), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2408) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2410), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2411) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2412), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2412) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2413), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(2413) });

        migrationBuilder.UpdateData(
            table: "manufacturer",
            keyColumn: "Id",
            keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 79, DateTimeKind.Utc).AddTicks(2562), new DateTime(2026, 8, 21, 9, 7, 3, 79, DateTimeKind.Utc).AddTicks(2562) });

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
            column: "ConcurrencyStamp",
            value: "c03a4032-ee46-4faa-b0fd-768ec433c72e");

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
            column: "ConcurrencyStamp",
            value: "5bb83e90-08c0-41b9-95ab-dcfc4b70993f");

        migrationBuilder.UpdateData(
            table: "saleschannel",
            keyColumn: "Id",
            keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 91, DateTimeKind.Utc).AddTicks(1440), new DateTime(2026, 8, 21, 9, 7, 3, 91, DateTimeKind.Utc).AddTicks(1444) });

        migrationBuilder.UpdateData(
            table: "saleschannel_sync_state",
            keyColumn: "Id",
            keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 93, DateTimeKind.Utc).AddTicks(4878), new DateTime(2026, 8, 21, 9, 7, 3, 93, DateTimeKind.Utc).AddTicks(4879) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(8913), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(8916) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9414), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9414) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9416), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9417) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9419), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9419) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9420), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9420) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9599), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9599) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9601), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9601) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9605), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9605) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9606), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9606) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9422), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9422) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9430), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9430) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9431), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9431) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9433), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9433) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9589), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9590) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9591), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9592) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9593), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9593) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9594), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9594) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9596), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9596) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9602), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9602) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9603), new DateTime(2026, 8, 21, 9, 7, 3, 121, DateTimeKind.Utc).AddTicks(9603) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 95, DateTimeKind.Utc).AddTicks(4442), new DateTime(2026, 8, 21, 9, 7, 3, 95, DateTimeKind.Utc).AddTicks(4445) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 95, DateTimeKind.Utc).AddTicks(4664), new DateTime(2026, 8, 21, 9, 7, 3, 95, DateTimeKind.Utc).AddTicks(4664) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 95, DateTimeKind.Utc).AddTicks(4666), new DateTime(2026, 8, 21, 9, 7, 3, 95, DateTimeKind.Utc).AddTicks(4667) });

        migrationBuilder.UpdateData(
            table: "warehouse",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(6417), new DateTime(2026, 8, 21, 9, 7, 3, 78, DateTimeKind.Utc).AddTicks(6419) });

        migrationBuilder.CreateIndex(
            name: "IX_shop_domain_Host_Port",
            table: "shop_domain",
            columns: new[] { "Host", "Port" },
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_shop_domain_SalesChannelId",
            table: "shop_domain",
            column: "SalesChannelId");

        migrationBuilder.CreateIndex(
            name: "IX_shop_domain_TenantId",
            table: "shop_domain",
            column: "TenantId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "shop_domain");

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(4912), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(4916) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5721), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5721) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5724), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5724) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5732), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5732) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5734), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5734) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5736), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5736) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5738), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5738) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5739), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5739) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5741), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5741) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5742), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5743) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5744), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5744) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5747), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5747) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5749), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5749) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5768), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5768) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5770), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5770) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5783), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5783) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5785), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5785) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5786), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5787) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5788), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5788) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5791), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5791) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5792), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5793) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5794), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5794) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5796), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5796) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5797), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5797) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5802), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5802) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5804), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5805) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5806), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5806) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5809), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5809) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5811), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5811) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5820), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5820) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5824), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5824) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5833), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5834) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5835), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5835) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5837), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5837) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5838), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5839) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5841), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5842) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5843), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5843) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5845), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5845) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5846), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5847) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5848), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5848) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5850), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5850) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5851), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5851) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5853), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5853) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5856), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5856) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5857), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5857) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5859), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5859) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5860), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5860) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5868), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5869) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5871), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5871) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5873), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5873) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5875), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5875) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5878), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5878) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5879), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5880) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5881), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5881) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5883), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5883) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5884), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5884) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5886), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5886) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5887), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5888) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5889), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5889) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5892), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5892) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5893), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5894) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5895), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5895) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5897), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5897) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5905), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5905) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5906), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5907) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5908), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5908) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5910), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5910) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5913), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5913) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5914), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5915) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5916), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5916) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5918), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5918) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5919), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5919) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5921), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5921) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5923), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5923) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5925), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5926) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5928), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5928) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5930), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5930) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5931), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5932) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5933), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5933) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5941), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5942) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5944), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5944) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5945), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5945) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5947), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5947) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5950), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5950) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5951), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5951) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5953), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5953) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5954), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5955) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5956), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5956) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5958), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5958) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5959), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5959) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5961), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5961) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5964), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5964) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5965), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5965) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5967), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5967) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5973), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5973) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5981), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5981) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5983), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5983) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5984), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5985) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5987), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5987) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5990), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5990) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5991), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5992) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5993), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5993) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5995), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5995) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5996), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5996) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5998), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5998) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5999), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(5999) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6001), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6001) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6004), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6004) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6005), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6005) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6007), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6007) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6008), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6008) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6016), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6017) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6018), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6019) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6020), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6020) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6022), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6022) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6025), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6025) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6026), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6026) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6028), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6028) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6029), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6030) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6031), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6031) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6032), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6033) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6034), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6034) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6037), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6037) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6040), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6040) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6041), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6041) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6043), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6043) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6044), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6044) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6053), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6053) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6055), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6055) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6056), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6056) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6058), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6058) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6061), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6061) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6062), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6063) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6064), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6064) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6066), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6066) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6067), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6067) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6069), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6069) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6070), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6071) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6072), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6072) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6075), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6075) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6076), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6076) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6078), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6078) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6079), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6080) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6088), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6088) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6090), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6090) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6092), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6092) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6094), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6094) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6097), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6097) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6098), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6098) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6100), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6100) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6101), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6102) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6103), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6103) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6105), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6105) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6106), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6106) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6108), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6108) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6110), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6111) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6112), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6112) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6114), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6114) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6115), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6115) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6123), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6123) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6125), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6126) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6127), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6128) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6129), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6129) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6132), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6132) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6134), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6134) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6135), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6135) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6137), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6137) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6138), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6139) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6141), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6141) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6143), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6143) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6144), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6144) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6147), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6147) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6149), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6149) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6150), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6150) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6152), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6152) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6159), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6160) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6161), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6161) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6163), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6163) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6165), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6165) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6167), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6168) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6169), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6169) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6170), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6171) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6172), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6172) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6174), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6174) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6175), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6175) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6177), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6177) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6178), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6178) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6186), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6186) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6188), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6188) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6189), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6190) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6191), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6191) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6199), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6199) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6202), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6202) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6204), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6204) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6205), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6205) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6208), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6208) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6210), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6210) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6211), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6211) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6213), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6213) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6214), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6215) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6216), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6216) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6218), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6218) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6219), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6219) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6222), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6222) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6223), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6223) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6225), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6225) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6226), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6226) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6234), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6234) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6236), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6236) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6238), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6238) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6239), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6240) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6242), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6242) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6244), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6244) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6246), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6246) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6247), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6248) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6249), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6249) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6252), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6252) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6253), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6253) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6255), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6255) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6257), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6258) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6259), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6259) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6260), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6261) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6262), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6262) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6270), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6271) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6273), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6273) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6275), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6275) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6276), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6276) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6279), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6279) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6281), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6281) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6282), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6283) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6284), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6284) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6286), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6286) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6287), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6287) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6289), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6289) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6290), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6290) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6293), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6293) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6295), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6295) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6296), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6296) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6298), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6298) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6306), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6307) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6308), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6308) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6310), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6310) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6311), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6312) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6314), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6314) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6316), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6316) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6317), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6318) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6319), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6319) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6321), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6321) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6322), new DateTime(2026, 7, 8, 11, 10, 50, 409, DateTimeKind.Utc).AddTicks(6322) });

        migrationBuilder.UpdateData(
            table: "manufacturer",
            keyColumn: "Id",
            keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 410, DateTimeKind.Utc).AddTicks(9138), new DateTime(2026, 7, 8, 11, 10, 50, 410, DateTimeKind.Utc).AddTicks(9140) });

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
            column: "ConcurrencyStamp",
            value: "3669273e-9fce-473e-a307-81c52657b4ed");

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
            column: "ConcurrencyStamp",
            value: "d68af6de-cb97-4b47-b1cc-873c26467ad2");

        migrationBuilder.UpdateData(
            table: "saleschannel",
            keyColumn: "Id",
            keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 424, DateTimeKind.Utc).AddTicks(1463), new DateTime(2026, 7, 8, 11, 10, 50, 424, DateTimeKind.Utc).AddTicks(1467) });

        migrationBuilder.UpdateData(
            table: "saleschannel_sync_state",
            keyColumn: "Id",
            keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 429, DateTimeKind.Utc).AddTicks(4639), new DateTime(2026, 7, 8, 11, 10, 50, 429, DateTimeKind.Utc).AddTicks(4643) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(5499), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(5505) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6033), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6034) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6037), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6037) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6039), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6039) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6040), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6041) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6189), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6189) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6190), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6190) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6197), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6197) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6198), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6198) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6042), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6042) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6044), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6044) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6045), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6045) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6050), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6050) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6180), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6180) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6182), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6182) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6184), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6184) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6185), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6186) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6187), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6187) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6194), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6194) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6195), new DateTime(2026, 7, 8, 11, 10, 50, 463, DateTimeKind.Utc).AddTicks(6195) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 431, DateTimeKind.Utc).AddTicks(9750), new DateTime(2026, 7, 8, 11, 10, 50, 431, DateTimeKind.Utc).AddTicks(9753) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 432, DateTimeKind.Utc).AddTicks(142), new DateTime(2026, 7, 8, 11, 10, 50, 432, DateTimeKind.Utc).AddTicks(143) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 432, DateTimeKind.Utc).AddTicks(147), new DateTime(2026, 7, 8, 11, 10, 50, 432, DateTimeKind.Utc).AddTicks(147) });

        migrationBuilder.UpdateData(
            table: "warehouse",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 50, 410, DateTimeKind.Utc).AddTicks(1890), new DateTime(2026, 7, 8, 11, 10, 50, 410, DateTimeKind.Utc).AddTicks(1891) });
    }
}
