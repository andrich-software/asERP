using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.MSSQL.Migrations
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
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "saleschannel_carrier_mapping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemoteCarrierCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(2887), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(2894) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3670), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3672), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3672) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3674), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3675) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3677), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3677) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3679), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3679) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3680), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3680) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3682), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3682) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3686), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3686) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3688), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3688) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3706), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3706) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3710), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3712), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3712) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3713), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3713) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3715), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3715) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3716), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3717) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3720), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3721), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3722) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3723), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3723) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3724), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3725) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3726), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3726) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3727), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3728) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3729), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3729) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3730), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3731) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3733), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3733) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3735), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3735) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3745), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3745) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3747), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3747) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3748), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3748) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3770), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3770) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3776), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3776) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3778), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3778) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3781), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3781) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3782), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3782) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3784), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3784) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3787), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3787) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3788), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3788) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3790), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3792), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3792) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3793), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3794) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3796), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3796) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3798), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3798) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3806), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3807) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3808), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3809) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3810), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3812), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3812) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3813), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3813) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3815), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3815) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3817), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3818) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3819), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3819) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3820), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3821) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3822), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3822) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3823), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3824) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3825), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3825) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3826), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3826) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3828), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3828) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3831), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3831) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3833), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3833) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3842), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3843) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3846), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3846) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3847), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3847) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3849), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3849) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3850), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3852), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3852) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3855), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3855) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3856), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3856) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3858), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3858) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3859), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3859) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3882), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3882) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3884), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3884) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3885), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3885) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3886), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3887) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3889), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3889) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3891), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3891) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3899), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3901), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3901) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3903), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3903) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3904), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3904) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3906), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3906) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3907), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3907) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3910), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3911), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3911) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3913), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3913) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3915), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3916) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3917), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3917) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3919), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3919) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3920), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3922), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3922) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3925), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3925) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3926), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3926) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3934), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3934) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3936), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3936) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3937), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3937) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3939), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3939) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3940), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3941) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3942), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3942) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3945), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3945) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3946), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3947) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3948), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3948) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3950), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3951), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3951) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3952), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3953) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3954), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3954) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3955), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3956) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3958), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3958) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3960), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3968), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3968) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3971), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3971) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3972), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3973) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3974), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3974) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3975), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3976) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3977), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3977) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3980), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3981), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3981) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3983), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3983) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3984), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3985) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3986), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3986) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3988), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3988) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3989), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3989) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3991), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3991) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3994), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3994) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3995), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(3995) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4003), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4003) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4005), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4005) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4006), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4007) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4008), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4008) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4009), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4011), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4011) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4013), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4014) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4015), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4015) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4017), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4017) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4019), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4019) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4021), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4021) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4022), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4022) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4024), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4024) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4025), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4025) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4028), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4028) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4030), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4037), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4038) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4039), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4039) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4041), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4041) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4042), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4043) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4044), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4044) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4045), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4046) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4048), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4048) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4049), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4051), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4051) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4052), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4053) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4054), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4054) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4055), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4056) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4057), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4057) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4058), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4059) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4061), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4061) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4062), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4063) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4071), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4071) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4072), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4073) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4074), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4074) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4075), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4076) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4077), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4077) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4078), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4079) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4081), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4081) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4082), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4083) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4089), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4091), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4091) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4093), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4093) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4094), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4094) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4096), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4096) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4097), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4097) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4100), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4101), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4101) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4109), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4109) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4111), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4111) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4113), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4113) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4114), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4115) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4116), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4116) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4117), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4118) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4120), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4122), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4122) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4124), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4124) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4125), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4125) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4127), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4127) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4128), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4128) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4130), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4131), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4131) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4134), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4134) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4135), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4135) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4144), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4145) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4147), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4147) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4148), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4149) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4150), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4152), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4152) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4153), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4153) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4156), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4156) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4157), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4158) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4159), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4159) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4160), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4162), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4162) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4163), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4163) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4165), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4165) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4166), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4166) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4169), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4169) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4172), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4172) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4180), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4182), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4182) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4184), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4184) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4185), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4186) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4187), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4187) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4189), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4189) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4191), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4191) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4193), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4208), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4208) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4210), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4211), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4212) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4213), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4213) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4214), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4215) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4216), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4216) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4219), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4219) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4220), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4229), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4229) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4231), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4231) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4232), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4233) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4234), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4234) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4235), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4236) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4237), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4237) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4240), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4241), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4241) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4243), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4243) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4244), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4244) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4246), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4246) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4247), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4247) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4249), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4249) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4250), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4252), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4253) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4254), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4254) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4262), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4262) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4264), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4264) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4266), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4266) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4267), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4267) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4269), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4269) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4270), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4271) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4273), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4273) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4275), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4275) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4276), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4276) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4278), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4278) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4279), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4279) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4281), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4281) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4282), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4282) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4283), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4284) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4287), new DateTime(2026, 8, 28, 12, 24, 54, 193, DateTimeKind.Utc).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 195, DateTimeKind.Utc).AddTicks(8308), new DateTime(2026, 8, 28, 12, 24, 54, 195, DateTimeKind.Utc).AddTicks(8309) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "56e23761-b31b-4dbb-8068-8c9bdd58b6b6");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "2b45f7c7-4836-4361-975e-7d5178e59d48");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified", "ShipmentTrackingMode" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 213, DateTimeKind.Utc).AddTicks(9527), new DateTime(2026, 8, 28, 12, 24, 54, 213, DateTimeKind.Utc).AddTicks(9531), 0 });

            migrationBuilder.UpdateData(
                table: "saleschannel_sync_state",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 216, DateTimeKind.Utc).AddTicks(5039), new DateTime(2026, 8, 28, 12, 24, 54, 216, DateTimeKind.Utc).AddTicks(5040) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(1972), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(1974) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2863), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2863) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2866), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2867) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2868), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2868) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2882), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2882) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3157), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3157) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3159), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3159) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3164), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3164) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3165), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3166) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2884), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2884) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2885), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2886) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2887), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2887) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2889), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(2889) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3144), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3145) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3147), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3147) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3149), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3149) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3154), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3154) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3156), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3156) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3160), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3161) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3162), new DateTime(2026, 8, 28, 12, 24, 54, 262, DateTimeKind.Utc).AddTicks(3162) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 222, DateTimeKind.Utc).AddTicks(3023), new DateTime(2026, 8, 28, 12, 24, 54, 222, DateTimeKind.Utc).AddTicks(3024) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 222, DateTimeKind.Utc).AddTicks(3411), new DateTime(2026, 8, 28, 12, 24, 54, 222, DateTimeKind.Utc).AddTicks(3411) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 222, DateTimeKind.Utc).AddTicks(3415), new DateTime(2026, 8, 28, 12, 24, 54, 222, DateTimeKind.Utc).AddTicks(3415) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 12, 24, 54, 194, DateTimeKind.Utc).AddTicks(6493), new DateTime(2026, 8, 28, 12, 24, 54, 194, DateTimeKind.Utc).AddTicks(6496) });

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
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 733, DateTimeKind.Utc).AddTicks(9027), new DateTime(2026, 8, 28, 11, 40, 50, 733, DateTimeKind.Utc).AddTicks(9031) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(605), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(605) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(610), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(613), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(613) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(616), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(617) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(643), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(644) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(647), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(649), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(656), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(656) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(658), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(658) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(661), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(661) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(663), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(663) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(665), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(665) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(667), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(667) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(669), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(671), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(672) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(676), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(677) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(679), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(679) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(681), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(681) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(694), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(695) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(696), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(697) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(698), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(698) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(700), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(700) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(714), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(714) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(718), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(718) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(720), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(722), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(722) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(724), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(724) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(726), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(726) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(737), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(737) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(744), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(744) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(746), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(746) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(750), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(764), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(764) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(765), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(766) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(767), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(768) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(769), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(769) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(772), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(772) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(774), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(774) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(778), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(778) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(783), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(783) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(785), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(785) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(787), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(787) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(789), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(789) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(791), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(791) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(793), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(793) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(795), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(795) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(832), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(832) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(848), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(848) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(850), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(850) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(853), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(853) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(855), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(855) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(857), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(857) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(859), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(859) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(861), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(861) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(863), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(863) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(867), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(867) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(868), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(869) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(870), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(871) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(872), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(873) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(874), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(875) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(877), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(877) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(889), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(889) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(891), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(891) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(896), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(896) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(898), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(898) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(900), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(902), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(902) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(904), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(904) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(906), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(906) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(908), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(908) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(910), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(913), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(914) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(915), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(916) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(917), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(918) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(920), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(933), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(933) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(935), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(935) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(936), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(937) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(938), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(939) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(942), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(942) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(944), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(944) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(946), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(946) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(948), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(948) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(950), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(950) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(952), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(952) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(954), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(954) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(956), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(956) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(961), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(961) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(963), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(963) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(975), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(976) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(977), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(978) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(979), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(979) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(981), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(981) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(983), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(983) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(985), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(985) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(989), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(989) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(991), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(991) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(993), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(993) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(995), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(995) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(997), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(997) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(999), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(999) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1001), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1001) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1003), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1003) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1018), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1018) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1020), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1022), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1022) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1024), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1024) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1026), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1026) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1028), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1029) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1031), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1031) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1033), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1033) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1038), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1038) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1040), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1042), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1042) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1044), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1044) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1046), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1046) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1048), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1048) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1060), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1061) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1062), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1063) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000121"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1066), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1066) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000122"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1068), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1068) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000123"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1071), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1071) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000124"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1073), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1073) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000125"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1075), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1075) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000126"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1077), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1077) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000127"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1079), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1079) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000128"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1081), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1081) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000129"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1086), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1086) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000130"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1088), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1088) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000131"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1090), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000132"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1092), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1092) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000133"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1104), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1105) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000134"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1106), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1107) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000135"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1108), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1109) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000136"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1110), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000137"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1114), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1114) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000138"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1116), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1116) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000139"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1118), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1118) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000140"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1120), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000141"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1130), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1131) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000142"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1133), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1133) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000143"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1135), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1135) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000144"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1137), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1137) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000145"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1140), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1141) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000146"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1142), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1143) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000147"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1156), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1157) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000148"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1158), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1159) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000149"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1160), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1161) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000150"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1162), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1163) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000151"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1164), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1165) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000152"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1166), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1167) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000153"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1170), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1170) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000154"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1172), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1172) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000155"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1174), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1174) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000156"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1176), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1176) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000157"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1178), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1178) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000158"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1180), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1180) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000159"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1182), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1182) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000160"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1185), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1185) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000161"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1199), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1199) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000162"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1200), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1201) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000163"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1202), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1203) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000164"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1204), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1204) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000165"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1206), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1206) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000166"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1208), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1208) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000167"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1210), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000168"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1212), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1212) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000169"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1215), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1216) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000170"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1217), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1218) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000171"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1219), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000172"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1221), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1222) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000173"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1223), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1224) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000174"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1225), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1226) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000175"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1238), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1238) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000176"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1240), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000177"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1243), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1244) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000178"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1245), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1245) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000179"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1247), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1247) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000180"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1249), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1249) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000181"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1251), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1251) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000182"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1253), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1253) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000183"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1256), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1257) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000184"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1258), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1259) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000185"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1262), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1262) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000186"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1264), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1264) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000187"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1266), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1266) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000188"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1268), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1268) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000189"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1281), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1281) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000190"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1283), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1283) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000191"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1285), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1285) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000192"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1287), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1287) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000193"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1290), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1290) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000194"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1292), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1292) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000195"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1294), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1294) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000196"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1296), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1297) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000197"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1298), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1299) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000198"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1300), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1301) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000199"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1302), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1303) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000200"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1305), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1305) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000201"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1308), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1309) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000202"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1311), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1311) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000203"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1323), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1323) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000204"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1325), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1325) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000205"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1326), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1327) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000206"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1328), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1329) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000207"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1331), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1332) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000208"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1333), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1333) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000209"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1337), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1337) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000210"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1339), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1339) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000211"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1341), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1341) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000212"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1343), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1343) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000213"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1345), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1345) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000214"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1347), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1347) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000215"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1349), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1349) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000216"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1351), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1351) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000217"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1364), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1365) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000218"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1366), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1366) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000219"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1368), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1368) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000220"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1370), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000221"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1372), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1372) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000222"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1374), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1374) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000223"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1376), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1376) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000224"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1378), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1378) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000225"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1381), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1381) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000226"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1383), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1383) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000227"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1385), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1385) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000228"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1387), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1387) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000229"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1389), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1389) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000230"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1392), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1392) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000231"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1394), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1394) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000232"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1405), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1405) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000233"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1409), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1409) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000234"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1418), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1418) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000235"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1420), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000236"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1422), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1422) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000237"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1424), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1424) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000238"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1426), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1426) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000239"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1428), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1428) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000240"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1430), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000241"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1434), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1434) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000242"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1436), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1436) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000243"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1437), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1438) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000244"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1439), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000245"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1441), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1441) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000246"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1443), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1443) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000247"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1445), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1445) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000248"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1447), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1447) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000249"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1450), new DateTime(2026, 8, 28, 11, 40, 50, 734, DateTimeKind.Utc).AddTicks(1451) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 736, DateTimeKind.Utc).AddTicks(3177), new DateTime(2026, 8, 28, 11, 40, 50, 736, DateTimeKind.Utc).AddTicks(3178) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "7fa1ab9a-979e-41b2-a368-fc5bdcf24a04");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "6d11c143-f6a2-4385-bf19-f83f8a5a5ccd");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 753, DateTimeKind.Utc).AddTicks(6195), new DateTime(2026, 8, 28, 11, 40, 50, 753, DateTimeKind.Utc).AddTicks(6199) });

            migrationBuilder.UpdateData(
                table: "saleschannel_sync_state",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 757, DateTimeKind.Utc).AddTicks(957), new DateTime(2026, 8, 28, 11, 40, 50, 757, DateTimeKind.Utc).AddTicks(962) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1096), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1100) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1760), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1760) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1763), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1763) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1765), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1766) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1775), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1776) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1954), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1954) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1956), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1956) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1961), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1962) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1963), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1964) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1778), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1778) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1779), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1780) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1781), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1782) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1783), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1784) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1940), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1940) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1943), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1943) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1945), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1945) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1950), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1950) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1952), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1952) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1958), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1958) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1959), new DateTime(2026, 8, 28, 11, 40, 50, 808, DateTimeKind.Utc).AddTicks(1960) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 760, DateTimeKind.Utc).AddTicks(5138), new DateTime(2026, 8, 28, 11, 40, 50, 760, DateTimeKind.Utc).AddTicks(5140) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 760, DateTimeKind.Utc).AddTicks(5399), new DateTime(2026, 8, 28, 11, 40, 50, 760, DateTimeKind.Utc).AddTicks(5400) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 760, DateTimeKind.Utc).AddTicks(5403), new DateTime(2026, 8, 28, 11, 40, 50, 760, DateTimeKind.Utc).AddTicks(5403) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 8, 28, 11, 40, 50, 735, DateTimeKind.Utc).AddTicks(1380), new DateTime(2026, 8, 28, 11, 40, 50, 735, DateTimeKind.Utc).AddTicks(1383) });
        }
    }
}
