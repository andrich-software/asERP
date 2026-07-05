using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class AddReturnShipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "return_shipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SalesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OriginalShippingId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ShippingProviderId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    TrackingNumber = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TrackingUrl = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true),
                    CarrierShipmentId = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                    LabelData = table.Column<byte[]>(type: "BLOB", nullable: true),
                    LabelFormat = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true),
                    RefundAmount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: true),
                    Note = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    ReceivedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastTrackedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastCarrierStatusRaw = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_return_shipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_return_shipment_sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_return_shipment_shipping_OriginalShippingId",
                        column: x => x.OriginalShippingId,
                        principalTable: "shipping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_return_shipment_shipping_provider_ShippingProviderId",
                        column: x => x.ShippingProviderId,
                        principalTable: "shipping_provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "return_label_outbox",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReturnShipmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ShippingProviderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdempotencyKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    AttemptCount = table.Column<int>(type: "INTEGER", nullable: false),
                    NextAttemptAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastError = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_return_label_outbox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_return_label_outbox_return_shipment_ReturnShipmentId",
                        column: x => x.ReturnShipmentId,
                        principalTable: "return_shipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "return_shipment_item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReturnShipmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SalesItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<double>(type: "REAL", nullable: false),
                    Reason = table.Column<int>(type: "INTEGER", nullable: false),
                    ReasonText = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Condition = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_return_shipment_item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_return_shipment_item_return_shipment_ReturnShipmentId",
                        column: x => x.ReturnShipmentId,
                        principalTable: "return_shipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_return_shipment_item_sales_item_SalesItemId",
                        column: x => x.SalesItemId,
                        principalTable: "sales_item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "return_shipment_item_serialnumber",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReturnShipmentItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SerialNumber = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_return_shipment_item_serialnumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_return_shipment_item_serialnumber_return_shipment_item_ReturnShipmentItemId",
                        column: x => x.ReturnShipmentItemId,
                        principalTable: "return_shipment_item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_return_label_outbox_ReturnShipmentId_IdempotencyKey",
                table: "return_label_outbox",
                columns: new[] { "ReturnShipmentId", "IdempotencyKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_return_label_outbox_Status_NextAttemptAt",
                table: "return_label_outbox",
                columns: new[] { "Status", "NextAttemptAt" });

            migrationBuilder.CreateIndex(
                name: "IX_return_shipment_OriginalShippingId",
                table: "return_shipment",
                column: "OriginalShippingId");

            migrationBuilder.CreateIndex(
                name: "IX_return_shipment_SalesId",
                table: "return_shipment",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_return_shipment_ShippingProviderId",
                table: "return_shipment",
                column: "ShippingProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_return_shipment_Status",
                table: "return_shipment",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_return_shipment_TrackingNumber_TenantId",
                table: "return_shipment",
                columns: new[] { "TrackingNumber", "TenantId" });

            migrationBuilder.CreateIndex(
                name: "IX_return_shipment_item_ReturnShipmentId",
                table: "return_shipment_item",
                column: "ReturnShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_return_shipment_item_SalesItemId",
                table: "return_shipment_item",
                column: "SalesItemId");

            migrationBuilder.CreateIndex(
                name: "IX_return_shipment_item_serialnumber_ReturnShipmentItemId",
                table: "return_shipment_item_serialnumber",
                column: "ReturnShipmentItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "return_label_outbox");

            migrationBuilder.DropTable(
                name: "return_shipment_item_serialnumber");

            migrationBuilder.DropTable(
                name: "return_shipment_item");

            migrationBuilder.DropTable(
                name: "return_shipment");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(7636), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(7637) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8236), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8236) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8245), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8245) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8247), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8247) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8249), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8249) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8260), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8263), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8263) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8265), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8265) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8272), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8272) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8274), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8274) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8277), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8277) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8279), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8279) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8280), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8282), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8282) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8292), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8292) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8295), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8296) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8297), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8297) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8299), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8299) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8302), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8303) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8304), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8304) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8305), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8306) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8314), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8315) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8317), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8317) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8319), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8319) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8321), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8321) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8322), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8323) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8330), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8333), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8333) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8335), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8335) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8336), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8337) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8338), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8338) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8340), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8341), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8343), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8343) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8346), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8346) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8347), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8347) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8349), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8349) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8357), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8358) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8360), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8361) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8362), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8362) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8364), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8364) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8365), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8365) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8368), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8368) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8370), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8371), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8371) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8373), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8373) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8374), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8376), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8376) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8377), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8378) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8379), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8379) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8382), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8382) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8383), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8383) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8384), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8385) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8392), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8393) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8394), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8395) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8396), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8397) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8398), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8398) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8400), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8402), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8403) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8404), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8404) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8406), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8406) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8407), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8407) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8409), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8409) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8410), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8411) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8412), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8412) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8413), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8414) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8416), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8416) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8417), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8418) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8419), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8419) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8427), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8428) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8430), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8432), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8432) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8433), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8434) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8435), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8435) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8438), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8438) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8440), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8441), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8441) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8443), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8443) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8444), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8445) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8446), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8446) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8447), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8448) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8449), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8449) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8451), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8452) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8453), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8453) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8455), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8455) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8464), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8464) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8467), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8467) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8468), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8469) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8470), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8472), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8472) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8474), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8474) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8476), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8476) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8477), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8478) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8479), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8479) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8480), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8481) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8482), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8482) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8484), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8484) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8485), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8486) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8488), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8488) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8490), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8490) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8491), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8491) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8499), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8502), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8502) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8503), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8504) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8505), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8505) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8506), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8507) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8510), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8515), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8515) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8517), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8517) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8519), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8519) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8520), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8521) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8522), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8522) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8523), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8524) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8525), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8525) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8528), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8528) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8529), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8529) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8531), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8531) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8532), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8532) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8534), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8534) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8535), new DateTime(2026, 7, 4, 12, 22, 38, 933, DateTimeKind.Utc).AddTicks(8536) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 934, DateTimeKind.Utc).AddTicks(7536), new DateTime(2026, 7, 4, 12, 22, 38, 934, DateTimeKind.Utc).AddTicks(7536) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "61be762a-5512-4099-93f1-88a7f584b066");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "9d478fd8-fa42-44d0-974c-5bd117d2c622");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 946, DateTimeKind.Utc).AddTicks(7170), new DateTime(2026, 7, 4, 12, 22, 38, 946, DateTimeKind.Utc).AddTicks(7171) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6445), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6448) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6804), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6805) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6808), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6809) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6810), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6811) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6812), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6812) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6842), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6842) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6843), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6843) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6847), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6847) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6849), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6849) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6819), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6819) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6821), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6821) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6822), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6822) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6824), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6824) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6833), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6833) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6834), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6834) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6836), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6836) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6837), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6837) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6840), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6840) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6844), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6845) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6846), new DateTime(2026, 7, 4, 12, 22, 38, 968, DateTimeKind.Utc).AddTicks(6846) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 948, DateTimeKind.Utc).AddTicks(5872), new DateTime(2026, 7, 4, 12, 22, 38, 948, DateTimeKind.Utc).AddTicks(5873) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 948, DateTimeKind.Utc).AddTicks(6070), new DateTime(2026, 7, 4, 12, 22, 38, 948, DateTimeKind.Utc).AddTicks(6071) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 948, DateTimeKind.Utc).AddTicks(6073), new DateTime(2026, 7, 4, 12, 22, 38, 948, DateTimeKind.Utc).AddTicks(6073) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 925, DateTimeKind.Utc).AddTicks(8180), new DateTime(2026, 7, 4, 12, 22, 38, 925, DateTimeKind.Utc).AddTicks(8187) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "256175bc-fe7e-40f9-bffe-ff425baec831", new DateTime(2026, 7, 4, 12, 22, 38, 886, DateTimeKind.Utc).AddTicks(8428), new DateTime(2026, 7, 4, 12, 22, 38, 886, DateTimeKind.Utc).AddTicks(8431), "AQAAAAIAAYagAAAAEKkEHBwbddSWIk9t6w9PQSMjmTzrkhk8ZMf7uhB5qIk8lgBpeDkusi9yg4Bb8MGrKg==", "972a717e-483f-4e67-8a8e-ecce39dd3e1e" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 931, DateTimeKind.Utc).AddTicks(7989), new DateTime(2026, 7, 4, 12, 22, 38, 931, DateTimeKind.Utc).AddTicks(8112), new Guid("4e729ad3-4a29-4176-a8eb-a0608b683ea9") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 38, 934, DateTimeKind.Utc).AddTicks(1269), new DateTime(2026, 7, 4, 12, 22, 38, 934, DateTimeKind.Utc).AddTicks(1270) });
        }
    }
}
