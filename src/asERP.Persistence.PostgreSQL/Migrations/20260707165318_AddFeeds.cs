using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.PostgreSQL.Migrations
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConcurrencyToken = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Template = table.Column<int>(type: "integer", nullable: false),
                    Currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    DefaultDeliveryTime = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DefaultShippingCost = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FeedId = table.Column<Guid>(type: "uuid", nullable: false),
                    IpAddress = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    UserAgent = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FeedId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
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
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 824, DateTimeKind.Utc).AddTicks(8372), new DateTime(2026, 7, 7, 16, 53, 16, 824, DateTimeKind.Utc).AddTicks(8379) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(106), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(106) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(112), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(112) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(116), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(117) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(121), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(121) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(140), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(140) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(171), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(172) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(177), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(178) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(181), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(181) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(185), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(185) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(188), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(189) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(192), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(193) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(196), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(197) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(205), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(206) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(209), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(210) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(213), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(214) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(217), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(217) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(220), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(221) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(224), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(225) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(228), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(228) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(231), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(232) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(238), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(239) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(260), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(262) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(265), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(266) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(269), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(271) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(274), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(275) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(278), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(278) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(282), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(282) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(285), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(286) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(314), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(314) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(325), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(326) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(329), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(330) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(333), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(333) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(337), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(337) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(341), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(342) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(344), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(345) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(348), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(349) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(357), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(357) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(380), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(380) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(385), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(385) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(388), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(389) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(392), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(392) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(396), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(396) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(400), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(403), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(404) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(410), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(411) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(414), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(414) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(418), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(419) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(422), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(422) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(425), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(426) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(429), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(429) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(432), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(433) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(436), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(436) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(442), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(443) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(465), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(466) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(470), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(470) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(474), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(475) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(478), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(479) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(515), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(515) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(519), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(523), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(523) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(530), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(530) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(534), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(534) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(537), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(537) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(541), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(541) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(545), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(545) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(548), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(549) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(552), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(552) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(555), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(556) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(562), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(562) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(583), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(585) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(589), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(590) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(593), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(594) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(597), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(597) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(601), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(601) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(604), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(605) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(608), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(609) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(615), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(616) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(619), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(619) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(623), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(623) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(627), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(627) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(630), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(631) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(634), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(634) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(637), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(638) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(641), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(641) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(647), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(648) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(669), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(675), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(676) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(679), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(680) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(684), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(685) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(688), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(689) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(692), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(692) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(696), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(696) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(702), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(703) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(706), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(707) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(710), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(710) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(714), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(714) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(717), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(718) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(721), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(721) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(724), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(725) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(728), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(728) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(734), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(734) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(753), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(754) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(759), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(763), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(763) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(766), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(767) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(770), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(771) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(774), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(774) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(777), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(778) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(785), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(786) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(789), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(789) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(792), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(793) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(796), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(796) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(799), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(800) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(803), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(803) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(806), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(807) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(810), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(810) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(816), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(817) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(820), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(820) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(823), new DateTime(2026, 7, 7, 16, 53, 16, 825, DateTimeKind.Utc).AddTicks(824) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 828, DateTimeKind.Utc).AddTicks(1016), new DateTime(2026, 7, 7, 16, 53, 16, 828, DateTimeKind.Utc).AddTicks(1019) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "f63b7e85-6b53-47d9-90c0-76dec31e9907");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "ed42020a-5924-49f8-8abc-ff81e6e722b9");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 853, DateTimeKind.Utc).AddTicks(5101), new DateTime(2026, 7, 7, 16, 53, 16, 853, DateTimeKind.Utc).AddTicks(5104) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(6580), new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(6584) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7310), new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7310) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7314), new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7315) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7328), new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7328) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7330), new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7330) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7538), new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7538) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7540), new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7540) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7546), new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7546) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7549), new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7549) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7332), new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7332) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7334), new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7334) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7336), new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7336) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7338), new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7338) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7524), new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7525) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7526), new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7527) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7532), new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7532) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7534), new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7534) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7536), new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7536) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7542), new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7542) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7544), new DateTime(2026, 7, 7, 16, 53, 16, 896, DateTimeKind.Utc).AddTicks(7544) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 857, DateTimeKind.Utc).AddTicks(6908), new DateTime(2026, 7, 7, 16, 53, 16, 857, DateTimeKind.Utc).AddTicks(6912) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 857, DateTimeKind.Utc).AddTicks(7236), new DateTime(2026, 7, 7, 16, 53, 16, 857, DateTimeKind.Utc).AddTicks(7236) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 857, DateTimeKind.Utc).AddTicks(7239), new DateTime(2026, 7, 7, 16, 53, 16, 857, DateTimeKind.Utc).AddTicks(7239) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 16, 826, DateTimeKind.Utc).AddTicks(1913), new DateTime(2026, 7, 7, 16, 53, 16, 826, DateTimeKind.Utc).AddTicks(1917) });

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
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3156), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3161) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3963), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3964) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3966), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3966) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3979), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3979) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3981), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3981) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3982), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3983) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3984), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3985) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3986), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3986) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3990), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3991) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3992), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3992) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3994), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3994) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3996), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3996) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3997), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3997) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3999), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(3999) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4001), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4001) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4002), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4003) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4006), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4006) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4007), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4008) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4009), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4009) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4019), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4019) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4020), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4021) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4022), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4022) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4024), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4024) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4026), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4026) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4029), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4030) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4031), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4031) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4033), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4033) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4034), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4034) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4036), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4036) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4048), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4048) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4053), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4054) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4055), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4055) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4058), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4058) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4060), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4060) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4061), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4062) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4071), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4072) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4074), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4074) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4076), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4076) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4078), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4078) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4080), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4083), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4083) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4085), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4085) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4087), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4087) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4088), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4089) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4090), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4090) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4092), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4092) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4094), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4094) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4096), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4096) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4099), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4099) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4101), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4101) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4103), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4103) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4112), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4112) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4114), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4114) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4116), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4116) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4118), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4118) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4119), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4119) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4122), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4123) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4124), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4124) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4126), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4126) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4128), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4128) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4129), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4131), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4131) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4133), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4133) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4134), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4135) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4137), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4137) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4139), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4139) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4141), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4141) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4150), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4150) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4152), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4152) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4154), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4154) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4156), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4156) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4158), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4158) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4161), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4161) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4162), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4163) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4164), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4164) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4166), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4166) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4167), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4168) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4169), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4169) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4171), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4171) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4172), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4173) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4175), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4176) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4177), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4177) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4179), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4179) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4188), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4188) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4190), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4190) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4192), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4192) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4194), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4194) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4204), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4204) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4207), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4207) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4209), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4209) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4210), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4211) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4212), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4212) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4214), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4214) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4216), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4216) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4217), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4218) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4219), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4220) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4222), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4223) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4224), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4224) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4226), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4226) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4236), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4236) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4238), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4239) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4240), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4241) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4242), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4242) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4244), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4244) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4247), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4247) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4249), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4249) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4251), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4251) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4253), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4253) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4254), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4255) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4256), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4256) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4258), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4258) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4260), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4263), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4263) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4264), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4265) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4266), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4266) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4268), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4268) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4270), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4272), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4272) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4273), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4274) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4276), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(4276) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 252, DateTimeKind.Utc).AddTicks(7278), new DateTime(2026, 7, 7, 15, 24, 52, 252, DateTimeKind.Utc).AddTicks(7279) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "dc582a1a-d109-4e02-a9f1-cc03f6b0c162");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "313bd444-e925-4b02-8a84-d1d5b638e25d");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 268, DateTimeKind.Utc).AddTicks(8749), new DateTime(2026, 7, 7, 15, 24, 52, 268, DateTimeKind.Utc).AddTicks(8751) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(1463), new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(1467) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2087), new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2088) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2090), new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2091) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2093), new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2094) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2095), new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2095) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2281), new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2282) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2283), new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2283) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2288), new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2288) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2290), new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2290) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2097), new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2097) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2105), new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2106) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2107), new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2108) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2109), new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2109) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2269), new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2269) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2271), new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2271) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2273), new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2273) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2275), new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2275) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2277), new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2277) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2285), new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2285) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2286), new DateTime(2026, 7, 7, 15, 24, 52, 300, DateTimeKind.Utc).AddTicks(2286) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 272, DateTimeKind.Utc).AddTicks(2407), new DateTime(2026, 7, 7, 15, 24, 52, 272, DateTimeKind.Utc).AddTicks(2410) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 272, DateTimeKind.Utc).AddTicks(2831), new DateTime(2026, 7, 7, 15, 24, 52, 272, DateTimeKind.Utc).AddTicks(2832) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 272, DateTimeKind.Utc).AddTicks(2835), new DateTime(2026, 7, 7, 15, 24, 52, 272, DateTimeKind.Utc).AddTicks(2835) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(9885), new DateTime(2026, 7, 7, 15, 24, 52, 251, DateTimeKind.Utc).AddTicks(9887) });
        }
    }
}
