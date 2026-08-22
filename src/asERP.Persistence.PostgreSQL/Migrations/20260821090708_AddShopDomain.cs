using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.PostgreSQL.Migrations;

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
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                SalesChannelId = table.Column<Guid>(type: "uuid", nullable: false),
                Host = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                Port = table.Column<int>(type: "integer", nullable: false),
                IsPrimary = table.Column<bool>(type: "boolean", nullable: false),
                RedirectToPrimary = table.Column<bool>(type: "boolean", nullable: false),
                DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                TenantId = table.Column<Guid>(type: "uuid", nullable: true)
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
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(6317), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(6330) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7051), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7051) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7054), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7054) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7055), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7056) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7057), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7057) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7059), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7059) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7060), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7060) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7062), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7062) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7063), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7063) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7066), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7066) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7067), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7068) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7069), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7069) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7070), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7070) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7072), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7072) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7073), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7073) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7075), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7075) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7084), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7084) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7088), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7088) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7089), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7090) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7091), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7091) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7092), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7093) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7094), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7094) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7095), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7095) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7097), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7097) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7098), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7098) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7101), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7101) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7102), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7102) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7104), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7104) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7105), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7105) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7116), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7117) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7130), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7131) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7132), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7132) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7140), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7141) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7143), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7143) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7145), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7145) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7146), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7146) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7148), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7148) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7149), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7149) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7151), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7151) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7152), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7152) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7153), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7154) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7156), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7156) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7158), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7158) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7159), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7159) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7161), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7161) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7162), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7162) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7164), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7164) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7165), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7165) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7173), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7174) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7176), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7177) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7178), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7178) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7180), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7180) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7181), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7181) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7183), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7183) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7184), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7184) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7186), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7186) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7187), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7187) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7190), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7190) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7191), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7191) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7192), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7193) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7194), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7194) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7195), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7195) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7197), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7197) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7198), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7198) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7206), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7206) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7209), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7209) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7211), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7212) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7213), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7213) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7214), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7214) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7216), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7216) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7217), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7217) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7219), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7219) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7220), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7220) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7223), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7223) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7224), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7224) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7226), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7226) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7227), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7227) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7228), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7228) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7230), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7230) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7231), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7231) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7238), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7239) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7241), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7241) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7243), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7243) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7244), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7244) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7246), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7246) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7247), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7247) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7249), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7249) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7250), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7250) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7252), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7252) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7254), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7254) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7256), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7256) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7257), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7257) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7258), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7259) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7260), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7260) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7261), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7261) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7263), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7263) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7270), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7270) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7272), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7273) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7274), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7274) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7276), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7276) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7277), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7277) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7278), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7279) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7280), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7280) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7281), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7282) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7283), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7283) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7285), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7285) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7287), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7287) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7288), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7288) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7289), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7290) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7291), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7291) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7292), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7292) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7293), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7294) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7301), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7301) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7304), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7304) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7305), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7306) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7307), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7307) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7308), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7309) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7310), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7310) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7311), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7312) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7313), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7313) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7314), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7314) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7317), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7317) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7318), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7318) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7324), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7324) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7325), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7325) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7326), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7327) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7328), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7328) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7329), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7329) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7337), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7337) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7340), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7340) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7341), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7342) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7343), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7343) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7344), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7345) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7346), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7346) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7347), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7347) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7349), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7349) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7350), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7350) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7352), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7353) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7354), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7354) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7355), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7356) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7357), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7357) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7358), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7358) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7359), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7360) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7361), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7361) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7368), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7368) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7371), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7371) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7372), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7372) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7374), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7374) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7375), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7375) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7377), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7377) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7378), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7378) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7380), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7380) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7381), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7381) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7383), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7384) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7385), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7385) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7386), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7386) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7388), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7388) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7389), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7389) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7391), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7391) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7392), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7392) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7399), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7399) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7402), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7402) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7404), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7404) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7405), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7405) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7407), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7407) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7408), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7408) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7409), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7410) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7411), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7411) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7412), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7412) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7415), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7415) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7416), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7416) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7418), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7418) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7419), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7419) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7420), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7420) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7422), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7422) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7423), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7423) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7431), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7431) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7435), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7435) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7436), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7437) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7438), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7438) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7439), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7440) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7441), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7441) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7442), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7442) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7443), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7444) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7445), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7445) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7447), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7448) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7449), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7449) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7450), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7450) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7452), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7452) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7453), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7453) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7454), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7455) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7456), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7456) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7463), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7464) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7467), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7467) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7468), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7469) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7470), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7470) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7471), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7472) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7473), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7473) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7474), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7474) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7476), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7476) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7477), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7477) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7479), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7480) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7481), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7481) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7482), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7483) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7484), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7484) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7485), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7485) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7486), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7487) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7488), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7488) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7496), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7496) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7498), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7498) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7500), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7500) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7501), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7501) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7503), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7503) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7504), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7504) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7506), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7506) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7507), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7507) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7513), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7513) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7515), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7516) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7517), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7517) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7518), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7519) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7520), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7520) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7521), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7521) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7523), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7523) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7524), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7524) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7531), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7532) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7534), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7534) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7535), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7536) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7537), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7537) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7539), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7539) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7540), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7540) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7541), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7542) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7543), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7543) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7545), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7545) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7547), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7547) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7549), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7549) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7550), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7551) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7552), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7552) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7554), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7554) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7555), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7555) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7557), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7557) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7558), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7559) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7561), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7561) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7562), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7562) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7564), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7564) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7565), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7565) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7567), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7567) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7568), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7569) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7570), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7570) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7571), new DateTime(2026, 8, 21, 9, 7, 7, 912, DateTimeKind.Utc).AddTicks(7572) });

        migrationBuilder.UpdateData(
            table: "manufacturer",
            keyColumn: "Id",
            keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 913, DateTimeKind.Utc).AddTicks(8745), new DateTime(2026, 8, 21, 9, 7, 7, 913, DateTimeKind.Utc).AddTicks(8746) });

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
            column: "ConcurrencyStamp",
            value: "86b29505-ebbd-4e47-87f7-d16ecc3434c6");

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
            column: "ConcurrencyStamp",
            value: "b303743f-14da-4dcc-801e-f2b971008be3");

        migrationBuilder.UpdateData(
            table: "saleschannel",
            keyColumn: "Id",
            keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 925, DateTimeKind.Utc).AddTicks(444), new DateTime(2026, 8, 21, 9, 7, 7, 925, DateTimeKind.Utc).AddTicks(446) });

        migrationBuilder.UpdateData(
            table: "saleschannel_sync_state",
            keyColumn: "Id",
            keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 927, DateTimeKind.Utc).AddTicks(2024), new DateTime(2026, 8, 21, 9, 7, 7, 927, DateTimeKind.Utc).AddTicks(2025) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8232), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8235) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8745), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8746) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8755), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8755) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8757), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8757) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8758), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8758) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8903), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8904) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8905), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8905) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8910), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8910) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8912), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8912) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8760), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8760) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8761), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8761) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8762), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8763) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8764), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8764) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8896), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8896) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8898), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8898) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8899), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8899) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8901), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8901) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8902), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8902) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8906), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8906) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8909), new DateTime(2026, 8, 21, 9, 7, 7, 953, DateTimeKind.Utc).AddTicks(8909) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 929, DateTimeKind.Utc).AddTicks(1486), new DateTime(2026, 8, 21, 9, 7, 7, 929, DateTimeKind.Utc).AddTicks(1488) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 929, DateTimeKind.Utc).AddTicks(1702), new DateTime(2026, 8, 21, 9, 7, 7, 929, DateTimeKind.Utc).AddTicks(1702) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 929, DateTimeKind.Utc).AddTicks(1704), new DateTime(2026, 8, 21, 9, 7, 7, 929, DateTimeKind.Utc).AddTicks(1704) });

        migrationBuilder.UpdateData(
            table: "warehouse",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 8, 21, 9, 7, 7, 913, DateTimeKind.Utc).AddTicks(2441), new DateTime(2026, 8, 21, 9, 7, 7, 913, DateTimeKind.Utc).AddTicks(2443) });

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
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(4529), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(4543) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5369), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5369) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5381), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5381) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5383), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5383) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5384), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5385) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5386), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5386) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5388), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5388) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5389), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5389) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5391), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5391) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5392), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5392) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5396), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5396) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5397), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5398) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5399), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5399) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5400), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5400) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5402), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5402) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5403), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5403) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5413), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5413) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5415), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5415) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5419), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5419) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5420), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5420) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5422), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5422) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5423), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5424) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5425), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5425) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5427), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5427) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5428), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5428) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5430), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5430) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5432), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5433) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5434), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5434) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5435), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5436) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5437), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5437) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5438), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5438) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5440), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5440) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5448), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5448) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5449), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5450) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5452), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5452) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5454), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5454) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5455), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5455) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5457), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5457) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5458), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5458) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5460), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5460) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5461), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5461) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5463), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5463) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5465), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5465) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5467), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5467) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5468), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5468) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5469), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5470) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5471), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5471) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5472), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5472) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5480), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5480) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5482), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5482) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5486), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5486) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5487), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5488) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5489), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5489) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5491), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5491) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5492), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5492) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5494), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5494) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5495), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5495) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5497), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5497) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5499), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5500) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5501), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5501) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5502), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5503) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5504), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5504) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5505), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5505) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5507), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5507) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5514), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5514) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5516), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5516) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5518), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5519) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5520), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5520) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5522), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5522) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5523), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5523) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5525), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5525) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5526), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5526) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5528), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5528) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5529), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5530) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5532), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5532) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5535), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5535) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5536), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5536) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5538), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5538) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5546), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5546) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5548), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5548) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5555), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5555) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5557), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5557) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5559), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5559) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5561), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5561) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5562), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5563) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5564), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5564) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5565), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5566) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5567), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5567) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5568), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5568) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5570), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5570) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5572), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5572) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5574), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5574) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5575), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5575) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5576), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5577) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5578), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5578) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5579), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5579) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5587), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5587) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5589), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5590) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5592), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5592) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5595), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5595) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5597), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5597) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5598), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5598) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5599), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5600) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5601), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5601) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5602), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5603) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5604), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5604) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5607), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5607) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5608), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5608) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5609), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5610) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5611), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5611) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5612), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5613) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5614), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5614) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5622), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5622) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5623), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5624) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5626), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5626) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5628), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5628) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5629), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5629) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5631), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5631) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5632), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5632) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5634), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5634) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5635), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5635) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5636), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5637) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5639), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5639) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5642), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5642) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5643), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5643) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5644), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5645) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5646), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5646) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5647), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5647) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5655), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5655) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5656), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5656) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5659), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5659) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5660), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5661) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5662), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5662) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5664), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5664) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5665), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5665) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5667), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5667) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5668), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5669) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5670), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5670) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5672), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5673) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5674), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5674) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5675), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5675) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5677), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5677) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5678), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5678) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5679), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5680) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5687), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5687) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5689), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5690) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5693), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5693) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5695), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5695) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5696), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5696) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5698), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5698) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5699), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5700) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5701), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5701) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5702), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5703) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5704), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5704) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5707), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5707) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5708), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5708) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5710), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5710) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5711), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5711) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5713), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5713) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5714), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5715) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5722), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5722) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5724), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5724) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5727), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5727) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5728), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5728) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5730), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5730) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5731), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5732) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5733), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5733) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5735), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5735) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5736), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5736) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5738), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5738) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5741), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5742) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5747), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5747) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5748), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5748) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5750), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5750) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5751), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5751) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5753), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5753) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5761), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5761) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5763), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5763) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5765), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5766) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5767), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5767) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5768), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5769) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5770), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5770) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5771), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5771) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5773), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5773) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5774), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5774) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5775), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5776) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5778), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5778) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5780), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5780) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5781), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5781) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5782), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5783) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5784), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5784) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5785), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5785) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5793), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5793) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5795), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5795) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5797), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5798) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5799), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5800) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5801), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5801) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5802), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5803) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5804), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5804) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5805), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5806) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5807), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5807) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5808), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5809) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5811), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5811) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5813), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5813) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5814), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5814) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5816), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5816) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5817), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5817) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5819), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5819) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5826), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5827) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5828), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5829) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5831), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5832) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5833), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5833) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5835), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5835) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5836), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5836) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5838), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5838) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5839), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5840) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5841), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5841) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5843), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5843) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5846), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5846) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5847), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5848) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5849), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5849) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5850), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5851) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5852), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5852) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5853), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5854) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5861), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5861) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5863), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5863) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5866), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5866) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5868), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5868) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5869), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5869) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5871), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5871) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5872), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5873) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5874), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5874) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5875), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5876) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5877), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5877) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5880), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5880) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5881), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5882) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5883), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5883) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5885), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5885) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5886), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5886) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5888), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5888) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5889), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5889) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5891), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5892) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5894), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5894) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5896), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5896) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5897), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5898) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5899), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5899) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5900), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5901) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5902), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5902) });

        migrationBuilder.UpdateData(
            table: "country",
            keyColumn: "Id",
            keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5903), new DateTime(2026, 7, 8, 11, 28, 15, 443, DateTimeKind.Utc).AddTicks(5904) });

        migrationBuilder.UpdateData(
            table: "manufacturer",
            keyColumn: "Id",
            keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 444, DateTimeKind.Utc).AddTicks(7887), new DateTime(2026, 7, 8, 11, 28, 15, 444, DateTimeKind.Utc).AddTicks(7889) });

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
            column: "ConcurrencyStamp",
            value: "4c697aad-195b-403a-b9ec-25fd68ea6371");

        migrationBuilder.UpdateData(
            table: "role",
            keyColumn: "Id",
            keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
            column: "ConcurrencyStamp",
            value: "4f310c6b-80c0-409d-9f0a-7b5699bf34c5");

        migrationBuilder.UpdateData(
            table: "saleschannel",
            keyColumn: "Id",
            keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 458, DateTimeKind.Utc).AddTicks(7188), new DateTime(2026, 7, 8, 11, 28, 15, 458, DateTimeKind.Utc).AddTicks(7192) });

        migrationBuilder.UpdateData(
            table: "saleschannel_sync_state",
            keyColumn: "Id",
            keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 461, DateTimeKind.Utc).AddTicks(758), new DateTime(2026, 7, 8, 11, 28, 15, 461, DateTimeKind.Utc).AddTicks(760) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4122), new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4124) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4616), new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4616) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4626), new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4626) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4627), new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4628) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4629), new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4630) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4779), new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4779) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4780), new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4780) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4785), new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4786) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4787), new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4787) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4631), new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4631) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4632), new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4633) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4634), new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4634) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4635), new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4635) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4762), new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4762) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4766), new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4766) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4767), new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4767) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4769), new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4769) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4777), new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4777) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4781), new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4782) });

        migrationBuilder.UpdateData(
            table: "setting",
            keyColumn: "Id",
            keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4783), new DateTime(2026, 7, 8, 11, 28, 15, 487, DateTimeKind.Utc).AddTicks(4783) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 462, DateTimeKind.Utc).AddTicks(4487), new DateTime(2026, 7, 8, 11, 28, 15, 462, DateTimeKind.Utc).AddTicks(4488) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 462, DateTimeKind.Utc).AddTicks(4694), new DateTime(2026, 7, 8, 11, 28, 15, 462, DateTimeKind.Utc).AddTicks(4694) });

        migrationBuilder.UpdateData(
            table: "tax_class",
            keyColumn: "Id",
            keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 462, DateTimeKind.Utc).AddTicks(4697), new DateTime(2026, 7, 8, 11, 28, 15, 462, DateTimeKind.Utc).AddTicks(4697) });

        migrationBuilder.UpdateData(
            table: "warehouse",
            keyColumn: "Id",
            keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
            columns: new[] { "DateCreated", "DateModified" },
            values: new object[] { new DateTime(2026, 7, 8, 11, 28, 15, 444, DateTimeKind.Utc).AddTicks(1388), new DateTime(2026, 7, 8, 11, 28, 15, 444, DateTimeKind.Utc).AddTicks(1390) });
    }
}
