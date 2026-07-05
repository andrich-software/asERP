using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.PostgreSQL.Migrations
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SalesId = table.Column<Guid>(type: "uuid", nullable: false),
                    OriginalShippingId = table.Column<Guid>(type: "uuid", nullable: true),
                    ShippingProviderId = table.Column<Guid>(type: "uuid", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    TrackingNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TrackingUrl = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    CarrierShipmentId = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    LabelData = table.Column<byte[]>(type: "bytea", nullable: true),
                    LabelFormat = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RefundAmount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    Note = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    ReceivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastTrackedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastCarrierStatusRaw = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReturnShipmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShippingProviderId = table.Column<Guid>(type: "uuid", nullable: false),
                    IdempotencyKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    AttemptCount = table.Column<int>(type: "integer", nullable: false),
                    NextAttemptAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastError = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReturnShipmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    SalesItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<double>(type: "double precision", nullable: false),
                    Reason = table.Column<int>(type: "integer", nullable: false),
                    ReasonText = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Condition = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReturnShipmentItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    SerialNumber = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_return_shipment_item_serialnumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_return_shipment_item_serialnumber_return_shipment_item_Retu~",
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
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(3465), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4079), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4079) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4082), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4083) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4084), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4084) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4086), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4086) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4087), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4088) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4089), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4089) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4091), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4091) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4095), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4095) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4096), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4096) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4098), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4098) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4099), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4101), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4101) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4102), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4103) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4104), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4104) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4105), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4106) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4108), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4108) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4121), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4121) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4123), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4123) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4125), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4125) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4127), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4127) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4128), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4129) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4130), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4132), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4132) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4134), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4135) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4136), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4136) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4148), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4149) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4152), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4152) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4154), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4154) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4155), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4156) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4157), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4157) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4158), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4159) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4161), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4162) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4170), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4171) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4173), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4173) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4174), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4174) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4176), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4176) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4178), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4178) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4179), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4179) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4180), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4181) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4183), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4183) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4185), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4185) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4186), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4187) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4188), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4188) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4189), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4191), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4191) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4192), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4194), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4194) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4197), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4197) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4205), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4206) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4208), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4208) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4210), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4211), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4211) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4213), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4213) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4214), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4215) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4216), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4216) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4219), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4219) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4220), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4222), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4222) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4223), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4224) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4225), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4225) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4226), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4227) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4228), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4228) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4229), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4232), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4232) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4243), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4243) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4246), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4246) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4247), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4247) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4249), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4249) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4250), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4251) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4252), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4252) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4254), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4254) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4256), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4257) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4258), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4258) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4260), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4261), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4261) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4263), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4263) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4264), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4264) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4266), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4266) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4267), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4267) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4270), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4278), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4279) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4280), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4281) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4289), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4289) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4291), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4291) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4292), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4292) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4294), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4294) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4295), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4296) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4298), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4298) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4300), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4301), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4302) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4303), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4303) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4304), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4305) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4306), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4306) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4307), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4308) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4309), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4309) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4312), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4312) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4321), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4321) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4323), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4324) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4325), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4325) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4327), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4327) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4329), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4329) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4331), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4331) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4333), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4333) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4336), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4336) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4338), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4338) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4340), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4342), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4342) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4344), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4344) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4345), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4346) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4347), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4347) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4348), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4349) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4351), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4351) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4353), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4353) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4354), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4354) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4356), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4356) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4357), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4357) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4359), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4359) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4360), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4360) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4362), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(4362) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 486, DateTimeKind.Utc).AddTicks(4051), new DateTime(2026, 7, 4, 20, 54, 32, 486, DateTimeKind.Utc).AddTicks(4053) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "768b5a5b-a7ad-4cf5-92a1-50ad9ad60b27");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "729c0cd2-374c-4ee8-aacc-6cd07e99ea45");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 498, DateTimeKind.Utc).AddTicks(9827), new DateTime(2026, 7, 4, 20, 54, 32, 498, DateTimeKind.Utc).AddTicks(9829) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1409), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1412) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1767), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1767) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1778), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1778) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1780), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1781) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1782), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1782) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1798), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1798) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1799), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1800) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1805), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1805) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1813), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1813) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1783), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1784) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1785), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1785) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1786), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1786) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1788), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1788) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1789), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1789) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1792), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1793) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1794), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1794) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1795), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1795) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1797), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1797) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1801), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1801) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1802), new DateTime(2026, 7, 4, 20, 54, 32, 524, DateTimeKind.Utc).AddTicks(1802) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 500, DateTimeKind.Utc).AddTicks(5892), new DateTime(2026, 7, 4, 20, 54, 32, 500, DateTimeKind.Utc).AddTicks(5893) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 500, DateTimeKind.Utc).AddTicks(6096), new DateTime(2026, 7, 4, 20, 54, 32, 500, DateTimeKind.Utc).AddTicks(6097) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 500, DateTimeKind.Utc).AddTicks(6099), new DateTime(2026, 7, 4, 20, 54, 32, 500, DateTimeKind.Utc).AddTicks(6099) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 479, DateTimeKind.Utc).AddTicks(2350), new DateTime(2026, 7, 4, 20, 54, 32, 479, DateTimeKind.Utc).AddTicks(2355) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "233ceafa-cfa6-4f89-9203-32f83077e7b5", new DateTime(2026, 7, 4, 20, 54, 32, 439, DateTimeKind.Utc).AddTicks(7374), new DateTime(2026, 7, 4, 20, 54, 32, 439, DateTimeKind.Utc).AddTicks(7379), "AQAAAAIAAYagAAAAEJQVsTPvQlDsxdjN2r5xKTkr0BrsRIr8PMb33F3f87aUx5Bdp4sEF95ak2ejBgYAyQ==", "3455084c-2610-400c-8ef3-41d1a466f7de" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 483, DateTimeKind.Utc).AddTicks(4167), new DateTime(2026, 7, 4, 20, 54, 32, 483, DateTimeKind.Utc).AddTicks(4290), new Guid("9971bf12-acb8-41a3-badd-0792bba64408") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(7527), new DateTime(2026, 7, 4, 20, 54, 32, 485, DateTimeKind.Utc).AddTicks(7528) });

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
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 724, DateTimeKind.Utc).AddTicks(7723), new DateTime(2026, 7, 4, 12, 22, 14, 724, DateTimeKind.Utc).AddTicks(7724) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(651), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(653) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(661), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(662) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(671), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(672) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(674), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(674) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(676), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(676) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(678), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(679) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(681), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(681) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(683), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(683) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(685), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(685) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(687), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(688) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(716), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(716) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(718), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(719) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(721), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(722) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(734), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(735) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(737), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(737) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(739), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(739) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(741), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(742) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(744), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(744) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(747), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(748) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(750), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(752), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(752) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(754), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(755) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(756), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(757) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(758), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(761), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(761) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(773), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(773) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(794), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(795) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(797), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(797) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(799), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(799) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(801), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(802) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(804), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(804) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(806), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(806) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(808), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(808) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(810), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(811) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(814), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(815) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(817), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(817) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(819), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(819) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(821), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(821) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(823), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(823) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(825), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(825) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(827), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(828) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(829), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(830) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(843), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(844) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(846), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(846) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(848), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(849) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(851), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(851) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(853), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(853) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(855), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(855) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(858), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(858) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(860), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(861) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(865), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(865) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(867), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(867) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(869), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(869) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(871), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(872) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(873), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(874) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(875), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(876) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(877), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(878) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(880), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(894), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(894) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(896), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(897) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(899), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(899) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(901), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(901) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(903), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(903) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(905), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(906) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(908), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(908) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(910), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(914), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(914) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(916), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(916) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(918), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(919) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(920), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(921) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(922), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(923) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(925), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(925) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(927), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(927) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(929), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(944), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(944) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(946), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(947) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(949), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(949) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(951), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(951) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(953), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(954) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(956), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(956) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(958), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(958) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(960), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(964), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(964) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(966), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(967) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(968), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(969) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(971), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(971) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(973), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(973) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(975), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(975) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(978), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(978) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(980), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(980) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(994), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(994) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(996), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(996) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(998), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(999) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1000), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1001) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1003), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1003) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1005), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1005) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1007), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1007) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1010), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1014), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1015) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1017), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1017) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1019), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1019) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1021), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1021) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1024), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1024) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1026), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1026) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1028), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1028) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1030), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1031) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1035), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1035) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1042), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1042) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1044), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1044) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1047), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1047) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1050), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1052), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1052) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1054), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1055) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1056), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1057) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1060), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1061) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1063), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1063) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1065), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1065) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1067), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1068) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1070), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 726, DateTimeKind.Utc).AddTicks(2851), new DateTime(2026, 7, 4, 12, 22, 14, 726, DateTimeKind.Utc).AddTicks(2852) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "9a41636c-2493-48d3-a363-ad94f51c5eb5");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "aacccb6a-cc73-49aa-9bea-5eed30a92dbd");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 738, DateTimeKind.Utc).AddTicks(8898), new DateTime(2026, 7, 4, 12, 22, 14, 738, DateTimeKind.Utc).AddTicks(8900) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3620), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3963), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3963) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3966), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3966) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3967), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3968) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3969), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3969) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3992), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3993) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3994), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3994) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3998), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3999), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3999) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3970), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3970) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3980), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3980) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3982), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3982) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3983), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3983) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3984), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3985) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3986), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3986) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3987), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3987) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3988), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3988) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3990), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3990) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3995), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3995) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3996), new DateTime(2026, 7, 4, 12, 22, 14, 758, DateTimeKind.Utc).AddTicks(3996) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(4612), new DateTime(2026, 7, 4, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(4614) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(4818), new DateTime(2026, 7, 4, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(4818) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(4821), new DateTime(2026, 7, 4, 12, 22, 14, 740, DateTimeKind.Utc).AddTicks(4821) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 715, DateTimeKind.Utc).AddTicks(5110), new DateTime(2026, 7, 4, 12, 22, 14, 715, DateTimeKind.Utc).AddTicks(5116) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83ef6ae0-6c75-45ca-a9fa-60613ff4c3c2", new DateTime(2026, 7, 4, 12, 22, 14, 675, DateTimeKind.Utc).AddTicks(6190), new DateTime(2026, 7, 4, 12, 22, 14, 675, DateTimeKind.Utc).AddTicks(6192), "AQAAAAIAAYagAAAAELWyxMBJCTB/jmH7SOFGwrysvNIWTTAn2/0FVPxhMdaagmKZfwSrNyn1yUzeHDovlg==", "0514403b-5646-43b4-b7e9-0b8fde7ba19a" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 722, DateTimeKind.Utc).AddTicks(1169), new DateTime(2026, 7, 4, 12, 22, 14, 722, DateTimeKind.Utc).AddTicks(1295), new Guid("5c2f05fe-b3b0-49d5-9308-7af02e4456d0") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(4394), new DateTime(2026, 7, 4, 12, 22, 14, 725, DateTimeKind.Utc).AddTicks(4395) });
        }
    }
}
