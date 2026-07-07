using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asERP.Persistence.MSSQL.Migrations
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Template = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    SalesChannelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    DefaultDeliveryTime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DefaultShippingCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(2439), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(2443) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3369), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3370) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3372), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3373) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3375), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3375) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3377), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3377) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3379), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3379) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3381), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3382) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3391), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3391) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3393), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3394) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3395), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3396) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3398), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3398) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3400), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3400) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3416), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3416) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3419), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3419) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3421), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3422) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3426), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3427) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3429), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3430) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3432), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3432) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3434), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3434) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3436), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3436) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3438), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3438) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3440), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3442), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3442) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3446), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3446) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3448), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3449) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3450), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3451) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3464), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3465) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3466), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3479), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3479) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3493), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3493) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3497), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3498) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3502), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3502) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3504), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3504) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3506), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3506) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3508), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3508) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3510), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3512), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3512) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3514), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3515) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3516), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3517) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3520), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3520) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3522), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3523) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3524), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3525) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3526), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3526) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3528), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3529) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3540), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3541) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3543), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3543) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3545), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3545) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3549), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3549) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3552), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3552) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3554), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3554) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3556), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3556) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3558), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3558) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3560), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3560) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3562), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3562) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3564), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3564) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3568), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3568) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3570), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3572), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3572) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3574), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3574) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3576), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3576) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3587), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3588) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3590), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3591) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3592), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3593) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3596), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3597) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3599), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3599) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3601), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3601) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3603), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3604) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3605), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3606) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3607), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3608) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3610), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3610) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3612), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3612) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3615), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3615) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3617), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3618) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3619), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3619) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3621), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3622) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3623), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3635), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3636) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3638), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3639) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3641), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3641) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3645), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3646) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3648), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3648) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3650), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3650) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3652), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3652) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3654), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3654) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3656), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3657) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3658), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3658) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3660), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3661) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3664), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3664) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3666), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3666) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3668), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3668) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3670), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3672), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3672) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3683), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3684) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3686), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3687) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3689), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3689) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3693), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3693) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3695), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3695) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3697), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3697) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3699), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3699) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3701), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3701) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3703), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3704) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3705), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3706) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3707), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3708) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3711), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3711) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3713), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3713) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3715), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3716) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3717), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3718) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3719), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3720) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3731), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3732) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3734), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3734) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3736), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3736) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3740), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3740) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3742), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3743) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3745), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3745) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3747), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3747) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3749), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3749) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3751), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3751) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3753), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3753) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3755), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3755) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3763), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(3764) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 401, DateTimeKind.Utc).AddTicks(8959), new DateTime(2026, 7, 7, 16, 53, 2, 401, DateTimeKind.Utc).AddTicks(8960) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "006ec653-95b0-46e3-bd58-06e8f8621352");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "9efdcf00-1e78-43bd-9fea-1284f6a89f95");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 421, DateTimeKind.Utc).AddTicks(3878), new DateTime(2026, 7, 7, 16, 53, 2, 421, DateTimeKind.Utc).AddTicks(3881) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(5325), new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(5332) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(6591), new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(6592) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(6596), new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(6597) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(6600), new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(6600) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(6605), new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(6605) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(7817), new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(7817) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(7820), new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(7820) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(7834), new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(7835) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(7837), new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(7838) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(6608), new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(6608) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(6611), new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(6611) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(6627), new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(6627) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(6631), new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(6631) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(7787), new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(7790) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(7806), new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(7806) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(7809), new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(7809) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(7812), new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(7812) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(7814), new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(7815) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(7823), new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(7824) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(7829), new DateTime(2026, 7, 7, 16, 53, 2, 479, DateTimeKind.Utc).AddTicks(7829) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 424, DateTimeKind.Utc).AddTicks(9078), new DateTime(2026, 7, 7, 16, 53, 2, 424, DateTimeKind.Utc).AddTicks(9081) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 424, DateTimeKind.Utc).AddTicks(9521), new DateTime(2026, 7, 7, 16, 53, 2, 424, DateTimeKind.Utc).AddTicks(9522) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 424, DateTimeKind.Utc).AddTicks(9526), new DateTime(2026, 7, 7, 16, 53, 2, 424, DateTimeKind.Utc).AddTicks(9526) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(9876), new DateTime(2026, 7, 7, 16, 53, 2, 400, DateTimeKind.Utc).AddTicks(9877) });

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
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(6047), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(6055) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8001), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8001) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8040), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8040) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8044), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8045) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8048), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8049) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8052), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8052) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8055), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8056) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8059), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8059) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8063), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8063) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8071), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8072) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8075), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8075) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8078), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8079) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8082), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8082) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8085), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8086) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8089), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8089) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8092), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8093) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8096), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8096) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8103), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8103) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8126), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8126) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8129), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8130) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8133), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8134) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8137), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8137) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8140), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8141) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8144), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8147), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8148) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8154), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8154) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8158), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8158) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8161), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8162) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8165), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8165) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8169), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8169) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8172), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8173) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8177), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8178) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8181), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8182) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8188), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8188) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8210), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8211) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8214), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8214) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8217), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8218) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8221), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8221) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8224), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8225) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8228), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8228) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8231), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8232) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8238), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8239) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8242), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8242) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8245), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8246) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8249), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8249) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8252), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8253) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8256), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8256) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8259), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8260) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8263), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8263) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8270), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8270) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8292), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8293) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8296), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8296) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000053"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8300), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8300) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000054"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8303), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8304) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000055"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8339), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8340) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000056"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8343), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8343) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000057"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8346), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8347) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000058"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8353), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8354) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000059"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8357), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8358) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000060"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8360), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8361) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000061"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8364), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8365) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000062"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8368), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8368) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000063"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8371), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8372) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000064"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8375), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8375) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000065"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8378), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8379) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000066"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8385), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8386) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000067"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8408), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8408) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000068"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8411), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8412) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000069"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8415), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8415) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000070"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8418), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8419) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000071"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8422), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8422) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000072"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8425), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8426) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000073"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8429), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8429) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000074"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8435), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8436) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000075"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8439), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8440) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000076"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8443), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8443) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000077"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8446), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8447) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000078"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8450), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8450) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000079"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8453), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8454) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000080"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8457), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8457) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000081"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8461), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8461) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000082"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8468), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8468) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000083"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8489), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8489) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000084"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8492), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8493) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000085"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8496), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8497) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000086"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8499), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8500) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000087"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8503), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8504) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000088"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8507), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8507) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000089"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8510), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8510) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000090"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8517), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8518) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000091"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8521), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8521) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000092"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8524), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8525) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000093"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8528), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8528) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000094"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8531), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8532) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000095"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8535), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8536) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000096"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8539), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8539) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000097"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8542), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8543) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000098"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8549), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8549) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8570), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8570) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8573), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8574) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8577), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8577) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8580), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8581) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8584), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8584) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8587), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8588) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000105"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8591), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8591) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000106"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8598), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8598) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000107"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8601), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8602) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000108"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8605), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8605) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000109"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8608), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8609) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000110"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8612), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8612) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000111"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8616), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8616) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000112"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8619), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8619) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000113"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8623), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8623) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000114"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8630), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8630) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000115"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8633), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8634) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000116"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8637), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8637) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000117"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8640), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8641) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000118"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8644), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8644) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000119"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8648), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8648) });

            migrationBuilder.UpdateData(
                table: "country",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000120"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8651), new DateTime(2026, 7, 7, 15, 20, 22, 245, DateTimeKind.Utc).AddTicks(8651) });

            migrationBuilder.UpdateData(
                table: "manufacturer",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 248, DateTimeKind.Utc).AddTicks(8962), new DateTime(2026, 7, 7, 15, 20, 22, 248, DateTimeKind.Utc).AddTicks(8965) });

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "abc43a7e-f7bb-4447-baaf-1add431ddbdf",
                column: "ConcurrencyStamp",
                value: "f3610330-991a-4e0b-a2f1-732111c5e090");

            migrationBuilder.UpdateData(
                table: "role",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "d3fdb538-705f-4a3a-9bf5-400ca37c3d02");

            migrationBuilder.UpdateData(
                table: "saleschannel",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 280, DateTimeKind.Utc).AddTicks(2249), new DateTime(2026, 7, 7, 15, 20, 22, 280, DateTimeKind.Utc).AddTicks(2255) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666615"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(1199), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(1204) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666616"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3016), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3017) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666617"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3024), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3024) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666618"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3029), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3029) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666619"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3046), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3046) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666620"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3600), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3601) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666621"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3604), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3605) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666622"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3615), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3615) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666623"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3618), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3619) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666624"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3050), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3051) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666625"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3054), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3054) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666626"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3057), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3058) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666627"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3061), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3062) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666628"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3573), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3574) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666629"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3579), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3580) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666630"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3583), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3584) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666631"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3593), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3593) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666632"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3597), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3597) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666633"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3608), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3608) });

            migrationBuilder.UpdateData(
                table: "setting",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666634"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3611), new DateTime(2026, 7, 7, 15, 20, 22, 352, DateTimeKind.Utc).AddTicks(3612) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777771"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 285, DateTimeKind.Utc).AddTicks(8067), new DateTime(2026, 7, 7, 15, 20, 22, 285, DateTimeKind.Utc).AddTicks(8071) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777772"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 285, DateTimeKind.Utc).AddTicks(8935), new DateTime(2026, 7, 7, 15, 20, 22, 285, DateTimeKind.Utc).AddTicks(8936) });

            migrationBuilder.UpdateData(
                table: "tax_class",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777773"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 285, DateTimeKind.Utc).AddTicks(8942), new DateTime(2026, 7, 7, 15, 20, 22, 285, DateTimeKind.Utc).AddTicks(8943) });

            migrationBuilder.UpdateData(
                table: "warehouse",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2026, 7, 7, 15, 20, 22, 247, DateTimeKind.Utc).AddTicks(322), new DateTime(2026, 7, 7, 15, 20, 22, 247, DateTimeKind.Utc).AddTicks(325) });
        }
    }
}
