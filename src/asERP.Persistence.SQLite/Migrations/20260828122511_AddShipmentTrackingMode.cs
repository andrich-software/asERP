using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class AddShipmentTrackingMode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShipmentTrackingMode",
                table: "saleschannel",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "saleschannel_carrier_mapping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RemoteCarrierCode = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ShippingProviderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saleschannel_carrier_mapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_saleschannel_carrier_mapping_saleschannel_SalesChannelId",
                        column: x => x.SalesChannelId,
                        principalTable: "saleschannel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_saleschannel_carrier_mapping_shipping_provider_ShippingProviderId",
                        column: x => x.ShippingProviderId,
                        principalTable: "shipping_provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 571, DateTimeKind.Utc).AddTicks(9605), new DateTime(2026, 8, 28, 12, 25, 10, 571, DateTimeKind.Utc).AddTicks(9611) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(380), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(391), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(391) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(393), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(393) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(395), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(395) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(397), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(397) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(408), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(408) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(411), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(411) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(413), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(413) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(415), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(415) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(419), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(419) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(421), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(421) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(422), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(423) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(424), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(424) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(425), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(427), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(427) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(429), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(429) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(430), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(433), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(435), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(435) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(436), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(436) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(438), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(438) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(446), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(446) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(448), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(448) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(449), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(452), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(452) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(455), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(455) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(456), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(457) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(458), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(458) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(476), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(477) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(480), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(482), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(482) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(483), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(483) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(485), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(485) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(487), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(488) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(489), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(489) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(491), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(491) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(492), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(492) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(501), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(501) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(503), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(503) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(504), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(505) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(506), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(506) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(628), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(629) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(630), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(631) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(632), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(632) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(634), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(634) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(636), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(636) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(637), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(638) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(639), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(639) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(642), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(642) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(645), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(645) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(646), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(648), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(648) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(649), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(658), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(658) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(660), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(661), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(662) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(663), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(663) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(666), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(666) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(667), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(668) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(669), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(669) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(671), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(671) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(672), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(672) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(674), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(674) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(675), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(675) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(677), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(677) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(679), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(680) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(681), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(681) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(682), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(682) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(684), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(684) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(692), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(692) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(694), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(694) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(695), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(696) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(697), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(697) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(700), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(701), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(701) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(703), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(703) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(704), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(705) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(706), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(706) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(708), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(708) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(709), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(709) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(711), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(711) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(713), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(714) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(715), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(715) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(716), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(717) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(718), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(718) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(726), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(726) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(728), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(728) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(730), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(731), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(731) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(734), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(734) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(736), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(736) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(737), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(737) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(739), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(739) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(740), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(742), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(742) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(743), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(743) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(746), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(746) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(749), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(749) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(750), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(752), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(752) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(753), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(753) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(762), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(762) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(764), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(764) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(765), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(766) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(767), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(767) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(770), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(771), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(772) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(773), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(773) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(774), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(775) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(776), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(776) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(778), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(778) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(779), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(779) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(781), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(781) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(783), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(784) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(785), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(785) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(786), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(787) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(788), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(788) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(796), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(796) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(798), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(798) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(799), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(799) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(802), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(802) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(806), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(806) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(807), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(807) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(809), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(809) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(810), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(811) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(813), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(813) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(815), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(815) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(816), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(816) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(818), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(818) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(821), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(821) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(822), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(822) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(823), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(824) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(825), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(825) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(833), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(834) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(841), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(841) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(842), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(843) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(844), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(844) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(847), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(847) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(849), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(849) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(850), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(852), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(852) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(853), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(853) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(855), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(855) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(857), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(857) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(858), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(859) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(861), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(861) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(863), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(863) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(864), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(865) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(866), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(866) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(874), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(875) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(876), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(876) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(878), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(878) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(879), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(879) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(882), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(882) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(884), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(884) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(885), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(885) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(887), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(887) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(888), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(888) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(890), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(891), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(891) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(893), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(893) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(896), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(896) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(897), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(897) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(898), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(899) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(900), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(909), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(909) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(912), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(912) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(913), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(914) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(915), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(915) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(918), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(918) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(919), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(921), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(921) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(922), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(923) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(924), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(924) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(926), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(926) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(927), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(927) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(929), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(929) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(931), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(932) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(933), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(933) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(934), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(935) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(936), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(936) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(944), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(944) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(946), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(946) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(947), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(948) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(949), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(949) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(952), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(952) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(953), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(954) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(955), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(955) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(957), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(957) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(958), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(958) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(961), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(961) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(962), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(962) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(964), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(964) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(967), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(967) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(968), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(968) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(970), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(970) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(971), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(971) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(979), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(979) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(981), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(981) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(982), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(983) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(984), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(984) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(987), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(987) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(988), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(989) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(990), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(991), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(992) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(993), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(993) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(994), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(995) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(996), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(996) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(998), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(998) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1000), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1001) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1002), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1002) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1003), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1003) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1005), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1005) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1013), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1013) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1015), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1015) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1016), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1017) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1018), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1018) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1021), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1021) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1022), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1023) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1024), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1024) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1026), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1026) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1027), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1027) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1029), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1029) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1030), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1032), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1032) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1034), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1035) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1036), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1036) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1043), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1043) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1045), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1045) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1053), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1054) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1056), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1056) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1057), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1058) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1059), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1059) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1062), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1062) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1063), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1063) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1065), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1065) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1066), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1066) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1069), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1069) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1070), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1072), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1072) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1073), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1073) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1076), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1076) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1078), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1078) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1079), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1079) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1081), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1081) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1082), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1083), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1084) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1085), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(1085) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 573, DateTimeKind.Utc).AddTicks(4029), new DateTime(2026, 8, 28, 12, 25, 10, 573, DateTimeKind.Utc).AddTicks(4031) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "7369fd7c-7a1d-4a08-9840-b9faf76fd9ee");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "852a57d6-0f25-4d90-bd43-5f96dea9655e");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified", "ShipmentTrackingMode" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 584, DateTimeKind.Utc).AddTicks(9078), new DateTime(2026, 8, 28, 12, 25, 10, 584, DateTimeKind.Utc).AddTicks(9082), 0 });

            migrationBuilder.UpdateData(
                table: "saleschannel_sync_state",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 587, DateTimeKind.Utc).AddTicks(4049), new DateTime(2026, 8, 28, 12, 25, 10, 587, DateTimeKind.Utc).AddTicks(4053) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3214), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3218) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3790), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3790) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3794), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3794) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3796), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3796) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3804), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3804) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3961), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3962) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3963), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3963) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3967), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3968) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3969), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3969) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3805), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3806) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3807), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3807) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3808), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3809) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3810), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3810) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3950), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3951) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3952), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3953) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3954), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3955) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3958), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3958) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3960), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3960) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3964), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3965) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3966), new DateTime(2026, 8, 28, 12, 25, 10, 620, DateTimeKind.Utc).AddTicks(3966) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 590, DateTimeKind.Utc).AddTicks(8730), new DateTime(2026, 8, 28, 12, 25, 10, 590, DateTimeKind.Utc).AddTicks(8731) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 590, DateTimeKind.Utc).AddTicks(8951), new DateTime(2026, 8, 28, 12, 25, 10, 590, DateTimeKind.Utc).AddTicks(8951) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 590, DateTimeKind.Utc).AddTicks(8953), new DateTime(2026, 8, 28, 12, 25, 10, 590, DateTimeKind.Utc).AddTicks(8953) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(7143), new DateTime(2026, 8, 28, 12, 25, 10, 572, DateTimeKind.Utc).AddTicks(7146) });

            migrationBuilder.CreateIndex(
                name: "IX_saleschannel_carrier_mapping_SalesChannelId_RemoteCarrierCode",
                table: "saleschannel_carrier_mapping",
                columns: new[] { "SalesChannelId", "RemoteCarrierCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_saleschannel_carrier_mapping_ShippingProviderId",
                table: "saleschannel_carrier_mapping",
                column: "ShippingProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_saleschannel_carrier_mapping_TenantId",
                table: "saleschannel_carrier_mapping",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "saleschannel_carrier_mapping");

            migrationBuilder.DropColumn(
                name: "ShipmentTrackingMode",
                table: "saleschannel");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 16, DateTimeKind.Utc).AddTicks(8646), new DateTime(2026, 8, 28, 11, 41, 5, 16, DateTimeKind.Utc).AddTicks(8651) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(623), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(626) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(634), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(634) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(638), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(639) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(642), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(642) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(645), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(646) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(681), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(681) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(685), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(685) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(693), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(693) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(695), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(696) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(698), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(698) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(703), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(703) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(705), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(706) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(708), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(708) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(710), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(711) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(713), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(713) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(717), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(718) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(720), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(722), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(723) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(725), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(725) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(728), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(728) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(730), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(731) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(747), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(747) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(749), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(754), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(755) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(757), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(757) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(759), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(761), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(762) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(764), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(764) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(786), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(787) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(792), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(792) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(795), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(796) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(832), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(833) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(835), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(835) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(837), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(838) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(841), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(841) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(843), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(843) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(845), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(846) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(862), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(863) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(865), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(865) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(869), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(869) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(872), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(872) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(874), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(874) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(876), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(877) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(879), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(879) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(881), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(882) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(884), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(884) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(887), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(887) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(891), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(892) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(894), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(894) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(896), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(897) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(899), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(899) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(901), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(901) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(905), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(905) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(923), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(924) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(926), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(926) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(930), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(931) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(933), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(933) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(935), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(936) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(938), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(938) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(941), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(941) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(943), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(943) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(945), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(946) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(948), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(948) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(952), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(953) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(955), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(955) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(957), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(958) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(960), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(962), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(963) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(965), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(965) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(980), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(982), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(983) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(987), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(987) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(989), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(992), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(992) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(994), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(995) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(997), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(997) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(999), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(999) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1001), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1002) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1004), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1004) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1008), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1009) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1011), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1011) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1013), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1013) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1015), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1016) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1018), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1018) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1020), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1021) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1036), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1036) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1038), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1039) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1043), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1043) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1045), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1045) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1047), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1048) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1050), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1052), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1052) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1055), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1055) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1057), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1057) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1059), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1064), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1064) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1066), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1066) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1068), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1069) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1071), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1071) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1073), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1073) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1075), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1075) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1091), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1091) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1093), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1094) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1098), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1098) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1100), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1101) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1103), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1103) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1105), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1106) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1108), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1108) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1110), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1111) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1113), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1113) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1115), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1116) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1120), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1122), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1123) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1125), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1125) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1127), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1127) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1129), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1132), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1132) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1147), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1147) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1149), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1154), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1154) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1156), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1157) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1159), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1159) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1161), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1162) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1164), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1164) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1177), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1178) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1182), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1182) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1184), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1185) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1189), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1189) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1191), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1192) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1194), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1194) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1196), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1196) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1199), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1199) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1201), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1201) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1216), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1217) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1219), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1219) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1223), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1224) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1226), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1226) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1228), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1229) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1231), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1231) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1233), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1234) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1237), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1237) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1239), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1242), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1242) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1246), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1247) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1249), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1249) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1251), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1251) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1254), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1254) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1256), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1256) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1258), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1259) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1274), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1275) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1277), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1277) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1281), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1282) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1284), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1284) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1286), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1287) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1289), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1289) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1291), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1291) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1294), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1294) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1296), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1296) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1298), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1299) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1303), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1303) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1305), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1306) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1308), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1308) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1310), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1312), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1313) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1315), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1315) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1331), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1331) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1335), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1335) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1339), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1339) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1342), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1342) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1344), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1344) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1347), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1347) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1349), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1349) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1353), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1353) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1355), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1356) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1358), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1358) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1362), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1363) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1365), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1365) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1367), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1368) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1370), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1372), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1373) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1375), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1375) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1390), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1392), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1393) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1397), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1397) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1399), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1402), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1402) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1404), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1405) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1407), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1407) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1409), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1412), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1412) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1415), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1416) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1420), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1422), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1423) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1425), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1425) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1428), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1428) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1430), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1431) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1433), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1433) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1448), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1448) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1450), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1451) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1455), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1455) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1458), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1458) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1460), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1463), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1463) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1465), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1465) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1467), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1468) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1470), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1472), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1472) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1477), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1477) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1479), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1479) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1481), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1482) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1484), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1484) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1486), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1487) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1489), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1489) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1504), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1504) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1507), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1507) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1511), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1511) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1513), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1514) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1524), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1525) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1527), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1527) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1531), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1531) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1533), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1533) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1536), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1536) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1538), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1538) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1542), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1543) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1545), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1545) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1547), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1547) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1549), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1550) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1551), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1552) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1554), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1554) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1570), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1572), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1572) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1576), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1577) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1579), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1579) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1581), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1582) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1584), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1584) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1586), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1586) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1589), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1589) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1591), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1591) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1593), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1594) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1599), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1599) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1601), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1602) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1603), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1604) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1606), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1606) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1609), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1612), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1612) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1614), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1614) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1616), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1617) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1621), new DateTime(2026, 8, 28, 11, 41, 5, 17, DateTimeKind.Utc).AddTicks(1621) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 19, DateTimeKind.Utc).AddTicks(8178), new DateTime(2026, 8, 28, 11, 41, 5, 19, DateTimeKind.Utc).AddTicks(8181) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "7be45078-dcbd-4209-af38-82b3afc79893");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "1bf79fc5-a435-4633-a864-dc1904ecc675");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 82, DateTimeKind.Utc).AddTicks(3431), new DateTime(2026, 8, 28, 11, 41, 5, 82, DateTimeKind.Utc).AddTicks(3436) });

            migrationBuilder.UpdateData(
                table: "saleschannel_sync_state",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 85, DateTimeKind.Utc).AddTicks(9593), new DateTime(2026, 8, 28, 11, 41, 5, 85, DateTimeKind.Utc).AddTicks(9596) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 153, DateTimeKind.Utc).AddTicks(8982), new DateTime(2026, 8, 28, 11, 41, 5, 153, DateTimeKind.Utc).AddTicks(8987) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(238), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(239) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(244), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(244) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(247), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(247) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(249), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(250) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(660), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(660) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(663), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(664) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(670), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(671) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(673), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(673) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(252), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(252) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(267), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(267) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(269), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(270) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(272), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(272) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(625), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(625) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(629), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(629) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(648), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(648) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(650), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(651) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(653), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(653) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(666), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(666) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(668), new DateTime(2026, 8, 28, 11, 41, 5, 154, DateTimeKind.Utc).AddTicks(668) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 89, DateTimeKind.Utc).AddTicks(8445), new DateTime(2026, 8, 28, 11, 41, 5, 89, DateTimeKind.Utc).AddTicks(8450) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 89, DateTimeKind.Utc).AddTicks(8783), new DateTime(2026, 8, 28, 11, 41, 5, 89, DateTimeKind.Utc).AddTicks(8784) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 89, DateTimeKind.Utc).AddTicks(8787), new DateTime(2026, 8, 28, 11, 41, 5, 89, DateTimeKind.Utc).AddTicks(8787) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 41, 5, 18, DateTimeKind.Utc).AddTicks(2599), new DateTime(2026, 8, 28, 11, 41, 5, 18, DateTimeKind.Utc).AddTicks(2602) });
        }
    }
}
