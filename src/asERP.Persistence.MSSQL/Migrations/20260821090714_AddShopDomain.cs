using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.MSSQL.Migrations;

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
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                SalesChannelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Host = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                Port = table.Column<int>(type: "int", nullable: false),
                IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                RedirectToPrimary = table.Column<bool>(type: "bit", nullable: false),
                DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(36), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(39) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(765), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(766) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(768), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(769) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(770), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(771) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(778), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(778) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(790), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(790) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(792), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(792) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(793), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(793) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(795), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(795) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(796), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(797) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(798), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(798) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(799), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(800) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(802), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(803) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(804), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(804) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(805), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(806) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(807), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(807) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(809), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(809) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(810), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(810) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(812), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(812) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(813), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(813) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(816), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(816) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(824), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(824) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(826), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(826) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(827), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(827) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(829), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(829) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(830), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(830) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(832), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(832) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(833), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(834) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(836), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(836) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(845), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(846) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(848), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(848) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(850), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(850) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(851), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(852) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(853), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(853) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(854), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(854) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(856), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(856) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(858), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(859) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(867), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(867) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(869), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(869) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(871), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(871) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(872), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(873) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(874), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(874) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(875), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(875) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(889), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(889) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(892), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(892) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(893), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(893) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(895), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(895) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(896), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(896) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(898), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(898) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(899), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(899) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(901), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(901) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(902), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(903) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(905), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(905) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(913), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(913) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(915), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(915) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(916), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(916) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(918), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(918) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(919), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(919) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(921), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(921) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(922), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(922) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(925), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(925) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(927), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(927) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(928), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(928) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(929), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(930) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(931), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(931) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(932), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(933) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(934), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(934) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(935), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(935) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(938), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(938) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(946), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(946) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(948), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(948) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(949), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(950) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(951), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(951) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(952), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(953) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(954), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(954) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(956), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(956) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(958), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(958) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(960), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(960) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(961), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(961) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(962), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(963) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(964), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(964) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(965), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(965) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(967), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(967) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(968), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(968) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(971), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(971) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(979), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(980) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(981), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(981) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(983), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(983) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(984), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(984) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(986), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(986) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(987), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(987) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(989), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(989) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(991), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(992) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(993), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(993) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(994), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(994) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(996), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(996) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(997), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(997) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(998), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(999) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1000), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1000) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1001), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1002) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1004), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1004) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1012), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1012) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1014), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1014) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1016), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1016) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1017), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1017) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1019), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1019) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1020), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1020) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1022), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1022) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1024), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1025) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1026), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1026) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1027), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1028) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1029), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1029) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1030), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1030) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1032), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1032) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1033), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1033) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1035), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1035) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1037), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1037) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1045), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1045) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1046), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1047) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1048), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1048) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1049), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1050) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1051), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1051) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1052), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1053) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1054), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1054) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1057), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1057) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1058), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1058) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1060), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1060) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1061), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1061) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1063), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1063) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1064), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1064) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1065), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1066) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1067), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1067) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1069), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1070) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1078), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1078) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1080), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1080) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1082), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1082) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1083), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1083) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1089), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1089) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1090), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1090) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1092), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1092) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1094), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1094) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1096), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1096) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1097), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1097) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1099), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1099) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1100), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1100) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1101), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1102) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1103), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1103) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1104), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1104) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1107), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1107) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1115), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1116) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1117), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1117) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1118), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1119) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1120), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1120) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1121), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1122) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1123), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1123) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1124), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1125) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1127), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1127) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1129), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1129) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1130), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1130) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1131), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1132) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1133), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1133) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1134), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1135) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1136), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1136) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1137), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1137) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1140), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1140) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1147), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1148) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1150), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1150) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1151), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1152) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1153), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1153) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1154), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1155) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1156), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1156) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1157), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1158) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1160), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1160) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1162), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1162) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1163), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1163) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1164), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1165) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1166), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1166) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1168), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1168) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1169), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1169) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1170), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1171) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1173), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1173) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1180), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1181) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1182), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1182) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1184), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1184) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1185), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1185) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1187), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1187) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1188), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1188) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1189), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1190) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1192), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1192) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1194), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1194) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1195), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1195) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1197), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1197) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1198), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1198) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1200), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1200) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1202), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1202) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1203), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1203) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1206), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1206) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1214), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1215) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1217), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1217) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1218), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1219) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1220), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1220) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1221), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1222) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1223), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1223) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1224), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1224) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1227), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1227) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1228), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1229) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1230), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1230) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1231), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1231) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1233), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1233) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1234), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1234) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1235), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1236) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1237), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1237) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1239), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1240) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1247), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1248) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1250), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1250) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1251), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1252) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1253), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1253) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1255), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1255) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1256), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1256) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1258), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1258) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1260), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1260) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1262), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1262) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1263), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1263) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1265), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1266) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1267), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1267) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1268), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1268) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1270), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1270) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1271), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1271) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1274), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1274) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1281), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1282) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1289), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1289) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1290), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1290) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1292), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1292) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1293), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1294) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1295), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1295) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1296), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1296) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1299), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1299) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1300), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1301) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1302), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1302) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1303), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1304) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1305), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1305) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1306), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1306) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1308), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1308) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1309), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1309) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1312), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1312) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1313), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1313) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1315), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1315) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1316), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1316) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1317), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(1318) });

        migrationBuilder.UpdateData(
            table: "manufacturer",
            keyColumn: "Id",
            keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 547, DateTimeKind.Utc).AddTicks(2072), new DateTime(2026, 8, 21, 9, 7, 13, 547, DateTimeKind.Utc).AddTicks(2073) });

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
            column: "ConcurrencyStamp",
            value: "ca5be815-31af-4f30-8985-2847085dafa6");

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
            column: "ConcurrencyStamp",
            value: "ac356d1b-9a64-4cfa-bda7-7bd28968cc9b");

        migrationBuilder.UpdateData(
            table: "saleschannel",
            keyColumn: "Id",
            keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 559, DateTimeKind.Utc).AddTicks(9341), new DateTime(2026, 8, 21, 9, 7, 13, 559, DateTimeKind.Utc).AddTicks(9343) });

        migrationBuilder.UpdateData(
            table: "saleschannel_sync_state",
            keyColumn: "Id",
            keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 562, DateTimeKind.Utc).AddTicks(2187), new DateTime(2026, 8, 21, 9, 7, 13, 562, DateTimeKind.Utc).AddTicks(2189) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(7815), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(7817) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8339), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8339) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8341), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8342) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8344), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8344) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8351), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8351) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8514), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8515) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8516), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8516) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8520), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8520) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8522), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8522) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8353), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8353) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8354), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8354) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8356), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8356) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8357), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8357) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8505), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8505) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8507), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8507) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8508), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8508) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8511), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8512) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8513), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8513) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8517), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8518) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8519), new DateTime(2026, 8, 21, 9, 7, 13, 589, DateTimeKind.Utc).AddTicks(8519) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 564, DateTimeKind.Utc).AddTicks(1538), new DateTime(2026, 8, 21, 9, 7, 13, 564, DateTimeKind.Utc).AddTicks(1539) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 564, DateTimeKind.Utc).AddTicks(1750), new DateTime(2026, 8, 21, 9, 7, 13, 564, DateTimeKind.Utc).AddTicks(1750) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 564, DateTimeKind.Utc).AddTicks(1753), new DateTime(2026, 8, 21, 9, 7, 13, 564, DateTimeKind.Utc).AddTicks(1753) });

        migrationBuilder.UpdateData(
            table: "warehouse",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(5664), new DateTime(2026, 8, 21, 9, 7, 13, 546, DateTimeKind.Utc).AddTicks(5665) });

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
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 456, DateTimeKind.Utc).AddTicks(9619), new DateTime(2026, 7, 8, 11, 10, 41, 456, DateTimeKind.Utc).AddTicks(9625) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(384), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(384) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(387), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(387) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(390), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(391) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(392), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(392) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(394), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(394) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(406), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(406) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(408), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(408) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(410), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(410) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(411), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(412) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(413), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(413) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(414), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(415) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(416), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(416) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(427), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(427) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(431), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(431) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(432), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(432) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(434), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(434) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(436), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(436) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(437), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(437) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(440), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(441) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(442), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(442) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(443), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(444) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(446), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(446) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(461), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(461) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(479), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(480) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(481), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(481) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(483), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(483) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(484), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(484) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(486), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(486) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(498), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(499) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(507), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(507) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(509), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(509) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(511), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(511) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(512), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(512) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(514), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(514) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(515), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(516) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(517), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(517) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(519), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(519) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(521), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(522) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(523), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(523) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(524), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(525) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(526), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(526) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(527), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(527) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(529), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(529) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(530), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(530) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(538), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(539) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(542), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(542) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(543), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(544) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(545), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(545) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(547), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(547) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(548), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(548) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(550), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(550) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(551), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(552) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(553), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(553) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(557), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(557) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(558), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(559) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(560), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(560) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(561), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(561) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(563), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(563) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(564), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(565) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(566), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(566) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(574), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(574) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(577), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(577) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(578), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(579) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(580), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(580) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(582), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(582) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(583), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(583) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(585), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(585) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(586), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(586) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(588), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(588) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(591), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(591) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(592), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(592) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(594), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(594) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(595), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(595) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(597), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(597) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(598), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(598) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(599), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(600) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(607), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(608) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(611), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(611) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(613), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(613) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(615), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(615) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(616), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(616) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(618), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(618) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(619), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(619) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(621), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(621) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(622), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(622) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(625), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(625) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(626), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(627) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(628), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(628) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(629), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(630) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(631), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(631) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(632), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(633) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(634), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(634) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(642), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(642) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(645), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(645) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(646), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(647) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(648), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(648) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(650), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(650) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(651), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(651) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(653), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(653) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(654), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(654) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(656), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(656) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(658), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(659) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(660), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(660) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(662), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(662) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(663), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(663) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(665), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(665) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(666), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(666) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(667), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(668) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(675), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(675) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(678), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(678) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(679), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(680) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(681), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(681) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(683), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(683) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(684), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(684) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(686), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(686) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(687), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(688) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(693), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(693) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(696), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(696) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(698), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(698) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(699), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(699) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(701), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(701) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(702), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(702) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(704), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(704) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(705), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(705) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(713), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(713) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(717), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(718) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(719), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(719) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(721), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(721) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(722), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(723) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(724), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(724) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(725), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(726) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(727), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(727) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(728), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(729) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(731), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(731) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(733), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(733) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(734), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(735) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(736), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(736) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(737), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(737) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(739), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(739) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(740), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(740) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(748), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(748) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(751), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(751) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(753), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(753) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(754), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(755) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(756), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(756) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(758), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(758) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(759), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(759) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(761), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(761) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(763), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(763) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(766), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(766) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(768), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(768) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(769), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(769) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(771), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(771) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(772), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(772) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(774), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(774) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(775), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(775) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(783), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(783) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(786), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(786) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(787), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(788) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(789), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(789) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(791), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(791) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(792), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(792) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(794), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(794) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(795), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(796) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(797), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(797) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(800), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(800) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(801), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(801) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(803), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(803) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(804), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(805) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(806), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(806) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(807), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(807) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(809), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(809) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(817), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(818) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(820), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(820) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(822), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(822) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(823), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(823) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(825), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(825) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(826), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(827) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(828), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(828) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(829), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(830) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(831), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(831) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(834), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(834) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(835), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(835) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(837), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(837) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(838), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(838) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(840), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(840) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(841), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(841) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(842), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(843) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(850), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(851) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(854), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(854) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(855), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(855) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(857), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(857) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(858), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(858) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(860), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(860) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(861), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(862) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(864), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(864) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(866), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(866) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(868), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(869) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(870), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(870) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(872), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(872) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(873), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(873) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(874), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(875) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(876), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(876) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(877), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(877) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(885), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(885) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(888), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(888) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(890), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(890) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(892), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(892) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(893), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(893) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(900), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(900) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(901), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(902) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(903), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(903) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(905), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(905) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(907), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(908) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(909), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(909) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(910), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(911) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(912), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(912) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(913), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(914) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(915), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(915) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(917), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(917) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(925), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(925) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(928), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(928) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(930), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(930) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(932), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(932) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(933), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(934) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(935), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(935) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(936), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(937) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(938), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(938) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(939), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(940) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(942), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(942) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(944), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(944) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(945), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(946) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(947), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(947) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(948), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(949) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(950), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(950) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(952), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(952) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(959), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(959) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(962), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(962) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(963), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(964) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(965), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(965) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(967), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(967) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(968), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(968) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(970), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(971) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(972), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(972) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(973), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(974) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(976), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(976) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(978), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(978) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(979), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(979) });

        migrationBuilder.UpdateData(
            table: "manufacturer",
            keyColumn: "Id",
            keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 458, DateTimeKind.Utc).AddTicks(3997), new DateTime(2026, 7, 8, 11, 10, 41, 458, DateTimeKind.Utc).AddTicks(3998) });

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
            column: "ConcurrencyStamp",
            value: "85f04a8d-53d9-48bb-9948-4e2c3c35fa74");

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
            column: "ConcurrencyStamp",
            value: "399c67c6-a4da-4493-942c-509e2c83b05d");

        migrationBuilder.UpdateData(
            table: "saleschannel",
            keyColumn: "Id",
            keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 474, DateTimeKind.Utc).AddTicks(7051), new DateTime(2026, 7, 8, 11, 10, 41, 474, DateTimeKind.Utc).AddTicks(7054) });

        migrationBuilder.UpdateData(
            table: "saleschannel_sync_state",
            keyColumn: "Id",
            keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 477, DateTimeKind.Utc).AddTicks(9604), new DateTime(2026, 7, 8, 11, 10, 41, 477, DateTimeKind.Utc).AddTicks(9607) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 516, DateTimeKind.Utc).AddTicks(9422), new DateTime(2026, 7, 8, 11, 10, 41, 516, DateTimeKind.Utc).AddTicks(9423) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(322), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(322) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(326), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(326) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(328), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(328) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(330), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(330) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(608), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(609) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(614), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(614) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(619), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(619) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(621), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(621) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(332), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(332) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(334), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(334) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(344), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(344) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(346), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(346) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(598), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(598) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(601), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(601) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(603), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(603) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(605), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(605) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(606), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(607) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(615), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(616) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(617), new DateTime(2026, 7, 8, 11, 10, 41, 517, DateTimeKind.Utc).AddTicks(617) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 479, DateTimeKind.Utc).AddTicks(3529), new DateTime(2026, 7, 8, 11, 10, 41, 479, DateTimeKind.Utc).AddTicks(3530) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 479, DateTimeKind.Utc).AddTicks(3748), new DateTime(2026, 7, 8, 11, 10, 41, 479, DateTimeKind.Utc).AddTicks(3748) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 479, DateTimeKind.Utc).AddTicks(3750), new DateTime(2026, 7, 8, 11, 10, 41, 479, DateTimeKind.Utc).AddTicks(3750) });

        migrationBuilder.UpdateData(
            table: "warehouse",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(7230), new DateTime(2026, 7, 8, 11, 10, 41, 457, DateTimeKind.Utc).AddTicks(7230) });
    }
}
