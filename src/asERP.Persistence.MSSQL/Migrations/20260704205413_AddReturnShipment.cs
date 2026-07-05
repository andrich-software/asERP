using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.MSSQL.Migrations
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OriginalShippingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShippingProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TrackingNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrackingUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    CarrierShipmentId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    LabelData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LabelFormat = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    RefundAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ReceivedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastTrackedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastCarrierStatusRaw = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReturnShipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShippingProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdempotencyKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AttemptCount = table.Column<int>(type: "int", nullable: false),
                    NextAttemptAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastError = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReturnShipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Reason = table.Column<int>(type: "int", nullable: false),
                    ReasonText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReturnShipmentItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5073), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5079) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5784), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5784) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5788), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5788) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5790), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5790) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5799), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5799) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5801), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5801) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5802), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5803) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5804), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5804) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5805), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5806) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5807), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5807) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5809), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5809) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5811), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5811) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5814), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5814) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5815), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5816) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5828), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5829) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5831), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5831) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5833), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5833) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5834), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5834) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5836), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5836) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5837), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5838) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5840), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5840) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5842), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5842) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5843), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5845), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5845) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5846), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5847) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5848), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5848) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5864), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5864) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5867), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5867) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5870), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5870) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5871), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5871) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5880), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5881) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5883), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5883) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5885), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5885) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5886), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5887) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5888), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5888) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5890), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5893), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5893) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5894), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5894) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5896), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5896) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5897), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5897) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5899), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5900), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5900) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5902), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5902) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5903), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5903) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5906), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5906) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5908), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5908) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5916), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5917) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5919), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5920) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5921), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5922) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5923), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5924) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5925), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5925) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5927), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5927) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5929), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5930) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5931), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5931) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5932), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5933) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5934), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5934) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5935), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5936) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5937), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5937) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5938), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5939) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5940), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5940) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5944), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5944) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5946), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5946) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5947), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5947) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5974), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5974) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5976), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5976) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5978), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5978) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5979), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5979) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5981), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5981) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5984), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5984) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5985), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5985) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5987), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5987) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5988), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5988) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5990), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5990) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5991), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5992) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5993), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5993) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5994), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5995) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5997), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5998) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5999), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(5999) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6000), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6001) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6009), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6012), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6012) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6013), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6014) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6015), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6015) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6017), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6017) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6019), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6020) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6021), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6021) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6022), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6023) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6024), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6024) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6025), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6026) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6027), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6027) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6028), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6029) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6030), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6033), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6033) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6034), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6034) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6036), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6036) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6044), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6045) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6047), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6047) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6049), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6049) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6050), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6050) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6052), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6052) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6055), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6056) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6057), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6057) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6059), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6059) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6061), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6061) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6063), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6063) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6064), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6064) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6066), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6066) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6067), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6068) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6070), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6070) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6072), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6072) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6073), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6073) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6075), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6075) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6076), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6077) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6078), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6078) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6079), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6081), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6081) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6083), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6084) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6085), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6085) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6086), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6087) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6088), new DateTime(2026, 7, 4, 20, 53, 57, 339, DateTimeKind.Utc).AddTicks(6088) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 340, DateTimeKind.Utc).AddTicks(6366), new DateTime(2026, 7, 4, 20, 53, 57, 340, DateTimeKind.Utc).AddTicks(6366) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "43504ce8-5a5d-4f3d-ad1a-c0fb66fb17bd");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "263cc9cd-66a4-468e-9493-793f87f042b2");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 357, DateTimeKind.Utc).AddTicks(7311), new DateTime(2026, 7, 4, 20, 53, 57, 357, DateTimeKind.Utc).AddTicks(7314) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1236), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1614), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1614) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1617), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1617) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1618), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1618) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1620), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1620) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1642), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1642) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1643), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1643) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1647), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1647) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1649), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1649) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1621), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1622) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1629), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1630) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1631), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1631) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1632), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1632) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1634), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1634) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1635), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1635) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1636), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1637) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1638), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1638) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1639), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1639) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1645), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1645) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1646), new DateTime(2026, 7, 4, 20, 53, 57, 389, DateTimeKind.Utc).AddTicks(1646) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 360, DateTimeKind.Utc).AddTicks(1372), new DateTime(2026, 7, 4, 20, 53, 57, 360, DateTimeKind.Utc).AddTicks(1374) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 360, DateTimeKind.Utc).AddTicks(1697), new DateTime(2026, 7, 4, 20, 53, 57, 360, DateTimeKind.Utc).AddTicks(1698) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 360, DateTimeKind.Utc).AddTicks(1701), new DateTime(2026, 7, 4, 20, 53, 57, 360, DateTimeKind.Utc).AddTicks(1701) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 331, DateTimeKind.Utc).AddTicks(2954), new DateTime(2026, 7, 4, 20, 53, 57, 331, DateTimeKind.Utc).AddTicks(2959) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc3732dd-58de-40ed-8e43-09344d93d7c0", new DateTime(2026, 7, 4, 20, 53, 57, 284, DateTimeKind.Utc).AddTicks(268), new DateTime(2026, 7, 4, 20, 53, 57, 284, DateTimeKind.Utc).AddTicks(271), "AQAAAAIAAYagAAAAEO2yosTBmMJF5puDfaTCyMSpWKLfNPACe3dbcn/a/Oguk9sDVajO5uPATde/sxoejA==", "d96ef203-51d7-4f81-8367-56b330c914ce" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 337, DateTimeKind.Utc).AddTicks(1290), new DateTime(2026, 7, 4, 20, 53, 57, 337, DateTimeKind.Utc).AddTicks(1524), new Guid("2d3bece8-33e4-4ae4-b0e0-85cb491527d0") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 20, 53, 57, 340, DateTimeKind.Utc).AddTicks(70), new DateTime(2026, 7, 4, 20, 53, 57, 340, DateTimeKind.Utc).AddTicks(71) });

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
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(2394), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(2395) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3220), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3223), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3223) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3225), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3225) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3227), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3227) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3228), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3229) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3230), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3230) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3242), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3250), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3250) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3252), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3252) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3254), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3254) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3255), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3256) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3257), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3257) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3259), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3259) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3267), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3268) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3269), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3273), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3273) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3275), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3275) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3277), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3277) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3278), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3279) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3280), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3280) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3282), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3282) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3283), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3284) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3294), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3295) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3299), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3299) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3301), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3301) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3308), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3309) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3312), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3313) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3314), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3314) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3316), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3316) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3317), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3318) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3319), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3319) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3322), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3323) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3324), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3324) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3326), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3326) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3328), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3328) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3329), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3331), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3331) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3333), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3333) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3342), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3343) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3346), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3347) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3348), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3348) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3350), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3350) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3352), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3352) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3353), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3354) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3355), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3355) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3357), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3357) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3358), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3359) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3361), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3362) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3363), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3363) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3365), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3365) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3366), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3366) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3368), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3368) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3370), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3372), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3372) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3381), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3382) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3385), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3386) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3387), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3387) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3389), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3389) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3391), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3391) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3392), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3393) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3394), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3394) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3396), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3396) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3397), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3398) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3401), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3401) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3402), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3402) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3404), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3404) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3406), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3406) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3407), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3408) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3418), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3418) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3419), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3420) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3430), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3431) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3435), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3435) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3436), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3437) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3438), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3439) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3440), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3442), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3442) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3443), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3444) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3445), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3445) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3447), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3447) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3450), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3452), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3452) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3453), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3454) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3455), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3455) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3457), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3457) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3458), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3459) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3460), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3471), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3472) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3477), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3477) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3478), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3479) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3480), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3482), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3482) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3484), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3484) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3485), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3486) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3487), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3487) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3489), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3489) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3492), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3492) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3493), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3494) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3495), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3495) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3497), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3497) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3498), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3499) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3500), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3502), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3502) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3510), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3511) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3515), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3515) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3517), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3517) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3518), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3519) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3520), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3522), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3522) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3524), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3524) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3525), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3526) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3527), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3527) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3530), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3532), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3532) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3533), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3533) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3535), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3535) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3537), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3537) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3538), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3538) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3540), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3541), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(3542) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 957, DateTimeKind.Utc).AddTicks(3667), new DateTime(2026, 7, 4, 12, 20, 42, 957, DateTimeKind.Utc).AddTicks(3668) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "3a0842a0-f640-44e4-ab3b-218d2435240e");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "d9cb0686-7bf5-4b48-9377-9bae53af7eb7");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 970, DateTimeKind.Utc).AddTicks(4225), new DateTime(2026, 7, 4, 12, 20, 42, 970, DateTimeKind.Utc).AddTicks(4226) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(742), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(744) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1148), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1148) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1158), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1159) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1160), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1161) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1162), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1162) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1180), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1180) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1182), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1182) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1188), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1188) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1190), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1190) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1164), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1164) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1166), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1166) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1167), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1168) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1169), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1169) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1171), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1171) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1174), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1174) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1175), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1176) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1177), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1177) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1179), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1179) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1183), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1184) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1185), new DateTime(2026, 7, 4, 12, 20, 42, 994, DateTimeKind.Utc).AddTicks(1185) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 972, DateTimeKind.Utc).AddTicks(1891), new DateTime(2026, 7, 4, 12, 20, 42, 972, DateTimeKind.Utc).AddTicks(1893) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 972, DateTimeKind.Utc).AddTicks(2122), new DateTime(2026, 7, 4, 12, 20, 42, 972, DateTimeKind.Utc).AddTicks(2122) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 972, DateTimeKind.Utc).AddTicks(2125), new DateTime(2026, 7, 4, 12, 20, 42, 972, DateTimeKind.Utc).AddTicks(2125) });

            migrationBuilder.UpdateData(
                table: "tenant",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 948, DateTimeKind.Utc).AddTicks(4171), new DateTime(2026, 7, 4, 12, 20, 42, 948, DateTimeKind.Utc).AddTicks(4174) });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e54fe31-a748-48e8-b8f1-aa139cf2258b", new DateTime(2026, 7, 4, 12, 20, 42, 899, DateTimeKind.Utc).AddTicks(6026), new DateTime(2026, 7, 4, 12, 20, 42, 899, DateTimeKind.Utc).AddTicks(6031), "AQAAAAIAAYagAAAAEBAiF1xerHYWZNNte1bvQJpj4fmvU9gvsYEerY3AEy3r4OU59KhE+1W6OiqK+nDkNw==", "7e7c48f4-0971-4568-b47e-6095363ed5b5" });

            migrationBuilder.UpdateData(
                table: "user_tenant",
                keyColumns: new[] { "TenantId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "8e445865-a24d-4543-a6c6-9443d048cdb9" },
                columns: new[] { "DateCreated", "DateModified", "Id" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 954, DateTimeKind.Utc).AddTicks(246), new DateTime(2026, 7, 4, 12, 20, 42, 954, DateTimeKind.Utc).AddTicks(390), new Guid("30e53717-4db8-404b-9ba8-1c2120a7a2c4") });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(6622), new DateTime(2026, 7, 4, 12, 20, 42, 956, DateTimeKind.Utc).AddTicks(6623) });
        }
    }
}
