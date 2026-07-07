using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class AddFeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "feed",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConcurrencyToken = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Template = table.Column<int>(type: "INTEGER", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "TEXT", nullable: true),
                    IsEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    DefaultDeliveryTime = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    DefaultShippingCost = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_feed_saleschannel_SalesChannelId",
                        column: x => x.SalesChannelId,
                        principalTable: "saleschannel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "feed_log",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FeedId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IpAddress = table.Column<string>(type: "TEXT", maxLength: 45, nullable: true),
                    UserAgent = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feed_log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_feed_log_feed_FeedId",
                        column: x => x.FeedId,
                        principalTable: "feed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "feed_product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FeedId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feed_product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_feed_product_feed_FeedId",
                        column: x => x.FeedId,
                        principalTable: "feed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_feed_product_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(7817), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(7822) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8757), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8758) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8761), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8762) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8764), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8764) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8767), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8767) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8769), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8769) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8771), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8771) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8773), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8773) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8775), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8776) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8780), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8780) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8782), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8782) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8784), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8784) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8786), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8786) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8788), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8789) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8804), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8805) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8808), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8808) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8810), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8813), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8814) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8816), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8816) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8818), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8818) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8820), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8822), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8822) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8824), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8824) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8826), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8826) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8828), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8828) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8832), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8832) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8834), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8834) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8836), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8836) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8838), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8838) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8852), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8852) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8868), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8868) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8871), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8872) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8875), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8875) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8878), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8879) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8881), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8881) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8883), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8883) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8885), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8886) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8887), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8888) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8889), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8890) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8892), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8892) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8904), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8905) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8908), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8908) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8910), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8911) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8912), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8913) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8914), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8915) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8916), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8917) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8927), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8928) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8930), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8931) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8933), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8933) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8936), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8937) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8939), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8939) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8941), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8941) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8943), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8943) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8945), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8945) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8947), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8947) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8949), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8949) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8951), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8951) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8954), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8955) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8956), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8957) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8958), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8958) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8961), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8961) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8963), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8963) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8974), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8975) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8978), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8978) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8980), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8981) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8984), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8984) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8986), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8986) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8988), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8989) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8990), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8991) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8992), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8993) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8994), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8995) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8996), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8997) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8998), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(8999) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9002), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9002) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9004), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9004) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9006), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9006) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9008), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9008) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9010), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9010) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9021), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9022) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9024), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9025) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9026), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9027) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9030), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9032), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9032) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9034), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9035) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9036), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9037) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9039), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9039) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9041), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9041) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9043), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9043) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9045), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9046) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9049), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9049) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9051), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9051) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9053), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9053) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9055), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9055) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9057), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9057) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9069), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9069) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9072), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9073) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9075), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9075) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9079), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9079) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9081), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9081) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9083), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9084) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9086), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9086) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9088), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9088) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9090), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9092), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9092) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9094), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9095) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9098), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9099) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9101), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9101) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9103), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9104) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9105), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9106) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9108), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9108) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9110), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9110) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9112), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9112) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9113), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9114) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9117), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9117) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9120), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9120) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9122), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9122) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9124), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9124) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9126), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9126) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9128), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9128) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9130), new DateTime(2026, 7, 7, 16, 52, 2, 931, DateTimeKind.Utc).AddTicks(9130) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 933, DateTimeKind.Utc).AddTicks(4022), new DateTime(2026, 7, 7, 16, 52, 2, 933, DateTimeKind.Utc).AddTicks(4024) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "caea5655-da46-4bd6-b009-6afe44369743");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "64c7c451-25f0-4f12-9296-c5d4fcf918f9");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 949, DateTimeKind.Utc).AddTicks(9189), new DateTime(2026, 7, 7, 16, 52, 2, 949, DateTimeKind.Utc).AddTicks(9194) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2029), new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2034) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2747), new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2748) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2752), new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2753) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2755), new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2755) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2765), new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2765) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2967), new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2967) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2969), new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2969) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2974), new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2975) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2976), new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2977) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2767), new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2767) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2769), new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2769) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2771), new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2771) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2773), new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2773) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2953), new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2953) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2955), new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2955) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2958), new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2958) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2963), new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2963) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2965), new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2965) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2971), new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2971) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2973), new DateTime(2026, 7, 7, 16, 52, 2, 987, DateTimeKind.Utc).AddTicks(2973) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 952, DateTimeKind.Utc).AddTicks(4833), new DateTime(2026, 7, 7, 16, 52, 2, 952, DateTimeKind.Utc).AddTicks(4835) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 952, DateTimeKind.Utc).AddTicks(5111), new DateTime(2026, 7, 7, 16, 52, 2, 952, DateTimeKind.Utc).AddTicks(5111) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 952, DateTimeKind.Utc).AddTicks(5116), new DateTime(2026, 7, 7, 16, 52, 2, 952, DateTimeKind.Utc).AddTicks(5117) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 52, 2, 932, DateTimeKind.Utc).AddTicks(4210), new DateTime(2026, 7, 7, 16, 52, 2, 932, DateTimeKind.Utc).AddTicks(4211) });

            migrationBuilder.CreateIndex(
                name: "IX_feed_SalesChannelId",
                table: "feed",
                column: "SalesChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_feed_TenantId",
                table: "feed",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_feed_log_FeedId_DateCreated",
                table: "feed_log",
                columns: new[] { "FeedId", "DateCreated" },
                descending: new[] { false, true });

            migrationBuilder.CreateIndex(
                name: "IX_feed_product_FeedId_ProductId",
                table: "feed_product",
                columns: new[] { "FeedId", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_feed_product_ProductId",
                table: "feed_product",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feed_log");

            migrationBuilder.DropTable(
                name: "feed_product");

            migrationBuilder.DropTable(
                name: "feed");

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(2267), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(2272) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3306), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3306) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3310), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3311) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3320), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3321) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3322), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3323) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3324), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3325) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3326), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3327) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3328), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3329) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3330), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3332), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3332) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3334), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3334) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3337), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3337) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3339), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3339) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3341), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3341) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3343), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3343) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3344), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3345) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3357), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3357) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3359), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3359) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3361), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3361) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3364), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3365) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3366), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3366) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3369), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3369) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3370), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3371) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3372), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3373) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3374), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3374) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3376), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3376) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3378), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3378) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3381), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3381) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3383), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3383) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3394), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3395) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3402), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3403) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3404), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3405) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3415), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3415) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3417), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3417) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3419), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3419) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3422), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3423) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3424), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3424) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3426), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3426) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3428), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3428) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3430), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3432), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3432) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3433), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3434) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3435), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3435) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3439), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3439) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3440), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3441) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3442), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3442) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3444), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3444) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3446), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3446) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3456), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3456) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3458), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3458) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3460), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3460) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3463), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3464) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3465), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3466) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3467), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3468) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3469), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3471), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3471) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3473), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3473) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3475), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3475) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3477), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3477) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3480), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3480) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3482), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3482) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3483), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3484) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3485), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3485) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3487), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3487) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3496), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3496) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3498), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3499) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3500), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3504), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3504) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3506), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3506) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3507), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3508) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3509), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3511), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3511) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3513), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3513) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3515), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3515) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3517), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3517) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3520), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3522), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3522) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3524), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3524) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3525), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3525) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3527), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3527) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3537), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3538) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3540), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3540) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3542), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3542) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3545), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3545) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3547), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3547) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3549), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3549) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3551), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3551) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3552), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3553) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3554), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3554) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3556), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3557) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3558), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3558) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3561), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3562) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3563), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3563) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3565), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3565) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3571), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3571) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3573), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3573) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3582), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3583) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3584), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3585) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3586), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3587) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3590), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3592), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3592) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3594), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3594) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3596), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3596) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3598), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3598) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3600), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3600) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3602), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3602) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3603), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3604) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3607), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3607) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3609), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3609) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3611), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3611) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3613), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3613) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3615), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3615) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3617), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3617) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3618), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3619) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3620), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3620) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3623), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3626), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3626) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3628), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3628) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3629), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3631), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(3631) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 400, DateTimeKind.Utc).AddTicks(5792), new DateTime(2026, 7, 7, 15, 25, 1, 400, DateTimeKind.Utc).AddTicks(5793) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "f857316b-33d3-4385-99be-82763f34f6e0");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "fbb1af03-aaa0-4931-9902-09e7b7b71a35");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 414, DateTimeKind.Utc).AddTicks(6632), new DateTime(2026, 7, 7, 15, 25, 1, 414, DateTimeKind.Utc).AddTicks(6636) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(3), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(7) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(604), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(604) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(607), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(608) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(610), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(611) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(612), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(612) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(799), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(799) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(800), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(801) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(805), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(805) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(807), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(807) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(614), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(614) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(622), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(622) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(624), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(624) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(633), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(633) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(788), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(788) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(790), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(790) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(792), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(792) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(793), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(794) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(795), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(795) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(802), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(802) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(804), new DateTime(2026, 7, 7, 15, 25, 1, 448, DateTimeKind.Utc).AddTicks(804) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 416, DateTimeKind.Utc).AddTicks(7936), new DateTime(2026, 7, 7, 15, 25, 1, 416, DateTimeKind.Utc).AddTicks(7937) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 416, DateTimeKind.Utc).AddTicks(8187), new DateTime(2026, 7, 7, 15, 25, 1, 416, DateTimeKind.Utc).AddTicks(8187) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 416, DateTimeKind.Utc).AddTicks(8189), new DateTime(2026, 7, 7, 15, 25, 1, 416, DateTimeKind.Utc).AddTicks(8190) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(8167), new DateTime(2026, 7, 7, 15, 25, 1, 399, DateTimeKind.Utc).AddTicks(8169) });
        }
    }
}
