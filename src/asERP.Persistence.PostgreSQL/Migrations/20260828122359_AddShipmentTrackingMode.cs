using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.PostgreSQL.Migrations
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
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "saleschannel_carrier_mapping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "uuid", nullable: false),
                    RemoteCarrierCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ShippingProviderId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
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
                        name: "FK_saleschannel_carrier_mapping_shipping_provider_ShippingProv~",
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
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(3717), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(3722) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4440), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4465), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4465) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4467), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4467) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4469), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4469) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4472), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4472) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4473), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4473) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4476), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4476) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4478), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4478) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4479), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4479) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4482), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4483) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4484), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4485) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4497), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4497) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4499), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4499) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4500), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4511) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4512), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4513) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4514), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4514) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4515), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4515) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4518), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4518) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4519), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4519) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4521), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4521) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4522), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4522) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4523), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4524) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4525), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4525) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4527), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4527) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4531), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4532) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4534), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4534) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4536), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4536) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4544), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4544) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4553), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4553) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4559), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4560) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4561), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4561) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4562), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4562) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4564), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4564) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4566), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4567) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4568), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4568) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4569), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4569) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4571), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4571) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4572), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4572) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4573), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4573) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4575), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4575) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4576), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4576) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4578), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4579) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4580), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4580) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4587), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4588) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4589), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4589) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4590), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4591) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4592), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4592) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4593), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4593) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4596), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4596) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4598), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4599) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4600), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4601), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4601) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4603), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4603) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4604), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4604) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4605), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4606) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4607), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4607) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4608), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4609) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4611), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4611) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4613), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4613) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4620), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4621) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4622), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4622) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4623), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4623) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4625), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4625) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4626), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4626) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4628), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4628) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4630), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4631), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4632) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4633), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4633) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4634), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4634) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4636), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4636) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4637), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4637) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4638), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4639) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4641), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4641) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4643), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4644) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4645), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4645) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4652), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4652) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4654), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4654) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4655), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4655) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4657), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4657) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4658), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4658) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4659), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4660) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4662), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4662) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4663), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4664) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4665), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4665) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4666), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4666) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4667), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4668) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4669), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4669) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4670), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4672), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4672) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4674), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4674) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4676), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4676) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4683), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4683) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4685), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4685) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4686), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4686) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4692), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4692) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4693), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4694) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4695), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4695) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4698), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4699) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4700), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4701), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4701) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4703), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4703) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4704), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4704) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4705), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4706) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4707), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4707) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4708), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4708) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4711), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4711) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4712), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4712) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4720), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4721), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4722) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4723), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4723) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4724), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4724) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4726), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4726) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4727), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4727) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4730), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4730) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4732), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4732) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4733), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4733) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4734), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4734) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4736), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4736) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4737), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4737) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4738), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4738) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4740), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4743), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4744) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4745), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4745) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4753), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4753) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4755), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4755) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4756), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4757) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4758), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4758) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4759), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4759) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4761), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4761) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4763), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4763) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4764), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4764) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4766), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4766) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4767), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4767) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4768), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4769) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4770), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4771), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4771) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4773), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4773) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4775), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4775) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4776), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4777) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4784), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4785) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4786), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4786) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4788), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4788) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4790), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4791), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4791) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4793), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4794) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4796), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4796) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4797), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4798) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4799), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4799) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4800), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4801), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4802) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4803), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4803) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4804), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4804) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4805), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4806) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4808), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4808) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4810), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4817), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4817) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4819), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4819) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4820), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4821) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4822), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4822) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4823), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4823) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4825), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4825) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4827), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4827) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4829), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4829) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4830), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4831), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4832) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4833), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4833) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4834), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4834) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4837), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4837) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4838), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4838) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4841), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4841) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4842), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4842) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4850), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4851), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4851) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4853), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4853) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4854), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4854) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4855), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4856) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4857), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4857) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4859), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4860) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4861), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4861) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4862), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4862) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4864), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4864) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4865), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4865) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4866), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4867) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4868), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4868) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4869), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4872), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4872) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4873), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4873) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4878), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4879) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4886), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4886) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4888), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4888) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4889), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4889) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4892), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4892) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4893), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4893) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4895), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4896) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4897), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4897) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4898), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4898) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4900), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4901), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4901) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4902), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4902) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4904), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4904) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4905), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4905) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4908), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4908) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4909), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4909) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4910), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4911) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4918), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4918) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4920), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4921), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4921) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4922), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4923) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4924), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4924) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4926), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4927) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4928), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4928) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4929), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4929) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4931), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4931) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4932), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4932) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4933), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4934) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4936), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4936) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4937), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4937) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4940), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4941), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4941) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4942), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4943) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4950), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4952), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4952) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4953), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4953) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4955), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4955) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4956), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4956) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4959), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4959) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4960), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4962), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4962) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4963), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4963) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4964), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4964) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4966), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4966) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4967), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4967) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4968), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4969) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4971), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4971) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4972), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4972) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4974), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4974) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4982), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4982) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4983), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4983) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4986), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4986) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4987), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4987) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4988), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4989) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4991), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4991) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4992), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4993) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4994), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4994) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4995), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4995) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4997), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4997) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4998), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4998) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4999), new DateTime(2026, 8, 28, 12, 23, 58, 497, DateTimeKind.Utc).AddTicks(4999) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 498, DateTimeKind.Utc).AddTicks(6957), new DateTime(2026, 8, 28, 12, 23, 58, 498, DateTimeKind.Utc).AddTicks(6959) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "0495864f-a111-4bc7-a32b-169fc8a65775");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "4a4b0a59-d947-45ba-9699-539effa0ef6d");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified", "ShipmentTrackingMode" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 511, DateTimeKind.Utc).AddTicks(6909), new DateTime(2026, 8, 28, 12, 23, 58, 511, DateTimeKind.Utc).AddTicks(6912), 0 });

            migrationBuilder.UpdateData(
                table: "saleschannel_sync_state",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 514, DateTimeKind.Utc).AddTicks(8958), new DateTime(2026, 8, 28, 12, 23, 58, 514, DateTimeKind.Utc).AddTicks(8961) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(8734), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(8737) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9276), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9277) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9280), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9281) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9289), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9289) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9291), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9291) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9436), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9437) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9438), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9438) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9442), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9442) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9445), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9445) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9292), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9292) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9294), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9294) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9295), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9295) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9296), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9297) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9426), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9426) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9428), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9428) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9431), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9432) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9433), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9433) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9435), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9435) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9439), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9441), new DateTime(2026, 8, 28, 12, 23, 58, 549, DateTimeKind.Utc).AddTicks(9441) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 518, DateTimeKind.Utc).AddTicks(3699), new DateTime(2026, 8, 28, 12, 23, 58, 518, DateTimeKind.Utc).AddTicks(3700) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 518, DateTimeKind.Utc).AddTicks(3898), new DateTime(2026, 8, 28, 12, 23, 58, 518, DateTimeKind.Utc).AddTicks(3898) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 518, DateTimeKind.Utc).AddTicks(3901), new DateTime(2026, 8, 28, 12, 23, 58, 518, DateTimeKind.Utc).AddTicks(3901) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 23, 58, 498, DateTimeKind.Utc).AddTicks(614), new DateTime(2026, 8, 28, 12, 23, 58, 498, DateTimeKind.Utc).AddTicks(616) });

            migrationBuilder.CreateIndex(
                name: "IX_saleschannel_carrier_mapping_SalesChannelId_RemoteCarrierCo~",
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
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(8371), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(8378) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9204), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9204) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9206), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9207) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9209), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9209) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9216), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9216) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9218), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9218) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9221), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9221) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9222), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9222) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9224), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9224) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9225), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9226) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9227), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9227) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9240), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9243), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9244) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9245), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9245) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9247), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9259) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9260), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9262), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9262) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9263), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9264) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9265), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9265) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9266), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9267) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9269), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9269) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9271), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9271) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9272), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9272) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9274), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9274) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9275), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9276) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9279), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9279) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9281), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9281) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9289), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9292), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9293) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9303), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9303) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9308), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9308) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9309), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9310) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9311), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9311) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9313), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9313) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9314), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9315) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9316), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9316) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9319), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9319) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9320), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9320) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9322), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9322) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9323), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9323) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9325), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9325) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9326), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9326) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9328), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9328) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9336), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9337) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9340), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9341), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9342) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9343), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9343) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9345), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9345) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9346), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9346) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9348), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9348) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9350), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9351), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9351) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9354), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9354) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9356), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9356) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9358), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9358) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9360), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9361), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9361) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9363), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9363) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9364), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9364) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9372), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9373) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9376), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9376) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9377), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9378) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9379), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9379) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9381), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9381) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9382), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9382) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9384), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9384) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9385), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9385) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9387), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9387) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9389), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9390) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9391), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9391) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9392), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9393) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9394), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9394) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9395), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9396) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9397), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9397) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9398), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9399) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9400), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9410), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9410) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9412), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9412) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9413), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9414) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9416), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9416) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9417), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9418) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9419), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9419) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9421), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9421) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9422), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9422) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9425), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9425) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9426), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9427) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9428), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9428) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9429), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9431), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9431) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9432), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9433) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9434), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9434) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9435), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9436) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9445), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9445) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9447), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9447) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9452), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9452) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9453), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9454) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9455), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9455) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9456), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9457) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9458), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9458) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9460), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9462), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9463) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9464), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9464) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9465), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9466) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9468), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9468) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9469), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9471), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9471) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9472), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9473) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9474), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9474) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9483), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9484) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9486), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9486) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9487), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9487) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9489), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9489) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9490), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9491) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9492), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9492) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9493), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9494) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9495), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9495) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9498), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9498) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9499), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9501), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9501) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9502), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9503) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9504), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9504) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9505), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9506) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9507), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9507) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9508), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9508) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9518), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9518) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9520), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9521), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9522) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9525), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9526) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9527), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9527) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9528), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9529) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9530), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9531), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9532) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9534), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9534) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9536), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9536) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9537), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9537) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9539), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9539) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9540), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9542), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9542) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9543), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9543) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9545), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9545) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9554), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9554) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9556), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9556) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9558), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9558) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9559), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9560) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9561), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9561) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9562), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9563) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9564), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9564) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9565), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9566) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9568), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9569) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9570), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9572), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9572) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9573), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9573) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9575), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9575) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9576), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9576) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9578), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9578) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9579), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9579) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9588), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9589) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9590), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9592), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9592) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9593), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9593) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9595), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9595) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9596), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9597) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9598), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9598) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9599), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9602), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9602) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9603), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9604) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9605), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9605) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9607), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9607) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9608), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9608) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9609), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9611), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9611) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9612), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9613) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9622), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9623) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9625), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9625) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9626), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9627) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9628), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9628) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9629), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9631), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9631) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9633), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9633) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9634), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9634) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9637), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9637) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9638), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9638) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9640), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9640) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9641), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9641) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9643), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9643) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9644), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9644) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9646), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9646) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9653), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9653) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9664), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9664) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9666), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9666) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9667), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9668) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9669), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9669) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9671), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9671) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9672), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9672) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9674), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9674) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9675), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9675) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9678), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9678) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9681), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9681) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9682), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9682) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9684), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9684) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9685), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9685) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9687), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9687) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9688), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9689) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9690), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9690) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9700), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9702), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9702) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9703), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9703) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9705), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9705) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9706), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9707) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9708), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9708) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9710), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9710) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9711), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9711) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9714), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9714) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9716), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9716) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9717), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9717) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9719), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9719) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9720), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9722), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9722) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9723), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9723) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9725), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9725) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9734), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9734) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9737), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9737) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9738), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9739) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9740), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9742), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9742) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9743), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9743) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9745), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9745) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9746), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9746) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9749), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9749) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9750), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9752), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9752) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9753), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9753) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9755), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9755) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9756), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9756) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9758), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9758) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9759), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9759) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9768), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9769) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9770), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9771) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9772), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9772) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9774), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9774) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9775), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9776) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9777), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9777) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9778), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9779) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9780), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9783), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9784) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9785), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9785) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9787), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9787) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9788), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9788) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9789), new DateTime(2026, 8, 28, 11, 40, 21, 661, DateTimeKind.Utc).AddTicks(9790) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 664, DateTimeKind.Utc).AddTicks(499), new DateTime(2026, 8, 28, 11, 40, 21, 664, DateTimeKind.Utc).AddTicks(500) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "bf86e4bc-702c-4950-937e-32363dbbbe57");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "cf6a1e64-a706-4a6c-a614-20fbefe9bcb9");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 685, DateTimeKind.Utc).AddTicks(548), new DateTime(2026, 8, 28, 11, 40, 21, 685, DateTimeKind.Utc).AddTicks(554) });

            migrationBuilder.UpdateData(
                table: "saleschannel_sync_state",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 689, DateTimeKind.Utc).AddTicks(4625), new DateTime(2026, 8, 28, 11, 40, 21, 689, DateTimeKind.Utc).AddTicks(4629) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(851), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(854) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2060), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2060) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2064), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2064) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2065), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2066) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2067), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2067) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2328), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2328) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2330), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2330) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2337), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2337) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2338), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2339) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2069), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2069) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2070), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2070) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2072), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2072) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2077), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2077) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2319), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2319) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2321), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2322) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2323), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2323) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2325), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2325) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2326), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2327) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2334), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2334) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2335), new DateTime(2026, 8, 28, 11, 40, 21, 743, DateTimeKind.Utc).AddTicks(2335) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 694, DateTimeKind.Utc).AddTicks(2108), new DateTime(2026, 8, 28, 11, 40, 21, 694, DateTimeKind.Utc).AddTicks(2111) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 694, DateTimeKind.Utc).AddTicks(2459), new DateTime(2026, 8, 28, 11, 40, 21, 694, DateTimeKind.Utc).AddTicks(2459) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 694, DateTimeKind.Utc).AddTicks(2462), new DateTime(2026, 8, 28, 11, 40, 21, 694, DateTimeKind.Utc).AddTicks(2463) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 21, 662, DateTimeKind.Utc).AddTicks(7977), new DateTime(2026, 8, 28, 11, 40, 21, 662, DateTimeKind.Utc).AddTicks(7978) });
        }
    }
}
